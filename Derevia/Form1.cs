using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Derevia;
using System.Windows.Forms;


namespace Derevia
{
    public partial class Form1 : Form

    {
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
            pt2.Insert2(ref pt2.cRoot, richTextBox1.Text);
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
                pt1.Search1(richTextBox1.Text);
                richTextBox2.Text = pt1.Search1(richTextBox1.Text).ToString();
            }

             if (radioButton2.Checked)

             {
                 pt2.Search2(ref pt2.cRoot, richTextBox1.Text);
                 richTextBox2.Text = pt2.Search2(ref pt2.cRoot, richTextBox1.Text).ToString();
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
    }
}
