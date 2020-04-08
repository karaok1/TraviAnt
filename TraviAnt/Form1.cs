using Fiddler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraviAnt.Proxy;

namespace TraviAnt
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        public delegate void WriterDelegate(string message, Color color);
        public WriterDelegate writer;
        Travian travian;
        Thread threadLogin;
        Thread worker;
        Thread timer;
        Thread threadBuild;
        VillageInfo villageInfo;
        string username, password, server;
        int _trainTroopType, _farmlistTroopType, _interval;

        public static readonly Size size = new Size(60, 60);
        public static readonly ResourceField[] ResourceFields = {
                new ResourceField(new Rectangle(new Point(497, 190), size), "Wood", 1, 1),
                new ResourceField(new Rectangle(new Point(659, 202), size), "Wood", 1, 3),
                new ResourceField(new Rectangle(new Point(599, 368), size), "Wood", 1, 14),
                new ResourceField(new Rectangle(new Point(585, 427), size), "Wood", 1, 17),
                new ResourceField(new Rectangle(new Point(554, 242), size), "Clay", 1, 5),
                new ResourceField(new Rectangle(new Point(612, 248), size), "Clay", 1, 6),
                new ResourceField(new Rectangle(new Point(494, 420), size), "Clay", 1, 16),
                new ResourceField(new Rectangle(new Point(673, 405), size), "Clay", 1, 18),
                new ResourceField(new Rectangle(new Point(441, 228), size), "Iron", 1, 4),
                new ResourceField(new Rectangle(new Point(696, 246), size), "Iron", 1, 7),
                new ResourceField(new Rectangle(new Point(652, 282), size), "Iron", 1, 10),
                new ResourceField(new Rectangle(new Point(739, 279), size), "Iron", 1, 11),
                new ResourceField(new Rectangle(new Point(589, 192), size), "Crop", 1, 2),
                new ResourceField(new Rectangle(new Point(379, 280), size), "Crop", 1, 8),
                new ResourceField(new Rectangle(new Point(462, 281), size), "Crop", 1, 9),
                new ResourceField(new Rectangle(new Point(388, 342), size), "Crop", 1, 12),
                new ResourceField(new Rectangle(new Point(462, 331), size), "Crop", 1, 13),
                new ResourceField(new Rectangle(new Point(721, 336), size), "Crop", 1, 15)
            };

        private bool _login;

        public Form1()
        {
            InitializeComponent();

            this.Init();
        }

        private void Init()
        {
            this.writer = new Form1.WriterDelegate(this.Log);
            form1 = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            GetUserSettings();
            Bot.Log("TTwars bot - TraviAnt. Made by Saisama.", Color.Blue);
            Bot.Log("Current version: " + assembly.GetName().Version.ToString(3), Color.Black);
        }

        private void GetUserSettings()
        {
            textBoxName.Text = Properties.Settings.Default.Username;
            textBoxPassword.Text = Properties.Settings.Default.Password;
            textBoxServer.Text = Properties.Settings.Default.Server;
            comboBoxTroop.SelectedIndex = Properties.Settings.Default.trainTroopType;
            textBoxTrainInterval.Text = Properties.Settings.Default.TrainInterval.ToString();
            checkBoxBuyAnimals.Checked = Properties.Settings.Default.BuyAnimals;
            checkBoxBuyResources.Checked = Properties.Settings.Default.BuyResources;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            username = textBoxName.Text;
            password = textBoxPassword.Text;
            server = textBoxServer.Text;
            var trainTroopType = comboBoxTroop.SelectedIndex;
            var farmlistTroopType = comboBoxTroop.SelectedIndex;
            if (username == string.Empty)
            {
                Bot.Log("Enter a valid username.", Color.Black);
            }
            else if (password == string.Empty)
            {
                Bot.Log("Enter a valid password.", Color.Black);
            }
            else if (Uri.CheckHostName(server) != UriHostNameType.Dns)
            {
                Bot.Log("Enter a valid server URL.", Color.Black);
            }
            else
            {
                travian = new Travian(username, password, server, trainTroopType, farmlistTroopType);
                travian.mainForm = this;
                Bot.Log("Loading page...", Color.Black);
                int loginAttempts = 1;

                threadLogin?.Abort();

                threadLogin = new Thread(() =>
                {
                    while (!_login)
                    {
                        travian.GetToken();
                        var token = Info.LoginId;
                        if (token.Length != 10)
                        {
                            Bot.Log("Token error, retrying in 2 seconds... Attempts: " + loginAttempts, Color.Black);
                            Thread.Sleep(2000);
                            loginAttempts++;
                            continue;
                        }
                        else
                        {
                            Bot.Log("Logging in...", Color.Black);
                            _login = travian.Login(token);
                        }
                    }

                    Bot.Log("Logged in!", Color.Black);
                });
                threadLogin.Start();
                SaveUserSettings();
            }
        }

        private void SaveUserSettings()
        {
            Properties.Settings.Default.Username = textBoxName.Text;
            Properties.Settings.Default.Password = textBoxPassword.Text;
            Properties.Settings.Default.Server = textBoxServer.Text;
            Properties.Settings.Default.trainTroopType = comboBoxTroop.SelectedIndex;
            Properties.Settings.Default.TrainInterval = Convert.ToInt32(textBoxTrainInterval.Text);
            Properties.Settings.Default.BuyAnimals = checkBoxBuyAnimals.Checked;
            Properties.Settings.Default.BuyResources = checkBoxBuyResources.Checked;
            Properties.Settings.Default.Save();
        }

        public static void StartBrowserProxy()
        {
            FiddlerProxy.Start();
            WinInetInterop.SetConnectionProxy(string.Concat(new object[]
                {
                    "127.0.0.1",
                    ":",
                    "7777"
                }));
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            StartBrowserProxy();

            username = textBoxName.Text;
            password = textBoxPassword.Text;
            server = textBoxServer.Text;
            _trainTroopType = comboBoxTroop.SelectedIndex;
            _farmlistTroopType = comboBoxFarmlist.SelectedIndex;
            _interval = Convert.ToInt32(textBoxTrainInterval.Text);
            travian = new Travian(username, password, server, _trainTroopType, _farmlistTroopType);
            travian.mainForm = this;

            villageInfo = new VillageInfo();
            travian.CollectData(ref villageInfo);
            var barracksId = villageInfo.Buildings.Barracks.Id;
            if (buttonStart.Text == "Stop")
            {
                Bot.Log("Bot stopped", Color.Black);
                worker.Abort();
                buttonStart.Text = "Start";
                if (timer != null)
                    if (timer.IsAlive)
                        timer.Abort();

                textBoxName.Enabled = true;
                textBoxPassword.Enabled = true;
                textBoxServer.Enabled = true;
                comboBoxFarmlist.Enabled = true;
                comboBoxTroop.Enabled = true;
                buttonLogin.Enabled = true;
                checkBoxBuyAnimals.Enabled = true;
                checkBoxBuyResources.Enabled = true;
                checkBoxExcludeList.Enabled = true;
                checkBoxNpc.Enabled = true;
            }
            else
            {
                if (_login)
                {
                    buttonStart.Text = "Stop";
                    textBoxName.Enabled = false;
                    textBoxPassword.Enabled = false;
                    textBoxServer.Enabled = false;
                    comboBoxFarmlist.Enabled = false;
                    comboBoxTroop.Enabled = false;
                    buttonLogin.Enabled = false;
                    checkBoxBuyAnimals.Enabled = false;
                    checkBoxBuyResources.Enabled = false;
                    checkBoxExcludeList.Enabled = false;
                    checkBoxNpc.Enabled = false;

                    if (checkBoxExcludeList.Checked)
                    {
                        travian.ExcludeLastList = true;
                        Bot.Log("Exclude raid list is active. The last raid list will not send to raid.", Color.Black);
                    }
                    if (checkBoxBuyAnimals.Checked)
                    {
                        travian.BuyAnimalsState = true;
                        Bot.Log("- Animal purchasing is active.", Color.Green);
                    }
                    if (checkBoxBuyResources.Checked)
                    {
                        travian.BuyResourcesState = true;
                        Bot.Log("- Resources purchasing is active.", Color.Green);
                    }
                    if (checkBoxNpc.Checked)
                    {
                        travian.DoNpc = true;
                        Bot.Log("- NPC is active.", Color.Green);
                    }

                    timer = new Thread(() =>
                    {
                        while (true)
                        {
                            Bot.Log("Starting to buy goodies in 5 seconds.", Color.Black);
                            Thread.Sleep(5000);
                            travian.BuyGoodies();
                            travian.TrainTroops(barracksId);
                            Thread.Sleep(355000);
                        }
                    });
                    timer.Start();

                    worker = new Thread(() =>
                    {
                        int raidCount = 0;

                        while (buttonStart.Text == "Stop")
                        {
                            if (raidCount < _interval)
                            {
                                if (travian.StartRaid())
                                {
                                    Bot.Log("Sending raid...", Color.Black);
                                }
                                else
                                {
                                    Bot.Log("Error: Raid couldn't started.", Color.Black);
                                }
                                raidCount++;
                                Thread.Sleep(10000);
                            }
                            else
                            {
                                Bot.Log("Training troops", Color.Black);
                                if (travian.TrainTroops(barracksId))
                                    Bot.Log("Raid next.", Color.Black);
                                raidCount = 0;
                            }

                        }
                    });
                    worker.Start();
                }
                else
                {
                    Bot.Log("First login!", Color.DarkRed);
                }
            }
            if (threadLogin != null) 
                threadLogin.Abort();
        }

        private void ButtonBuild_Click(object sender, EventArgs e)
        {
            if (_login)
            {
                switch (buttonBuild.Text)
                {
                    case "Start Building":
                    {
                        if (threadBuild != null)
                            if (threadBuild.IsAlive)
                                threadBuild.Abort();

                        travian.cts = new CancellationTokenSource();
                        buttonBuild.Text = "Stop Building";
                        threadBuild = new Thread(() =>
                        {
                            if (travian.BuildBuildings())
                            {
                                Bot.Log("Started building.", Color.Black);
                            }
                        });
                        threadBuild.Start();
                        break;
                    }
                    case "Stop Building":
                    {
                        buttonBuild.Text = "Start Building";
                        travian.cts.Cancel();

                        if (threadBuild != null)
                            if (threadBuild.IsAlive)
                                threadBuild.Abort();
                        break;
                    }
                }
            }
            else
            {
                Bot.Log("First login!", Color.Red);
            }
        }

        private void RichTextBoxLog_TextChanged(object sender, EventArgs e)
        {
            // change this with append text
            richTextBoxLog.ScrollToCaret();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveUserSettings();
            threadLogin?.Abort();
            worker?.Abort();
            timer?.Abort();
            threadBuild?.Abort();
        }

        private void TravianMap_Click(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            var X = Cursor.Position.X;
            var Y = Cursor.Position.Y;

            foreach (var rf in ResourceFields)
            {
                if ((X > rf.Rectangle.X - rf.Rectangle.Width / 2) && (X < rf.Rectangle.X + rf.Rectangle.Width / 2) &&
                    (Y > rf.Rectangle.Y - rf.Rectangle.Height / 2) && (Y < rf.Rectangle.Y + rf.Rectangle.Height / 2))
                {
                    ListViewItem item;
                    List<ResourceField> list = new List<ResourceField>();

                    Int32.TryParse(textBox9.Text, out int level);

                    var bq = new BuildQueue(rf.Id, level, 0);

                    item = new ListViewItem(rf.Id.ToString());
                    item.SubItems.Add(rf.Type);

                    if (textBox9.Text == "" || textBox9.Text.Equals(string.Empty))
                        item.SubItems.Add("20");
                    else
                        item.SubItems.Add(textBox9.Text);

                    item.SubItems.Add("00:00:00");
                    listView1.Items.Add(item);
                    Bot.Log("Adding to queue. Type: " + rf.Type, Color.DarkCyan);
                    Info.Queue.Add(bq);
                }
            }
        }

        private void ButtonRemoveBuilding_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                foreach (var item in listView1.Items)
                {
                    listView1.Items.Remove((ListViewItem)item);
                }
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

        }

        private void ButtonResetCert_Click(object sender, EventArgs e)
        {
            if (CertMaker.removeFiddlerGeneratedCerts(true))
            {
                MessageBox.Show("All Certificates have been removed!\nPlease restart the Bot, for the changes to take affect!", "Unistalled Certificate.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Bot.Log("Uninstalled Fiddler certificates.", Color.Black);
            }
            else
            {
                Bot.Log("Couldn't remove certificates.", Color.Black);
            }
        }

        private void ButtonCreateFarmlist_Click(object sender, EventArgs e)
        {
            if (_login)
            {
                int.TryParse(textBoxFarmlistOpt.Text, out var amount);
                if (textBoxFarmlistOpt.Text == string.Empty || amount < 1)
                {
                    TroopInfo.Amount = "1";
                    Bot.Log("Adding troops with default value: 1.", Color.Red);
                }
                else
                {
                    TroopInfo.Amount = textBoxFarmlistOpt.Text;
                }
                worker = new Thread(() =>
                {
                    Bot.Log(travian.CreateFarmlist() ? "Farmlist created successfully" : "Couldn't create farmlist",
                        Color.Black);
                });
                worker.Start();
            }
            else
            {
                Bot.Log("First login!", Color.Red);
            }
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            if (_login)
            {
                if (worker != null)
                    if (worker.IsAlive)
                    {
                        worker.Abort();
                        worker.Join();
                    }

                worker = new Thread(() =>
                {
                    var repeatCounter = 0;
                    Info.AttackUnits = new List<string>()
                    {
                        textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                        textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text
                    };

                    while (repeatCounter < numericRepeat.Value)
                    {
                        travian.AttackPlayer(textBoxX.Text, textBoxY.Text);
                        repeatCounter++;
                    }
                    Bot.Log("Attacks done!", Color.Black);
                });
                worker.Start();
            }
            else
            {
                Bot.Log("First login!", Color.Red);
            }
        }



        public void Log(string message, Color color)
        {
            var dt = DateTime.Now;
            string time = "[" + dt.ToString("HH:mm:ss") + "]: ";
            richTextBoxLog.AppendText(time + message + System.Environment.NewLine, color);
        }
    }
}
