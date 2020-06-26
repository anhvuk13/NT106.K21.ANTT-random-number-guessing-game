using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Linq;
using System.Configuration;
using System.Runtime.InteropServices;

namespace RNGG
{
    public partial class MainForm : Form
    {
        //  variables
        ////  main form
        private Thread thread = null;
        private TcpListener serverSocket;
        private IngameForm serverForm = null;
        ////  server
        private readonly object _lock = new object();
        private readonly Dictionary<String, TcpClient> clientsList = new Dictionary<string, TcpClient>();
        private Dictionary<String, int> scoreBoard = new Dictionary<string, int>();
        private Dictionary<String, bool> readyPlayers = new Dictionary<string, bool>();
        private int clientsCount = 0, luckyNumber, round = 0, currentRound, timeupCount, startRange, endRange;
        private bool ingame = false;
        private String correctPlayer, time = "";
        private Random rand;

        //  init
        public MainForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            rand = new Random();
        }

        //  envent handler
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ingame)
            {
                e.Cancel = true;
                (new Thread(() => MessageBox.Show("Please wait until the current game ends.", "Can't close this form now"))).Start();
                return;
            }

            if (serverForm != null)
            {
                this.Hide();
                
                String text = $">>> {time} - Server hosted a connection... <<<\n\n{serverForm.conversation.Text}\n>>> Connection closed <<<\n\n\n\n";
                (new Browser(text)).ShowDialog();
                serverForm.isServer = serverForm.isIngame = false;
                serverForm.Close();
            }

            if (serverSocket != null) serverSocket.Stop();
            if (thread != null) thread.Abort();
        }

        //  button click handler
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (serverForm != null)
            {
                serverForm.Show();
                return;
            }
            serverForm = new IngameForm(this, joinUsername.Text, joinIP.Text, joinPort.Text, time);
            serverForm.Show();
            if (thread == null) serverForm = null;
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            btnServer.Enabled = false;
            thread = new Thread(serverThread);
            thread.Start();
        }

        //  server
        private void serverThread()
        {
            int port;
            try
            {
                port = Int32.Parse(hostPort.Text);
                serverSocket = new TcpListener(IPAddress.Any, port);
                serverSocket.Start();
            }
            catch
            {
                btnServer.Invoke(new MethodInvoker(delegate ()
                {
                    btnServer.Enabled = true;
                }));
                MessageBox.Show("The port is invalid or in use.", "Error");
                return;
            }

            time = DateTime.Now.ToString("h:mm:ss tt");

            this.Invoke(new MethodInvoker(delegate ()
            {
                joinUsername.Text = "Server";
                joinIP.Text = "localhost";
                joinPort.Text = hostPort.Text;
                joinUsername.Enabled = joinIP.Enabled = joinPort.Enabled = hostPort.Enabled = false;
            }));

            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                btnClient.PerformClick();
            })))).Start();

            MessageBox.Show($"Successfully host a game at port {port}.", "Success");

            while (Thread.CurrentThread.IsAlive)
            {
                TcpClient client = null;
                try
                {
                    client = serverSocket.AcceptTcpClient();
                }
                catch (SocketException e)
                {
                    if ((e.SocketErrorCode == SocketError.Interrupted)) break;
                }

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesCount = stream.Read(buffer, 0, buffer.Length);
                String username = Encoding.UTF8.GetString(buffer, 0, bytesCount);

                if (thread != null && ingame)
                {
                    buffer = Encoding.UTF8.GetBytes("@@@Ingame!@@@");
                    stream.Write(buffer, 0, buffer.Length);
                    continue;
                }
                if (username == " ") username = $"Player {clientsCount}";
                if (clientsList.ContainsKey(username))
                {
                    buffer = Encoding.UTF8.GetBytes(" ");
                    stream.Write(buffer, 0, buffer.Length);
                    continue;
                }
                buffer = Encoding.UTF8.GetBytes(username);
                stream.Write(buffer, 0, buffer.Length);

                lock (_lock) clientsList.Add(username, client);
                if (username != "Server")
                {
                    broadcast($"m>>> {username} has joined the game.", username);
                    scoreBoard.Add(username, 0);
                }
                
                clientsCount++;

                Thread handlingThread = new Thread(o => clientsHandling((string)o));
                handlingThread.Start(username);
                broadcast($"\t{clientsList.Count - 1}");
            }

            btnServer.Invoke(new MethodInvoker(delegate ()
            {
                btnServer.Enabled = true;
                btnServer.ResetText();
            }));
        }

        public void clientsHandling(string username)
        {
            TcpClient client;
            lock (_lock) client = clientsList[username];
            while (thread.IsAlive)
            {
                int bytesCount = 0;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                try
                {
                    bytesCount = stream.Read(buffer, 0, buffer.Length);
                }
                catch { }
                if (bytesCount == 0) break;

                string requestFromClient = Encoding.UTF8.GetString(buffer, 0, bytesCount);
                var dataList = requestFromClient.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                    if (data[0] == 's')
                    {
                        if (correctPlayer == "" && timeupCount < readyPlayers.Count)
                            try
                            {
                                int ans = Int32.Parse(data.Substring(1));
                                if (ans == luckyNumber)
                                {
                                    correctPlayer = username;
                                    scoreBoard[username] += 10;
                                    broadcast($"mWe've just found the Round {currentRound - 1}'s winner...");
                                }
                                if (ans != luckyNumber)
                                {
                                    broadcast($"m{username} sent a wrong answer ({ans}). -1p");
                                    scoreBoard[username]--;
                                }
                            }
                            catch
                            {
                                broadcast($"m{username} sent an invalid answer! -1p");
                                scoreBoard[username]--;
                            }
                    }
                    else if (data[0] == 'm') broadcast($"m{username}: {data.Substring(1)}");
                    else if (data == "@@@Timeup!@@@")
                    {
                        timeupCount++;
                        if (timeupCount == readyPlayers.Count) (new Thread(() => timeup())).Start();
                    }
                    else if (data == "@@@Ready!@@@")
                    {
                        broadcast($"m>>> {username} is Ready!");
                        readyPlayers.Add(username, true);
                        readyCheck();
                    }
            }

            lock (_lock) clientsList.Remove(username);
            client.Client.Shutdown(SocketShutdown.Both);
            client.Close();

            if (username == "Server")
            {
                broadcast("@@@Exit!@@@");
            }
            else
            {
                broadcast($"m>>> {username} has left the game.");
                if (clientsList.Count == 1)
                {
                    broadcast($"m>>> Everybody have left the game!");
                    if (ingame)
                    {
                        ingame = false;
                        endGame();
                    }
                }
                broadcast($"\t{clientsList.Count - 1}");
                scoreBoard.Remove(username);
                if (readyPlayers.ContainsKey(username)) readyPlayers.Remove(username);
                readyCheck();
            }
        }

        private void readyCheck()
        {
            if (readyPlayers.Count != 0 && readyPlayers.Count == clientsList.Count - 1)
            {
                ingame = true;
                broadcast($"mThere is/are {readyPlayers.Count} participant(s).");
                (new Thread(roundStart)).Start();
            }
        }

        private void timeup()
        {
            string message;
            if (correctPlayer == "") message = $"mWhat a pity! No one has given the correct answer.";
            else message = $"mCongratulations! {correctPlayer} is the fastest to give the correct answer! +10p";
            broadcast($"{message}\nmThe Lucky Number is {luckyNumber}.\nm------------------------------");
            if (currentRound > round) (new Thread(endGame)).Start();
            else if (ingame) (new Thread(roundStart)).Start();
        }

        private void endGame()
        {
            if (ingame)
            {
                ingame = false;
                int highscore = Int32.MinValue;
                foreach (var i in scoreBoard)
                    if (i.Value > highscore) highscore = i.Value;

                string message;
                message = $"mThe highest score: {highscore}\nmThese user(s) have reached the highest score:\n";
                foreach (var i in scoreBoard)
                    if (i.Value == highscore) message += $"m  + {i.Key}\n";

                foreach (var i in clientsList)
                {
                    try
                    {
                        NetworkStream stream = i.Value.GetStream();
                        byte[] buffer;
                        if (i.Key == "Server")
                            buffer = Encoding.UTF8.GetBytes($"{message}\n");
                        else
                            buffer = Encoding.UTF8.GetBytes($"{message}\nmYour score: {scoreBoard[i.Key]}\n");
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch { }
                }
            }

            broadcast($"m==============================\nm\nmNew game generating...\nmWaiting for competitors...\n@@@Newgame!@@@");
            scoreBoard = scoreBoard.ToDictionary(p => p.Key, p => 0);
            round = 0;
            readyPlayers.Clear();
        }

        private void roundStart()
        {
            Thread.Sleep(2000);
            timeupCount = 0;
            if (round == 0)
            {
                round = rand.Next(5, 11);
                broadcast($"mThis game has {round} Round(s). Let's fight!");
                currentRound = 1;
            }
            startRange = rand.Next(0, 11) * 10;
            endRange = startRange + rand.Next(1, 6) * 10;
            luckyNumber = rand.Next(startRange, endRange + 1);
            broadcast($"m>>> Round {currentRound}: Submit an integer in [{startRange}, {endRange}].\n@@@Nextround!@@@{rand.Next(5, 11)}\t{startRange}\t{endRange}\t{luckyNumber}");
            currentRound++;
            correctPlayer = "";
        }

        public void broadcast(string data, String except = "")
        {
            byte[] buffer = Encoding.UTF8.GetBytes($"{data}\n");
            lock (_lock)
            {
                foreach (var c in clientsList) if (c.Key != except)
                {
                    NetworkStream stream = c.Value.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }











        //  gui
        public static void btnMouseHover(Button btn)
        {
            btn.BackColor = Color.Navy;
            btn.ForeColor = Color.White;
        }

        public static void btnMouseLeave(Button btn)
        {
            btn.BackColor = Color.Black;
            btn.ForeColor = Color.DeepSkyBlue;
        }

        public static void btnMouseDown(Button btn)
        {
            btn.BackColor = Color.LightSkyBlue;
            btn.ForeColor = Color.Black;
        }

        private void btnServer_MouseHover(object sender, EventArgs e)
        {
            btnMouseHover(btnServer);
        }

        private void btnServer_MouseLeave(object sender, EventArgs e)
        {
            btnMouseLeave(btnServer);
        }

        private void btnServer_MouseDown(object sender, MouseEventArgs e)
        {
            btnMouseDown(btnServer);
        }

        private void btnClient_MouseHover(object sender, EventArgs e)
        {
            btnMouseHover(btnClient);
        }

        private void btnClient_MouseLeave(object sender, EventArgs e)
        {
            btnMouseLeave(btnClient);
        }

        private void btnClient_MouseDown(object sender, MouseEventArgs e)
        {
            btnMouseDown(btnClient);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnMouseHover(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnMouseLeave(btnExit);
        }

        private void btnExit_MouseDown(object sender, MouseEventArgs e)
        {
            btnMouseDown(btnExit);
        }
    }
}