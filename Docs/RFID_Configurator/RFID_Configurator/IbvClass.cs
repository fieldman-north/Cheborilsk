using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_Configurator
{
    class IbvClass
    {
        public byte IbvTimer { get => ibvTimer; }
        public sbyte Celsium_1 { get => celsium_1; }
        public sbyte Celsium_2 { get => celsium_2; }
        public sbyte Celsium_3 { get => celsium_3; }
        public sbyte Celsium_4 { get => celsium_4; }
        public byte Status { get => status; }
        public byte CntrIn1 { get => cntrIn1; }
        public byte CntrIn2 { get => cntrIn2; }
        public bool In_1_fl { get => in_1_fl; }
        public bool In_1_reg { get => in_1_reg; }
        public bool In_2_fl { get => in_2_fl; }
        public bool In_2_reg { get => in_2_reg; }
        public bool In_3_fl { get => in_3_fl; }
        public bool In_3_reg { get => in_3_reg; }
        public bool In_4_reg { get => in_4_reg; }

        private bool in_1_fl;
        private bool in_1_reg;
        private bool in_2_fl;
        private bool in_2_reg;
        private bool in_3_fl;
        private bool in_3_reg;
        private bool in_4_reg;
        private byte status;
        private byte cntrIn1;
        private byte cntrIn2;
        private byte ibvTimer;
        private sbyte celsium_1;
        private sbyte celsium_2;
        private sbyte celsium_3;
        private sbyte celsium_4;
        //-------------------------------------------------------
        public bool getFlag(byte flag, byte reg)
        {
            reg &= flag;
            if (reg > 0) return true;
            return false;
        }
        public void StatInfo(byte[] data)
        {
            if (data[0] == 8)
            {
                status = data[1];
                in_1_fl = getFlag(0x01, Status);
                in_1_reg = getFlag(0x02, Status);
                in_2_fl = getFlag(0x04, Status);
                in_2_reg = getFlag(0x08, Status);
                in_3_fl = getFlag(0x10, Status);
                in_3_reg = getFlag(0x20, Status);
                in_4_reg = getFlag(0x40, Status);
                cntrIn1 = data[2];
                cntrIn2 = data[3];
                ibvTimer = data[4];
                celsium_1 = (sbyte)data[5];
                celsium_2 = (sbyte)data[6];
                celsium_3 = (sbyte)data[7];
                celsium_4 = (sbyte)data[8];
            }
        }
    }
}
