using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenfireLogReader
{
    public partial class skipFileDialog : Form
    {
        private String m_filename = null;

        public String Filename
        {
            set
            {
                if (value != "")
                {
                    m_filename = value;
                    skipText.Text = "An error occurred processing \"" + m_filename + "\". Skip this file?";
                }
                else
                {
                    m_filename = null;
                    skipText.Text = "";
                }
            }
            get
            {
                return this.m_filename;
            }
        }

        public skipFileDialog(String filename)
        {
            InitializeComponent();
            this.Filename = filename;
        }

        public new DialogResult ShowDialog()
        {
            if (m_filename == null)
            {
                throw (new NullReferenceException("The filename has not been set"));
            }
            else
            {
                return base.ShowDialog();
            }
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
