﻿using System;
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
using System.Text.RegularExpressions; 


namespace Derevia
{
    public partial class Form1 : Form
    {
        public static bool StringIsValid(string str)
        {
            return !string.IsNullOrEmpty(str) && !Regex.IsMatch(str, @"[^a-z]");
        }


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

            string[] t = text.Split(new char[] {' ', '\n', '_', '\t', '\r', '-' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < t.Length; i++)
            {
                Vstavka(t[i].ToLower());
            }
        }
     
        string filename1 = "../../Tests/Python.txt";
        string filename2 = "../../Tests/C.txt";
        string filename3 = "../../Tests/CSH.txt";
        string filename4 = "../../Tests/Java.txt";
        string filename5 = "../../Tests/100000.txt";
        string filename6 = "../../Tests/10000.txt";
        string filename7 = "../../Tests/1000.txt";
        string filename8 = "../../Tests/100.txt";
        int fals;

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
            if (StringIsValid(richTextBox1.Text.ToLower()))
            Vstavka(richTextBox1.Text);
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pt1.Delete1(richTextBox1.Text);
            pt2.Delete2(richTextBox1.Text);
            pt3.Delete3(richTextBox1.Text);
            fals = pt4.Delete4(richTextBox1.Text);

            if (fals == 0) { MessageBox.Show("Данное слово отсутствует в дереве"); }
            else { MessageBox.Show("Данное слово успешно удалено"); }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
           
            
            if (radioButton1.Checked)
               
            {
                DateTime starttime = DateTime.Now;
                fals = pt1.Search1(richTextBox1.Text);
                DateTime endtime = DateTime.Now;
                textBox1.Visible = true;
                textBox1.Text=(endtime - starttime).ToString();
            }

             if (radioButton2.Checked)

             {
                 DateTime starttime = DateTime.Now;
                fals = pt2.Search2( richTextBox1.Text);
                 DateTime endtime = DateTime.Now;
                textBox1.Visible = true;
                textBox1.Text = (endtime - starttime).ToString();
            }
             
            if (radioButton3.Checked)

            {
                DateTime starttime = DateTime.Now;
                fals = pt3.Search3(richTextBox1.Text);
                DateTime endtime = DateTime.Now;
                textBox1.Visible = true;
                textBox1.Text = (endtime - starttime).ToString();
            }

            if (radioButton4.Checked)

            {
                DateTime starttime = DateTime.Now;
                fals = pt4.Search4(richTextBox1.Text);
                DateTime endtime = DateTime.Now;
                textBox1.Visible = true;
                textBox1.Text = (endtime - starttime).ToString();
            }
           
            if (fals==0) { MessageBox.Show("Данное слово отсутсвует в дереве"); }
            else { MessageBox.Show("Данная слово присутствует в дереве"); }


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
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text.ToLower();
                using (StreamWriter sw = new StreamWriter(filename1, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }

        }

        private void ДобавитьСловоВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename3, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }

        }

        private void ДобавитьФайлВБиблиотекуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename2, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }

        }

        private void ДобавитьСловоВБиблиотекуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (StringIsValid(richTextBox1.Text.ToLower()))
            {
                string newZapis = richTextBox1.Text;
                using (StreamWriter sw = new StreamWriter(filename4, true))
                {
                    sw.WriteLine(newZapis);
                }
            }
            else { MessageBox.Show("Вводимая строка должна содержать только буквы латинского алфавита"); }

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

        private void СловToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename6);
        }

        private void СловToolStripMenuItem3_Click(object sender, EventArgs e)
        {

            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename5);
        }

        private void СловToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename7);
        }

        private void СловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt1 = new Trie();
            pt2 = new TST();
            pt3 = new DST();
            pt4 = new BST();

            VstavkaFaila(filename8);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
