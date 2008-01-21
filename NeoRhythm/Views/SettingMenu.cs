using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using TripleSoftware.NeoRhythm.Data;
using System.ComponentModel;
using System.Reflection;

namespace TripleSoftware.NeoRhythm.Views
{
    public class SettingMenu : Menu
    {
        BiorhythmCalculator calculator;
        IntPtr owner;

        public SettingMenu(IntPtr owner, BiorhythmCalculator calculator) : base(owner)
        {
            this.calculator = calculator;
            this.owner = owner;
            MenuPage item = new MenuPage();

            base.ImageList = ImageList.FromResource(Assembly.GetExecutingAssembly(), "TripleSoftware.NeoRhythm.Resource.resources", "tool", 48);

            base.TabPages.Add(item);
            
            item.Buttons[0].ImageIndex = 0;
            item.Buttons[0].Text = "Set Birthday";
            item.Buttons[0].Click += new CancelEventHandler(birthdayClick);
            item.Buttons[0].Enabled = true;
            item.Buttons[1].ImageIndex = 1;
            item.Buttons[1].Text = "Set day";
            item.Buttons[1].Click += new CancelEventHandler(setdayClick);
            item.Buttons[1].Enabled = true;
            item.Buttons[2].ImageIndex = 2;
            item.Buttons[2].Text = "About";
            item.Buttons[2].Click += new CancelEventHandler(aboutClick);
            item.Buttons[2].Enabled = true;
            
            base.CloseViewSweep.Enabled = true;
            base.CloseViewSweep.Occurred +=new CancelEventHandler(CloseViewSweep_Occurred);


        }

        void  CloseViewSweep_Occurred(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
             
        }


        void  birthdayClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            DatePicker datePicker = new DatePicker(owner);
            datePicker.Title.Text = "Enter your birthdate";
            datePicker.Value = calculator.BirthDate;
            if (datePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                calculator.BirthDate = datePicker.Value;

            datePicker.Dispose();
        }

        void setdayClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            DatePicker datePicker = new DatePicker(owner);
            datePicker.Title.Text = "Enter date";
            datePicker.Value = calculator.CurrentDate;
            if (datePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                calculator.CurrentDate = datePicker.Value;

            datePicker.Dispose();
        }
        
        void aboutClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show(owner, "For Neonode N2\n\n\x00a9 2008 Triple Software \n\n Coded by Remmelt Koenes", "NeoRhythm " + Assembly.GetExecutingAssembly().GetName().Version);
        } 

    }
}
