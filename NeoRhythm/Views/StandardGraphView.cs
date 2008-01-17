using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Neonode.Forms;
using TripleSoftware.NeoRhythm.Data;

namespace TripleSoftware.NeoRhythm.Views
{
    public class StandardGraphView : CustomView
    {
        private BiorhythmCalculator calculator;

        public StandardGraphView(BiorhythmCalculator calculator)
        {
            this.calculator = calculator;
            calculator.Updated += new EventHandler(OnCalculatorUpdate);

            this.LeftSweep.Occurred += new System.ComponentModel.CancelEventHandler(LeftSweep_Occurred);
            this.LeftSweep.Enabled = true;

            this.RightSweep.Occurred += new System.ComponentModel.CancelEventHandler(RightSweep_Occurred);
            this.RightSweep.Enabled = true;

            OnCalculatorUpdate(this, EventArgs.Empty);
        }

        private void LeftSweep_Occurred(object sender, CancelEventArgs e)
        {
            calculator.CurrentDate = calculator.CurrentDate.AddDays(-1);
        }

        private void RightSweep_Occurred(object sender,CancelEventArgs e)
        {
            calculator.CurrentDate = calculator.CurrentDate.AddDays(1);
        }

        private void OnCalculatorUpdate(object sender, EventArgs e)
        {
            this.Description.Text = "Biorhythm for : " + calculator.BirthDate.ToShortDateString();
            this.Title.Text = calculator.CurrentDate.ToShortDateString();
        }

        protected void DoPaint(PaintEventArgs e)
        {
            
        }
    }
}
