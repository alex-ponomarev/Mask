using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        ClassLibrary1.Component1.Mask worker = new ClassLibrary1.Component1.Mask();
        ClassLibrary1.MathMetods raplacer = new ClassLibrary1.MathMetods();
        public Form1()
        {
            InitializeComponent();            
            worker.Masked = " ||      ||      ||";
            textBox1.Text = worker.Masked;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            raplacer.NoticeRaplace(worker.DataValid, textBox2);
        }

        private void userControl11_NumEv(object sender, ClassLibrary1.UserControl1.Number e)
        {
            worker.CursorPosition = textBox1.SelectionStart;
            worker.NewChar = Char.Parse(e.Num.ToString());
            textBox1.Text = worker.CharReplace;
            textBox1.SelectionStart = worker.CursorPosition;
        }

        private void userControl11_ClearEvent(object sender, ClassLibrary1.UserControl1.Clearing e)
        {
            worker.CursorPosition = textBox1.SelectionStart;
            worker.UserComponentDeleteEvent = e.ClearVariants;
            textBox1.Text = worker.UserComponentDeleteEvent;
            textBox1.SelectionStart = worker.CursorPosition;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                worker.CursorPosition = textBox1.SelectionStart;
                textBox1.Text = worker.Delete;
                textBox1.SelectionStart = worker.CursorPosition;
            }
            else {
                worker.CursorPosition = textBox1.SelectionStart;
                worker.NewChar = e.KeyChar;
                textBox1.Text = worker.CharReplace;
                textBox1.SelectionStart = worker.CursorPosition;
            }


          
            





        }
    }
}
