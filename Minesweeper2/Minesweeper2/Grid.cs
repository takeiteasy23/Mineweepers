using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper2
{
    class Grid : PictureBox
    {
        private Constant constant = new Constant();
        private Game game = new Game();

        #region 建構圖片
        /// <summary>
        /// 圖片設定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Grid(int x, int y)
        {   // 圖片設定
            this.Image = Properties.Resources._base;
            this.Location = new Point(x, y);    // 每張圖片的位置
            this.Size = new Size(Constant.PIC_SIZE, Constant.PIC_SIZE);
            this.SizeMode = PictureBoxSizeMode.StretchImage;    // 依 Size 比例放大縮小原始圖片
        }
        #endregion

        #region 圖片置換
        /// <summary>
        /// 滑鼠事件觸發後的所有圖片置換動作
        /// </summary>
        public void ReplaceFlag() => this.Image = Properties.Resources.flag;
        public void ReplaceUnknown() => this.Image = Properties.Resources.unknown;
        public void ReplaceBase() => this.Image = Properties.Resources._base;
        public void ReplaceMine() => this.Image = Properties.Resources._9;  // 地雷
        public void ReplaceMineClk() => this.Image = Properties.Resources._10;  // 被踩中的地雷

        public void ReplaceOpen(int numOfMine)
        {
            switch (numOfMine)
            {
                case 0:
                    this.Image = Properties.Resources._0;
                    break;
                case 1:
                    this.Image = Properties.Resources._1;
                    break;
                case 2:
                    this.Image = Properties.Resources._2;
                    break;
                case 3:
                    this.Image = Properties.Resources._3;
                    break;
                case 4:
                    this.Image = Properties.Resources._4;
                    break;
                case 5:
                    this.Image = Properties.Resources._5;
                    break;
                case 6:
                    this.Image = Properties.Resources._6;
                    break;
                case 7:
                    this.Image = Properties.Resources._7;
                    break;
                case 8:
                    this.Image = Properties.Resources._8;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}