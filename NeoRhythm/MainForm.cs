using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using WinForms = System.Windows.Forms;
using TripleSoftware.NeoRhythm.Views;
using TripleSoftware.NeoRhythm.Data;


namespace TripleSoftware.NeoRhythm
{
    class MainForm : Form
    {
        private StandardGraphView standardGraphView;
        //ExtraGraphView extraGraphView = new ExtraGraphView();
        private PercentageView percentageView;
        private SettingMenu settingsMenu;


        BiorhythmCalculator calculator;

        TabView tabView;

        public MainForm()
        {
            calculator = new BiorhythmCalculator();
            calculator.Load();


            standardGraphView = new StandardGraphView(calculator);
            percentageView = new PercentageView(calculator);
            settingsMenu = new SettingMenu(this.Handle, calculator);

            tabView = new TabView(this.Handle);
            
            tabView.TabPages.Add(new TabPage(standardGraphView, "Standard"));
            //tabView.TabPages.Add(new TabPage(extraGraphView, "Extra"));
            tabView.TabPages.Add(new TabPage(percentageView, "Percentage"));
            tabView.ToolsSweep.Enabled = true;
            tabView.ToolsSweep.Occurred += new System.ComponentModel.CancelEventHandler(ToolsSweep_Occurred);

            percentageView.ToolsSweep.Enabled = true;
            percentageView.ToolsSweep.Occurred += new System.ComponentModel.CancelEventHandler(ToolsSweep_Occurred);

            standardGraphView.ToolsSweep.Enabled = true;
            standardGraphView.ToolsSweep.Occurred += new System.ComponentModel.CancelEventHandler(ToolsSweep_Occurred);

            tabView.Closed += new EventHandler(OnClose);

            this.Load += new EventHandler(MainForm_Load);
        }

        void ToolsSweep_Occurred(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            settingsMenu.Show();
        }

        private void OnClose(object sender, EventArgs e)
        {
            calculator.Save();
            WinForms.Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabView.SelectedIndex = 0;
            standardGraphView.Show();
            tabView.Show();
            if (calculator.BirthDate == DateTime.MinValue)
            {
                DatePicker datePicker = new DatePicker(tabView); 
                datePicker.Title.Text = "Enter your birthdate";
                datePicker.Value = calculator.BirthDate;
                if (datePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    calculator.BirthDate = datePicker.Value;

                datePicker.Dispose();
            }
        }

    }
}
