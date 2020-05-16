using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Derevia;
using System.IO;
using System.Windows.Forms;


namespace Derevia
{
    public partial class Form1 : Form
    {
        public void Vstavka(string i)
        {
            pt1.Insert1(i.ToLower());
            pt2.Insert2(i);
            pt3.Insert3(i);
            pt4.Insert4(i);
        }

        public void VstavkaFaila(string a)
        {

            string text;
            using (StreamReader sr = new StreamReader(a))
            {
                text = sr.ReadToEnd();
            }

            string[] t = text.Split(new char[] {' ', '\n', '_', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < t.Length; i++)
            {
                Vstavka(t[i].ToLower());
            }
        }


        string filename1 = "Python.txt";
        string filename2 = "C.txt";
        string filename3 = "CSH.txt";
        string filename4 = "Java.txt";

        public string Adres
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }        

        public Form1()
        {
            InitializeComponent();
        }

        Trie pt1 = new Trie();
        TST pt2 = new TST();
        DST pt3 = new DST();
        BST pt4 = new BST();

        private void Button1_Click(object sender, EventArgs e)
        {
            Vstavka(richTextBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pt1.Delete1(richTextBox1.Text);
            pt2.Delete2(richTextBox1.Text);
            pt3.Delete3(richTextBox1.Text);
            pt4.Delete4(richTextBox1.Text);

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
               
            {
                
                richTextBox2.Text = pt1.Search1(richTextBox1.Text).ToString();
            }

             if (radioButton2.Checked)

             {
                 pt2.Search2( richTextBox1.Text);
                 richTextBox2.Text = pt2.Search2( richTextBox1.Text).ToString();
             }
             
            if (radioButton3.Checked)

            {
                pt3.Search3(richTextBox1.Text);
                richTextBox2.Text = pt3.Search3(richTextBox1.Text).ToString();
            }

            if (radioButton4.Checked)

            {
                pt4.Search4(richTextBox1.Text);
                richTextBox2.Text = pt4.Search4(richTextBox1.Text).ToString();
            }



        }

        private void ЗагрузитьБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename1);
        }

        private void ЗагрузитьБибиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename3);
        }

        private void ЗагрузитьБиблиотекуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename2);
        }

        private void ЗагрузитьБиблиотекуToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename4);
        }

        private void ДобавитьСловоВБиблиоткуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newZapis = richTextBox1.Text;
            using (StreamWriter sw = new StreamWriter(filename1, true))
            {
                sw.WriteLine(newZapis);
            }
        }

        private void ДобавитьСловоВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newZapis = richTextBox1.Text;
            using (StreamWriter sw = new StreamWriter(filename3, true))
            {
                sw.WriteLine(newZapis);
            }
        }

        private void ДобавитьФайлВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newZapis = richTextBox1.Text;
            using (StreamWriter sw = new StreamWriter(filename2, true))
            {
                sw.WriteLine(newZapis);
            }
        }

        private void ДобавитьСловоВБиблиотекуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string newZapis = richTextBox1.Text;
            using (StreamWriter sw = new StreamWriter(filename4, true))
            {
                sw.WriteLine(newZapis);
            }
        }

        private void УдалитьСловоИзБиблиотекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Queue q = new Queue();
            string text;

            using (StreamReader sr = new StreamReader(filename1)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }

            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив

            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }

            using (StreamWriter sw = new StreamWriter(filename1, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }

        private void УдалитьСловоИзБиблиотекеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Queue q = new Queue();
            string text;

            using (StreamReader sr = new StreamReader(filename3)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }

            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t' ,'\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив

            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }

            using (StreamWriter sw = new StreamWriter(filename3, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }

        private void УдалитьСловоИзБиблиотекиToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Queue q = new Queue();
            string text;

            using (StreamReader sr = new StreamReader(filename2)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }

            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r'}, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив

            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }

            using (StreamWriter sw = new StreamWriter(filename2, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }

        private void УдалитьСловоИзБиблиотекиToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            Queue q = new Queue();
            string text;

            using (StreamReader sr = new StreamReader(filename4)) //считываем файл в строку
            {
                text = sr.ReadToEnd();
            }

            string[] t = text.Split(new char[] { ' ', '\n', '_', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries); //сплитим ее в массив

            for (int i = 0; i < t.Length; i++)      //переписываем все в очередь кроме удаляемого элемента
            {
                if (!(t[i] == richTextBox1.Text))
                {
                    q.Enqueue(t[i]);
                }
            }

            using (StreamWriter sw = new StreamWriter(filename4, false)) //чистим очередь перезаписываем в файл
            {
                while (q.Count != 0)
                {
                    sw.WriteLine(q.Dequeue());
                }
            }
        }

        private void ПитонToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2
        }
    }
}
