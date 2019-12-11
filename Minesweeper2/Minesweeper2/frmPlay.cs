using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper2
{
    public partial class frmPlay : Form
    {
        private Constant constant = new Constant();
        private Grid[,] grid;
        private Game game = new Game();
        private int counter = 0;
        private int numOfFlag = 0;
        private int numOfMine = 0;
        private int realMine = 0;
        private int grid_x = 0;
        private int grid_y = 0;
        private bool IsFirst = true;
        
        private int[,] CountMine;
        private FlagType[,] IsFlag;

        public frmPlay()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Visible 視窗可見
            // IsFirst 第一次按下之後再開始計算
            // counter 時限
            // realMine 遊戲結束(贏局停止計時)
            if (this.Visible && !IsFirst && counter < 999 && realMine > 0) counter++;
            lblTimer.Text = counter.ToString();
            if (counter == 999)
            {
                counter = 1000;
                MessageBox.Show("Time Over");
                reset();
            }
        }

        #region 創建初始畫面
        /// <summary>
        /// 參數取得、創建圖片矩陣
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="mine"></param>
        public void GetnumOfMine(int x, int y, int mine)
        {
            grid_x = x;
            grid_y = y;
            numOfMine = mine;
            realMine = mine;
            createMatrix();
        }

        private void createMatrix()
        {
            lblFlag.Text = numOfFlag.ToString();
            lblMine.Text = numOfMine.ToString();
            grid = new Grid[grid_x, grid_y];
            CountMine = new int[grid_x + 2, grid_y + 2];  // -1: Mine, 0~8: Count
            IsFlag = new FlagType[grid_x, grid_y]; // none, flag, unknown

            for (int i = 0; i < grid_x; i++)
            {
                for (int j = 0; j < grid_y; j++)
                {   // form中新增圖片，監聽事件
                    grid[i, j] = new Grid(Constant.INI_X + j * Constant.PIC_SIZE, Constant.INI_Y + i * Constant.PIC_SIZE);
                    grid[i, j].MouseDown += new MouseEventHandler(PictureBox_MouseDown);
                    this.Controls.Add(grid[i, j]);
                }
            }

            game.IniIsMine(CountMine, numOfMine);   // 初始化地雷座標
        }
        #endregion

        #region 滑鼠事件處理
        /// <summary>
        /// 滑鼠事件觸發及處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pic = sender as PictureBox;  // 將 object 轉為 PictureBox 物件
            int x = game.GetPosX(pic.Location.Y); // 轉置處理
            int y = game.GetPosY(pic.Location.X);
            
            if (e.Button == MouseButtons.Right && IsFlag[x, y] != FlagType.Open) // flag
            {
                if (IsFirst)
                {
                    IsFirst = false;
                    game.IniCountMine(CountMine);
                }
                int count = game.Flag(x, y, grid[x, y], IsFlag, numOfMine);
                if (count == 1 && CountMine[x + 1, y + 1] == -1) realMine--;
                else if (count == -1 && CountMine[x + 1, y + 1] == -1) realMine++;
                ChangeNum(count);
            }
            else if (e.Button == MouseButtons.Left && IsFlag[x, y] == FlagType.None) // Open
            {
                if (IsFirst)
                {
                    if (CountMine[x + 1, y + 1] == -1)
                    {   // 防止第一次及踩雷
                        game.IniIsMine(CountMine, 1);
                        CountMine[x + 1, y + 1] = 0;
                    }

                    game.IniCountMine(CountMine);
                    game.Open(x + 1, y + 1, CountMine, grid, IsFlag);

                    IsFirst = false;
                }
                else if (CountMine[x + 1, y + 1] == -1)
                {
                    if(game.Lose(x + 1, y + 1, CountMine, grid, IsFlag) == DialogResult.Retry)
                    {
                        restart();
                    }
                    else
                    {
                        reset();
                    }

                }
                else game.Open(x + 1, y + 1, CountMine, grid, IsFlag);
            }
        }

        private void ChangeNum(int count)
        {
            numOfFlag += count;
            lblFlag.Text = numOfFlag.ToString();
            numOfMine -= count;
            lblMine.Text = numOfMine.ToString();
            if (realMine == 0)
            {
                if (game.Win(counter) == DialogResult.Retry)
                {
                    restart();
                }
                else
                {
                    reset();
                }
            }
        }
        #endregion

        #region 重新開始
        /// <summary>
        /// 新回合的初始化
        /// </summary>
        private void restart()
        {
            IsFirst = true;
            counter = 0;
            numOfMine = numOfMine + numOfFlag;
            realMine = numOfMine;
            numOfFlag = 0;
            lblFlag.Text = numOfFlag.ToString();
            lblMine.Text = numOfMine.ToString();

            for (int i = 0; i < grid_x; i++)
            {
                for (int j = 0; j < grid_y; j++)
                {
                    CountMine[i + 1, j + 1] = 0;
                    grid[i, j].ReplaceBase();
                    IsFlag[i, j] = FlagType.None;
                }
            }
            game.IniIsMine(CountMine, numOfMine);
            
            GC.Collect(2, GCCollectionMode.Forced);
        }

        private void reset()
        {
            frmStart fromStart = new frmStart();
            fromStart.Visible = true;
            this.Visible = false;
            GC.Collect(2, GCCollectionMode.Forced);
        }
        #endregion
    }
}
