using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;

using TripleSoftware.NeoRhtyhm.Views;


namespace TripleSoftware.NeoRhtyhm
{
    class MainForm : Neonode.Forms.Form
    {
        StandardGraphView standardGraphView = new StandardGraphView();
        ExtraGraphView extraGraphView = new ExtraGraphView();
        PercentageView percentageView = new PercentageView();

        TabView tabView;

        public MainForm()
        {
            tabView = new TabView(this.Handle);

            tabView.TabPages.Add(new TabPage(standardGraphView, "Standard"));
            tabView.TabPages.Add(new TabPage(extraGraphView, "Extra"));
            tabView.TabPages.Add(new TabPage(percentageView, "Percentage"));

            this.Load += new EventHandler(MainForm_Load);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabView.SelectedIndex = 0;
            standardGraphView.Show();
            tabView.Show();
            standardGraphView.Invalidate();
        }

    }
}
