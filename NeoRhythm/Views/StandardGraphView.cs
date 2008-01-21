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

            this.Paint += new EventHandler<PaintEventArgs>(DoPaint);

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
            this.Invalidate();
        }

        protected void DoPaint(object sender, PaintEventArgs e)
        {
            int[] physical = calculator.GetPhysical();
            int[] emotional = calculator.GetEmotional();
            int[] intellectual = calculator.GetIntellactual();
            int top = 126;
            Point[] graphPhysical = new Point[physical.Length];
            Point[] graphEmotional = new Point[emotional.Length];
            Point[] graphIntellectual = new Point[intellectual.Length];

            int x =  Width / physical.Length;

            for (int i = 0; i < graphPhysical.Length; i++) {
                graphPhysical[i] = new Point();
                graphPhysical[i].Y = top - physical[i];
                graphPhysical[i].X = x * i;
            }

            for (int i = 0; i < graphEmotional.Length; i++) {
                graphEmotional[i] = new Point();
                graphEmotional[i].Y = top - emotional[i];
                graphEmotional[i].X = x * i;
            }

            for (int i = 0; i < graphIntellectual.Length; i++) {
                graphIntellectual[i] = new Point();
                graphIntellectual[i].Y = top - intellectual[i];
                graphIntellectual[i].X = x * i;
            }

            e.Graphics.DrawLines(new Pen(Color.Red), graphPhysical);
            e.Graphics.DrawLines(new Pen(Color.Green), graphEmotional);
            e.Graphics.DrawLines(new Pen(Color.Yellow), graphIntellectual);

            base.OnPaint(e);
        }
    }
}
