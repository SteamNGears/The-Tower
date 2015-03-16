using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
namespace TheTower
{
    public class ControlWriter : TextWriter
    {
        private TextBox textbox;
        public ControlWriter()
        {
            this.textbox = null;
        }
        public ControlWriter(Control textbox)
        {
            this.textbox = (TextBox)textbox;
        }

        public override void Write(char value)
        {
            textbox.Text += value;
        }

        public override void Write(string value)
        {
            textbox.AppendText(value);
            textbox.SelectionStart = textbox.Text.Length;
            textbox.ScrollToCaret();
        
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
