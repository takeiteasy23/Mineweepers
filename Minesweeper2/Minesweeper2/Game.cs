using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper2
{
    class Game
    {
        private Constant constant = new Constant();

        #region 數值設定
        /// <summary>
        /// 數值設定、檢查
        /// </summary>
        /// <param name="txtbox"></param>
        /// <param name="MaxNum"></param>
        /// <param name="MinNum"></param>
        /// <returns></returns>
        public bool CheckGridRange(TextBox txtbox, int MaxNum, int MinNum)
        {
            if (Convert.ToInt32(txtbox.Text) > MaxNum || Convert.ToInt32(txtbox.Text) < MinNum)
            {
                string txtname;
                if (MinNum == Constant.MIN_MINE) txtname = "Mine";
                else
                {
                    if (MaxNum == Constant.MAX_X) txtname = "X";
                    else txtname = "Y";
                }
                MessageBox.Show($"{txtname} 範圍應界於 {MinNum}~{MaxNum} 之間");
                txtbox.Focus();
                return false;
            }
            return true;
        }

        public int GetPosY(int pos) => (pos - Constant.INI_X) / Constant.PIC_SIZE;

        public int GetPosX(int pos) => (pos - Constant.INI_Y) / Constant.PIC_SIZE;
        #endregion

        #region 滑鼠觸發
        /// <summary>
        /// 滑鼠事件處理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="grid"></param>
        /// <param name="IsFlag"></param>
        /// <param name="numOfMine"></param>
        /// <returns></returns>
        public int Flag(int x, int y, Grid grid, FlagType[,] IsFlag, int numOfMine)
        {
            if (IsFlag[x, y] == FlagType.None && numOfMine > 0)
            {
                grid.ReplaceFlag();
                IsFlag[x, y] = FlagType.Flag;

                return 1;
            }

            else if (IsFlag[x, y] == FlagType.Flag)
            {
                grid.ReplaceUnknown();
                IsFlag[x, y] = FlagType.Unknown;

                return -1;
            }
            else
            {
                grid.ReplaceBase();
                IsFlag[x, y] = FlagType.None;

                return 0;
            }
        }

        public void Open(int x, int y, int[,] CountMine, Grid[,] grid, FlagType[,] IsFlag)
        {
            grid[x - 1, y - 1].ReplaceOpen(CountMine[x, y]);
            IsFlag[x - 1, y - 1] = FlagType.Open;
            if (CountMine[x, y] == 0)
            {
                if (x - 2 >= 0 && IsFlag[x - 2, y - 1] == FlagType.None && CountMine[x - 1, y] != -1)
                { // (-1, 0)
                    Open(x - 1, y, CountMine, grid, IsFlag);
                }
                if (y - 2 >= 0 && IsFlag[x - 1, y - 2] == FlagType.None && CountMine[x, y - 1] != -1)
                { // (0,-1)
                    Open(x, y - 1, CountMine, grid, IsFlag);
                }
                if (x < CountMine.GetLength(0) - 2 && IsFlag[x, y - 1] == FlagType.None && CountMine[x + 1, y] != -1)
                { // (1, 0)
                    Open(x + 1, y, CountMine, grid, IsFlag);
                }
                if (y < CountMine.GetLength(1) - 2 && IsFlag[x - 1, y] == FlagType.None && CountMine[x, y + 1] != -1)
                { // (0, 1)
                    Open(x, y + 1, CountMine, grid, IsFlag);
                }
                if (x - 2 >= 0 && y - 2 >= 0 && IsFlag[x - 2, y - 2] == FlagType.None && CountMine[x - 1, y - 1] != -1)
                { // (-1, -1)
                    Open(x - 1, y - 1, CountMine, grid, IsFlag);
                }
                if (x - 2 >= 0 && y < CountMine.GetLength(1) - 2 && IsFlag[x - 2, y] == FlagType.None && CountMine[x - 1, y + 1] != -1)
                { // (-1, 1)
                    Open(x - 1, y + 1, CountMine, grid, IsFlag);
                }
                if (x < CountMine.GetLength(0) - 2 && y - 2 >= 0 && IsFlag[x, y - 2] == FlagType.None && CountMine[x + 1, y - 1] != -1)
                { // (1, -1)
                    Open(x + 1, y - 1, CountMine, grid, IsFlag);
                }
                if (x < CountMine.GetLength(0) - 2 && y < CountMine.GetLength(1) - 2 && IsFlag[x, y] == FlagType.None && CountMine[x + 1, y + 1] != -1)
                { // (1, 1)
                    Open(x + 1, y + 1, CountMine, grid, IsFlag);
                }
            }
        }
        #endregion

        #region 遊戲結束
        public DialogResult Lose(int x, int y, int[,] CountMine, Grid[,] grid, FlagType[,] IsFlag)
        {
            grid[x - 1, y - 1].ReplaceMineClk();
            IsFlag[x - 1, y - 1] = FlagType.Open;
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0;j < grid.GetLength(1); j++)
                {
                    if(CountMine[i+1, j+1] == -1 && IsFlag[i, j] == FlagType.None)
                        grid[i, j].ReplaceMine();
                }
            }
            return MessageBox.Show("You Lose", "", MessageBoxButtons.RetryCancel);
        }

        public DialogResult Win(int counter)
        {
            return MessageBox.Show("You Win" + Environment.NewLine + "took: " + counter + " s"
                , "", MessageBoxButtons.RetryCancel);
        }
        #endregion

        #region 遊戲初始化
        /// <summary>
        /// 地雷設定、計算
        /// </summary>
        /// <param name="CountMine"></param>
        /// <param name="numOfMine"></param>
        public void IniIsMine(int[,] CountMine, int numOfMine)
        {
            Random rand = new Random(Convert.ToInt32(DateTime.Now.Millisecond.ToString()));

            int x;
            int y;

            while (numOfMine > 0)
            {
                x = rand.Next(1, CountMine.GetLength(0)-1); // row
                y = rand.Next(1, CountMine.GetLength(1)-1); // column
                if (CountMine[x, y] == 0)
                {
                    CountMine[x, y] = -1;
                    numOfMine--;
                }
            }
        }

        public void IniCountMine(int[,] CountMine)
        {
            for (int x = 1; x < CountMine.GetLength(0) - 1; x++)
            {
                for (int y = 1; y < CountMine.GetLength(1) - 1; y++)
                {
                    if (CountMine[x, y] != -1)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                if (CountMine[x+i, y+j] < 0 && (i != 0 || j != 0))
                                {
                                    CountMine[x, y]++;
                                    // CountMine[x, y] -= CountMine[i, j];
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
