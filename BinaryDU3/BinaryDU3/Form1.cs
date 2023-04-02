using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BinaryDU3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("texty.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("windows-1250"));
            bw.Write("Toto je první věta. Tohle druhá.");
            bw.Write("Tady je druhý řádek. To je ale pěkné.");
            bw.Write("A tady je řádek poslední. Třetí.");
            BinaryReader br = new BinaryReader(fs, Encoding.GetEncoding("windows-1250"));
            br.BaseStream.Position = 0;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox1.Items.Add(br.ReadString());
            }
            fs.Close();
            fs = new FileStream("texty.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs, Encoding.GetEncoding("windows-1250"));
            foreach(string str in listBox1.Items)
                bw.Write(str.Replace('.','!'));
            br = new BinaryReader(fs, Encoding.GetEncoding("windows-1250"));
            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox2.Items.Add(br.ReadString());
            }
            fs.Close();
        }
    }
}
