using System;
using System.Windows.Forms;

namespace Device_Configurator
{
    public partial class Form2 : Form
    {
        bool chngLow1, chngLow2, chngLow3, chngLow4, chngLow5, chngLow6, chngLow7, chngLow8;
        bool chngHi1, chngHi2, chngHi3, chngHi4, chngHi5, chngHi6, chngHi7, chngHi8;
        public bool errFl = false;
        Form1 papa;
        public Form2(Form1 papa)
        {
            InitializeComponent();
            this.papa = papa;
            getUstavki();
        }

        private void setUstavki_Click(object sender, EventArgs e)       // Сохранить в память уставки температур
        {
            if (chngLow1) errFl |= tUstavkiToPort(papa.devAdr, 0x15, (byte)numericUpDown1.Value);
            if (chngHi1) errFl |= tUstavkiToPort(papa.devAdr, 0x1A, (byte)numericUpDown16.Value);
            if (chngLow2) errFl |= tUstavkiToPort(papa.devAdr, 0x25, (byte)numericUpDown2.Value);
            if (chngHi2) errFl |= tUstavkiToPort(papa.devAdr, 0x2A, (byte)numericUpDown15.Value);
            if (chngLow3) errFl |= tUstavkiToPort(papa.devAdr, 0x35, (byte)numericUpDown3.Value);
            if (chngHi3) errFl |= tUstavkiToPort(papa.devAdr, 0x3A, (byte)numericUpDown14.Value);
            if (chngLow4) errFl |= tUstavkiToPort(papa.devAdr, 0x45, (byte)numericUpDown4.Value);
            if (chngHi4) errFl |= tUstavkiToPort(papa.devAdr, 0x4A, (byte)numericUpDown13.Value);
            if (chngLow5) errFl |= tUstavkiToPort(papa.devAdr, 0x55, (byte)numericUpDown5.Value);
            if (chngHi5) errFl |= tUstavkiToPort(papa.devAdr, 0x5A, (byte)numericUpDown12.Value);
            if (chngLow6) errFl |= tUstavkiToPort(papa.devAdr, 0x65, (byte)numericUpDown6.Value);
            if (chngHi6) errFl |= tUstavkiToPort(papa.devAdr, 0x6A, (byte)numericUpDown11.Value);
            if (chngLow7) errFl |= tUstavkiToPort(papa.devAdr, 0x75, (byte)numericUpDown7.Value);
            if (chngHi7) errFl |= tUstavkiToPort(papa.devAdr, 0x7A, (byte)numericUpDown10.Value);
            if (chngLow8) errFl |= tUstavkiToPort(papa.devAdr, 0x85, (byte)numericUpDown8.Value);
            if (chngHi8) errFl |= tUstavkiToPort(papa.devAdr, 0x8A, (byte)numericUpDown9.Value);
            ChngFlRst();
            papa.brTermo = 0;
            papa.brTrig = 0;
            papa.brInvers = 0;
            if (comboBox1.SelectedIndex == 1) papa.brTermo |= 0x01;
            else if (comboBox1.SelectedIndex == 2) papa.brTrig |= 0x01;
            if (checkBox1.Checked) papa.brInvers |= 0x01;
            if (comboBox2.SelectedIndex == 1) papa.brTermo |= 0x02;
            else if (comboBox2.SelectedIndex == 2) papa.brTrig |= 0x02;
            if (checkBox2.Checked) papa.brInvers |= 0x02;
            if (comboBox3.SelectedIndex == 1) papa.brTermo |= 0x04;
            else if (comboBox3.SelectedIndex == 2) papa.brTrig |= 0x04;
            if (checkBox3.Checked) papa.brInvers |= 0x04;
            if (comboBox4.SelectedIndex == 1) papa.brTermo |= 0x08;
            else if (comboBox4.SelectedIndex == 2) papa.brTrig |= 0x08;
            if (checkBox4.Checked) papa.brInvers |= 0x08;
            if (comboBox5.SelectedIndex == 1) papa.brTermo |= 0x10;
            else if (comboBox5.SelectedIndex == 2) papa.brTrig |= 0x10;
            if (checkBox5.Checked) papa.brInvers |= 0x10;
            if (comboBox6.SelectedIndex == 1) papa.brTermo |= 0x20;
            else if (comboBox6.SelectedIndex == 2) papa.brTrig |= 0x20;
            if (checkBox6.Checked) papa.brInvers |= 0x20;
            if (comboBox7.SelectedIndex == 1) papa.brTermo |= 0x40;
            else if (comboBox7.SelectedIndex == 2) papa.brTrig |= 0x40;
            if (checkBox7.Checked) papa.brInvers |= 0x40;
            if (comboBox8.SelectedIndex == 1) papa.brTermo |= 0x80;
            else if (comboBox8.SelectedIndex == 2) papa.brTrig |= 0x80;
            if (checkBox8.Checked) papa.brInvers |= 0x80;
            errFl |= papa.BrSetCmd();
            if (!errFl)
            {
                MessageBox.Show("Настройки сохранены успешно!");
                this.Close();
            }
            else MessageBox.Show("Ошибка сохранения");
        }
        private bool tUstavkiToPort(byte adr, byte chnl, byte value)    // Команда записи температурной уставки в порт
        {
            papa.cmd[0] = adr;
            papa.cmd[1] = 0x0E;
            papa.cmd[2] = chnl;
            papa.cmd[3] = value;
            var tmout = 100;
            if (papa.port1.BaudRate < 4800) tmout = 250;
            if (papa.portal_1(papa.cmd, 4, tmout) == 0x8E) return false;
            else return true;
        }
        private void ChngFlRst()                        // Обнулить флаги изменений
        {
            chngLow1 = false;
            chngLow2 = false;
            chngLow3 = false;
            chngLow4 = false;
            chngLow5 = false;
            chngLow6 = false;
            chngLow7 = false;
            chngLow8 = false;
            chngHi1 = false;
            chngHi2 = false;
            chngHi3 = false;
            chngHi4 = false;
            chngHi5 = false;
            chngHi6 = false;
            chngHi7 = false;
            chngHi8 = false;
        }
        private void getUstavki()                       // Прочитать маски и уставки температур из БР-8К
        {
            papa.cmd[0] = papa.devAdr;
            papa.cmd[1] = 0x13;
            var tmout = 100;
            if (papa.port1.BaudRate < 4800) tmout = 300;
            if (papa.portal_1(papa.cmd, 2, tmout) == 0x93)
            {
                numericUpDown1.Value = papa.indataPort1[6];
                numericUpDown16.Value = papa.indataPort1[7];
                numericUpDown2.Value = papa.indataPort1[8];
                numericUpDown15.Value = papa.indataPort1[9];
                numericUpDown3.Value = papa.indataPort1[10];
                numericUpDown14.Value = papa.indataPort1[11];
                numericUpDown4.Value = papa.indataPort1[12];
                numericUpDown13.Value = papa.indataPort1[13];
                numericUpDown5.Value = papa.indataPort1[14];
                numericUpDown12.Value = papa.indataPort1[15];
                numericUpDown6.Value = papa.indataPort1[16];
                numericUpDown11.Value = papa.indataPort1[17];
                numericUpDown7.Value = papa.indataPort1[18];
                numericUpDown10.Value = papa.indataPort1[19];
                numericUpDown8.Value = papa.indataPort1[20];
                numericUpDown9.Value = papa.indataPort1[21];
                ChngFlRst();
                if (papa.getFlag(0x01, papa.brTermo))
                {
                    comboBox1.SelectedIndex = 1;
                    numericUpDown1.Visible = true;
                    numericUpDown16.Visible = true;
                }
                else if (papa.getFlag(0x01, papa.brTrig)) comboBox1.SelectedIndex = 2;
                else comboBox1.SelectedIndex = 0;
                if (papa.getFlag(0x01, papa.brInvers)) checkBox1.Checked = true;
                else checkBox1.Checked = false;
                if (papa.getFlag(0x02, papa.brTermo))
                {
                    comboBox2.SelectedIndex = 1;
                    numericUpDown2.Visible = true;
                    numericUpDown15.Visible = true;
                }
                else if (papa.getFlag(0x02, papa.brTrig)) comboBox2.SelectedIndex = 2;
                else comboBox2.SelectedIndex = 0;
                if (papa.getFlag(0x02, papa.brInvers)) checkBox2.Checked = true;
                else checkBox2.Checked = false;
                if (papa.getFlag(0x04, papa.brTermo))
                {
                    comboBox3.SelectedIndex = 1;
                    numericUpDown3.Visible = true;
                    numericUpDown14.Visible = true;
                }
                else if (papa.getFlag(0x04, papa.brTrig)) comboBox3.SelectedIndex = 2;
                else comboBox3.SelectedIndex = 0;
                if (papa.getFlag(0x04, papa.brInvers)) checkBox3.Checked = true;
                else checkBox3.Checked = false;
                if (papa.getFlag(0x08, papa.brTermo))
                {
                    comboBox4.SelectedIndex = 1;
                    numericUpDown4.Visible = true;
                    numericUpDown13.Visible = true;
                }
                else if (papa.getFlag(0x08, papa.brTrig)) comboBox4.SelectedIndex = 2;
                else comboBox4.SelectedIndex = 0;
                if (papa.getFlag(0x08, papa.brInvers)) checkBox4.Checked = true;
                else checkBox4.Checked = false;
                if (papa.getFlag(0x10, papa.brTermo)) comboBox5.SelectedIndex = 1;
                else if (papa.getFlag(0x10, papa.brTrig)) comboBox5.SelectedIndex = 2;
                else comboBox5.SelectedIndex = 0;
                if (papa.getFlag(0x10, papa.brInvers)) checkBox5.Checked = true;
                else checkBox5.Checked = false;
                if (papa.getFlag(0x20, papa.brTermo)) comboBox6.SelectedIndex = 1;
                else if (papa.getFlag(0x20, papa.brTrig)) comboBox6.SelectedIndex = 2;
                else comboBox6.SelectedIndex = 0;
                if (papa.getFlag(0x20, papa.brInvers)) checkBox6.Checked = true;
                else checkBox6.Checked = false;
                if (papa.getFlag(0x40, papa.brTermo)) comboBox7.SelectedIndex = 1;
                else if (papa.getFlag(0x40, papa.brTrig)) comboBox7.SelectedIndex = 2;
                else comboBox7.SelectedIndex = 0;
                if (papa.getFlag(0x40, papa.brInvers)) checkBox7.Checked = true;
                else checkBox7.Checked = false;
                if (papa.getFlag(0x80, papa.brTermo)) comboBox8.SelectedIndex = 1;
                else if (papa.getFlag(0x80, papa.brTrig)) comboBox8.SelectedIndex = 2;
                else comboBox8.SelectedIndex = 0;
                if (papa.getFlag(0x80, papa.brInvers)) checkBox8.Checked = true;
                else checkBox8.Checked = false;
            }
        }

        #region Регуляшки чейнжи и прочие обработчики контролов
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                numericUpDown1.Visible = true;
                numericUpDown16.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
                numericUpDown16.Visible = false;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                numericUpDown2.Visible = true;
                numericUpDown15.Visible = true;
            }
            else
            {
                numericUpDown2.Visible = false;
                numericUpDown15.Visible = false;
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1)
            {
                numericUpDown3.Visible = true;
                numericUpDown14.Visible = true;
            }
            else
            {
                numericUpDown3.Visible = false;
                numericUpDown14.Visible = false;
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 1)
            {
                numericUpDown4.Visible = true;
                numericUpDown13.Visible = true;
            }
            else
            {
                numericUpDown4.Visible = false;
                numericUpDown13.Visible = false;
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 1)
            {
                numericUpDown5.Visible = true;
                numericUpDown12.Visible = true;
            }
            else
            {
                numericUpDown5.Visible = false;
                numericUpDown12.Visible = false;
            }
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 1)
            {
                numericUpDown6.Visible = true;
                numericUpDown11.Visible = true;
            }
            else
            {
                numericUpDown6.Visible = false;
                numericUpDown11.Visible = false;
            }
        }
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 1)
            {
                numericUpDown7.Visible = true;
                numericUpDown10.Visible = true;
            }
            else
            {
                numericUpDown7.Visible = false;
                numericUpDown10.Visible = false;
            }
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 1)
            {
                numericUpDown8.Visible = true;
                numericUpDown9.Visible = true;
            }
            else
            {
                numericUpDown8.Visible = false;
                numericUpDown9.Visible = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chngLow1 = true;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            chngLow2 = true;
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            chngLow3 = true;
        }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            chngLow4 = true;
        }
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            chngLow5 = true;
        }
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            chngLow6 = true;
        }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            chngLow7 = true;
        }
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            chngLow8 = true;
        }
        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            chngHi1 = true;
        }
        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            chngHi2 = true;
        }
        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            chngHi3 = true;
        }
        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            chngHi4 = true;
        }
        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            chngHi5 = true;
        }
        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            chngHi6 = true;
        }
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            chngHi7 = true;
        }
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            chngHi8 = true;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
#endregion
    }
}
