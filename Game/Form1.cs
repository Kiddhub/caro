using System.Net.NetworkInformation;

namespace Game
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        SocketManager socket;

        public Form1()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            ChessBoard = new ChessBoardManager(pnlChessBoard, txbPlayerName, pctbMark);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarked += ChessBoard_PlayerMarked;
            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;
            socket = new SocketManager();
            NewGame();
        }
        void NewGame()
        {
            prcbCoolDown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            ChessBoard.DrawChessBoard();
        }
        void Quit()
        {
            if (MessageBox.Show("Are you sure", "Dialog", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
        void Undo()
        {
            ChessBoard.Undo();
            prcbCoolDown.Value = 0;
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            pnlChessBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Game over");
        }

        void ChessBoard_PlayerMarked(object? sender, ButtonClickEvent e)
        {
            tmCoolDown.Start();
            pnlChessBoard.Enabled = false;
            prcbCoolDown.Value = 0;

            socket.Send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
            undoToolStripMenuItem.Enabled = false;
            Listen();
        }

        void ChessBoard_EndedGame(object? sender, EventArgs e)
        {
            EndGame();
            socket.Send(new SocketData((int)SocketCommand.END_GAME, "", new Point()));
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {

                EndGame();
                socket.Send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            socket.Send(new SocketData((int)SocketCommand.NEW_GAME, "", new Point()));
            pnlChessBoard.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;
            if (!socket.ConnectServer())

            {
                //Kiem tra xem thang nao danh truoc
                socket.isServer = true;
                pnlChessBoard.Enabled = true;
                socket.CreateServer();

            }
            else
            {
                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                Listen();



            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        void Listen()
        {

            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)socket.Receive();
                    ProcessData(data);
                }
                catch
                {

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    }));                 
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prcbCoolDown.Value = 0;
                        pnlChessBoard.Enabled = true;
                        tmCoolDown.Start();
                        ChessBoard.OtherPlayerMark(data.Point);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;
                case (int)SocketCommand.UNDO:                 
                    Undo();
                    prcbCoolDown.Value = 0;
                    
                    break;
                case (int)SocketCommand.END_GAME:
                    MessageBox.Show("Game over");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Time out !!");
                    break;
                case (int)SocketCommand.QUIT:
                    tmCoolDown.Stop();
                    MessageBox.Show("Player was out");
                    break;
                default:
                    break;
            }
            Listen();
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you sure","Dialog",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.Send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch
                {

                }
               
            }
        }
    }
}