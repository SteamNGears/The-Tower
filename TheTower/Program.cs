using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TheTower
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartGame());
        }
    }
}
