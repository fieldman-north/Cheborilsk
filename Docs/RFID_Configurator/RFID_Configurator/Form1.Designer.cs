namespace Device_Configurator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.port1 = new System.IO.Ports.SerialPort(this.components);
            this.lbBR = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.rbEMDB = new System.Windows.Forms.RadioButton();
            this.adrNumer = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rbEth = new System.Windows.Forms.RadioButton();
            this.btnChkDev = new System.Windows.Forms.Button();
            this.rbMDB = new System.Windows.Forms.RadioButton();
            this.rbUART = new System.Windows.Forms.RadioButton();
            this.gbAllControls = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbCurr = new System.Windows.Forms.Label();
            this.lbVolt = new System.Windows.Forms.Label();
            this.tbCurr = new System.Windows.Forms.TextBox();
            this.tbVoltage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbMask = new System.Windows.Forms.TextBox();
            this.cbDevBoud = new System.Windows.Forms.ComboBox();
            this.cbGrnLed = new System.Windows.Forms.CheckBox();
            this.lbStatID = new System.Windows.Forms.Label();
            this.tbDevText = new System.Windows.Forms.TextBox();
            this.lbStr8 = new System.Windows.Forms.Label();
            this.tbStr0 = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.lbStr0 = new System.Windows.Forms.Label();
            this.cbRelay = new System.Windows.Forms.CheckBox();
            this.cbBlLed = new System.Windows.Forms.CheckBox();
            this.cbRedLed = new System.Windows.Forms.CheckBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.lbStr7 = new System.Windows.Forms.Label();
            this.lbStr6 = new System.Windows.Forms.Label();
            this.lbStr5 = new System.Windows.Forms.Label();
            this.lbStr4 = new System.Windows.Forms.Label();
            this.lbStr3 = new System.Windows.Forms.Label();
            this.lbStr2 = new System.Windows.Forms.Label();
            this.lbStr1 = new System.Windows.Forms.Label();
            this.lbType = new System.Windows.Forms.Label();
            this.numericRfidPoolTime = new System.Windows.Forms.NumericUpDown();
            this.numericLedActTime = new System.Windows.Forms.NumericUpDown();
            this.numericOutTime = new System.Windows.Forms.NumericUpDown();
            this.cbStr4 = new System.Windows.Forms.ComboBox();
            this.cbDevMode = new System.Windows.Forms.ComboBox();
            this.numericDevAdr = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbUncnown = new System.Windows.Forms.GroupBox();
            this.tbUnStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUnDevInfo = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.debugPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adrNumer)).BeginInit();
            this.gbAllControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRfidPoolTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLedActTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDevAdr)).BeginInit();
            this.gbUncnown.SuspendLayout();
            this.SuspendLayout();
            // 
            // port1
            // 
            this.port1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // lbBR
            // 
            this.lbBR.AutoSize = true;
            this.lbBR.Location = new System.Drawing.Point(81, 154);
            this.lbBR.Name = "lbBR";
            this.lbBR.Size = new System.Drawing.Size(0, 13);
            this.lbBR.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Порт";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(6, 110);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(127, 25);
            this.pbStatus.TabIndex = 12;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(41, 114);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(55, 13);
            this.lbStatus.TabIndex = 11;
            this.lbStatus.Text = "BoudRate";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(69, 154);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(58, 21);
            this.cbPort.TabIndex = 5;
            this.cbPort.Click += new System.EventHandler(this.cbPort_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbStatus);
            this.groupBox1.Controls.Add(this.rbEMDB);
            this.groupBox1.Controls.Add(this.adrNumer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pbStatus);
            this.groupBox1.Controls.Add(this.rbEth);
            this.groupBox1.Controls.Add(this.btnChkDev);
            this.groupBox1.Controls.Add(this.rbMDB);
            this.groupBox1.Controls.Add(this.cbPort);
            this.groupBox1.Controls.Add(this.rbUART);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 325);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Подключение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Статусная информация";
            // 
            // tbStatus
            // 
            this.tbStatus.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbStatus.Location = new System.Drawing.Point(2, 199);
            this.tbStatus.MaxLength = 31;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ReadOnly = true;
            this.tbStatus.Size = new System.Drawing.Size(135, 20);
            this.tbStatus.TabIndex = 76;
            // 
            // rbEMDB
            // 
            this.rbEMDB.AutoSize = true;
            this.rbEMDB.Location = new System.Drawing.Point(7, 60);
            this.rbEMDB.Name = "rbEMDB";
            this.rbEMDB.Size = new System.Drawing.Size(115, 17);
            this.rbEMDB.TabIndex = 2;
            this.rbEMDB.Text = "Ethernet-MODBUS";
            this.rbEMDB.UseVisualStyleBackColor = true;
            // 
            // adrNumer
            // 
            this.adrNumer.Location = new System.Drawing.Point(16, 155);
            this.adrNumer.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.adrNumer.Name = "adrNumer";
            this.adrNumer.Size = new System.Drawing.Size(53, 20);
            this.adrNumer.TabIndex = 4;
            this.adrNumer.ValueChanged += new System.EventHandler(this.adrNumer_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Адрес";
            // 
            // rbEth
            // 
            this.rbEth.AutoSize = true;
            this.rbEth.Location = new System.Drawing.Point(7, 40);
            this.rbEth.Name = "rbEth";
            this.rbEth.Size = new System.Drawing.Size(98, 17);
            this.rbEth.TabIndex = 1;
            this.rbEth.Text = "Ethernet-UART";
            this.rbEth.UseVisualStyleBackColor = true;
            // 
            // btnChkDev
            // 
            this.btnChkDev.Location = new System.Drawing.Point(19, 294);
            this.btnChkDev.Name = "btnChkDev";
            this.btnChkDev.Size = new System.Drawing.Size(100, 25);
            this.btnChkDev.TabIndex = 6;
            this.btnChkDev.Text = "Найти устр.";
            this.btnChkDev.UseVisualStyleBackColor = true;
            this.btnChkDev.Click += new System.EventHandler(this.btnChkDev_Click);
            // 
            // rbMDB
            // 
            this.rbMDB.AutoSize = true;
            this.rbMDB.Location = new System.Drawing.Point(7, 80);
            this.rbMDB.Name = "rbMDB";
            this.rbMDB.Size = new System.Drawing.Size(98, 17);
            this.rbMDB.TabIndex = 3;
            this.rbMDB.Text = "MODBUS-RTU";
            this.rbMDB.UseVisualStyleBackColor = true;
            // 
            // rbUART
            // 
            this.rbUART.AutoSize = true;
            this.rbUART.Checked = true;
            this.rbUART.Location = new System.Drawing.Point(7, 20);
            this.rbUART.Name = "rbUART";
            this.rbUART.Size = new System.Drawing.Size(55, 17);
            this.rbUART.TabIndex = 0;
            this.rbUART.TabStop = true;
            this.rbUART.Text = "UART";
            this.rbUART.UseVisualStyleBackColor = true;
            this.rbUART.Click += new System.EventHandler(this.rbUART_Click);
            // 
            // gbAllControls
            // 
            this.gbAllControls.Controls.Add(this.button9);
            this.gbAllControls.Controls.Add(this.button8);
            this.gbAllControls.Controls.Add(this.button7);
            this.gbAllControls.Controls.Add(this.button6);
            this.gbAllControls.Controls.Add(this.button5);
            this.gbAllControls.Controls.Add(this.button4);
            this.gbAllControls.Controls.Add(this.button3);
            this.gbAllControls.Controls.Add(this.button2);
            this.gbAllControls.Controls.Add(this.textBox4);
            this.gbAllControls.Controls.Add(this.textBox3);
            this.gbAllControls.Controls.Add(this.textBox2);
            this.gbAllControls.Controls.Add(this.textBox1);
            this.gbAllControls.Controls.Add(this.lbCurr);
            this.gbAllControls.Controls.Add(this.lbVolt);
            this.gbAllControls.Controls.Add(this.tbCurr);
            this.gbAllControls.Controls.Add(this.tbVoltage);
            this.gbAllControls.Controls.Add(this.button1);
            this.gbAllControls.Controls.Add(this.tbMask);
            this.gbAllControls.Controls.Add(this.cbDevBoud);
            this.gbAllControls.Controls.Add(this.cbGrnLed);
            this.gbAllControls.Controls.Add(this.lbStatID);
            this.gbAllControls.Controls.Add(this.tbDevText);
            this.gbAllControls.Controls.Add(this.lbStr8);
            this.gbAllControls.Controls.Add(this.tbStr0);
            this.gbAllControls.Controls.Add(this.tbType);
            this.gbAllControls.Controls.Add(this.lbStr0);
            this.gbAllControls.Controls.Add(this.cbRelay);
            this.gbAllControls.Controls.Add(this.cbBlLed);
            this.gbAllControls.Controls.Add(this.cbRedLed);
            this.gbAllControls.Controls.Add(this.btnSetting);
            this.gbAllControls.Controls.Add(this.lbStr7);
            this.gbAllControls.Controls.Add(this.lbStr6);
            this.gbAllControls.Controls.Add(this.lbStr5);
            this.gbAllControls.Controls.Add(this.lbStr4);
            this.gbAllControls.Controls.Add(this.lbStr3);
            this.gbAllControls.Controls.Add(this.lbStr2);
            this.gbAllControls.Controls.Add(this.lbStr1);
            this.gbAllControls.Controls.Add(this.lbType);
            this.gbAllControls.Controls.Add(this.numericRfidPoolTime);
            this.gbAllControls.Controls.Add(this.numericLedActTime);
            this.gbAllControls.Controls.Add(this.numericOutTime);
            this.gbAllControls.Controls.Add(this.cbStr4);
            this.gbAllControls.Controls.Add(this.cbDevMode);
            this.gbAllControls.Controls.Add(this.numericDevAdr);
            this.gbAllControls.Location = new System.Drawing.Point(149, 7);
            this.gbAllControls.Name = "gbAllControls";
            this.gbAllControls.Size = new System.Drawing.Size(345, 325);
            this.gbAllControls.TabIndex = 16;
            this.gbAllControls.TabStop = false;
            this.gbAllControls.Text = "RFID считыватель ";
            this.gbAllControls.Visible = false;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(81, 295);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(41, 25);
            this.button9.TabIndex = 83;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(81, 294);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(41, 25);
            this.button8.TabIndex = 82;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(81, 295);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(41, 25);
            this.button7.TabIndex = 81;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(81, 295);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 25);
            this.button6.TabIndex = 80;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(81, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(41, 25);
            this.button5.TabIndex = 79;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(81, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 25);
            this.button4.TabIndex = 78;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(81, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 25);
            this.button3.TabIndex = 77;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(81, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 25);
            this.button2.TabIndex = 76;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(49, 257);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(78, 49);
            this.textBox4.TabIndex = 75;
            this.textBox4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(49, 257);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(78, 49);
            this.textBox3.TabIndex = 74;
            this.textBox3.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(49, 257);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(78, 49);
            this.textBox2.TabIndex = 73;
            this.textBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 257);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(78, 49);
            this.textBox1.TabIndex = 72;
            this.textBox1.Visible = false;
            // 
            // lbCurr
            // 
            this.lbCurr.AutoSize = true;
            this.lbCurr.Location = new System.Drawing.Point(188, 260);
            this.lbCurr.Name = "lbCurr";
            this.lbCurr.Size = new System.Drawing.Size(29, 13);
            this.lbCurr.TabIndex = 71;
            this.lbCurr.Text = "Ток:";
            this.lbCurr.Visible = false;
            // 
            // lbVolt
            // 
            this.lbVolt.AutoSize = true;
            this.lbVolt.Location = new System.Drawing.Point(143, 240);
            this.lbVolt.Name = "lbVolt";
            this.lbVolt.Size = new System.Drawing.Size(74, 13);
            this.lbVolt.TabIndex = 70;
            this.lbVolt.Text = "Напряжение:";
            this.lbVolt.Visible = false;
            // 
            // tbCurr
            // 
            this.tbCurr.BackColor = System.Drawing.SystemColors.Window;
            this.tbCurr.Enabled = false;
            this.tbCurr.Location = new System.Drawing.Point(223, 260);
            this.tbCurr.Name = "tbCurr";
            this.tbCurr.Size = new System.Drawing.Size(115, 20);
            this.tbCurr.TabIndex = 69;
            // 
            // tbVoltage
            // 
            this.tbVoltage.BackColor = System.Drawing.SystemColors.Window;
            this.tbVoltage.Enabled = false;
            this.tbVoltage.Location = new System.Drawing.Point(223, 240);
            this.tbVoltage.Name = "tbVoltage";
            this.tbVoltage.Size = new System.Drawing.Size(115, 20);
            this.tbVoltage.TabIndex = 68;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 25);
            this.button1.TabIndex = 67;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btnRelay_Click);
            // 
            // tbMask
            // 
            this.tbMask.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbMask.Enabled = false;
            this.tbMask.Location = new System.Drawing.Point(128, 220);
            this.tbMask.MaxLength = 35;
            this.tbMask.Name = "tbMask";
            this.tbMask.Size = new System.Drawing.Size(210, 20);
            this.tbMask.TabIndex = 66;
            this.tbMask.Visible = false;
            // 
            // cbDevBoud
            // 
            this.cbDevBoud.Enabled = false;
            this.cbDevBoud.FormattingEnabled = true;
            this.cbDevBoud.Location = new System.Drawing.Point(223, 80);
            this.cbDevBoud.Name = "cbDevBoud";
            this.cbDevBoud.Size = new System.Drawing.Size(115, 21);
            this.cbDevBoud.TabIndex = 8;
            // 
            // cbGrnLed
            // 
            this.cbGrnLed.AutoSize = true;
            this.cbGrnLed.Location = new System.Drawing.Point(7, 260);
            this.cbGrnLed.Name = "cbGrnLed";
            this.cbGrnLed.Size = new System.Drawing.Size(71, 17);
            this.cbGrnLed.TabIndex = 65;
            this.cbGrnLed.Text = "Зелёный";
            this.cbGrnLed.UseVisualStyleBackColor = true;
            this.cbGrnLed.Visible = false;
            this.cbGrnLed.CheckedChanged += new System.EventHandler(this.cbGrnLed_CheckedChanged);
            // 
            // lbStatID
            // 
            this.lbStatID.AutoSize = true;
            this.lbStatID.Location = new System.Drawing.Point(6, 220);
            this.lbStatID.Name = "lbStatID";
            this.lbStatID.Size = new System.Drawing.Size(134, 13);
            this.lbStatID.TabIndex = 64;
            this.lbStatID.Text = "Код приложенной карты:";
            this.lbStatID.Visible = false;
            // 
            // tbDevText
            // 
            this.tbDevText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDevText.Enabled = false;
            this.tbDevText.Location = new System.Drawing.Point(145, 200);
            this.tbDevText.MaxLength = 31;
            this.tbDevText.Name = "tbDevText";
            this.tbDevText.Size = new System.Drawing.Size(193, 20);
            this.tbDevText.TabIndex = 63;
            this.tbDevText.Visible = false;
            this.tbDevText.TextChanged += new System.EventHandler(this.tbTextLabel_TextChanged);
            // 
            // lbStr8
            // 
            this.lbStr8.AutoSize = true;
            this.lbStr8.Location = new System.Drawing.Point(6, 200);
            this.lbStr8.Name = "lbStr8";
            this.lbStr8.Size = new System.Drawing.Size(95, 13);
            this.lbStr8.TabIndex = 62;
            this.lbStr8.Text = "Текстовая метка";
            this.lbStr8.Visible = false;
            // 
            // tbStr0
            // 
            this.tbStr0.BackColor = System.Drawing.SystemColors.Window;
            this.tbStr0.Location = new System.Drawing.Point(223, 40);
            this.tbStr0.Name = "tbStr0";
            this.tbStr0.ReadOnly = true;
            this.tbStr0.Size = new System.Drawing.Size(115, 20);
            this.tbStr0.TabIndex = 61;
            // 
            // tbType
            // 
            this.tbType.BackColor = System.Drawing.SystemColors.Window;
            this.tbType.Location = new System.Drawing.Point(223, 20);
            this.tbType.Name = "tbType";
            this.tbType.ReadOnly = true;
            this.tbType.Size = new System.Drawing.Size(115, 20);
            this.tbType.TabIndex = 60;
            // 
            // lbStr0
            // 
            this.lbStr0.AutoSize = true;
            this.lbStr0.Location = new System.Drawing.Point(6, 40);
            this.lbStr0.Name = "lbStr0";
            this.lbStr0.Size = new System.Drawing.Size(94, 13);
            this.lbStr0.TabIndex = 59;
            this.lbStr0.Text = "Ключей в памяти";
            // 
            // cbRelay
            // 
            this.cbRelay.AutoSize = true;
            this.cbRelay.Location = new System.Drawing.Point(7, 300);
            this.cbRelay.Name = "cbRelay";
            this.cbRelay.Size = new System.Drawing.Size(58, 17);
            this.cbRelay.TabIndex = 51;
            this.cbRelay.Text = "Выход";
            this.cbRelay.UseVisualStyleBackColor = true;
            this.cbRelay.Visible = false;
            this.cbRelay.Click += new System.EventHandler(this.cbRelay_Click);
            // 
            // cbBlLed
            // 
            this.cbBlLed.AutoSize = true;
            this.cbBlLed.Location = new System.Drawing.Point(7, 280);
            this.cbBlLed.Name = "cbBlLed";
            this.cbBlLed.Size = new System.Drawing.Size(57, 17);
            this.cbBlLed.TabIndex = 50;
            this.cbBlLed.Text = "Синий";
            this.cbBlLed.UseVisualStyleBackColor = true;
            this.cbBlLed.Visible = false;
            this.cbBlLed.CheckedChanged += new System.EventHandler(this.cbBlLed_CheckedChanged);
            this.cbBlLed.Click += new System.EventHandler(this.cbBlLed_Click);
            // 
            // cbRedLed
            // 
            this.cbRedLed.AutoSize = true;
            this.cbRedLed.Location = new System.Drawing.Point(7, 240);
            this.cbRedLed.Name = "cbRedLed";
            this.cbRedLed.Size = new System.Drawing.Size(71, 17);
            this.cbRedLed.TabIndex = 49;
            this.cbRedLed.Text = "Красный";
            this.cbRedLed.UseVisualStyleBackColor = true;
            this.cbRedLed.Visible = false;
            this.cbRedLed.CheckedChanged += new System.EventHandler(this.cbRedLed_CheckedChanged);
            this.cbRedLed.Click += new System.EventHandler(this.cbRedLed_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(246, 294);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(93, 25);
            this.btnSetting.TabIndex = 9;
            this.btnSetting.Text = "Настроить";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // lbStr7
            // 
            this.lbStr7.AutoSize = true;
            this.lbStr7.Location = new System.Drawing.Point(6, 180);
            this.lbStr7.Name = "lbStr7";
            this.lbStr7.Size = new System.Drawing.Size(146, 13);
            this.lbStr7.TabIndex = 25;
            this.lbStr7.Text = "Период чтения RFID (мСек)";
            this.lbStr7.Visible = false;
            // 
            // lbStr6
            // 
            this.lbStr6.AutoSize = true;
            this.lbStr6.Location = new System.Drawing.Point(6, 160);
            this.lbStr6.Name = "lbStr6";
            this.lbStr6.Size = new System.Drawing.Size(198, 13);
            this.lbStr6.TabIndex = 24;
            this.lbStr6.Text = "Время индикации чтения RFID (мСек)";
            this.lbStr6.Visible = false;
            // 
            // lbStr5
            // 
            this.lbStr5.AutoSize = true;
            this.lbStr5.Location = new System.Drawing.Point(6, 140);
            this.lbStr5.Name = "lbStr5";
            this.lbStr5.Size = new System.Drawing.Size(201, 13);
            this.lbStr5.TabIndex = 23;
            this.lbStr5.Text = "Время включения выхода замка (Сек)";
            this.lbStr5.Visible = false;
            // 
            // lbStr4
            // 
            this.lbStr4.AutoSize = true;
            this.lbStr4.Location = new System.Drawing.Point(6, 120);
            this.lbStr4.Name = "lbStr4";
            this.lbStr4.Size = new System.Drawing.Size(116, 13);
            this.lbStr4.TabIndex = 22;
            this.lbStr4.Text = "Дежурная индикация";
            this.lbStr4.Visible = false;
            // 
            // lbStr3
            // 
            this.lbStr3.AutoSize = true;
            this.lbStr3.Location = new System.Drawing.Point(6, 100);
            this.lbStr3.Name = "lbStr3";
            this.lbStr3.Size = new System.Drawing.Size(150, 13);
            this.lbStr3.TabIndex = 21;
            this.lbStr3.Text = "Режим работы считывателя";
            this.lbStr3.Visible = false;
            // 
            // lbStr2
            // 
            this.lbStr2.AutoSize = true;
            this.lbStr2.Location = new System.Drawing.Point(6, 80);
            this.lbStr2.Name = "lbStr2";
            this.lbStr2.Size = new System.Drawing.Size(121, 13);
            this.lbStr2.TabIndex = 20;
            this.lbStr2.Text = "Скорость линии связи";
            // 
            // lbStr1
            // 
            this.lbStr1.AutoSize = true;
            this.lbStr1.Location = new System.Drawing.Point(6, 60);
            this.lbStr1.Name = "lbStr1";
            this.lbStr1.Size = new System.Drawing.Size(98, 13);
            this.lbStr1.TabIndex = 19;
            this.lbStr1.Text = "Адрес устройства";
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Location = new System.Drawing.Point(6, 20);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(94, 13);
            this.lbType.TabIndex = 18;
            this.lbType.Text = "Тип считывателя";
            // 
            // numericRfidPoolTime
            // 
            this.numericRfidPoolTime.BackColor = System.Drawing.SystemColors.Window;
            this.numericRfidPoolTime.Enabled = false;
            this.numericRfidPoolTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericRfidPoolTime.Location = new System.Drawing.Point(223, 180);
            this.numericRfidPoolTime.Maximum = new decimal(new int[] {
            2600,
            0,
            0,
            0});
            this.numericRfidPoolTime.Name = "numericRfidPoolTime";
            this.numericRfidPoolTime.Size = new System.Drawing.Size(115, 20);
            this.numericRfidPoolTime.TabIndex = 58;
            this.numericRfidPoolTime.Visible = false;
            this.numericRfidPoolTime.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            // 
            // numericLedActTime
            // 
            this.numericLedActTime.BackColor = System.Drawing.SystemColors.Window;
            this.numericLedActTime.Enabled = false;
            this.numericLedActTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericLedActTime.Location = new System.Drawing.Point(223, 160);
            this.numericLedActTime.Maximum = new decimal(new int[] {
            2600,
            0,
            0,
            0});
            this.numericLedActTime.Name = "numericLedActTime";
            this.numericLedActTime.Size = new System.Drawing.Size(115, 20);
            this.numericLedActTime.TabIndex = 57;
            this.numericLedActTime.Visible = false;
            this.numericLedActTime.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // numericOutTime
            // 
            this.numericOutTime.BackColor = System.Drawing.SystemColors.Window;
            this.numericOutTime.DecimalPlaces = 1;
            this.numericOutTime.Enabled = false;
            this.numericOutTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericOutTime.Location = new System.Drawing.Point(223, 140);
            this.numericOutTime.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericOutTime.Name = "numericOutTime";
            this.numericOutTime.Size = new System.Drawing.Size(115, 20);
            this.numericOutTime.TabIndex = 56;
            this.numericOutTime.Visible = false;
            this.numericOutTime.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // cbStr4
            // 
            this.cbStr4.BackColor = System.Drawing.SystemColors.Window;
            this.cbStr4.Enabled = false;
            this.cbStr4.FormattingEnabled = true;
            this.cbStr4.Location = new System.Drawing.Point(223, 120);
            this.cbStr4.Name = "cbStr4";
            this.cbStr4.Size = new System.Drawing.Size(115, 21);
            this.cbStr4.TabIndex = 33;
            this.cbStr4.Visible = false;
            // 
            // cbDevMode
            // 
            this.cbDevMode.BackColor = System.Drawing.SystemColors.Window;
            this.cbDevMode.Enabled = false;
            this.cbDevMode.FormattingEnabled = true;
            this.cbDevMode.Location = new System.Drawing.Point(223, 100);
            this.cbDevMode.Name = "cbDevMode";
            this.cbDevMode.Size = new System.Drawing.Size(115, 21);
            this.cbDevMode.TabIndex = 32;
            this.cbDevMode.Visible = false;
            // 
            // numericDevAdr
            // 
            this.numericDevAdr.BackColor = System.Drawing.SystemColors.Window;
            this.numericDevAdr.Enabled = false;
            this.numericDevAdr.Location = new System.Drawing.Point(223, 60);
            this.numericDevAdr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericDevAdr.Name = "numericDevAdr";
            this.numericDevAdr.Size = new System.Drawing.Size(115, 20);
            this.numericDevAdr.TabIndex = 7;
            this.numericDevAdr.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbUncnown
            // 
            this.gbUncnown.Controls.Add(this.tbUnStatus);
            this.gbUncnown.Controls.Add(this.label5);
            this.gbUncnown.Controls.Add(this.label4);
            this.gbUncnown.Controls.Add(this.tbUnDevInfo);
            this.gbUncnown.Location = new System.Drawing.Point(149, 7);
            this.gbUncnown.Name = "gbUncnown";
            this.gbUncnown.Size = new System.Drawing.Size(345, 325);
            this.gbUncnown.TabIndex = 66;
            this.gbUncnown.TabStop = false;
            this.gbUncnown.Text = "Неизвестное устройство";
            this.gbUncnown.Visible = false;
            // 
            // tbUnStatus
            // 
            this.tbUnStatus.Enabled = false;
            this.tbUnStatus.Location = new System.Drawing.Point(124, 40);
            this.tbUnStatus.Name = "tbUnStatus";
            this.tbUnStatus.Size = new System.Drawing.Size(213, 20);
            this.tbUnStatus.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Статус:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Тип устройства:";
            // 
            // tbUnDevInfo
            // 
            this.tbUnDevInfo.Enabled = false;
            this.tbUnDevInfo.Location = new System.Drawing.Point(124, 20);
            this.tbUnDevInfo.Name = "tbUnDevInfo";
            this.tbUnDevInfo.Size = new System.Drawing.Size(213, 20);
            this.tbUnDevInfo.TabIndex = 0;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // debugPort
            // 
            this.debugPort.BaudRate = 19200;
            this.debugPort.PortName = "COM10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 335);
            this.Controls.Add(this.gbAllControls);
            this.Controls.Add(this.lbBR);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbUncnown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Конфигуратор интерфейсных устройств НПО \"Электроавтоматика\"";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adrNumer)).EndInit();
            this.gbAllControls.ResumeLayout(false);
            this.gbAllControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRfidPoolTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLedActTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOutTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDevAdr)).EndInit();
            this.gbUncnown.ResumeLayout(false);
            this.gbUncnown.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.IO.Ports.SerialPort port1;
        private System.Windows.Forms.Label lbBR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbEth;
        private System.Windows.Forms.Button btnChkDev;
        private System.Windows.Forms.RadioButton rbMDB;
        private System.Windows.Forms.RadioButton rbUART;
        private System.Windows.Forms.GroupBox gbAllControls;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbStr4;
        private System.Windows.Forms.Label lbStr3;
        private System.Windows.Forms.Label lbStr2;
        private System.Windows.Forms.Label lbStr1;
        private System.Windows.Forms.Label lbStr7;
        private System.Windows.Forms.Label lbStr6;
        private System.Windows.Forms.Label lbStr5;
        private System.Windows.Forms.ComboBox cbStr4;
        private System.Windows.Forms.ComboBox cbDevMode;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.CheckBox cbRelay;
        private System.Windows.Forms.CheckBox cbBlLed;
        private System.Windows.Forms.NumericUpDown numericRfidPoolTime;
        private System.Windows.Forms.NumericUpDown numericLedActTime;
        private System.Windows.Forms.NumericUpDown numericOutTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown adrNumer;
        private System.Windows.Forms.TextBox tbStr0;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Label lbStr0;
        private System.Windows.Forms.TextBox tbDevText;
        private System.Windows.Forms.Label lbStr8;
        private System.Windows.Forms.Label lbStatID;
        private System.Windows.Forms.CheckBox cbGrnLed;
        private System.Windows.Forms.CheckBox cbRedLed;
        private System.Windows.Forms.RadioButton rbEMDB;
        private System.Windows.Forms.GroupBox gbUncnown;
        private System.Windows.Forms.TextBox tbUnStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUnDevInfo;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbCurr;
        private System.Windows.Forms.Label lbVolt;
        private System.Windows.Forms.TextBox tbCurr;
        private System.Windows.Forms.TextBox tbVoltage;
        private System.Windows.Forms.Timer timer2;
        private System.IO.Ports.SerialPort debugPort;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.NumericUpDown numericDevAdr;
        public System.Windows.Forms.ComboBox cbDevBoud;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button9;
    }
}

