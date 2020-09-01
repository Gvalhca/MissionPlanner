﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.NewForms;

namespace MissionPlanner.Controls.NewControls
{
    public partial class SNSControl : UserControl
    {
        private SNSInfo snsInfo;
        public SNSControl()
        {
            InitializeComponent();
        }

        private void myButton1_MouseUp(object sender, MouseEventArgs e)
        {
            if (snsInfo != null) 
            {
                snsInfo.Close();
            }
            snsInfo = new SNSInfo();
            snsInfo.Show();
        }
    }
}
