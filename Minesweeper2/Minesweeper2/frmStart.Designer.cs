namespace Minesweeper2
{
    partial class frmStart
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMine = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.easy = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMine
            // 
            this.txtMine.Location = new System.Drawing.Point(121, 128);
            this.txtMine.Name = "txtMine";
            this.txtMine.Size = new System.Drawing.Size(70, 22);
            this.txtMine.TabIndex = 13;
            this.txtMine.Text = "12";
            this.txtMine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(121, 98);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(70, 22);
            this.txtY.TabIndex = 12;
            this.txtY.Text = "10";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(121, 68);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(70, 22);
            this.txtX.TabIndex = 11;
            this.txtX.Text = "10";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mine:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "X :";
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start.Location = new System.Drawing.Point(98, 176);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(93, 33);
            this.start.TabIndex = 7;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // easy
            // 
            this.easy.Location = new System.Drawing.Point(31, 24);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(72, 23);
            this.easy.TabIndex = 14;
            this.easy.Text = "EASY";
            this.easy.UseVisualStyleBackColor = true;
            this.easy.Click += new System.EventHandler(this.easy_Click);
            // 
            // medium
            // 
            this.medium.Location = new System.Drawing.Point(106, 24);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(72, 23);
            this.medium.TabIndex = 15;
            this.medium.Text = "MEDIUM";
            this.medium.UseVisualStyleBackColor = true;
            this.medium.Click += new System.EventHandler(this.medium_Click);
            // 
            // hard
            // 
            this.hard.Location = new System.Drawing.Point(181, 24);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(72, 23);
            this.hard.TabIndex = 16;
            this.hard.Text = "HARD";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Controls.Add(this.txtMine);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Name = "frmStart";
            this.Text = "Minesweeper2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMine;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button easy;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Button hard;
    }
}

