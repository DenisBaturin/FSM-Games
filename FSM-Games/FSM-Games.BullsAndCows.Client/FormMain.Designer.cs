namespace FSM_Games.BullsAndCows.Client
{
    partial class FormMain
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.MenuItemHelpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemHelpRules = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGameExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGameSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemGameSound = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGameNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRazr = new System.Windows.Forms.Label();
            this.lvStat = new System.Windows.Forms.ListView();
            this.btn_BS = new System.Windows.Forms.Button();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Lost = new System.Windows.Forms.Button();
            this.btn_0 = new System.Windows.Forms.Button();
            this.btn_9 = new System.Windows.Forms.Button();
            this.btn_8 = new System.Windows.Forms.Button();
            this.btn_7 = new System.Windows.Forms.Button();
            this.btn_6 = new System.Windows.Forms.Button();
            this.btn_5 = new System.Windows.Forms.Button();
            this.btn_4 = new System.Windows.Forms.Button();
            this.btn_3 = new System.Windows.Forms.Button();
            this.btn_2 = new System.Windows.Forms.Button();
            this.btn_1 = new System.Windows.Forms.Button();
            this.txt_Input = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(312, 168);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(40, 20);
            this.numericUpDown1.TabIndex = 42;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // MenuItemHelpSeparator1
            // 
            this.MenuItemHelpSeparator1.Name = "MenuItemHelpSeparator1";
            this.MenuItemHelpSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItemHelpRules
            // 
            this.MenuItemHelpRules.Name = "MenuItemHelpRules";
            this.MenuItemHelpRules.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuItemHelpRules.Size = new System.Drawing.Size(180, 22);
            this.MenuItemHelpRules.Text = "Правила";
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHelpRules,
            this.MenuItemHelpSeparator1,
            this.MenuItemHelpAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(24, 20);
            this.MenuItemHelp.Text = "?";
            // 
            // MenuItemHelpAbout
            // 
            this.MenuItemHelpAbout.Name = "MenuItemHelpAbout";
            this.MenuItemHelpAbout.Size = new System.Drawing.Size(180, 22);
            this.MenuItemHelpAbout.Text = "О программе...";
            this.MenuItemHelpAbout.Click += new System.EventHandler(this.MenuItemHelpAbout_Click);
            // 
            // MenuItemGameExit
            // 
            this.MenuItemGameExit.Name = "MenuItemGameExit";
            this.MenuItemGameExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.MenuItemGameExit.Size = new System.Drawing.Size(180, 22);
            this.MenuItemGameExit.Text = "Выход";
            this.MenuItemGameExit.Click += new System.EventHandler(this.MenuItemGameExit_Click);
            // 
            // MenuItemGameSeparator1
            // 
            this.MenuItemGameSeparator1.Name = "MenuItemGameSeparator1";
            this.MenuItemGameSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MenuItemGameSound
            // 
            this.MenuItemGameSound.Checked = true;
            this.MenuItemGameSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemGameSound.Name = "MenuItemGameSound";
            this.MenuItemGameSound.Size = new System.Drawing.Size(180, 22);
            this.MenuItemGameSound.Text = "Звук";
            // 
            // MenuItemGameNewGame
            // 
            this.MenuItemGameNewGame.Name = "MenuItemGameNewGame";
            this.MenuItemGameNewGame.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemGameNewGame.Size = new System.Drawing.Size(180, 22);
            this.MenuItemGameNewGame.Text = "Новая игра";
            this.MenuItemGameNewGame.Click += new System.EventHandler(this.MenuItemGameNewGame_Click);
            // 
            // MenuItemGame
            // 
            this.MenuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGameNewGame,
            this.MenuItemGameSound,
            this.MenuItemGameSeparator1,
            this.MenuItemGameExit});
            this.MenuItemGame.Name = "MenuItemGame";
            this.MenuItemGame.Size = new System.Drawing.Size(46, 20);
            this.MenuItemGame.Text = "Игра";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGame,
            this.MenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(362, 24);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStripMain";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Коров";
            this.columnHeader3.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Быков";
            this.columnHeader2.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Число";
            // 
            // lblRazr
            // 
            this.lblRazr.Location = new System.Drawing.Point(208, 168);
            this.lblRazr.Name = "lblRazr";
            this.lblRazr.Size = new System.Drawing.Size(96, 32);
            this.lblRazr.TabIndex = 25;
            this.lblRazr.Text = "Количество цифр в числе:";
            // 
            // lvStat
            // 
            this.lvStat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStat.FullRowSelect = true;
            this.lvStat.HideSelection = false;
            this.lvStat.Location = new System.Drawing.Point(8, 32);
            this.lvStat.Name = "lvStat";
            this.lvStat.Size = new System.Drawing.Size(192, 232);
            this.lvStat.TabIndex = 40;
            this.lvStat.UseCompatibleStateImageBehavior = false;
            this.lvStat.View = System.Windows.Forms.View.Details;
            // 
            // btn_BS
            // 
            this.btn_BS.Location = new System.Drawing.Point(256, 104);
            this.btn_BS.Name = "btn_BS";
            this.btn_BS.Size = new System.Drawing.Size(48, 24);
            this.btn_BS.TabIndex = 39;
            this.btn_BS.Text = "<=";
            this.btn_BS.UseVisualStyleBackColor = true;
            this.btn_BS.Click += new System.EventHandler(this.btn_BS_Click);
            // 
            // btn_Enter
            // 
            this.btn_Enter.Location = new System.Drawing.Point(304, 56);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(48, 72);
            this.btn_Enter.TabIndex = 38;
            this.btn_Enter.Text = "Ввод";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Enter_Click);
            // 
            // btn_Lost
            // 
            this.btn_Lost.Location = new System.Drawing.Point(208, 136);
            this.btn_Lost.Name = "btn_Lost";
            this.btn_Lost.Size = new System.Drawing.Size(144, 24);
            this.btn_Lost.TabIndex = 37;
            this.btn_Lost.Text = "Подсказка";
            this.btn_Lost.UseVisualStyleBackColor = true;
            this.btn_Lost.Click += new System.EventHandler(this.btn_Lost_Click);
            // 
            // btn_0
            // 
            this.btn_0.Location = new System.Drawing.Point(208, 56);
            this.btn_0.Name = "btn_0";
            this.btn_0.Size = new System.Drawing.Size(24, 24);
            this.btn_0.TabIndex = 36;
            this.btn_0.Text = "0";
            this.btn_0.UseVisualStyleBackColor = true;
            this.btn_0.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_9
            // 
            this.btn_9.Location = new System.Drawing.Point(232, 104);
            this.btn_9.Name = "btn_9";
            this.btn_9.Size = new System.Drawing.Size(24, 24);
            this.btn_9.TabIndex = 35;
            this.btn_9.Text = "9";
            this.btn_9.UseVisualStyleBackColor = true;
            this.btn_9.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_8
            // 
            this.btn_8.Location = new System.Drawing.Point(208, 104);
            this.btn_8.Name = "btn_8";
            this.btn_8.Size = new System.Drawing.Size(24, 24);
            this.btn_8.TabIndex = 34;
            this.btn_8.Text = "8";
            this.btn_8.UseVisualStyleBackColor = true;
            this.btn_8.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_7
            // 
            this.btn_7.Location = new System.Drawing.Point(280, 80);
            this.btn_7.Name = "btn_7";
            this.btn_7.Size = new System.Drawing.Size(24, 24);
            this.btn_7.TabIndex = 33;
            this.btn_7.Text = "7";
            this.btn_7.UseVisualStyleBackColor = true;
            this.btn_7.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_6
            // 
            this.btn_6.Location = new System.Drawing.Point(256, 80);
            this.btn_6.Name = "btn_6";
            this.btn_6.Size = new System.Drawing.Size(24, 24);
            this.btn_6.TabIndex = 32;
            this.btn_6.Text = "6";
            this.btn_6.UseVisualStyleBackColor = true;
            this.btn_6.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_5
            // 
            this.btn_5.Location = new System.Drawing.Point(232, 80);
            this.btn_5.Name = "btn_5";
            this.btn_5.Size = new System.Drawing.Size(24, 24);
            this.btn_5.TabIndex = 31;
            this.btn_5.Text = "5";
            this.btn_5.UseVisualStyleBackColor = true;
            this.btn_5.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_4
            // 
            this.btn_4.Location = new System.Drawing.Point(208, 80);
            this.btn_4.Name = "btn_4";
            this.btn_4.Size = new System.Drawing.Size(24, 24);
            this.btn_4.TabIndex = 30;
            this.btn_4.Text = "4";
            this.btn_4.UseVisualStyleBackColor = true;
            this.btn_4.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_3
            // 
            this.btn_3.Location = new System.Drawing.Point(280, 56);
            this.btn_3.Name = "btn_3";
            this.btn_3.Size = new System.Drawing.Size(24, 24);
            this.btn_3.TabIndex = 29;
            this.btn_3.Text = "3";
            this.btn_3.UseVisualStyleBackColor = true;
            this.btn_3.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_2
            // 
            this.btn_2.Location = new System.Drawing.Point(256, 56);
            this.btn_2.Name = "btn_2";
            this.btn_2.Size = new System.Drawing.Size(24, 24);
            this.btn_2.TabIndex = 28;
            this.btn_2.Text = "2";
            this.btn_2.UseVisualStyleBackColor = true;
            this.btn_2.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // btn_1
            // 
            this.btn_1.Location = new System.Drawing.Point(232, 56);
            this.btn_1.Name = "btn_1";
            this.btn_1.Size = new System.Drawing.Size(24, 24);
            this.btn_1.TabIndex = 27;
            this.btn_1.Text = "1";
            this.btn_1.UseVisualStyleBackColor = true;
            this.btn_1.Click += new System.EventHandler(this.NumButton_Click);
            // 
            // txt_Input
            // 
            this.txt_Input.Location = new System.Drawing.Point(208, 32);
            this.txt_Input.Name = "txt_Input";
            this.txt_Input.ReadOnly = true;
            this.txt_Input.Size = new System.Drawing.Size(144, 20);
            this.txt_Input.TabIndex = 26;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 273);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblRazr);
            this.Controls.Add(this.lvStat);
            this.Controls.Add(this.btn_BS);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.btn_Lost);
            this.Controls.Add(this.btn_0);
            this.Controls.Add(this.btn_9);
            this.Controls.Add(this.btn_8);
            this.Controls.Add(this.btn_7);
            this.Controls.Add(this.btn_6);
            this.Controls.Add(this.btn_5);
            this.Controls.Add(this.btn_4);
            this.Controls.Add(this.btn_3);
            this.Controls.Add(this.btn_2);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.txt_Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"Быки и коровы\"";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripSeparator MenuItemHelpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelpRules;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameExit;
        private System.Windows.Forms.ToolStripSeparator MenuItemGameSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameSound;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameNewGame;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGame;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label lblRazr;
        private System.Windows.Forms.ListView lvStat;
        private System.Windows.Forms.Button btn_BS;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Lost;
        private System.Windows.Forms.Button btn_0;
        private System.Windows.Forms.Button btn_9;
        private System.Windows.Forms.Button btn_8;
        private System.Windows.Forms.Button btn_7;
        private System.Windows.Forms.Button btn_6;
        private System.Windows.Forms.Button btn_5;
        private System.Windows.Forms.Button btn_4;
        private System.Windows.Forms.Button btn_3;
        private System.Windows.Forms.Button btn_2;
        private System.Windows.Forms.Button btn_1;
        private System.Windows.Forms.TextBox txt_Input;
    }
}

