using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Runtime.InteropServices;

namespace Dead_Island_Riptide_Cheat
{
    public partial class DeadIslandRiptideCheatTrainer : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );


        public Point mouseLocation;



        Mem mMemLib = new Mem();
        public DeadIslandRiptideCheatTrainer()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void DeadIslandRiptideCheatTrainer_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            if (mMemLib.OpenProcess("DeadIslandRiptideGame"))
            {
                label2.ForeColor = Color.Green;
                label2.Text = "Spiel gefunden";
            }
            
            Thread TH = new Thread(WriteMemory);
            Thread FT = new Thread(WriteMemory2);
            Thread HK = new Thread(WriteMemory3);
            Thread UA = new Thread(WriteMemory4);
            Thread UF = new Thread(WriteMemory5);

            TH.Start();
            FT.Start();
            HK.Start();
            UA.Start();
            UF.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }



        private void button2_Click_2(object sender, EventArgs e)
        {
            if (button2.Enabled)
            {
                mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x01281C08,20,30,20,80", "int", "24396500");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Enabled)
            {
                mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x012822C8,D20,180,BC8", "int", "999999999");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void WriteMemory()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x012822F8,628,48,20,D04", "int", "2131741184");
                }

                Thread.Sleep(1);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void WriteMemory2()
        {
            while (true)
            {
                if (checkBox2.Checked)
                {
                    mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x012822F8,158,88,50", "int", "1337");
                }

                Thread.Sleep(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                Close();
            }
        }



        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WriteMemory3()
        {

            /*weitere pointer offsets für haltbarkeit
             * 1. "gamedll_x64_rwdi.dll+0x0128BA58,208,9B8,18,8,54"
             * 2. "gamedll_x64_rwdi.dll+0x0128BA58,208,40,0,978,54"
             * 3. "gamedll_x64_rwdi.dll+0x0128BA58,208,9B8,20,978,54"
             * 
             * Standart haltbarkeit upgrade 4 BBQ waffe 1119944730
             */
            while (true)
            {
                if (checkBox3.Checked)
                {
                    mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x0128BA58,208,9B8,18,8,54", "int", "2119944730");
                }

                Thread.Sleep(1);
            }
        }

        private void WriteMemory4()
        {

            /*
             * weitere pointer offsets für die Ausdauer
             * 1. "engine_x64_rwdi.dll+0x00A51F58,280,128,30,20,D94"
             * 2. "engine_x64_rwdi.dll+0x00A6F7C8,510,128,30,20,D94"
             * 3. "engine_x64_rwdi.dll+0x00A6F7D0,510,128,30,20,D94"
             * 4. "gamedll_x64_rwdi.dll+0x01281860,48,38,268,0,D5C"
             * 5. "gamedll_x64_rwdi.dll+0x012824D0,8,3B8,C0,60,D5C"
             * 6. "gamedll_x64_rwdi.dll+0x012824C0,10,3B8,C0,60,D5C"
             * 
             * Standart Ausdauer wert ohne upgrades 1065353216
             */
            while (true)
            {
                if (checkBox4.Checked)
                {
                    mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x012824D0,8,3B8,C0,60,D5C", "int", "1065353216");
                }

                Thread.Sleep(1);
            }
        }
        private void WriteMemory5()
        {

            /*
             * pointer offsets für flashlight
             * 
             * value: 1120403456
             * 
             * 1. "gamedll_x64_rwdi.dll+0x012822C8,D20,180,48,20,8B8,68"
             * 2. "gamedll_x64_rwdi.dll+0x013271B0,A50,50,D88,48,20,8B8,68"
             *    "gamedll_x64_rwdi.dll+0x012822C8,A50,50,AA8,48,20,8B8,68"
             *    "gamedll_x64_rwdi.dll+0x013271B0,A50,50,8A0,48,20,8B8,68"
             *    "gamedll_x64_rwdi.dll+0x012822C8,D20,180,48,B8,20,8B8,68"
             *    "gamedll_x64_rwdi.dll+0x013271B0,A50,50,ED8,8,20,8B8,68"
             *    "gamedll_x64_rwdi.dll+0x01246118,18,48,20,40,0,880,68"
             */
            while (true)
            {
                if (checkBox5.Checked)
                {
                    mMemLib.WriteMemory("gamedll_x64_rwdi.dll+0x013271B0,A50,50,D88,48,20,8B8,68", "int", "1120403456");
                }

                Thread.Sleep(1);
            }
        }
    }
}