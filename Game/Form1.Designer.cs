namespace Game
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlChessBoard = new Panel();
            panel2 = new Panel();
            pctbAvatar = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            btnLAN = new Button();
            txbIP = new TextBox();
            pctbMark = new PictureBox();
            prcbCoolDown = new ProgressBar();
            txbPlayerName = new TextBox();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            newGameToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctbMark).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.BackColor = SystemColors.Control;
            pnlChessBoard.Location = new Point(12, 39);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(541, 510);
            pnlChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(pctbAvatar);
            panel2.Location = new Point(581, 39);
            panel2.Name = "panel2";
            panel2.Size = new Size(291, 264);
            panel2.TabIndex = 1;
            // 
            // pctbAvatar
            // 
            pctbAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pctbAvatar.BackColor = SystemColors.ActiveCaption;
            pctbAvatar.Location = new Point(3, 3);
            pctbAvatar.Name = "pctbAvatar";
            pctbAvatar.Size = new Size(285, 285);
            pctbAvatar.TabIndex = 0;
            pctbAvatar.TabStop = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnLAN);
            panel3.Controls.Add(txbIP);
            panel3.Controls.Add(pctbMark);
            panel3.Controls.Add(prcbCoolDown);
            panel3.Controls.Add(txbPlayerName);
            panel3.Location = new Point(581, 309);
            panel3.Name = "panel3";
            panel3.Size = new Size(291, 240);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 159);
            label1.Name = "label1";
            label1.Size = new Size(228, 37);
            label1.TabIndex = 5;
            label1.Text = "5 in a line to win";
            // 
            // btnLAN
            // 
            btnLAN.Location = new Point(3, 90);
            btnLAN.Name = "btnLAN";
            btnLAN.Size = new Size(123, 23);
            btnLAN.TabIndex = 4;
            btnLAN.Text = "LAN";
            btnLAN.UseVisualStyleBackColor = true;
            btnLAN.Click += btnLAN_Click;
            // 
            // txbIP
            // 
            txbIP.Location = new Point(3, 61);
            txbIP.Name = "txbIP";
            txbIP.Size = new Size(123, 23);
            txbIP.TabIndex = 3;
            txbIP.Text = "127.0.0.1";
            // 
            // pctbMark
            // 
            pctbMark.BackColor = SystemColors.ActiveCaption;
            pctbMark.BackgroundImageLayout = ImageLayout.Stretch;
            pctbMark.Location = new Point(132, 3);
            pctbMark.Name = "pctbMark";
            pctbMark.Size = new Size(156, 110);
            pctbMark.TabIndex = 2;
            pctbMark.TabStop = false;
            // 
            // prcbCoolDown
            // 
            prcbCoolDown.Location = new Point(3, 32);
            prcbCoolDown.Name = "prcbCoolDown";
            prcbCoolDown.Size = new Size(123, 23);
            prcbCoolDown.TabIndex = 1;
            // 
            // txbPlayerName
            // 
            txbPlayerName.Location = new Point(3, 3);
            txbPlayerName.Name = "txbPlayerName";
            txbPlayerName.ReadOnly = true;
            txbPlayerName.Size = new Size(123, 23);
            txbPlayerName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(884, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameToolStripMenuItem, undoToolStripMenuItem, quitToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            newGameToolStripMenuItem.Size = new Size(131, 22);
            newGameToolStripMenuItem.Text = "New game";
            newGameToolStripMenuItem.Click += newGameToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(131, 22);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(131, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlChessBoard);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctbAvatar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pctbMark).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlChessBoard;
        private Panel panel2;
        private PictureBox pctbAvatar;
        private Panel panel3;
        private Label label1;
        private Button btnLAN;
        private TextBox txbIP;
        private PictureBox pctbMark;
        private ProgressBar prcbCoolDown;
        private TextBox txbPlayerName;
        private System.Windows.Forms.Timer tmCoolDown;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
    }
}