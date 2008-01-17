using System;
using Neonode.Forms;
using TripleSoftware.NeoRhythm.Data;

namespace TripleSoftware.NeoRhythm.Views
{
	/// <summary>
	/// Description of PercentageView.
	/// </summary>
	public class PercentageView : ListView
	{
		private BiorhythmCalculator calculator;
		
		private ListViewItem physicalListItem;
		private ListViewItem emotionalListItem;
		private ListViewItem intellectualListItem;
        private ListViewItem birthDateListItem;
		
		public PercentageView(BiorhythmCalculator calculator)
		{
			this.calculator = calculator;
            calculator.Updated += new EventHandler(OnCalculatorUpdate);

			this.Title.Text = calculator.CurrentDate.ToShortDateString();

            birthDateListItem = new ListViewItem();
            physicalListItem = new ListViewItem();
            emotionalListItem = new ListViewItem();
            intellectualListItem = new ListViewItem();

            OnCalculatorUpdate(this, EventArgs.Empty);

            birthDateListItem.Description = "Your birthdate, tap to set";

			this.Items.Add(birthDateListItem);
			this.Items.Add(physicalListItem);
			this.Items.Add(emotionalListItem);
			this.Items.Add(intellectualListItem);

            this.Click += new EventHandler(OnClick);
		}

        private void OnCalculatorUpdate(object sender, EventArgs e) 
        {
            int physical;
            int emotional;
            int intellactual;

            physical = Convert.ToInt32((Math.Round(calculator.Physical, 0) + 100) / 2);
            emotional = Convert.ToInt32((Math.Round(calculator.Emotional, 0) + 100) / 2);
            intellactual = Convert.ToInt32((Math.Round(calculator.Intellactual, 0) + 100) / 2);

            birthDateListItem.Text = "Birthdate: " + calculator.BirthDate.ToShortDateString();
            physicalListItem.Text = String.Format("Physical: {0}%", physical);
            emotionalListItem.Text = String.Format("Emotional: {0}%", emotional);
            intellectualListItem.Text = String.Format("Intellectual: {0}%", intellactual);

            this.Title.Text = calculator.CurrentDate.ToShortDateString();
        }

        private void OnClick(object o, EventArgs e)
        {
            if (birthDateListItem.Selected) {
                DatePicker datePicker = new DatePicker(this);
                datePicker.Value = calculator.BirthDate;
                if (datePicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    calculator.BirthDate = datePicker.Value;

                datePicker.Dispose();
            }
        }


	}
}
