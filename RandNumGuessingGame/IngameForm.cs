using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace RNGG
{
    public partial class IngameForm : Form
    {

        //  variables
        private MainForm parent;
        private TcpClient client = null;
        private Thread thread = null;
        private String joinUsername, joinIP, joinPort, time;
        private bool isAuto = false;
        public bool isIngame = false, isServer = false;
        private int timeLeft = -1, startRange, endRange, valRange, lastSubmitTime;
        private List<int> trueVal = null;
        private Random rand;

        //  init
        public IngameForm(MainForm parent, string joinUsername, string joinIP, string joinPort, String time)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.parent = parent;
            this.joinUsername = joinUsername;
            this.joinIP = joinIP;
            this.joinPort = joinPort;
            this.time = time;
            rand = new Random();
        }

        //  event handler
        private void ClientForm_Load(object sender, EventArgs e)
        {
            string username = joinUsername;
            IPAddress ip = null;
            int port = 0;
            if (username == "Username" || username == "") username = " ";
            try
            {
                ip = Dns.Resolve(joinIP).AddressList[0];
                port = Int32.Parse(joinPort);
            }
            catch
            {
                MessageBox.Show("The IPEndpoint is incorrect.", "Error");
                this.Close();
                return;
            }
            client = new TcpClient();
            try
            {
                client.Connect(ip, port);
            }
            catch
            {
                MessageBox.Show("Server is not running!", "Error");
                this.Close();
                return;
            }

            //  assign username
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(username);
            stream.Write(buffer, 0, buffer.Length);

            buffer = new byte[1024];
            int bytesCount = stream.Read(buffer, 0, buffer.Length);
            string res = Encoding.UTF8.GetString(buffer, 0, bytesCount);
            String[] ress = res.Split('\t');
            if (ress[0] == "Server")
            {
                isServer = true;
                btnReady.Enabled = btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = btnClear.Enabled = label1.Enabled = false;
                answer.BorderStyle = BorderStyle.None;
            }
            else if (ress[0] == "@@@Ingame!@@@")
            {
                MessageBox.Show("Sorry, the game has started!", "Error");
                this.Close();
                return;
            }
            else if (ress[0] == " ")
            {
                MessageBox.Show($"{username} is invalid or already picked.", "Error");
                this.Close();
                return;
            }

            if (!isServer)
            {
                MessageBox.Show($"{ress[0]} is your username.", "Success");
                time = DateTime.Now.ToString("h:mm:ss tt");
            }

            this.Text = ress[0];
            if (ress.Length > 1) playerNum.Text = $"{ress[1].Trim('\n')} player(s) have joined the game.";

            thread = new Thread(o => ReceiveData((TcpClient)o));
            thread.Start(client);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isServer)
            {
                this.Hide();
                parent.Show();
                e.Cancel = true;
                return;
            }
            else if (isIngame)
            {
                e.Cancel = true;
                (new Thread(() => MessageBox.Show("You have to stay until the game ends.\nPlease take your responsibility for having clicked \"Ready!\" button.\nHave fun!", "Error"))).Start();
                return;
            }

            if (this.Text != "Anonymous")
            try
            {
                String path = Path.Combine(
                    Path.GetDirectoryName(Application.ExecutablePath),
                    $"History_{this.Text}.txt"
                );
                StreamWriter sw;
                if (!File.Exists(path)) sw = File.CreateText(path);
                else sw = File.AppendText(path);
                String hostOrJoin;
                if (this.Text == "Server") hostOrJoin = $">>> {time} - Server hosted a connection... <<<";
                else hostOrJoin = $">>> {time} - {this.Text} connected to Server... <<<";
                conversation.Text = $"{hostOrJoin}\n\n{conversation.Text}\n>>> Connection closed <<<\n\n\n\n";
                foreach (String line in conversation.Lines)
                    sw.WriteLine(line);
                sw.Close();
            } catch
            {
                MessageBox.Show("Can't write log file.", "Error");
            }

            if (thread != null) thread.Abort();

            if (client != null)
            {
                try
                {
                    client.Client.Shutdown(SocketShutdown.Send);
                }
                catch { }
                client.Close();
            }

            parent.Show();
        }

        private void send(String message)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes($"{message}\n");
            stream.Write(buffer, 0, buffer.Length);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft > -1)
            {
                pic1.Image = pic2.Image = pic3.Image = (Image)Properties.Resources.ResourceManager.GetObject($"_{timeLeft}");
                if (timeLeft == 0)
                {
                    btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = label3.Enabled = label4.Enabled = range.Enabled = luckyNumber.Enabled = false;
                    send("@@@Timeup!@@@");
                }
                else if (isAuto && lastSubmitTime - timeLeft >= 3)
                    (new Thread(() => autoSubmit())).Start();
                else if (!isAuto && lastSubmitTime - timeLeft >= 3)
                {
                    btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = true;
                    answer.Focus();
                    answer.Select();
                }
            }
            else
            {
                pic1.Image = pic2.Image = pic3.Image = (Image)Properties.Resources.a;
                timer.Stop();
            }
        }

        private void answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
            }
        }

        private void message_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        //  button click handler
        private void btnReady_Click(object sender, EventArgs e)
        {
            btnReady.Enabled = false;
            send("@@@Ready!@@@");
        }

        private void submit(int val)
        {
            if (timeLeft <= 0) return;
            (new Thread(() => send($"s{val}"))).Start();
            lastSubmitTime = timeLeft;
            if (!this.InvokeRequired)
                btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
            int index = trueVal.IndexOf(val);
            if (index != -1 && index <= valRange)
            {
                int temp = trueVal[valRange];
                trueVal[valRange] = trueVal[index];
                trueVal[index] = temp;
                valRange--;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            submit(Int32.Parse(answer.Text));
            answer.Clear();
        }

        private void autoSubmit()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate ()
                {
                    autoSubmit();
                }));
            else
            {
                btnSubmit.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
                if (isAuto) btnAutoplayWholeGame.Enabled = false;
                int val = rand.Next(0, valRange + 1);
                submit(trueVal[val]);
            }
        }

        private void btnAutoPlaySingleTurn_Click(object sender, EventArgs e)
        {
            autoSubmit();
        }

        private void btnAutoplayWholeGame_Click(object sender, EventArgs e)
        {
            isAuto = true;
            autoSubmit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            send($"m{message.Text}");
            message.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            conversation.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //  thread body
        private void ReceiveData(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] receivedBytes = new byte[1024];
            int bytesCount;

            while (Thread.CurrentThread.IsAlive)
            {
                try
                {
                    if ((bytesCount = stream.Read(receivedBytes, 0, receivedBytes.Length)) <= 0) break;
                } catch { break; }
                string respondFromServer = Encoding.UTF8.GetString(receivedBytes, 0, bytesCount);
                var dataList = respondFromServer.Split(new String[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String data in dataList)
                {
                    if (data[0] == 'm')
                        conversation.Invoke(new MethodInvoker(delegate ()
                        {
                            conversation.AppendText($"{data.Substring(1)}\n");
                            conversation.ScrollToCaret();
                        }));
                    else if (data[0] == '\t')
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            playerNum.Text = $"{data.Substring(1)} player(s) have joined the game.";
                        }));

                    else if (data.StartsWith("@@@Nextround!@@@"))
                    {
                        if (!isIngame) isIngame = true;

                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            label3.Enabled = range.Enabled = true;
                        }));

                        var rand = data.Substring(16).Split(new String[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        startRange = Int32.Parse(rand[1]);
                        endRange = Int32.Parse(rand[2]);
                        valRange = endRange - startRange;
                        trueVal = Enumerable.Range(startRange, valRange + 1).ToList();
                        range.Invoke(new MethodInvoker(delegate ()
                        {
                            range.Text = $"[{startRange}, {endRange}]";
                        }));

                        if (isServer) luckyNumber.Invoke(new MethodInvoker(delegate ()
                        {
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                label4.Enabled = luckyNumber.Enabled = true;
                            }));
                            luckyNumber.Text = rand[3];
                        }));
                        else
                        {
                            lastSubmitTime = 100;
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = true;
                                answer.Focus();
                                answer.Select();
                            }));
                        }

                        timeLeft = Int32.Parse(rand[0]);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            pic1.Image = pic2.Image = pic3.Image = (Image)Properties.Resources.ResourceManager.GetObject($"_{timeLeft}");
                            timer.Start();
                        }));
                    }
                    else if (!isServer && data == "@@@Newgame!@@@")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            btnReady.Enabled = true;
                            btnSubmit.Enabled = btnAutoplayWholeGame.Enabled = btnAutoPlaySingleTurn.Enabled = answer.Enabled = false;
                        }));
                        isIngame = isAuto = false;
                    }
                    else if (data == "@@@Exit!@@@")
                    {
                        closeWhenServerDown();
                        break;
                    }
                }
            }
            if (isIngame)
            {
                isIngame = false;
                closeWhenServerDown();
            }
            stream.Close();
        }

        private void closeWhenServerDown()
        {
            MessageBox.Show("The Server is down.", "Connection closed");
            (new Thread(() => this.Invoke(new MethodInvoker(delegate ()
            {
                this.Close();
            })))).Start();
        }




        //gui
        private void btnAutoPlaySingleRound_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnAutoPlaySingleTurn);
        }

        private void btnAutoPlaySingleRound_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnAutoPlaySingleTurn);
        }

        private void btnAutoPlaySingleRound_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnAutoPlaySingleTurn);
        }

        private void btnAutoplayWholeGame_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnAutoplayWholeGame);
        }

        private void btnAutoplayWholeGame_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnAutoplayWholeGame);
        }

        private void btnAutoplayWholeGame_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnAutoplayWholeGame);
        }

        private void btnSubmit_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnSubmit);
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnSubmit);
        }

        private void btnSubmit_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnSubmit);
        }

        private void btnReady_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnReady);
        }

        private void btnReady_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnReady);
        }

        private void btnReady_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnReady);
        }

        private void btnSend_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnSend);
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnSend);
        }

        private void btnSend_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnSend);
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnClear);
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnClear);
        }

        private void btnClear_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnClear);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            MainForm.btnMouseHover(btnExit);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            MainForm.btnMouseLeave(btnExit);
        }

        private void btnExit_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.btnMouseDown(btnExit);
        }
    }
}
