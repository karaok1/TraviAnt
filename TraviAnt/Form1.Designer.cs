using MetroFramework.Controls;

namespace TraviAnt
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxCreateFarmlist = new System.Windows.Forms.GroupBox();
            this.textBoxFarmlistOpt = new System.Windows.Forms.TextBox();
            this.labeltrainTroopType = new System.Windows.Forms.Label();
            this.comboBoxFarmlist = new System.Windows.Forms.ComboBox();
            this.labelFarmlistOpt = new System.Windows.Forms.Label();
            this.buttonCreateFarmlist = new System.Windows.Forms.Button();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonResetCert = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelServer = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.tabPageMain = new MetroFramework.Controls.MetroTabPage();
            this.groupBoxPreferences = new System.Windows.Forms.GroupBox();
            this.checkBoxNpc = new System.Windows.Forms.CheckBox();
            this.checkBoxExcludeList = new System.Windows.Forms.CheckBox();
            this.checkBoxBuyResources = new System.Windows.Forms.CheckBox();
            this.checkBoxBuyAnimals = new System.Windows.Forms.CheckBox();
            this.groupBoxTrain = new System.Windows.Forms.GroupBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.comboBoxTroop = new System.Windows.Forms.ComboBox();
            this.textBoxTrainInterval = new System.Windows.Forms.TextBox();
            this.labelTrainTroops = new System.Windows.Forms.Label();
            this.labelTrainInterval = new System.Windows.Forms.Label();
            this.groupBoxAttackOptions = new System.Windows.Forms.GroupBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelRepeatAttacks = new System.Windows.Forms.Label();
            this.attackButton = new System.Windows.Forms.Button();
            this.numericRepeat = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBoxSendHero = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelCatapult = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelRam = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelTeutonicKnight = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.labelPaladin = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.labelScout = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.labelAxeman = new System.Windows.Forms.Label();
            this.labelClubswinger = new System.Windows.Forms.Label();
            this.labelSpearman = new System.Windows.Forms.Label();
            this.tabPageSettings = new MetroFramework.Controls.MetroTabPage();
            this.groupBoxBuildingOpt = new System.Windows.Forms.GroupBox();
            this.buttonResetBuildList = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRemoveBuilding = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.groupBoxBuild = new System.Windows.Forms.GroupBox();
            this.travianMap = new System.Windows.Forms.PictureBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.pictureBoxTravian = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxCreateFarmlist.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.groupBoxPreferences.SuspendLayout();
            this.groupBoxTrain.SuspendLayout();
            this.groupBoxAttackOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepeat)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.groupBoxBuildingOpt.SuspendLayout();
            this.groupBoxBuild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.travianMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTravian)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLogin);
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(758, 374);
            this.tabControl.TabIndex = 0;
            this.tabControl.UseSelectable = true;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.Controls.Add(this.groupBox1);
            this.tabPageLogin.Controls.Add(this.groupBoxLogin);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 38);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(750, 332);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Login";
            this.tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxCreateFarmlist);
            this.groupBox1.Location = new System.Drawing.Point(328, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 346);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bot options";
            // 
            // groupBoxCreateFarmlist
            // 
            this.groupBoxCreateFarmlist.Controls.Add(this.textBoxFarmlistOpt);
            this.groupBoxCreateFarmlist.Controls.Add(this.labeltrainTroopType);
            this.groupBoxCreateFarmlist.Controls.Add(this.comboBoxFarmlist);
            this.groupBoxCreateFarmlist.Controls.Add(this.labelFarmlistOpt);
            this.groupBoxCreateFarmlist.Controls.Add(this.buttonCreateFarmlist);
            this.groupBoxCreateFarmlist.Location = new System.Drawing.Point(27, 19);
            this.groupBoxCreateFarmlist.Name = "groupBoxCreateFarmlist";
            this.groupBoxCreateFarmlist.Size = new System.Drawing.Size(387, 317);
            this.groupBoxCreateFarmlist.TabIndex = 32;
            this.groupBoxCreateFarmlist.TabStop = false;
            this.groupBoxCreateFarmlist.Text = "Farmlist Options";
            // 
            // textBoxFarmlistOpt
            // 
            this.textBoxFarmlistOpt.Location = new System.Drawing.Point(107, 86);
            this.textBoxFarmlistOpt.Name = "textBoxFarmlistOpt";
            this.textBoxFarmlistOpt.Size = new System.Drawing.Size(150, 20);
            this.textBoxFarmlistOpt.TabIndex = 30;
            // 
            // labeltrainTroopType
            // 
            this.labeltrainTroopType.AutoSize = true;
            this.labeltrainTroopType.Location = new System.Drawing.Point(20, 53);
            this.labeltrainTroopType.Name = "labeltrainTroopType";
            this.labeltrainTroopType.Size = new System.Drawing.Size(61, 13);
            this.labeltrainTroopType.TabIndex = 34;
            this.labeltrainTroopType.Text = "Troop type:";
            // 
            // comboBoxFarmlist
            // 
            this.comboBoxFarmlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFarmlist.FormattingEnabled = true;
            this.comboBoxFarmlist.Items.AddRange(new object[] {
            "Maceman",
            "Spearman",
            "Axeman",
            "Scout"});
            this.comboBoxFarmlist.Location = new System.Drawing.Point(107, 45);
            this.comboBoxFarmlist.Name = "comboBoxFarmlist";
            this.comboBoxFarmlist.Size = new System.Drawing.Size(150, 21);
            this.comboBoxFarmlist.TabIndex = 33;
            // 
            // labelFarmlistOpt
            // 
            this.labelFarmlistOpt.AutoSize = true;
            this.labelFarmlistOpt.Location = new System.Drawing.Point(20, 86);
            this.labelFarmlistOpt.Name = "labelFarmlistOpt";
            this.labelFarmlistOpt.Size = new System.Drawing.Size(81, 13);
            this.labelFarmlistOpt.TabIndex = 31;
            this.labelFarmlistOpt.Text = "Troops amount:";
            // 
            // buttonCreateFarmlist
            // 
            this.buttonCreateFarmlist.Location = new System.Drawing.Point(23, 121);
            this.buttonCreateFarmlist.Name = "buttonCreateFarmlist";
            this.buttonCreateFarmlist.Size = new System.Drawing.Size(234, 30);
            this.buttonCreateFarmlist.TabIndex = 29;
            this.buttonCreateFarmlist.Text = "Create Farmlist";
            this.buttonCreateFarmlist.UseVisualStyleBackColor = true;
            this.buttonCreateFarmlist.Click += new System.EventHandler(this.ButtonCreateFarmlist_Click);
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Controls.Add(this.textBoxName);
            this.groupBoxLogin.Controls.Add(this.buttonStart);
            this.groupBoxLogin.Controls.Add(this.buttonResetCert);
            this.groupBoxLogin.Controls.Add(this.labelUsername);
            this.groupBoxLogin.Controls.Add(this.labelPassword);
            this.groupBoxLogin.Controls.Add(this.textBoxPassword);
            this.groupBoxLogin.Controls.Add(this.buttonLogin);
            this.groupBoxLogin.Controls.Add(this.labelServer);
            this.groupBoxLogin.Controls.Add(this.textBoxServer);
            this.groupBoxLogin.Location = new System.Drawing.Point(8, 6);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(314, 346);
            this.groupBoxLogin.TabIndex = 16;
            this.groupBoxLogin.TabStop = false;
            this.groupBoxLogin.Text = "Login settings";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(96, 40);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(155, 20);
            this.textBoxName.TabIndex = 8;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(29, 200);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(222, 35);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // buttonResetCert
            // 
            this.buttonResetCert.Location = new System.Drawing.Point(29, 137);
            this.buttonResetCert.Name = "buttonResetCert";
            this.buttonResetCert.Size = new System.Drawing.Size(96, 27);
            this.buttonResetCert.TabIndex = 15;
            this.buttonResetCert.Text = "Reset Certificate";
            this.buttonResetCert.UseVisualStyleBackColor = true;
            this.buttonResetCert.Click += new System.EventHandler(this.ButtonResetCert_Click);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(26, 47);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(58, 13);
            this.labelUsername.TabIndex = 6;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(26, 72);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(96, 69);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(155, 20);
            this.textBoxPassword.TabIndex = 9;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(139, 137);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(112, 27);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(26, 101);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(64, 13);
            this.labelServer.TabIndex = 12;
            this.labelServer.Text = "Server host:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(96, 98);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(155, 20);
            this.textBoxServer.TabIndex = 11;
            this.textBoxServer.Text = "unl.ttwars.com";
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.groupBoxPreferences);
            this.tabPageMain.Controls.Add(this.groupBoxTrain);
            this.tabPageMain.Controls.Add(this.groupBoxAttackOptions);
            this.tabPageMain.HorizontalScrollbarBarColor = true;
            this.tabPageMain.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageMain.HorizontalScrollbarSize = 10;
            this.tabPageMain.Location = new System.Drawing.Point(4, 38);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(750, 332);
            this.tabPageMain.TabIndex = 1;
            this.tabPageMain.Text = "Options";
            this.tabPageMain.UseVisualStyleBackColor = true;
            this.tabPageMain.VerticalScrollbarBarColor = true;
            this.tabPageMain.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageMain.VerticalScrollbarSize = 10;
            // 
            // groupBoxPreferences
            // 
            this.groupBoxPreferences.Controls.Add(this.checkBoxNpc);
            this.groupBoxPreferences.Controls.Add(this.checkBoxExcludeList);
            this.groupBoxPreferences.Controls.Add(this.checkBoxBuyResources);
            this.groupBoxPreferences.Controls.Add(this.checkBoxBuyAnimals);
            this.groupBoxPreferences.Location = new System.Drawing.Point(245, 6);
            this.groupBoxPreferences.Name = "groupBoxPreferences";
            this.groupBoxPreferences.Size = new System.Drawing.Size(497, 117);
            this.groupBoxPreferences.TabIndex = 32;
            this.groupBoxPreferences.TabStop = false;
            this.groupBoxPreferences.Text = "Preferences";
            // 
            // checkBoxNpc
            // 
            this.checkBoxNpc.AutoSize = true;
            this.checkBoxNpc.Location = new System.Drawing.Point(254, 37);
            this.checkBoxNpc.Name = "checkBoxNpc";
            this.checkBoxNpc.Size = new System.Drawing.Size(48, 17);
            this.checkBoxNpc.TabIndex = 32;
            this.checkBoxNpc.Text = "NPC";
            this.checkBoxNpc.UseVisualStyleBackColor = true;
            // 
            // checkBoxExcludeList
            // 
            this.checkBoxExcludeList.AutoSize = true;
            this.checkBoxExcludeList.Location = new System.Drawing.Point(25, 37);
            this.checkBoxExcludeList.Name = "checkBoxExcludeList";
            this.checkBoxExcludeList.Size = new System.Drawing.Size(118, 17);
            this.checkBoxExcludeList.TabIndex = 29;
            this.checkBoxExcludeList.Text = "Exclude last raid list";
            this.checkBoxExcludeList.UseVisualStyleBackColor = true;
            // 
            // checkBoxBuyResources
            // 
            this.checkBoxBuyResources.AutoSize = true;
            this.checkBoxBuyResources.Location = new System.Drawing.Point(25, 80);
            this.checkBoxBuyResources.Name = "checkBoxBuyResources";
            this.checkBoxBuyResources.Size = new System.Drawing.Size(170, 17);
            this.checkBoxBuyResources.TabIndex = 31;
            this.checkBoxBuyResources.Text = "Buy resources every 6 minutes";
            this.checkBoxBuyResources.UseVisualStyleBackColor = true;
            // 
            // checkBoxBuyAnimals
            // 
            this.checkBoxBuyAnimals.AutoSize = true;
            this.checkBoxBuyAnimals.Location = new System.Drawing.Point(25, 60);
            this.checkBoxBuyAnimals.Name = "checkBoxBuyAnimals";
            this.checkBoxBuyAnimals.Size = new System.Drawing.Size(165, 17);
            this.checkBoxBuyAnimals.TabIndex = 30;
            this.checkBoxBuyAnimals.Text = "Buy animals every 12 minutes";
            this.checkBoxBuyAnimals.UseVisualStyleBackColor = true;
            // 
            // groupBoxTrain
            // 
            this.groupBoxTrain.Controls.Add(this.labelInfo);
            this.groupBoxTrain.Controls.Add(this.comboBoxTroop);
            this.groupBoxTrain.Controls.Add(this.textBoxTrainInterval);
            this.groupBoxTrain.Controls.Add(this.labelTrainTroops);
            this.groupBoxTrain.Controls.Add(this.labelTrainInterval);
            this.groupBoxTrain.Location = new System.Drawing.Point(245, 123);
            this.groupBoxTrain.Name = "groupBoxTrain";
            this.groupBoxTrain.Size = new System.Drawing.Size(497, 206);
            this.groupBoxTrain.TabIndex = 27;
            this.groupBoxTrain.TabStop = false;
            this.groupBoxTrain.Text = "Training options";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(24, 141);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(190, 13);
            this.labelInfo.TabIndex = 27;
            this.labelInfo.Text = "(Train troops after this amount of raids.)";
            // 
            // comboBoxTroop
            // 
            this.comboBoxTroop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTroop.FormattingEnabled = true;
            this.comboBoxTroop.Items.AddRange(new object[] {
            "Maceman",
            "Spearman",
            "Axeman",
            "Scout"});
            this.comboBoxTroop.Location = new System.Drawing.Point(96, 60);
            this.comboBoxTroop.Name = "comboBoxTroop";
            this.comboBoxTroop.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTroop.TabIndex = 23;
            // 
            // textBoxTrainInterval
            // 
            this.textBoxTrainInterval.Location = new System.Drawing.Point(117, 105);
            this.textBoxTrainInterval.Name = "textBoxTrainInterval";
            this.textBoxTrainInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxTrainInterval.TabIndex = 26;
            // 
            // labelTrainTroops
            // 
            this.labelTrainTroops.AutoSize = true;
            this.labelTrainTroops.Location = new System.Drawing.Point(24, 62);
            this.labelTrainTroops.Name = "labelTrainTroops";
            this.labelTrainTroops.Size = new System.Drawing.Size(66, 13);
            this.labelTrainTroops.TabIndex = 24;
            this.labelTrainTroops.Text = "Train troops:";
            // 
            // labelTrainInterval
            // 
            this.labelTrainInterval.AutoSize = true;
            this.labelTrainInterval.Location = new System.Drawing.Point(24, 108);
            this.labelTrainInterval.Name = "labelTrainInterval";
            this.labelTrainInterval.Size = new System.Drawing.Size(71, 13);
            this.labelTrainInterval.TabIndex = 25;
            this.labelTrainInterval.Text = "Train interval:";
            // 
            // groupBoxAttackOptions
            // 
            this.groupBoxAttackOptions.Controls.Add(this.textBoxY);
            this.groupBoxAttackOptions.Controls.Add(this.labelY);
            this.groupBoxAttackOptions.Controls.Add(this.textBoxX);
            this.groupBoxAttackOptions.Controls.Add(this.labelX);
            this.groupBoxAttackOptions.Controls.Add(this.textBox1);
            this.groupBoxAttackOptions.Controls.Add(this.labelRepeatAttacks);
            this.groupBoxAttackOptions.Controls.Add(this.attackButton);
            this.groupBoxAttackOptions.Controls.Add(this.numericRepeat);
            this.groupBoxAttackOptions.Controls.Add(this.textBox2);
            this.groupBoxAttackOptions.Controls.Add(this.checkBoxSendHero);
            this.groupBoxAttackOptions.Controls.Add(this.textBox3);
            this.groupBoxAttackOptions.Controls.Add(this.labelCatapult);
            this.groupBoxAttackOptions.Controls.Add(this.textBox4);
            this.groupBoxAttackOptions.Controls.Add(this.labelRam);
            this.groupBoxAttackOptions.Controls.Add(this.textBox5);
            this.groupBoxAttackOptions.Controls.Add(this.labelTeutonicKnight);
            this.groupBoxAttackOptions.Controls.Add(this.textBox6);
            this.groupBoxAttackOptions.Controls.Add(this.labelPaladin);
            this.groupBoxAttackOptions.Controls.Add(this.textBox7);
            this.groupBoxAttackOptions.Controls.Add(this.labelScout);
            this.groupBoxAttackOptions.Controls.Add(this.textBox8);
            this.groupBoxAttackOptions.Controls.Add(this.labelAxeman);
            this.groupBoxAttackOptions.Controls.Add(this.labelClubswinger);
            this.groupBoxAttackOptions.Controls.Add(this.labelSpearman);
            this.groupBoxAttackOptions.Location = new System.Drawing.Point(8, 6);
            this.groupBoxAttackOptions.Name = "groupBoxAttackOptions";
            this.groupBoxAttackOptions.Size = new System.Drawing.Size(231, 323);
            this.groupBoxAttackOptions.TabIndex = 22;
            this.groupBoxAttackOptions.TabStop = false;
            this.groupBoxAttackOptions.Text = "Attack options";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(163, 19);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(28, 20);
            this.textBoxY.TabIndex = 24;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(140, 22);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 13);
            this.labelY.TabIndex = 25;
            this.labelY.Text = "Y:";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(94, 19);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(28, 20);
            this.textBoxX.TabIndex = 22;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(71, 22);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 13);
            this.labelX.TabIndex = 23;
            this.labelX.Text = "X:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // labelRepeatAttacks
            // 
            this.labelRepeatAttacks.AutoSize = true;
            this.labelRepeatAttacks.Location = new System.Drawing.Point(14, 263);
            this.labelRepeatAttacks.Name = "labelRepeatAttacks";
            this.labelRepeatAttacks.Size = new System.Drawing.Size(45, 13);
            this.labelRepeatAttacks.TabIndex = 21;
            this.labelRepeatAttacks.Text = "Repeat:";
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(17, 282);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(177, 33);
            this.attackButton.TabIndex = 2;
            this.attackButton.Text = "Attack";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // numericRepeat
            // 
            this.numericRepeat.Location = new System.Drawing.Point(94, 256);
            this.numericRepeat.Name = "numericRepeat";
            this.numericRepeat.Size = new System.Drawing.Size(47, 20);
            this.numericRepeat.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // checkBoxSendHero
            // 
            this.checkBoxSendHero.AutoSize = true;
            this.checkBoxSendHero.Location = new System.Drawing.Point(145, 257);
            this.checkBoxSendHero.Name = "checkBoxSendHero";
            this.checkBoxSendHero.Size = new System.Drawing.Size(49, 17);
            this.checkBoxSendHero.TabIndex = 19;
            this.checkBoxSendHero.Text = "Hero";
            this.checkBoxSendHero.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 98);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // labelCatapult
            // 
            this.labelCatapult.AutoSize = true;
            this.labelCatapult.Location = new System.Drawing.Point(14, 236);
            this.labelCatapult.Name = "labelCatapult";
            this.labelCatapult.Size = new System.Drawing.Size(49, 13);
            this.labelCatapult.TabIndex = 18;
            this.labelCatapult.Text = "Catapult:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(94, 124);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 6;
            // 
            // labelRam
            // 
            this.labelRam.AutoSize = true;
            this.labelRam.Location = new System.Drawing.Point(14, 210);
            this.labelRam.Name = "labelRam";
            this.labelRam.Size = new System.Drawing.Size(32, 13);
            this.labelRam.TabIndex = 17;
            this.labelRam.Text = "Ram:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(94, 150);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 7;
            // 
            // labelTeutonicKnight
            // 
            this.labelTeutonicKnight.AutoSize = true;
            this.labelTeutonicKnight.Location = new System.Drawing.Point(14, 184);
            this.labelTeutonicKnight.Name = "labelTeutonicKnight";
            this.labelTeutonicKnight.Size = new System.Drawing.Size(44, 13);
            this.labelTeutonicKnight.TabIndex = 16;
            this.labelTeutonicKnight.Text = "Teuton:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(94, 176);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 8;
            // 
            // labelPaladin
            // 
            this.labelPaladin.AutoSize = true;
            this.labelPaladin.Location = new System.Drawing.Point(14, 158);
            this.labelPaladin.Name = "labelPaladin";
            this.labelPaladin.Size = new System.Drawing.Size(45, 13);
            this.labelPaladin.TabIndex = 15;
            this.labelPaladin.Text = "Paladin:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(94, 202);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 20);
            this.textBox7.TabIndex = 9;
            // 
            // labelScout
            // 
            this.labelScout.AutoSize = true;
            this.labelScout.Location = new System.Drawing.Point(14, 132);
            this.labelScout.Name = "labelScout";
            this.labelScout.Size = new System.Drawing.Size(38, 13);
            this.labelScout.TabIndex = 14;
            this.labelScout.Text = "Scout:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(94, 228);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 20);
            this.textBox8.TabIndex = 10;
            // 
            // labelAxeman
            // 
            this.labelAxeman.AutoSize = true;
            this.labelAxeman.Location = new System.Drawing.Point(14, 106);
            this.labelAxeman.Name = "labelAxeman";
            this.labelAxeman.Size = new System.Drawing.Size(48, 13);
            this.labelAxeman.TabIndex = 13;
            this.labelAxeman.Text = "Axeman:";
            // 
            // labelClubswinger
            // 
            this.labelClubswinger.AutoSize = true;
            this.labelClubswinger.Location = new System.Drawing.Point(14, 53);
            this.labelClubswinger.Name = "labelClubswinger";
            this.labelClubswinger.Size = new System.Drawing.Size(69, 13);
            this.labelClubswinger.TabIndex = 11;
            this.labelClubswinger.Text = "Clubswıinger:";
            // 
            // labelSpearman
            // 
            this.labelSpearman.AutoSize = true;
            this.labelSpearman.Location = new System.Drawing.Point(14, 80);
            this.labelSpearman.Name = "labelSpearman";
            this.labelSpearman.Size = new System.Drawing.Size(58, 13);
            this.labelSpearman.TabIndex = 12;
            this.labelSpearman.Text = "Spearman:";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.groupBoxBuildingOpt);
            this.tabPageSettings.Controls.Add(this.groupBoxBuild);
            this.tabPageSettings.HorizontalScrollbarBarColor = true;
            this.tabPageSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageSettings.HorizontalScrollbarSize = 10;
            this.tabPageSettings.Location = new System.Drawing.Point(4, 38);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(750, 332);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Building";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            this.tabPageSettings.VerticalScrollbarBarColor = true;
            this.tabPageSettings.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageSettings.VerticalScrollbarSize = 10;
            // 
            // groupBoxBuildingOpt
            // 
            this.groupBoxBuildingOpt.Controls.Add(this.buttonResetBuildList);
            this.groupBoxBuildingOpt.Controls.Add(this.listView1);
            this.groupBoxBuildingOpt.Controls.Add(this.buttonRemoveBuilding);
            this.groupBoxBuildingOpt.Controls.Add(this.label1);
            this.groupBoxBuildingOpt.Controls.Add(this.textBox9);
            this.groupBoxBuildingOpt.Controls.Add(this.buttonBuild);
            this.groupBoxBuildingOpt.Location = new System.Drawing.Point(475, 7);
            this.groupBoxBuildingOpt.Name = "groupBoxBuildingOpt";
            this.groupBoxBuildingOpt.Size = new System.Drawing.Size(267, 328);
            this.groupBoxBuildingOpt.TabIndex = 32;
            this.groupBoxBuildingOpt.TabStop = false;
            this.groupBoxBuildingOpt.Text = "Building options";
            // 
            // buttonResetBuildList
            // 
            this.buttonResetBuildList.Location = new System.Drawing.Point(150, 289);
            this.buttonResetBuildList.Name = "buttonResetBuildList";
            this.buttonResetBuildList.Size = new System.Drawing.Size(111, 32);
            this.buttonResetBuildList.TabIndex = 35;
            this.buttonResetBuildList.Text = "Reset";
            this.buttonResetBuildList.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderType,
            this.columnHeaderLevel});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(18, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(243, 238);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            this.columnHeaderId.Width = 70;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 80;
            // 
            // columnHeaderLevel
            // 
            this.columnHeaderLevel.Text = "Level";
            this.columnHeaderLevel.Width = 80;
            // 
            // buttonRemoveBuilding
            // 
            this.buttonRemoveBuilding.Location = new System.Drawing.Point(150, 260);
            this.buttonRemoveBuilding.Name = "buttonRemoveBuilding";
            this.buttonRemoveBuilding.Size = new System.Drawing.Size(111, 23);
            this.buttonRemoveBuilding.TabIndex = 34;
            this.buttonRemoveBuilding.Text = "Remove";
            this.buttonRemoveBuilding.UseVisualStyleBackColor = true;
            this.buttonRemoveBuilding.Click += new System.EventHandler(this.ButtonRemoveBuilding_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "To level:";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(69, 262);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(75, 20);
            this.textBox9.TabIndex = 31;
            this.textBox9.Text = "20";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(6, 288);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(138, 33);
            this.buttonBuild.TabIndex = 30;
            this.buttonBuild.Text = "Start Building";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.ButtonBuild_Click);
            // 
            // groupBoxBuild
            // 
            this.groupBoxBuild.Controls.Add(this.travianMap);
            this.groupBoxBuild.Location = new System.Drawing.Point(9, 7);
            this.groupBoxBuild.Name = "groupBoxBuild";
            this.groupBoxBuild.Size = new System.Drawing.Size(460, 335);
            this.groupBoxBuild.TabIndex = 31;
            this.groupBoxBuild.TabStop = false;
            this.groupBoxBuild.Text = "Building view";
            // 
            // travianMap
            // 
            this.travianMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.travianMap.Image = global::TraviAnt.Properties.Resources.travmap;
            this.travianMap.Location = new System.Drawing.Point(3, 16);
            this.travianMap.Name = "travianMap";
            this.travianMap.Size = new System.Drawing.Size(454, 316);
            this.travianMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.travianMap.TabIndex = 0;
            this.travianMap.TabStop = false;
            this.travianMap.Click += new System.EventHandler(this.TravianMap_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 380);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(758, 160);
            this.richTextBoxLog.TabIndex = 10;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.TextChanged += new System.EventHandler(this.RichTextBoxLog_TextChanged);
            // 
            // pictureBoxTravian
            // 
            this.pictureBoxTravian.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTravian.Name = "pictureBoxTravian";
            this.pictureBoxTravian.Size = new System.Drawing.Size(433, 309);
            this.pictureBoxTravian.TabIndex = 0;
            this.pictureBoxTravian.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 540);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TraviAnt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxCreateFarmlist.ResumeLayout(false);
            this.groupBoxCreateFarmlist.PerformLayout();
            this.groupBoxLogin.ResumeLayout(false);
            this.groupBoxLogin.PerformLayout();
            this.tabPageMain.ResumeLayout(false);
            this.groupBoxPreferences.ResumeLayout(false);
            this.groupBoxPreferences.PerformLayout();
            this.groupBoxTrain.ResumeLayout(false);
            this.groupBoxTrain.PerformLayout();
            this.groupBoxAttackOptions.ResumeLayout(false);
            this.groupBoxAttackOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepeat)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.groupBoxBuildingOpt.ResumeLayout(false);
            this.groupBoxBuildingOpt.PerformLayout();
            this.groupBoxBuild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.travianMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTravian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonStart;
        public System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.GroupBox groupBoxTrain;
        private System.Windows.Forms.ComboBox comboBoxTroop;
        private System.Windows.Forms.TextBox textBoxTrainInterval;
        private System.Windows.Forms.Label labelTrainTroops;
        private System.Windows.Forms.Label labelTrainInterval;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.CheckBox checkBoxExcludeList;
        private System.Windows.Forms.CheckBox checkBoxBuyResources;
        private System.Windows.Forms.CheckBox checkBoxBuyAnimals;
        private System.Windows.Forms.Button buttonResetCert;
        private System.Windows.Forms.GroupBox groupBoxPreferences;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxCreateFarmlist;
        private System.Windows.Forms.TextBox textBoxFarmlistOpt;
        private System.Windows.Forms.Label labeltrainTroopType;
        private System.Windows.Forms.ComboBox comboBoxFarmlist;
        private System.Windows.Forms.Label labelFarmlistOpt;
        private System.Windows.Forms.Button buttonCreateFarmlist;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.GroupBox groupBoxAttackOptions;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelRepeatAttacks;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.NumericUpDown numericRepeat;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBoxSendHero;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label labelCatapult;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelRam;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelTeutonicKnight;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label labelPaladin;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label labelScout;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label labelAxeman;
        private System.Windows.Forms.Label labelClubswinger;
        private System.Windows.Forms.Label labelSpearman;
        private System.Windows.Forms.GroupBox groupBoxBuild;
        private System.Windows.Forms.PictureBox travianMap;
        private System.Windows.Forms.GroupBox groupBoxBuildingOpt;
        private System.Windows.Forms.Button buttonRemoveBuilding;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.PictureBox pictureBoxTravian;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderLevel;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.Button buttonResetBuildList;
        private System.Windows.Forms.CheckBox checkBoxNpc;
        private MetroTabControl tabControl;
        private MetroTabPage tabPageMain;
        private MetroTabPage tabPageSettings;
    }
}

