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
        string filename1 = "Python.txt";

        string txt="";

        public string Adres
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        string text; 


        public Form1()
        {
            InitializeComponent();
        }

        Trie pt1 = new Trie();
        TST pt2 = new TST();
        DST pt3 = new DST();
        BST pt4 = new BST();

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            pt1.Insert1(richTextBox1.Text);
            pt2.Insert2(richTextBox1.Text);
            pt3.Insert3(richTextBox1.Text);
            pt4.Insert4(richTextBox1.Text);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pt1.Delete1(richTextBox1.Text);
            pt2.Delete2(richTextBox1.Text);
           // pt3.Delete3(richTextBox1.Text);
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

        private void НайтиФайлВПапкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                this.textBlock.Text = "Picked photo: " + file.Name;
            }
            else
            {
                this.textBlock.Text = "Operation cancelled.";
            }
            */
        }

        private void ПитонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filename1))
            {
                using (StreamWriter sw = new StreamWriter(filename1, false)) { }
            }


            using (StreamReader sr = new StreamReader(filename1))
            {
                text = sr.ReadToEnd();
            }

            string [] mas  = text.Split(' ', '\n', '_');

            for ( int i=0; i<mas.Length;i++ )
            {
                pt1.Insert1(mas[i]);
                pt2.Insert2(mas[i]);
                pt3.Insert3(mas[i]);
                pt4.Insert4(mas[i]);

            }
            
        }

        private void НайтиФайлПоПолномуПутиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form2();
            ifrm.ShowDialog(this); // отображаем Form2
            //this.Hide(); // скрываем Form1 (this - текущая форма)

            
        }
    }
}
