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
            birthDateListItem.Text = "Birthdate: " + calculator.BirthDate.ToShortDateString();
            physicalListItem.Text = "Physical: " + calculator.Physical.ToString();
            emotionalListItem.Text = "Emotional: " + calculator.Emotional.ToString();
            intellectualListItem.Text = "Intellectual: " + calculator.Intellactual.ToString();
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
