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


namespace TestForm
{
    public partial class Form1 : Form
    {
        //EconomyBot.MyBot my = new EconomyBot.MyBot();

        public Form1()
        {
            
            
            InitializeComponent();
        }

        static void WriteFile(string Filename, string Message)
        {
            FileStream fs = new FileStream(Filename, FileMode.Append, FileAccess.Write);

            if(fs.CanWrite)
            {
                byte[] buffer = Encoding.ASCII.GetBytes(Message);
                byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(buffer, 0, buffer.Length);
                fs.Write(newline, 0, newline.Length);


            }

            fs.Flush();
            fs.Close();
        }

        static void ReadFile(string Filename)
        {
            FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            if (fs.CanRead) { 
            byte[] buffer = new byte[fs.Length];
            int bytesread = fs.Read(buffer, 0, buffer.Length);

            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesread));
        }
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String wording;
            string Filename = @"C:\test\doc.txt";
            MessageBox.Show("Hello World");
            //button1.Visible = boolean
            //textBox1.Text = DateTime.Now.ToString();
            wording = textBox1.Text;
            WriteFile(Filename, wording);

            EconomyBot.MyBot bot = new EconomyBot.MyBot();


        }
    }
}
