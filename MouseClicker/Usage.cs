﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClicker
{
    public partial class Usage : Form
    {
        public Usage()
        {
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            MessageBox.Show("asd");
        }
    }
}
