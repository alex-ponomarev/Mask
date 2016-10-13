using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class UserControl1 : UserControl
    {

        public class Number : EventArgs
        {
            public int Num { get; set; }
        }
        public delegate void DelEvNum(object sender, Number e);
        public event DelEvNum NumEv;

        public delegate void Clear(object sender, Clearing e);
        public event Clear ClearEvent;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int n = int.Parse(button.Text);
            if (NumEv != null)
            {
                NumEv(this, new Number { Num = n });
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Clearing clear = new Clearing();
            if (button.Text.Equals("C"))
                clear.ClearVariants = "FullClear";
            if (button.Text.Equals("←"))
                clear.ClearVariants = "DeleteLastSymbol";
            ClearEvent(this, clear);
        }
        public class Clearing : EventArgs
        {
            public string ClearVariants { set; get; }
        }
    }
}
