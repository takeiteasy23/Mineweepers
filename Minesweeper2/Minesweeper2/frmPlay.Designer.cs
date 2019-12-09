namespace Minesweeper2
{
    partial class frmPlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMine = new System.Windows.Forms.Label();
            this.lblFlag = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "mine:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "flag:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "time:";
            // 
            // lblMine
            // 
            this.lblMine.AutoSize = true;
            this.lblMine.Location = new System.Drawing.Point(191, 19);
            this.lblMine.Name = "lblMine";
            this.lblMine.Size = new System.Drawing.Size(28, 12);
            this.lblMine.TabIndex = 8;
            this.lblMine.Text = "mine";
            this.lblMine.UseWaitCursor = true;
            // 
            // lblFlag
            // 
            this.lblFlag.AutoSize = true;
            this.lblFlag.Location = new System.Drawing.Point(121, 19);
            this.lblFlag.Name = "lblFlag";
            this.lblFlag.Size = new System.Drawing.Size(23, 12);
            this.lblFlag.TabIndex = 7;
            this.lblFlag.Text = "flag";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(51, 19);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(29, 12);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "timer";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMine);
            this.Controls.Add(this.lblFlag);
            this.Controls.Add(this.lblTimer);
            this.Name = "frmPlay";
            this.Text = "Play";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMine;
        private System.Windows.Forms.Label lblFlag;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer timer1;
    }
}