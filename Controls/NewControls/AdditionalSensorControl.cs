﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner.Utilities;

namespace MissionPlanner.Controls.NewControls
{
    public partial class AdditionalSensorControl : UserControl
    {
        private Binding textBinding;

        public string sensorName
        {
            get { return sensorName_label.Text; }
            set
            {
                sensorName_label.Text = value;
                switch (value)
                {
                    case "Напряжение":
                        textBinding.Format += voltage_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Температура двигателя":
                        textBinding.Format += temp_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Топливо":
                        textBinding.Format += fuel_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Воздушная скорость":
                        textBinding.Format += speed_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Путевая скорость":
                        textBinding.Format += speed_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Высота (СНС)":
                        textBinding.Format += alt_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Следующая точка":
                        textBinding.Format += nextWP_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    case "Сила тока":
                        textBinding.Format += amperage_Format;
                        sensorValue_label.DataBindings.Add(textBinding);
                        break;
                    default:
                        sensorValue = "wrong sensor name";
                        break;
                }
            }
        }

        public string sensorValue
        {
            get { return sensorValue_label.Text; }
            set { sensorValue_label.Text = sensorValue; }
        }

        private void voltage_Format(object sender, ConvertEventArgs e)
        {
            double voltage = (double) e.Value;
            e.Value = voltage.ToString("F2") + " V";
        }

        private void temp_Format(object sender, ConvertEventArgs e)
        {
            double temp = (double) e.Value;
            e.Value = temp.ToString("F1") + "°";
        }

        private void fuel_Format(object sender, ConvertEventArgs e)
        {
            double fuel = (double) e.Value;
            e.Value = fuel.ToString("F2");
        }

        private void speed_Format(object sender, ConvertEventArgs e)
        {
            double speed = (double) e.Value * 3.6;
            e.Value = speed.ToString("F1") + " км/ч";
        }

        private void alt_Format(object sender, ConvertEventArgs e)
        {
            double alt = (double) e.Value;
            e.Value = alt.ToString("F2");
        }

        private void nextWP_Format(object sender, ConvertEventArgs e)
        {
            int nextWP = (int) e.Value;
            e.Value = nextWP.ToString();
        }

        private void amperage_Format(object sender, ConvertEventArgs e)
        {
            double amp = (double) e.Value;
            e.Value = amp.ToString("F2") + " A";
        }

        public AdditionalSensorControl(BindingSource bindingSource)
        {
            textBinding = new Binding("Text", bindingSource, "battery_voltage2",
                true);
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void AdditionalSensorControl_Click(object sender, EventArgs e)
        {
            StatusControlPanel.instance.sensorsStrip_Click(sender, e);
        }
    }
}
