namespace Modbus_Cheborilsk
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstBaudrate = new System.Windows.Forms.ComboBox();
            this.lstPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lstDataType = new System.Windows.Forms.ComboBox();
            this.txtSampleRate = new System.Windows.Forms.TextBox();
            this.txtRegisterQty = new System.Windows.Forms.TextBox();
            this.txtStartAddr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSlaveID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstRegisterValues = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnWrite = new System.Windows.Forms.Button();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.txtWriteRegister = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBaudrate);
            this.groupBox1.Controls.Add(this.lstPorts);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(366, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки порта:";
            // 
            // lstBaudrate
            // 
            this.lstBaudrate.FormattingEnabled = true;
            this.lstBaudrate.Location = new System.Drawing.Point(105, 40);
            this.lstBaudrate.Name = "lstBaudrate";
            this.lstBaudrate.Size = new System.Drawing.Size(82, 21);
            this.lstBaudrate.TabIndex = 3;
            // 
            // lstPorts
            // 
            this.lstPorts.FormattingEnabled = true;
            this.lstPorts.Location = new System.Drawing.Point(105, 13);
            this.lstPorts.Name = "lstPorts";
            this.lstPorts.Size = new System.Drawing.Size(82, 21);
            this.lstPorts.TabIndex = 2;
            this.lstPorts.SelectedIndexChanged += new System.EventHandler(this.lstPorts_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Скорость:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Порт:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lstDataType);
            this.groupBox2.Controls.Add(this.txtSampleRate);
            this.groupBox2.Controls.Add(this.txtRegisterQty);
            this.groupBox2.Controls.Add(this.txtStartAddr);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(366, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Запрос:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Тип данных:";
            // 
            // lstDataType
            // 
            this.lstDataType.FormattingEnabled = true;
            this.lstDataType.Location = new System.Drawing.Point(105, 92);
            this.lstDataType.Name = "lstDataType";
            this.lstDataType.Size = new System.Drawing.Size(82, 21);
            this.lstDataType.TabIndex = 9;
            this.lstDataType.SelectedIndexChanged += new System.EventHandler(this.lstDataType_SelectedIndexChanged);
            // 
            // txtSampleRate
            // 
            this.txtSampleRate.Location = new System.Drawing.Point(105, 66);
            this.txtSampleRate.Name = "txtSampleRate";
            this.txtSampleRate.Size = new System.Drawing.Size(82, 20);
            this.txtSampleRate.TabIndex = 8;
            // 
            // txtRegisterQty
            // 
            this.txtRegisterQty.Location = new System.Drawing.Point(105, 40);
            this.txtRegisterQty.Name = "txtRegisterQty";
            this.txtRegisterQty.Size = new System.Drawing.Size(82, 20);
            this.txtRegisterQty.TabIndex = 7;
            // 
            // txtStartAddr
            // 
            this.txtStartAddr.Location = new System.Drawing.Point(105, 14);
            this.txtStartAddr.Name = "txtStartAddr";
            this.txtStartAddr.Size = new System.Drawing.Size(82, 20);
            this.txtStartAddr.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Частота опроса:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Кол-во регистров:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Адрес начальный:";
            // 
            // txtSlaveID
            // 
            this.txtSlaveID.Location = new System.Drawing.Point(471, 78);
            this.txtSlaveID.Name = "txtSlaveID";
            this.txtSlaveID.Size = new System.Drawing.Size(82, 20);
            this.txtSlaveID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Адрес MODBUS:";
            // 
            // lstRegisterValues
            // 
            this.lstRegisterValues.FormattingEnabled = true;
            this.lstRegisterValues.Location = new System.Drawing.Point(12, 12);
            this.lstRegisterValues.Name = "lstRegisterValues";
            this.lstRegisterValues.Size = new System.Drawing.Size(330, 290);
            this.lstRegisterValues.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 308);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(192, 308);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 348);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(573, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 17);
            this.lblStatus.Text = "Готов";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnWrite);
            this.groupBox3.Controls.Add(this.txtWriteValue);
            this.groupBox3.Controls.Add(this.txtWriteRegister);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(366, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 111);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Запись:";
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(9, 74);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(178, 23);
            this.btnWrite.TabIndex = 8;
            this.btnWrite.Text = "!!! Записать !!!";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(105, 39);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(82, 20);
            this.txtWriteValue.TabIndex = 7;
            // 
            // txtWriteRegister
            // 
            this.txtWriteRegister.Location = new System.Drawing.Point(105, 13);
            this.txtWriteRegister.Name = "txtWriteRegister";
            this.txtWriteRegister.Size = new System.Drawing.Size(82, 20);
            this.txtWriteRegister.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Значение:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Регистр:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 370);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lstRegisterValues);
            this.Controls.Add(this.txtSlaveID);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modbus отладчик, ЧЕБОРИЛЬСК 2022 (С)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox lstBaudrate;
        private System.Windows.Forms.ComboBox lstPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox lstDataType;
        private System.Windows.Forms.TextBox txtSampleRate;
        private System.Windows.Forms.TextBox txtRegisterQty;
        private System.Windows.Forms.TextBox txtStartAddr;
        private System.Windows.Forms.TextBox txtSlaveID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstRegisterValues;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWriteValue;
        private System.Windows.Forms.TextBox txtWriteRegister;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnWrite;
    }
}

