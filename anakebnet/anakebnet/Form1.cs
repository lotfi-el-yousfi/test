using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anakebnet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> read_line(string path)
        {
            List<string> l = new List<string>();

            StreamReader r = new StreamReader(path);
            while (r.EndOfStream == false)
            {
                string[] t = r.ReadLine().Split(';');
                Class1 c = new Class1();

                c.page_url = t[0];
                c.name = t[1];
                c.img = t[2];

                Class1.l.Add(c);
            }
            r.Close();
            return l;
        }
        string read_all(string path)
        {
            string code = "";
            StreamReader r = new StreamReader(path);
            code = r.ReadToEnd();
            r.Close();
            return code;
        }

        string download(string item)
        {
            WebClient w = new WebClient();
            string a = Encoding.ASCII.GetString(w.DownloadData(item));
            return a;
        }
        List<string> serch(string code, string pat)
        {
            List<string> l = new List<string>();
            l = regex_Class.serch(code, pat);
            return l;
        }
        void save(string txt, string path)
        {
            StreamWriter w = new StreamWriter(
            new FileStream(path, FileMode.Open, FileAccess.ReadWrite),
            Encoding.UTF8
            );
            w.Write(txt);
            w.Close();
        }
        string fusion(List<string> l)
        {
            string a = "";

            foreach (var item in l)
            {
                a += l + "\n";
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                read_line(openFileDialog1.FileName);
                dataGridView1.DataSource = Class1.l;
                MessageBox.Show("loaded");
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string a = "";
                saveFileDialog1.ShowDialog();
                foreach (Class1 item in Class1.l)
                {
                    a += "\n" + item.name + ";" + item.img + ";" + item.video;
                }
                save(a, saveFileDialog1.FileName);
                MessageBox.Show("saved");
            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (Class1 item in Class1.l)
            {
                try
                {
                    List<string> a = serch(read_all(item.page_url), @"http://ok.ru/videoembed/............");
                    item.video = a[0];


                    StreamWriter w = new StreamWriter(saveFileDialog1.FileName, true);
                    w.Write("\n" + item.page_url + ";" + item.name + ";" + item.img + ";" + item.video);
                    w.Close();
                }
                catch (Exception)
                {
                }

            }
            MessageBox.Show("j ai fini");

        }
    }
}
