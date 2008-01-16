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
        StandardGraphView standardGraphView;
        //ExtraGraphView extraGraphView = new ExtraGraphView();
        PercentageView percentageView;

        BiorhythmCalculator calculator;

        TabView tabView;

        public MainForm()
        {
            calculator = new BiorhythmCalculator();

            standardGraphView = new StandardGraphView(calculator);
            percentageView = new PercentageView(calculator);

            tabView = new TabView(this.Handle);
            
            tabView.TabPages.Add(new TabPage(standardGraphView, "Standard"));
            //tabView.TabPages.Add(new TabPage(extraGraphView, "Extra"));
            tabView.TabPages.Add(new TabPage(percentageView, "Percentage"));
            
            tabView.Closed += new EventHandler(OnClose);
            
            this.Load += new EventHandler(MainForm_Load);

        }

        private void OnClose(object sender, EventArgs e)
        {
            WinForms.Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabView.SelectedIndex = 0;
            standardGraphView.Show();
            tabView.Show();
        }

    }
}
