using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Device_Configurator
{
    public partial class Form1 : Form
    {
        Point pnt = new Point();
        Size sze = new Size();
        const bool DEBUG_INFO = false;
        private bool PortStat = false;
        private bool TextChng = false;          // Флаг изменения текстовой метки
        private bool portNewData = false;
        bool KpiStatRelay, KpiStatHand, KpiStatCurrAlrm, KpiStatLoAlrm, KpiStatHiAlrm;
        byte KpiStatVoltage, KpiStatAmperage;
        byte[] KpiMask = new byte[4];

        byte rxdLen;
        public byte devAdr;
        byte devType;
        byte rfidVer;
        byte errResp = 0;
        public byte brTermo;
        public byte brTrig;
        public byte brInvers;
        public byte[] devStatus = new byte[20];
        public byte[] cmd = new byte[64];
        public byte[] indataPort1 = new byte[255];
        long ElapsedTime;
        IbvClass ibv = new IbvClass();
        //-------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbPort.Items.AddRange(items: SerialPort.GetPortNames());
            if(cbPort.Items.Count > 0) cbPort.SelectedIndex = 0;
            AllReset();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void devAdrInfo()                      // Выводит на форму адрес и скорость девайса
        {
            numericDevAdr.Value = devAdr;
            try
            {
                cbDevBoud.SelectedIndex = cbDevBoud.FindString(port1.BaudRate.ToString());
            }
            catch (Exception err)
            {
                portCloseAtrbt();
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AllReset()
        {
            PortStat = false;
            timer1.Stop();
            timer2.Stop();
            if (adrNumer.Value > 0) btnChkDev.Text = "Подключить";
            else btnChkDev.Text = "Найти адрес";
            cbPort.Enabled = true;
            cbPort.SelectedItem = 0;
            adrNumer.Enabled = true;
            //btnChkDev.BackColor = Color.LightGray;
            pbStatus.BackColor = Color.LightGray;
            pbStatus.Value = 0;
            lbStatus.BackColor = Color.LightGray;
            lbStatus.Text = "";
            lbStatID.Text = "Код приложенной карты: ";
            tbStatus.Text = "";
            allFormDisable();
            //-------- позиции и размеры окон на изначальные места
            pnt.X = 145;
            pnt.Y = 200;
            tbDevText.Location = pnt;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            //----------------------------------
        }
        private void AllRight()
        {
            PortStat = true;
            btnChkDev.Text = "Отключить";
            cbPort.Enabled = false;
            cbPort.SelectedItem = 0;
            adrNumer.Enabled = false;
            //btnChkDev.BackColor = Color.Lime;
            pbStatus.BackColor = Color.Lime;
            pbStatus.ForeColor = Color.Lime;
            lbStatus.BackColor = Color.Lime;
            pbStatus.Value = 100;
            lbStatus.Text = port1.BaudRate.ToString() + " bps";

        }
        private void ChngEnable()
        {
            cbDevBoud.Enabled = true;
            cbDevMode.Enabled = true;
            cbStr4.Enabled = true;
            numericDevAdr.Enabled = true;
            numericOutTime.Enabled = true;
            numericLedActTime.Enabled = true;
            numericRfidPoolTime.Enabled = true;
            tbDevText.Enabled = true;
            if (devType == 4)                       // Для БР-8К
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
            }
        }
        private void ChngDisable()
        {
            cbDevBoud.Enabled = false;
            cbDevMode.Enabled = false;
            cbStr4.Enabled = false;
            numericDevAdr.Enabled = false;
            numericOutTime.Enabled = false;
            numericLedActTime.Enabled = false;
            numericRfidPoolTime.Enabled = false;
            tbDevText.Enabled = false;
            tbMask.Enabled = false;
            if (devType == 4)                       // Для БР-8К
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = false;
            }
        }
        private void allFormDisable()               // Отключение всех форм. Сброс к начальным установкам окна
        {
            gbUncnown.Visible = false;
            gbAllControls.Visible = false;
            tbType.Text = "";
            tbStr0.Text = "";
            tbStr0.Visible = false;
            sze.Height = 20;
            sze.Width = 115;
            pnt.X = 223;
            pnt.Y = 20;
            tbType.Size = sze;
            tbType.Location = pnt;
            lbStr0.Visible = false;
            btnSetting.Text = "Настроить";
            lbStr3.Visible = false;
            lbStr4.Visible = false;
            lbStr5.Visible = false;
            lbStr6.Visible = false;
            lbStr7.Visible = false;
            lbStr8.Visible = false;
            lbStatID.Visible = false;
            cbDevBoud.Items.Clear();
            cbStr4.Visible = false;
            cbStr4.Items.Clear();
            cbDevMode.Visible = false;
            cbDevMode.Items.Clear();
            numericOutTime.Visible = false;
            numericLedActTime.Visible = false;
            numericRfidPoolTime.Visible = false;
            tbDevText.Visible = false;
            cbRedLed.Visible = false;
            cbGrnLed.Visible = false;
            cbBlLed.Visible = false;
            cbRelay.Visible = false;
            tbMask.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            lbVolt.Visible = false;
            lbCurr.Visible = false;
            tbVoltage.Visible = false;
            tbCurr.Visible = false;
            textBox1.Visible = false;
            textBox1.BackColor = Color.White;
            textBox2.Visible = false;
            textBox2.BackColor = Color.White;
            textBox3.Visible = false;
            textBox3.BackColor = Color.White;
            textBox4.Visible = false;
            textBox4.BackColor = Color.White;
            timer1.Stop();
            timer2.Stop();
        }

        private void RFIDCntrlOn()                  // Включение формы RFID считывателя
        {
            cbDevBoud.Items.Add("2400");
            cbDevBoud.Items.Add("4800");
            cbDevBoud.Items.Add("9600");
            cbDevBoud.Items.Add("19200");
            devAdrInfo();
            lbStr0.Text = "Ключей в памяти";
            lbStr0.Visible = true;
            Int16 keys = indataPort1[10];
            keys <<= 8;
            keys += indataPort1[11];
            tbStr0.Text = keys.ToString();
            gbAllControls.Text = "RFID считыватель";
            lbStr3.Text = "Режим работы считывателя";
            lbStr5.Text = "Время включения выхода замка (Сек)";
            lbStr6.Text = "Время индикации чтения RFID (мСек)";
            lbStr7.Text = "Период чтения RFID (мСек)";
            tbStr0.Visible = true;
            lbStr3.Visible = true;
            lbStr4.Visible = true;
            lbStr5.Visible = true;
            lbStr6.Visible = true;
            lbStr7.Visible = true;
            lbStr8.Visible = true;
            lbStatID.Visible = true;
            cbDevMode.Visible = true;
            cbStr4.Visible = true;
            numericOutTime.Visible = true;
            numericLedActTime.Visible = true;
            numericRfidPoolTime.Visible = true;
            tbDevText.Visible = true;
            cbRedLed.Visible = true;
            cbGrnLed.Visible = true;
            cbBlLed.Visible = true;
            cbRelay.Visible = true;
            gbAllControls.Visible = true;
        }
        private byte RfidGetMode()                  // Возвращает текущий режим работы RFID считывателя
        {
            if (getFlag(0x10, indataPort1[13])) return 0; // флаг режима СКУД
            if (getFlag(0x20, indataPort1[13])) return 4; // флаг режима iButton
            if (getFlag(0x40, indataPort1[13])) return 1; // флаг режима Wiegand26     
            if (getFlag(0x80, indataPort1[13])) return 2; // флаг режима Wiegand34
            return 3;                               // флаг режима Wiegand42
        }
        private void RfidLedInfo()                  // Интерактив формы RFID считывателя
        {
            var stat = devStatus[3];
            stat &= 0x01;                        // флаг красного
            if (stat > 0)
            {
                cbRedLed.Checked = true;
            }
            else
            {
                cbRedLed.Checked = false;
            }
            stat = devStatus[3];
            stat &= 0x02;                        // флаг зелёного
            if (stat > 0)
            {
                cbGrnLed.Checked = true;
            }
            else
            {
                cbGrnLed.Checked = false;
            }
            stat = devStatus[3];
            stat &= 0x04;                        // флаг синего
            if (stat > 0)
            {
                cbBlLed.Checked = true;
            }
            else
            {
                cbBlLed.Checked = false;
            }


            stat = devStatus[3];
            stat &= 0x80;                        // флаг реле
            if (stat > 0) cbRelay.Checked = true;
            else cbRelay.Checked = false;
            stat = devStatus[1];
            stat &= 0x01;                        // флаг новой карты
            if (stat > 0)
            {
         //       lbStatID.ForeColor = Color.Red;
                lbStatID.Text = "ID приложенной карты: ";
                int i = 4;
                while (i < 9)
                {
                    lbStatID.Text += HexToStr(devStatus[i++]);
                }
                if (cbDevMode.Text == "СКУД")
                {
                    stat = devStatus[1];
                    stat &= 0x02;                            // Доступ открыт
                    if (stat > 0)
                    {
                        lbStatID.Text += "Доступ открыт";
                        lbStatID.ForeColor = Color.Green;
                    }
                    else
                    {
                        stat = devStatus[1];
                        stat &= 0x04;                        // Доступ закрыт
                        if (stat > 0)
                        {
                            lbStatID.Text += "Доступ закрыт";
                            lbStatID.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    lbStatID.ForeColor = Color.BlueViolet;
                }
            }
            else lbStatID.ForeColor = Color.Black;
        }
        private bool KpiStrToMask()                 // Конвертация строки в 4 байта маски КПИ
        {
            var j = 0;
            for (var i = 0; i < 35; i++)                        // Сформировать маску из строки
            {
                try
                {
                    if (tbMask.Text[i] == ' ') j++;
                    KpiMask[j] <<= 1;
                    if (tbMask.Text[i] == '1') KpiMask[j] |= 0x01;
                    else if (tbMask.Text[i] != '0' && tbMask.Text[i] != ' ')
                    {
                        MessageBox.Show("Ошибка маски");
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка маски");
                    return false;
                }
            }
            return true;
        }
        private void KpiStatInfo()                  // Интерактив формы КПИ реле
        {
            KpiStatRelay = getFlag(0x01, devStatus[1]);
            KpiStatHand = getFlag(0x02, devStatus[1]);
            KpiStatCurrAlrm = getFlag(0x08, devStatus[1]);
            KpiStatLoAlrm = getFlag(0x10, devStatus[1]);
            KpiStatHiAlrm = getFlag(0x20, devStatus[1]);
            if (KpiStatRelay)
            {
                if (devStatus[0] == 8)
                {
                    KpiStatVoltage = devStatus[5];
                    KpiStatAmperage = devStatus[6];
                }
                if (KpiStatHand) button1.BackColor = Color.YellowGreen;
                else button1.BackColor = Color.Green;
                tbVoltage.Text = KpiStatVoltage.ToString();
                var tmp = KpiStatAmperage & 0xF0;
                tmp >>= 4;
                tbCurr.Text = tmp.ToString() + ',';
                tmp = KpiStatAmperage & 0x0F;
                tbCurr.Text += tmp.ToString() + 'A';
            }
            else if (KpiStatCurrAlrm || KpiStatLoAlrm || KpiStatHiAlrm)
            {
                button1.BackColor = Color.Red;
                if (KpiStatCurrAlrm) button1.Text = "Превышен ток";
                else if (KpiStatLoAlrm) button1.Text = "Напр.Ниже";
                else if (KpiStatHiAlrm) button1.Text = "Напр.Выше";
            }
            else
            {
                tbVoltage.Text = "";
                tbCurr.Text = "";
                button1.Text = "Упр. Реле";
                if (!KpiStatHand) button1.BackColor = Color.LightGray;
                else button1.BackColor = Color.Aquamarine;
            }
            
        }
        private void ibvStatForm()                  // Интерактив формы ИБВ-4
        {
            //    textBox1.ForeColor = Color.BlanchedAlmond;
            
            textBox1.Text = "Вх 1:";
            textBox2.Text = "Вх 2:";
            textBox3.Text = "Вх 3:";
            textBox4.Text = "Вх 4:";
            if (ibv.In_1_reg)//---------------- Вход 1 -------
            {
                textBox1.BackColor = Color.LightGreen;
                textBox1.Text += "___   ";
            }
            else
            {
                textBox1.BackColor = Color.LightGray;
                textBox1.Text += "_/_   ";
            }
            textBox1.Text += " ДТЧ: ";
            textBox1.Text += ibv.Celsium_1.ToString();
            textBox1.Text += "°C";
            if (ibv.In_2_reg)//---------------- Вход 2 -------
            {
                textBox2.BackColor = Color.LightGreen;
                textBox2.Text += "___   ";
            }
            else
            {
                textBox2.BackColor = Color.LightGray;
                textBox2.Text += "_/_   ";
            }
            textBox2.Text += "Таймер:";
            textBox2.Text += ibv.IbvTimer.ToString();
            textBox2.Text += " ДТЧ: ";
            textBox2.Text += ibv.Celsium_2.ToString();
            textBox2.Text += "°C";
            if (ibv.In_3_reg)//---------------- Вход 3 -------
            {
                textBox3.BackColor = Color.LightGreen;
                textBox3.Text += "___   ";
            }
            else
            {
                textBox3.BackColor = Color.LightGray;
                textBox3.Text += "_/_   ";
            }
            textBox3.Text += "Счётчик:";
            textBox3.Text += ibv.CntrIn1.ToString();
            textBox3.Text += " ДТЧ: ";
            textBox3.Text += ibv.Celsium_3.ToString();
            textBox3.Text += "°C";
            if (ibv.In_4_reg)//---------------- Вход 4 -------
            {
                textBox4.BackColor = Color.LightGreen;
                textBox4.Text += "___   ";
            }
            else
            {
                textBox4.BackColor = Color.LightGray;
                textBox4.Text += "_/_   ";
            }
            textBox4.Text += "Счётчик:";
            textBox4.Text += ibv.CntrIn2.ToString();
            textBox4.Text += " ДТЧ: ";
            textBox4.Text += ibv.Celsium_4.ToString();
            textBox4.Text += "°C";
        }
        private byte brOutAdr()                     // Вычисление адреса по дип переключателю. Возвращает адрес первого канала
        {
            if (getFlag(0x10, devStatus[1]))
            {
                if (getFlag(0x20, devStatus[1]))
                {
                    if (getFlag(0x01, devStatus[1])) return 57; // 1 1 1 (57-64)
                    else return 25;                             // 1 1 0 (25-32)
                }
                else if (getFlag(0x01, devStatus[1])) return 41;// 1 0 1 (41-48)
                else return 9;                                  // 1 0 0 (9-16)
            }
            else if (getFlag(0x20, devStatus[1]))
            {
                if (getFlag(0x01, devStatus[1])) return 49;     // 0 1 1 (49-56)
                else return 17;                                 // 0 1 0 (17-24)
            }
            else if (getFlag(0x01, devStatus[1]))
                return 33;                                      // 0 0 1 (33-40)
            else return 1;                                      // 0 0 0 (1-8)
        }
        private void brStatForm()
        {
            if (getFlag(0x01, devStatus[2])) button2.BackColor = Color.Green;
            else button2.BackColor = Color.LightGray;
            if (getFlag(0x02, devStatus[2])) button3.BackColor = Color.Green;
            else button3.BackColor = Color.LightGray;
            if (getFlag(0x04, devStatus[2])) button4.BackColor = Color.Green;
            else button4.BackColor = Color.LightGray;
            if (getFlag(0x08, devStatus[2])) button5.BackColor = Color.Green;
            else button5.BackColor = Color.LightGray;
            if (getFlag(0x10, devStatus[2])) button6.BackColor = Color.Green;
            else button6.BackColor = Color.LightGray;
            if (getFlag(0x20, devStatus[2])) button7.BackColor = Color.Green;
            else button7.BackColor = Color.LightGray;
            if (getFlag(0x40, devStatus[2])) button8.BackColor = Color.Green;
            else button8.BackColor = Color.LightGray;
            if (getFlag(0x80, devStatus[2])) button9.BackColor = Color.Green;
            else button9.BackColor = Color.LightGray;
        }
        private string MaskToStr(byte msk)               // Конвертация 1 байта маски в строку
        {
            string res = "";
            byte x = 0x80;
            for (var i = 0; i < 8; i++)
            {
                if (x > 0)
                {
                    if (getFlag(x, msk))
                    {
                        res += '1';
                    }
                    else res += '0';
                    x >>= 1;
                }
            }
            return res;
        }
        private void RfidForm()                     // Подготовка формы RFID считывателя
        {
            RFIDCntrlOn();
            RfidLedInfo();
            rfidVer = indataPort1[7];
            if (rfidVer < 0x10)
            {
                tbType.Text = "Mifare";
                //--------------------------------//--------------------------------
                switch (rfidVer)                // Версия ПО База ПРОВЕРИТЬ ВСЕ ВАРИАНТЫ
                {
                    case 1:
                        tbType.Text += " MFWD";
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.Items.Add("iButton");
                        cbDevMode.SelectedIndex = RfidGetMode() - 1;
                        tbStr0.Visible = false;
                        lbStr0.Visible = false;
                        break;
                    case 2:
                        tbStr0.Text += "/43";
                        tbType.Text += " MFS-43";
                        cbDevMode.Items.Add("СКУД");
                        break;
                    case 3:
                        if (indataPort1[8] == 0)                // Подверсия ПО
                        {
                            tbStr0.Text += "/43";
                            tbType.Text += " MFWDS-43";
                        }
                        else if (indataPort1[8] == 1)
                        {
                            tbStr0.Text += "/2011";
                            tbType.Text += " MFWDS-2000";
                        }
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.Items.Add("iButton");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                    case 4:
                        tbStr0.Text += "/862";
                        tbType.Text += " MFWS-862";
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                    case 5:
                        tbStr0.Text += "/1681";
                        tbType.Text += " MFWS-1681";
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                }
            }
            else if (rfidVer < 0x20)
            {
                tbType.Text = "EM-Marine";
                switch (rfidVer)                // Версия ПО База ПРОВЕРИТЬ ВСЕ ВАРИАНТЫ
                {
                    case 0x10:
                        tbType.Text += " EMWD";
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.Items.Add("iButton");
                        cbDevMode.SelectedIndex = RfidGetMode() - 1;
                        tbStr0.Visible = false;
                        lbStr0.Visible = false;
                        break;
                    case 0x11:
                        tbStr0.Text += "/43";
                        tbType.Text += " EMS-43";
                        cbDevMode.Items.Add("СКУД");
                        break;
                    case 0x12:
                        tbStr0.Text += "/43";
                        tbType.Text += " EMWDS-43";
                        sze.Height = 20;
                        sze.Width = 125;
                        pnt.X = 213;
                        pnt.Y = 20;
                        tbType.Size = sze;
                        tbType.Location = pnt;
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.Items.Add("iButton");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                    case 0x13:
                        tbStr0.Text += "/862";
                        tbType.Text += " EMWS-862";
                        sze.Height = 20;
                        sze.Width = 125;
                        pnt.X = 213;
                        pnt.Y = 20;
                        tbType.Size = sze;
                        tbType.Location = pnt;
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                    case 0x14:
                        tbStr0.Text += "/1681";
                        tbType.Text += " EMWS-1681";
                        sze.Height = 20;
                        sze.Width = 125;
                        pnt.X = 213;
                        pnt.Y = 20;
                        tbType.Size = sze;
                        tbType.Location = pnt;
                        cbDevMode.Items.Add("СКУД");
                        cbDevMode.Items.Add("Wiegand26");
                        cbDevMode.Items.Add("Wiegand34");
                        cbDevMode.Items.Add("Wiegand42");
                        cbDevMode.SelectedIndex = RfidGetMode();
                        break;
                }
            }
            lbStr4.Text = "Дежурная индикация";
            cbStr4.Items.Add("Отключена");
            cbStr4.Items.Add("Включена");
            if (getFlag(0x08, indataPort1[13])) cbStr4.SelectedIndex = 1;   // флаг индикации
            else cbStr4.SelectedIndex = 0;
            //--------------------------------//--------------------------------
            if (getDevSett(devAdr) == 0x92)
            {
                numericOutTime.Value = indataPort1[9] * 0.5M;
                numericOutTime.Increment = 0.5M;
                numericLedActTime.Value = indataPort1[10] * 10;
                numericLedActTime.Increment = 10;
                numericRfidPoolTime.Value = indataPort1[11] * 10;
                numericRfidPoolTime.Increment = 10;
                getDevText(devAdr);
            }
        }
        private void KpiForm()                      // Подготовка формы КПИ
        {
            gbAllControls.Text = "Интерфейсный коммутатор";
            lbType.Text = "Тип коммутатора:";
            tbType.Visible = true;
            lbStr0.Text = "Тип блока питания:";
            lbStr0.Visible = true;
            tbStr0.Visible = true;
            lbStr1.Text = "Адрес устройства:";
            numericDevAdr.Enabled = false;
            numericDevAdr.Visible = true;
            lbStr2.Text = "Скорость линии связи:";
            cbDevBoud.Enabled = false;
            cbDevBoud.Visible = true;
            cbDevBoud.Items.Add("1200");
            cbDevBoud.Items.Add("2400");
            cbDevBoud.Items.Add("4800");
            devAdrInfo();
            if (indataPort1[7] == 1)                // Версия ПО База
            {
                var x = indataPort1[8];
                x &= 0x01;
                if (x > 0) tbType.Text = "КП-";     // Версия ПО (измеритель есть/нет)
                else tbType.Text = "КПИ-";
                switch (indataPort1[9])             // Версия железа
                {
                    case 0:
                        tbType.Text += "Щ";
                        tbStr0.Text = "~/- 20-265 Вольт.";
                            break;
                    case 1:
                        tbType.Text += "Щ";
                        tbStr0.Text = "~/- 7-26 Вольт.";
                            break;
                    case 2:
                        tbType.Text += "Щ";
                        tbStr0.Text = "- 5 Вольт.";
                            break;
                    case 3:
                        tbType.Text += "П";
                        tbStr0.Text = "~/- 20-265 Вольт.";
                            break;
                    case 4:
                        tbType.Text += "П";
                        tbStr0.Text = "~/- 7-26 Вольт.";
                            break;
                    case 5:
                        tbType.Text += "П";
                        tbStr0.Text = "- 5 Вольт.";
                            break;
                }
            }
            lbStr3.Text = "Состояние реле при включении питания:";
            lbStr3.Visible = true;
            cbDevMode.Items.Add("Отключено");
            cbDevMode.Items.Add("Восстановить");
            cbDevMode.Visible = true;
            var y = indataPort1[13];                // Настроечные флаги КПИ
            y &= 0x80;                              // Режим работы реле - сохранять в память состояние или нет
            if (y > 0)
            {
                cbDevMode.SelectedIndex = 1;
            }
            else cbDevMode.SelectedIndex = 0;
            lbStr5.Text = "Максимальный ток:";
            lbStr5.Visible = true;
            y = indataPort1[12];
            y >>= 4;
            numericOutTime.Value = y * 1M;
            y = indataPort1[12];
            y &= 0x0F;
            numericOutTime.Value += y * 0.1M;
            numericOutTime.Increment = 0.1M;
            numericOutTime.Visible = true;

            lbStr6.Text = "Минимальное напряжение:";
            lbStr6.Visible = true;
            numericLedActTime.Value = indataPort1[11];
            numericLedActTime.Increment = 1;
            numericLedActTime.Visible = true;
            lbStr7.Text = "Максимальное напряжение:";
            lbStr7.Visible = true;
            numericRfidPoolTime.Value = indataPort1[10];
            numericRfidPoolTime.Increment = 1;
            numericRfidPoolTime.Visible = true;
            lbStr4.Text = "Защитные функции реле:";
            lbStr4.Visible = true;
            cbStr4.Items.Add("Отключены");
            cbStr4.Items.Add("Превышение тока");
            cbStr4.Items.Add("Ток + напряжение");
            cbStr4.Items.Add("Ток + повыш.напряж.");
            cbStr4.Items.Add("Ток + пониж.напряж.");
            cbStr4.Items.Add("Превышение напряж.");
            cbStr4.Items.Add("Понижение напряж.");
            cbStr4.Visible = true;
            bool curr = getFlag(0x04, indataPort1[13]);
            bool hiVolt = getFlag(0x08, indataPort1[13]);
            bool loVolt = getFlag(0x10, indataPort1[13]);
            if (curr)
            {
                if (!hiVolt && !loVolt)
                {
                    cbStr4.SelectedIndex = 1;         // Контролировать только ток
                }
                else if (hiVolt && !loVolt)
                {
                    cbStr4.SelectedIndex = 3;         // Превышение напряжения + ток
                }
                else if (!hiVolt && loVolt)
                {
                    cbStr4.SelectedIndex = 4;         // Понижение напряжения + ток
                }
                else cbStr4.SelectedIndex = 2;        // Напряжения + ток
            }
            else if (hiVolt && !loVolt) cbStr4.SelectedIndex = 5; // Превышение напряжения
            else if (!hiVolt && loVolt) cbStr4.SelectedIndex = 6; // Понижение напряжения
            else cbStr4.SelectedIndex = 0;            // Контроль отключен
            lbStr8.Text = "Текстовая метка";
            lbStr8.Visible = true;
            getDevText(devAdr);
            tbDevText.Visible = true;
            lbStatID.Text = "Маска управления";
            lbStatID.Visible = true;
            tbMask.Text = "";
            if (getDevMask(devAdr) == 0xF8 && indataPort1[5] == 4)
            {
                KpiMask[0] = indataPort1[6];
                KpiMask[1] = indataPort1[7];
                KpiMask[2] = indataPort1[8];
                KpiMask[3] = indataPort1[9];
                tbMask.Text = MaskToStr(KpiMask[0]);
                tbMask.Text += ' ' + MaskToStr(KpiMask[1]);
                tbMask.Text += ' ' + MaskToStr(KpiMask[2]);
                tbMask.Text += ' ' + MaskToStr(KpiMask[3]);
            }
            tbMask.Visible = true;
            button1.Text = "Упр. Реле";
            button1.Enabled = true;
            button1.Visible = true;
            sze.Width = 93;
            sze.Height = 25;
            button1.Size = sze;
            pnt.X = 145;
            pnt.Y = 294;
            button1.Location = pnt;
            lbVolt.Visible = true;
            lbCurr.Visible = true;
            tbVoltage.Visible = true;
            tbCurr.Visible = true;
            gbAllControls.Visible = true;

        }
        private void IbvForm()                      // Подготовка формы ИБВ-4
        {
            gbAllControls.Text = "Интерфейсный блок ввода";
            lbType.Text = "Тип ИБВ:";
            tbType.Visible = true;
            lbStr0.Text = "Тип блока питания:";
            lbStr0.Visible = true;
            tbStr0.Visible = true;
            lbStr1.Text = "Адрес устройства:";
            numericDevAdr.Enabled = false;
            numericDevAdr.Visible = true;
            lbStr2.Text = "Скорость линии связи:";
            cbDevBoud.Enabled = false;
            cbDevBoud.Visible = true;
            cbDevBoud.Items.Add("1200");
            cbDevBoud.Items.Add("2400");
            cbDevBoud.Items.Add("4800");
            cbDevBoud.Items.Add("9600");
            devAdrInfo();
            if (indataPort1[7] == 1)                // Версия ПО База
            {
                tbType.Text = "ИБВ-4";
                switch (indataPort1[9])             // Версия железа
                {
                    case 0:
                        tbStr0.Text = "~/- 20-265 Вольт.";
                        break;
                    case 1:
                        tbStr0.Text = "~/- 7-26 Вольт.";
                        break;
                    case 2:
                        tbStr0.Text = "- 5 Вольт.";
                        break;
                }
            }
            lbStr3.Text = "Текстовая метка:";
            lbStr3.Visible = true;
            getDevText(devAdr);
            pnt.X = 145;
            pnt.Y = 100;
            tbDevText.Location = pnt;
            tbDevText.Visible = true;
            sze.Height = 49;
            sze.Width = 80;
            pnt.X = 7;
            pnt.Y = 123;
            textBox1.Location = pnt;
            textBox1.Size = sze;
            textBox1.Visible = true;
            pnt.X += 84;
            textBox2.Location = pnt;
            textBox2.Size = sze;
            textBox2.Visible = true;
            pnt.X += 84;
            textBox3.Location = pnt;
            textBox3.Size = sze;
            textBox3.Visible = true;
            pnt.X += 84;
            textBox4.Location = pnt;
            textBox4.Size = sze;
            textBox4.Visible = true;
            gbAllControls.Visible = true;
        }
        private void BrForm()
        {
            gbAllControls.Text = "Блок расширения";
            lbType.Text = "Тип БР:";
            tbType.Visible = true;
            lbStr0.Text = "Тип блока питания:";
            lbStr0.Visible = true;
            tbStr0.Visible = true;
            lbStr1.Text = "Адрес устройства:";
            numericDevAdr.Enabled = false;
            numericDevAdr.Visible = true;
            lbStr2.Text = "Скорость линии связи:";
            cbDevBoud.Enabled = false;
            cbDevBoud.Visible = true;
            cbDevBoud.Items.Add("1200");
            cbDevBoud.Items.Add("2400");
            cbDevBoud.Items.Add("4800");
            cbDevBoud.Items.Add("9600");
            devAdrInfo();
            if (indataPort1[7] == 1)                // Версия ПО База
            {
                tbType.Text = "БР-8К";
                switch (indataPort1[9])             // Версия железа
                {
                    case 0:
                        tbStr0.Text = "~/- 100-265 Вольт.";
                        break;
                    case 1:
                        tbStr0.Text = "~/- 7-26 Вольт.";
                        break;
                    case 2:
                        tbStr0.Text = "- 5 Вольт.";
                        break;
                }
            }
            brTermo = indataPort1[10];
            brTrig = indataPort1[11];
            brInvers = indataPort1[12];
            /*
            lbStr4.Text = "Маска входов - термодатчики:";
            lbStr4.Visible = true;
            sze.Height = 20;
            sze.Width = 115;
            pnt.X = 223;
            pnt.Y = 120;
            textBox1.Location = pnt;
            textBox1.Size = sze;
            textBox1.ReadOnly = false;
            textBox1.Enabled = false;
            br8.MaskTermo = indataPort1[10];
            brTermo = br8.MaskTermo;
            textBox1.Text = MaskToStr(br8.MaskTermo);
            textBox1.Visible = true;
            lbStr5.Text = "Маска входов - триггеры:";
            lbStr5.Visible = true;
            pnt.Y += 20;
            textBox2.Location = pnt;
            textBox2.Size = sze;
            textBox2.ReadOnly = false;
            textBox2.Enabled = false;
            br8.MaskTrig = indataPort1[11];
            brTrig = br8.MaskTrig;
            textBox2.Text = MaskToStr(br8.MaskTrig);
            textBox2.Visible = true;
            lbStr6.Text = "Маска входов - инверсия:";
            lbStr6.Visible = true;
            pnt.Y += 20;
            textBox3.Location = pnt;
            textBox3.Size = sze;
            textBox3.ReadOnly = false;
            textBox3.Enabled = false;
            br8.MaskInvers = indataPort1[12];
            brInvers = br8.MaskInvers;
            textBox3.Text = MaskToStr(indataPort1[12]);
            textBox3.Visible = true;
            */
            lbStr3.Text = "Текстовая метка:";
            lbStr3.Visible = true;
            pnt.X = 145;
            pnt.Y = 100;
            tbDevText.Location = pnt;
            getDevText(devAdr);
            sze.Width = 166;
            sze.Height = 25;
            button1.Size = sze;
            pnt.X = 78;
            pnt.Y = 294;
            button1.Location = pnt;
            button1.Text = "Настройки режима \"Мастер\"";
            button1.Enabled = false;
            button1.BackColor = Color.LightGray;
            button1.Visible = true;
            tbDevText.Visible = true;
            button2.Text = "Вых.1";
            pnt.X = 4;
            pnt.Y = 120;
            button2.Location = pnt;
            sze.Width = 42;
            sze.Height = 35;
            button2.Size = sze;
            button2.Visible = true;
            button3.Text = "Вых.2";
            pnt.X += 42;
            button3.Location = pnt;
            button3.Size = sze;
            button3.Visible = true;
            button4.Text = "Вых.3";
            pnt.X += 42;
            button4.Location = pnt;
            button4.Size = sze;
            button4.Visible = true;
            button5.Text = "Вых.4";
            pnt.X += 42;
            button5.Location = pnt;
            button5.Size = sze;
            button5.Visible = true;
            button6.Text = "Вых.5";
            pnt.X += 42;
            button6.Location = pnt;
            button6.Size = sze;
            button6.Visible = true;
            button7.Text = "Вых.6";
            pnt.X += 42;
            button7.Location = pnt;
            button7.Size = sze;
            button7.Visible = true;
            button8.Text = "Вых.7";
            pnt.X += 42;
            button8.Location = pnt;
            button8.Size = sze;
            button8.Visible = true;
            button9.Text = "Вых.8";
            pnt.X += 42;
            button9.Location = pnt;
            button9.Size = sze;
            button9.Visible = true; 

            gbAllControls.Visible = true;
        }

        private void UncnownWrk()
        {
            devType = 0;
            gbUncnown.Visible = true;
            tbUnDevInfo.ResetText();
            var i = 6;
            while (i < 14)
            {
                tbUnDevInfo.Text += HexToStr(indataPort1[i++]);
            }

        }
        private void UnDisplay()
        {
            tbUnStatus.ResetText();
            var i = 0;
            while (i++ < devStatus[0])
            {
                tbUnStatus.Text += HexToStr(devStatus[i]);
            }
        }
        private void displayDevInfo(byte type)      // Переключатель экранов в зависимости от типа девайса
        {
            devType = type;
            switch (type)
            {
                case 0:
                    allFormDisable();
                    UncnownWrk();
                    break;
                case 0x01:    // 0x01 - КПИ
                    KpiForm();
                    break;
                case 0x02:    // 0x02 - ИБВ-4
                    IbvForm();
                    break;
                case 0x04:    // 0x02 - ИБВ-4
                    BrForm();
                    break;
                case 0x0B:    // 0x0B - Считыватели RFID
                    RfidForm();
                    break;
                default:
                    UncnownWrk();
                    break;
            }
        }

        // Конвертеры ---------------------------------------------------------------------------------------
        private string AsciiToString(byte[] indataPort1, int ofset, byte len)   // Конвертер ASCII в строку
        {
            String retStr = "";
            char x;
            while(indataPort1[ofset] != 0 && len > 0)
            {
                x = (char)indataPort1[ofset];
                if (x > 0xBF)
                {
                    x += (char)0x0350;
                }
                retStr += x;
                ofset++;
                len--;
            }
            return retStr;
        }
        private byte ChrToASCII(char symb)                                      // Конвертер Char -> ASCII
        {
            byte res;
            if (symb >= 'А')
            {
                symb -= 'А';
                symb += (char)0xC0;
            }
            res = (byte)symb;
            return res;
        }
        private string HexToStr(byte data)          // Конвертер HEX в 2 символьную строку + пробел
        {
            var a = data;
            char ch = '0';
            a >>= 4;
            if (a > 9)
            {
                a += 7;
                while (a-- > 0) ch++;
            }
            else ch += (char)a;
            string str = ch.ToString();
            data &= 0x0F;
            ch = '0';
            if (data > 9)
            {
                data += 7;
                while (data-- > 0) ch++;
            }
            else ch += (char)data;
            str += ch.ToString();
            return str + ' ';
        }
        public byte getBit(byte data)               // На входе число от 0 до 7, на выходе маска с соответствующим битом
        {
            byte mask = 1;
            if (mask > 7) return 0;
            while (data-- > 0)
            {
                mask <<= 1;
            }
            return mask;
        }
        public bool getFlag(byte flag, byte reg)    // Проверка наличия указанного бита в байте
        {
            reg &= flag;
            if (reg > 0) return true;
            return false;
        }
        // Настроечные команды девайсу-----------------------------------------------------------------------
        private void KpiSetCmd(byte adr)                    // Форматирование настроечной команды КПИ девайсу
        {
            cmd[0] = adr;
            cmd[1] = 0x0F;
            cmd[2] = (byte)numericDevAdr.Value;
            cmd[3] = getBit((byte)cbDevBoud.SelectedIndex);     // Флаги
            cmd[3] >>= 1;
            if (cbDevMode.SelectedIndex == 1) cmd[3] |= 0x80;   // Состояние при включении
            switch (cbStr4.SelectedIndex)
            {
                case 0:
                    cmd[3] &= 0xE3;                             // Отключить все флаги контроля
                    break;
                case 1:
                    cmd[3] |= 0x04;                             // Контроль тока
                    break;
                case 2:
                    cmd[3] |= 0x1C;                             // Контроль превышения тока и оба уровня напряжения
                    break;
                case 3:
                    cmd[3] |= 0x0C;                             // Контроль превышения тока и превышения напряжения
                    break;
                case 4:
                    cmd[3] |= 0x14;                             // Контроль превышения тока и понижения напряжения
                    break;
                case 5:
                    cmd[3] |= 0x08;                             // Контроль превышения напряжения
                    break;
                case 6:
                    cmd[3] |= 0x10;                             // Контроль понижения напряжения
                    break;
            }
            if (!KpiStrToMask()) return;                        // Маска включения
            cmd[4] = KpiMask[0];
            cmd[5] = KpiMask[1];
            cmd[6] = KpiMask[2];
            cmd[7] = KpiMask[3];
            cmd[8] = (byte)numericOutTime.Value;                // Значения тока
            var x = (int)((numericOutTime.Value - cmd[8]) * 10);
            cmd[8] <<= 4;
            cmd[8] += (byte)x;
            cmd[9] = (byte)numericLedActTime.Value;             // Значения минимального напряжения
            cmd[10] = (byte)numericRfidPoolTime.Value;          // Значения максимального напряжения
            cmd[11] = 0;
            if (portal_1(cmd, 12, 300) == 0x8F)
            {
                MessageBox.Show("Настройки сохранены.");
            }
            else MessageBox.Show("Сохранение не удалось. Повторите попытку");
        }
        public void Ibv4SetCmd(byte devAdr)
        {
            cmd[0] = devAdr;
            cmd[1] = 0x0F;
            cmd[2] = (byte)numericDevAdr.Value;
            cmd[3] = getBit((byte)cbDevBoud.SelectedIndex);     // Флаги
            cmd[3] >>= 1;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 4, tmout) == 0x8F)
            {
                MessageBox.Show("Настройки сохранены.");
            }
            else MessageBox.Show("Сохранение не удалось. Повторите попытку");

        }
        public bool BrSetCmd()
        {
            cmd[0] = devAdr;
            cmd[1] = 0x0F;
            cmd[2] = (byte)numericDevAdr.Value;
            cmd[3] = 0;
            if (cbDevBoud.SelectedIndex == 1) cmd[3] |= 0x01;
            else if (cbDevBoud.SelectedIndex == 2) cmd[3] |= 0x02;
            else if (cbDevBoud.SelectedIndex == 3) cmd[3] |= 0x04;
            cmd[4] = brTermo;
            cmd[5] = brTrig;
            cmd[6] = brInvers;
            var tmout = 150;
            if (port1.BaudRate < 4800) tmout = 400;
            if (portal_1(cmd, 7, tmout) == 0x8F) return false;
            else return true;
        }
        private void RfidSetCmd()                   // Форматирование настроечной команды RFID считывателю
        {
            cmd[0] = devAdr;
            cmd[1] = 0x0F;
            cmd[2] = (byte)numericDevAdr.Value;
            cmd[4] = getBit((byte)cbDevBoud.SelectedIndex);
            cmd[4] >>= 1;
            cmd[3] = (byte)cbStr4.SelectedIndex; //
            cmd[3] <<= 3;
            cmd[4] += cmd[3];
            cmd[3] = 0;
            if (rfidVer == 1 || rfidVer == 0x10)                             // Поправка индекса для считывателей без СКУД
            {
                if (cbDevMode.SelectedIndex == 0) cmd[4] += 0x40;                   // Режим Wiegand26
                else if (cbDevMode.SelectedIndex == 1) cmd[4] += 0x80;              // Режим Wiegand34
                else if (cbDevMode.SelectedIndex == 3) cmd[4] += 0x20;              // Режим iButton
            }
            else
            {
                if (cbDevMode.SelectedIndex == 0) cmd[4] += 0x10;                   // Режим СКУД
                else if (cbDevMode.SelectedIndex == 1) cmd[4] += 0x40;              // Режим Wiegand26
                else if (cbDevMode.SelectedIndex == 2) cmd[4] += 0x80;              // Режим Wiegand34
                else if (cbDevMode.SelectedIndex == 4) cmd[4] += 0x20;              // Режим iButton
            }
            decimal x = numericOutTime.Value / 0.5M;
            cmd[5] = (byte)x;
            x = numericLedActTime.Value / 10;
            cmd[6] = (byte)x;
            x = numericRfidPoolTime.Value / 10;
            cmd[7] = (byte)x;
            var tmout = 300;
            if (port1.BaudRate < 4800) tmout = 450;
            if (portal_1(cmd, 8, tmout) == 0x8F)
            {
                MessageBox.Show("Настройки сохранены. Устройство будет перезапущено");
            }
            else MessageBox.Show("Сохранение не удалось. Повторите попытку");
        }
        private void devSaveTextLabel()             // Форматирование команды текстовой метки
        {
            if (TextChng)
            {
                TextChng = false;
                cmd[0] = devAdr;
                cmd[1] = 0x10;
                if (tbDevText.TextLength < 32) {
                    cmd[2] = (byte)tbDevText.TextLength;
                    for (int i = 0; i < tbDevText.TextLength; i++)
                    {
                        cmd[i + 3] = ChrToASCII(tbDevText.Text[i]);
                    }
                    byte len = cmd[2];
                    len += 3;
                    portal_1(cmd, len, len * 25 + 15);
                }
            }
        }
        // ----- Команды в порт -----------------------------------------------------------------------------
        #region Команды в порт
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int len;
            try
            {
                portNewData = true;
                len = port1.BytesToRead;
                port1.Read(indataPort1, rxdLen, len);
                rxdLen += (byte)len;
                ElapsedTime = Stopwatch.GetTimestamp();
         //       ElapsedTime *= ((long)1.0 / Stopwatch.Frequency);   //  - Приведение тиков к реальному времени в секундах
            }
            catch (Exception err)
            {
                portCloseAtrbt();
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte calcCRC8(byte[] buf, byte offset, byte cnt)
        {
            byte crc = 0, i = offset;
            while (i < cnt)
            {
                crc += buf[i++];
            }
            return crc;
        }
        private byte ParseStatus(byte ofset)
        {
            if (rxdLen == 255) rxdLen = 0;         // иногда вылетает исключение
            if (calcCRC8(indataPort1, ofset, rxdLen) == indataPort1[rxdLen]) {
                if (indataPort1[ofset + 1] == 0xF7 || indataPort1[ofset + 1] == 0xFF || (devType == 1 && indataPort1[ofset + 1] == 0x87))//
                {
                    for (var i = 0; i < 9; i++)
                    {
                        devStatus[i] = indataPort1[i + 2 + ofset];
                    }
                    return indataPort1[ofset + 2];              // Вернуть количество байт статусного ответа
                }
            }
      /*      else if (indataPort1[ofset + 1] == 0xF6)
            {
                if (calcCRC8(indataPort1, ofset, 3) == indataPort1[3])
                {
                    devStatus[1] = indataPort1[ofset + 2];
                    KpiStatInfo();
                }
            }*/
            return 0;
        }
        public byte getStat(byte adr)
        {
            cmd[0] = adr;
            cmd[1] = 0x7F;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 2, tmout) == 0xFF)
            {
                adrNumer.Value = devAdr;
                return ParseStatus(3);
            }
            return 0;
        }
        private byte getDevInfo(byte adr)
        {
            cmd[0] = adr;
            cmd[1] = 0x7A;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 2, tmout) == 0xFA) return indataPort1[6];   // Возвращает код типа устройства
            return 0;
        }
        private byte getDevSett(byte adr)
        {
            cmd[0] = adr;
            cmd[1] = 0x12;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 2, tmout) == 0x92) return 0x92;
            return 0;
        }
        private byte getDevText(byte adr)
        {
            cmd[0] = adr;
            cmd[1] = 0x11;
            var tmout = 750;
            if (port1.BaudRate < 4800) tmout = 1500;
            if (portal_1(cmd, 2, tmout) == 0x91)
            {
                tbDevText.Text = "";
                indataPort1[indataPort1[5] + 6] = 0;
                tbDevText.Text = AsciiToString(indataPort1, 6, indataPort1[5]);
                TextChng = false;
                return 0x91;
            }
            return 0;
        }
        private byte getDevMask(byte adr)
        {
            cmd[0] = adr;
            cmd[1] = 0x78;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 2, tmout) == 0xF8) return 0xF8;
            return 0;
        }
        private void RfidSetOut(char clr, bool state)
        {
            timer1.Stop();
            Thread.Sleep(50);
            cmd[0] = devAdr;
            cmd[1] = 0x07;
            cmd[2] = devStatus[3];
            switch(clr)
            {
                case 'R':
                    if (!state) cmd[2] |= 0x01;
                    else cmd[2] &= 0xFE;
                    break;
                case 'B':
                    if (!state) cmd[2] |= 0x04;
                    else cmd[2] &= 0xFB;
                    break;
                case 'O':
                    if (!state) cmd[2] |= 0x80;
                    else cmd[2] &= 0x7F;
                    break;
            }
            devStatus[3] = cmd[2];
            cmd[3] = calcCRC8(cmd, 0, 3);
            rxdLen = 0;
            try
            {
                port1.Write(cmd, 0, 4);
            }
            catch (Exception err)
            {
                portCloseAtrbt();
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Thread.Sleep(50);
            timer1.Start();

        }
        private void KpisetOut(byte adr, bool state)
        {
            cmd[0] = adr;
            cmd[1] = 0x07;
            if (state) cmd[2] = 0xFF;
            else cmd[2] = 0;
            var tmout = 100;
            if (port1.BaudRate < 4800) tmout = 250;
            if (portal_1(cmd, 3, tmout) == 0x87)
            {
                ParseStatus(4);
            }

        }
        public byte portal_1(byte[] sendBuf, byte len, int wait)
        {
            sendBuf[len] = calcCRC8(sendBuf, 0, len);
            rxdLen = 0;
            try
            {
                port1.Write(sendBuf, 0, ++len);
            }
            catch (Exception err)
            {
                portCloseAtrbt();
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Thread.Sleep(wait);
            //port1.Write(indataPort1,0,rxdLen);
            if (rxdLen > 3 && sendBuf[1] + 0x80 == indataPort1[len + 1])
            {
                rxdLen--;
                if (calcCRC8(indataPort1, len, rxdLen) == indataPort1[rxdLen])
                {
                    //port1.Write(indataPort1, len, rxdLen);
                    devAdr = indataPort1[len];
                    return indataPort1[len + 1];            // Возвращает код функции
                }
            }
            return 0;
        }
        private void portCloseAtrbt()
        {
            ChngDisable();
            allFormDisable();
            AllReset();
            rbEth.Enabled = true;
            rbMDB.Enabled = true;
            rbEMDB.Enabled = true;
        }
        #endregion
        //------------------------------------------------------------

        #region Обработчики кнопок, чекбоксов и пр...

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!portNewData)
            {
                while ((Stopwatch.GetTimestamp() - ElapsedTime) < 25000)
                {
                    // пустой цикл ожидания
                }
                if (getStat(devAdr) == 0)
                {
                    if (errResp++ > 10)
                    {
                        try
                        {
                            port1.Close();
                            if (DEBUG_INFO) debugPort.Close();
                        }
                        catch
                        {

                        }
                        portCloseAtrbt();
                        MessageBox.Show("Прибор не отвечает на запросы");
                    }
                }
                else errResp = 0;
            }
            else
            {
                portNewData = false;
                rxdLen--;
                ParseStatus(0);
            }
            tbStatus.Text = "";
            var i = 1;
            var x = devStatus[0];
            while (x-- > 0 && x < devStatus.Length)
            {
                tbStatus.Text += HexToStr(devStatus[i++]);
            }
            switch (devType)
            {
                case 0:
                    UnDisplay();
                    break;
                case 0x01:
                    KpiStatInfo();
                    break;
                case 0x02:
                    ibv.StatInfo(devStatus);
                    ibvStatForm();
                    break;
                case 0x04:
                    brStatForm();
                    break;
                case 0x0B:
                    RfidLedInfo();
                    break;
            }
            
            rxdLen = 0;
            Array.Clear(indataPort1, 0, indataPort1.Length);
            portNewData = false;
        }
        private void timer2_Tick(object sender, EventArgs e)                    // Цикл проверок при открытом порту
        {
            if (port1.IsOpen && rxdLen > 0){
                if ((Stopwatch.GetTimestamp() - ElapsedTime) > 22000)
                {
                    if (DEBUG_INFO) debugPort.Write(indataPort1, 0, 3);
                    if (rxdLen > 100) rxdLen = 0;
                    if (rxdLen > 2 && indataPort1[1] == 0xF6)
                    {
                        if (calcCRC8(indataPort1, 0, 3) == indataPort1[3])
                        {
                            indataPort1[3] = 0;
                            devStatus[1] = indataPort1[2];
                            getStat(devAdr);
                            KpiStatInfo();
                            portNewData = false;
                        }
                    }
                    rxdLen = 0;
                }
            }
        }

        private void adrNumer_ValueChanged(object sender, EventArgs e)
        {
                if (adrNumer.Value > 0) btnChkDev.Text = "Подключить";
                else btnChkDev.Text = "Найти адрес";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericDevAdr.Value == 0) numericDevAdr.Value++;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (devType == 0x0B)
            {
                if (numericOutTime.Value > 127.5M) numericOutTime.Value = 127.5M;
                else
                {
                    decimal x = numericOutTime.Value / 0.5M;
                    x = (int)x;
                    numericOutTime.Value = x * 0.5M;
                }
            }
            else if (devType == 0x01)
            {
                if (numericOutTime.Value > 10M) numericOutTime.Value = 10M;
                else
                {
                    decimal x = numericOutTime.Value / 0.1M;
                    x = (int)x;
                    numericOutTime.Value = x * 0.1M;
                }
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            switch (devType)
            {
                case 0x01:
                    if (numericLedActTime.Value > 254) numericLedActTime.Value = 254;
                    break;
                case 0x0B:
                    if (numericLedActTime.Value > 2550) numericLedActTime.Value = 2550;
                    else
                    {
                        int x = (int)numericLedActTime.Value;
                        x /= 10;
                        numericLedActTime.Value = x * 10;
                    }
                    break;
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            switch (devType)
            {
                case 0x01:
                    if (numericRfidPoolTime.Value > 254) numericRfidPoolTime.Value = 254;
                    break;
                case 0x0B:
                    if (numericRfidPoolTime.Value > 2550) numericRfidPoolTime.Value = 2550;
                    else
                    {
                        int x = (int)numericRfidPoolTime.Value;
                        x /= 10;
                        numericRfidPoolTime.Value = x * 10;
                    }
                    break;
            }
        }

        private void cbRedLed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRedLed.Checked)
            {
                cbRedLed.BackColor = Color.Red;
                cbRedLed.ForeColor = Color.White;
            }
            else
            {
                cbRedLed.BackColor = cbRelay.BackColor;// Color.LightGray;
                cbRedLed.ForeColor = Color.Black;
            }
        }

        private void cbGrnLed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrnLed.Checked)
            {
                cbGrnLed.BackColor = Color.Green;
                cbGrnLed.ForeColor = Color.White;
            }
            else
            {
                cbGrnLed.BackColor = cbRelay.BackColor;// Color.LightGray;
                cbGrnLed.ForeColor = Color.Black;
            }
        }

        private void cbBlLed_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlLed.Checked)
            {
                cbBlLed.BackColor = Color.Blue;
                cbBlLed.ForeColor = Color.White;
            }
            else
            {
                cbBlLed.BackColor = cbRelay.BackColor; // Color.LightGray;
                cbBlLed.ForeColor = Color.Black;
            }
            var x = devStatus[1] & 0x08;
            if (x > 0)
            {
                cbBlLed.Text = "Синий. Активирован режим добавления/удаления карт";
            }
            else cbBlLed.Text = "Синий";
        }

        private void cbRedLed_Click(object sender, EventArgs e)
        {
            if (cbRedLed.Checked) RfidSetOut('R', false);
            else RfidSetOut('R', true);
        }
        
        private void cbBlLed_Click(object sender, EventArgs e)
        {
            if (cbBlLed.Checked) RfidSetOut('B', false);
            else RfidSetOut('B', true);
        }

        private void cbRelay_Click(object sender, EventArgs e)
        {
            if (cbRelay.Checked) RfidSetOut('O', false);
            else RfidSetOut('O', true);
        }

        private void btnChkDev_Click(object sender, EventArgs e)                // Кнопка "Подключить"
        {
            if (PortStat == true)
            {
                portCloseAtrbt();
                try
                {
                    port1.Close();
                    if (DEBUG_INFO) debugPort.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (cbPort.Items.Count == 0)
                    {
                        MessageBox.Show("Не найдены порты в системе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    port1.PortName = cbPort.Text; //  "COM5"
                }
                catch (Exception err)
                {
                    portCloseAtrbt();
                    MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                pbStatus.Value = 0;
                pbStatus.ForeColor = Color.Aqua;
                while (pbStatus.Value != 100)
                {
                    pbStatus.Value += 20;
                    switch (pbStatus.Value)
                    {
                        case 20: port1.BaudRate = 1200; break;
                        case 40: port1.BaudRate = 2400; break;
                        case 60: port1.BaudRate = 4800; break;
                        case 80: port1.BaudRate = 9600; break;
                        case 100: port1.BaudRate = 19200; break;
                    }
                    try
                    {
                        rxdLen = 0;
                        port1.Open();
                       if (DEBUG_INFO) debugPort.Open();
                    }
                    catch (Exception err)
                    {
                        portCloseAtrbt();
                        MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (getStat((byte)adrNumer.Value) > 0)
                    {
                        rbEth.Enabled = false;
                        rbMDB.Enabled = false;
                        rbEMDB.Enabled = false;
                        AllRight();
                        displayDevInfo(getDevInfo(devAdr));
                        timer1.Interval = 500;
                        timer1.Start();
                        timer2.Interval = 10;
                        timer2.Start();
                        break;
                    }
                    else
                    {
                        try
                        {
                            port1.Close();
                            if (DEBUG_INFO) debugPort.Close();
                        }
                        catch (Exception err)
                        {
                            portCloseAtrbt();
                            MessageBox.Show(err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (!port1.IsOpen) AllReset();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)               // Кнопка "Настроить" "Сохранить"
        {
            if (btnSetting.Text == "Настроить")
            {
                btnSetting.Text = "Cохранить";
                ChngEnable();
                tbMask.Enabled = true;
            }
            else
            {
                devSaveTextLabel();
                switch (devType)
                {
                    case 0x01:
                        KpiSetCmd(devAdr);
                        break;
                    case 0x02:
                        Ibv4SetCmd(devAdr);
                        break;
                    case 0x04:
                        BrSetCmd();
                        break;
                    case 0x0B:
                        RfidSetCmd();
                        break;
                }
                btnSetting.Text = "Настроить";
                ChngDisable();
                TextChng = false;
            }
        }

        private void rbUART_Click(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            cbPort.Items.AddRange(items: SerialPort.GetPortNames());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.LightGray)
            {
                KpisetOut(brOutAdr(), true);
                button2.BackColor = Color.Green;
                devStatus[2] |= 0x01;
            }
            else
            {
                KpisetOut(brOutAdr(), false);
                button2.BackColor = Color.LightGray;
                devStatus[2] &= 0xFE;
            }
       }
        private void button3_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 1;
            if (button3.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button3.BackColor = Color.Green;
                devStatus[2] |= 0x02;
            }
            else
            {
                KpisetOut(adr, false);
                button3.BackColor = Color.LightGray;
                devStatus[2] &= 0xFD;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 2;
            if (button4.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button4.BackColor = Color.Green;
                devStatus[2] |= 0x04;
            }
            else
            {
                KpisetOut(adr, false);
                button4.BackColor = Color.LightGray;
                devStatus[2] &= 0xFB;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 3;
            if (button5.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button5.BackColor = Color.Green;
                devStatus[2] |= 0x08;
            }
            else
            {
                KpisetOut(adr, false);
                button5.BackColor = Color.LightGray;
                devStatus[2] &= 0xF7;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 4;
            if (button6.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button6.BackColor = Color.Green;
                devStatus[2] |= 0x10;
            }
            else
            {
                KpisetOut(adr, false);
                button6.BackColor = Color.LightGray;
                devStatus[2] &= 0xEF;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 5;
            if (button7.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button7.BackColor = Color.Green;
                devStatus[2] |= 0x20;
            }
            else
            {
                KpisetOut(adr, false);
                button7.BackColor = Color.LightGray;
                devStatus[2] &= 0xDF;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 6;
            if (button8.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button8.BackColor = Color.Green;
                devStatus[2] |= 0x40;
            }
            else
            {
                KpisetOut(adr, false);
                button8.BackColor = Color.LightGray;
                devStatus[2] &= 0xBF;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            byte adr = brOutAdr();
            adr += 7;
            if (button9.BackColor == Color.LightGray)
            {
                KpisetOut(adr, true);
                button9.BackColor = Color.Green;
                devStatus[2] |= 0x80;
            }
            else
            {
                KpisetOut(adr, false);
                button9.BackColor = Color.LightGray;
                devStatus[2] &= 0x7F;
            }
        }
        private void cbPort_Click(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            cbPort.Items.AddRange(items: SerialPort.GetPortNames());
        }

        private void btnRelay_Click(object sender, EventArgs e)
        {
            if (devType == 1)           // КПИ реле
            {
                if (!KpiStatHand && !KpiStatCurrAlrm && !KpiStatLoAlrm && !KpiStatHiAlrm) KpisetOut(devAdr, !KpiStatRelay);
                else
                {
                    KpisetOut(devAdr, KpiStatRelay);
                    KpisetOut(devAdr, !KpiStatRelay);
                }
                KpiStatInfo();
            }
            else if (devType == 4)      // БР-8К блок расширения
            {
                timer1.Stop();
                Form2 tempForm = new Form2(this);
                tempForm.ShowDialog();   
                if(tempForm.errFl == false)
                {
                    btnSetting.Text = "Настроить";
                    ChngDisable();
                    TextChng = false;
                }
                timer1.Start();
            }
        }

        private void tbTextLabel_TextChanged(object sender, EventArgs e)
        {
            TextChng = true;
        }

    }
    #endregion

}
