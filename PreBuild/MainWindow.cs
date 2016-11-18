/// Author: Devon
/// Version: 1.1b

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
using System.IO.Directory.CreateDirectory
//using EconomyBot;


namespace TestForm
{
    public partial class Form1 : Form
    {
        
        Boolean WriteFile1 = false;
        Boolean WriteFile2 = false;

        bool is64bit = !string.IsNullOrEmpty(
           Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
        
        // used to setup file location to system architecture 
        if(is64bit) {
           Dim Path as String = "c:/ProgramFiles(x86)/EconomyBot/";
        }else {
           Dim Path as String = "c:/ProgramFiles/EconomyBot";
        }


        // Required when running a Windows Form Application
        public Form1()
        {  
            InitializeComponent();
        }

        static void WriteFile(string Filename, string Message)
        {
            FileStream fs1 = new FileStream(@Path+"/doctype.txt", FileMode.Append, FileAccess.Write); // FileStream((String)FileName, FileMode.Type, FileAccess.Type)
            FileStream fs2 = new FileStream(@Path+"/server.txt", FileMode.Create, FileAccess.Write); // FileStream((String)FileName, FileMode.Type, FileAccess.Type)       
            if(WriteFile1 == true && WriteFile2 == false) 
            {     
                if(fs.CanWrite)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(Message);
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Write(newline, 0, newline.Length);
                    // Writes string to a byte array converting to ASCII 
                    // Allows the .txt to be able to read the array

                }

                fs.Flush();
                fs.Close();
                // Closes and cleans memory for use
                WriteFile1 = false;
                WriteFile2 = false;
            }
        }else if(WriteFile2 == true && WriteFile1 == false) 
        {
         if(fs.CanWrite)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(Message);
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Write(newline, 0, newline.Length);
                    // Writes string to a byte array converting to ASCII 
                    // Allows the .txt to be able to read the array

                }

                fs.Flush();
                fs.Close();
                // Closes and cleans memory for use
            }
        }

        static void ReadFile(string Filename)
        {
            FileStream fs = new FileStream(Filename, FileMode.Open, FileAccess.Read); // FileStream((String)FileName, FileMode.Type, FileAccess.Type)
            if (fs.CanRead) { 
            byte[] buffer = new byte[fs.Length]; // Byte Array
            int bytesread = fs.Read(buffer, 0, buffer.Length); // Reading from the first byte to the listed buffer length

            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesread)); // Debug purposes
        }
            fs.Close(); // Closes the read
        }


        // Event Handler for when Button1 is Clicked
        private void button1_Click(object sender, EventArgs e)
        {
            String wording;
            string Filename = @"C:\test\doc.txt"; // Defining a file location and name
            MessageBox.Show("Hello World"); // Test with MessageBoxes
            //button1.Visible = boolean
            //textBox1.Text = DateTime.Now.ToString();
            wording = textBox1.Text; // Test for applying text to a text field
            WriteFile(Filename, wording); // Use for testing currently
            MultiCode(); // Puts the process on another thread
        }
        public void FileSetup(String TempString) 
        {
            textBox1.Text = TempString; // Getter/Setter
        }
        public async Task<int> MultiCode() 
        {
        EconomyBot.MyBot bot = new EconomyBot.MyBot(); // Runs a hidden application behind the main application. (WILL CLOSE WITH MAIN APPLICATION)
        }
    }
}
