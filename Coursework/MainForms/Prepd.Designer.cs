namespace Coursework.MainForms
{
    partial class Prepd
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
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.idddd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.df = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.achievement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.achievementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.achievementdcrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(537, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 37);
            this.button3.TabIndex = 7;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(537, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "Редактировать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idddd,
            this.sub,
            this.df,
            this.achievement,
            this.achievementType,
            this.achievementdcrp});
            this.dgv.Location = new System.Drawing.Point(0, -2);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(531, 460);
            this.dgv.TabIndex = 4;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // idddd
            // 
            this.idddd.HeaderText = "id";
            this.idddd.Name = "idddd";
            this.idddd.Visible = false;
            // 
            // sub
            // 
            this.sub.HeaderText = "Предмет";
            this.sub.Name = "sub";
            // 
            // df
            // 
            this.df.HeaderText = "Количество часов";
            this.df.Name = "df";
            // 
            // achievement
            // 
            this.achievement.HeaderText = "Фамилия";
            this.achievement.Name = "achievement";
            // 
            // achievementType
            // 
            this.achievementType.HeaderText = "Имя";
            this.achievementType.Name = "achievementType";
            // 
            // achievementdcrp
            // 
            this.achievementdcrp.HeaderText = "Отчество";
            this.achievementdcrp.Name = "achievementdcrp";
            // 
            // Prepd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv);
            this.MaximumSize = new System.Drawing.Size(750, 500);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "Prepd";
            this.Text = "Преподаватели";
            this.Load += new System.EventHandler(this.Prepd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn idddd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub;
        private System.Windows.Forms.DataGridViewTextBoxColumn df;
        private System.Windows.Forms.DataGridViewTextBoxColumn achievement;
        private System.Windows.Forms.DataGridViewTextBoxColumn achievementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn achievementdcrp;
    }
}