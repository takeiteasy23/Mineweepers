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
    #region 起始畫面
    public partial class frmStart : Form
    {
        private Constant constant = new Constant();
        private Game game = new Game();
        frmPlay formPlay;
        public frmStart()
        {
            InitializeComponent();
            formPlay = new frmPlay();
        }

        #region start button
        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_Click(object sender, EventArgs e)
        {
            try     // 防止非法輸入
            {
                if (    // 邊界檢查
                game.CheckGridRange(txtX, Constant.MAX_X, Constant.MIN) &&
                game.CheckGridRange(txtY, Constant.MAX_Y, Constant.MIN) &&
                game.CheckGridRange(txtMine, Convert.ToInt32(txtX.Text) * Convert.ToInt32(txtY.Text), Constant.MIN_MINE))
                {   // 設定 formPlay 畫面，及傳遞參數
                    formPlay.GetnumOfMine(Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text), Convert.ToInt32(txtMine.Text));
                    formPlay.Width = Convert.ToInt32(txtY.Text) * Constant.PIC_SIZE + 45;
                    formPlay.Height = Convert.ToInt32(txtX.Text) * Constant.PIC_SIZE + 100;
                    formPlay.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 難度設定
        /// <summary>
        /// 難度設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easy_Click(object sender, EventArgs e)
        {
            txtX.Text = "10";
            txtY.Text = "10";
            txtMine.Text = "12";
        }

        private void medium_Click(object sender, EventArgs e)
        {
            txtX.Text = "12";
            txtY.Text = "15";
            txtMine.Text = "30";
        }

        private void hard_Click(object sender, EventArgs e)
        {
            txtX.Text = "15";
            txtY.Text = "20";
            txtMine.Text = "60";
        }
        #endregion
    }
    #endregion
}
