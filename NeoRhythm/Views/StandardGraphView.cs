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
        Image graphImage = new Bitmap(176, 126);

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
            BuildGraphs();
            this.Description.Text = "Biorhythm for : " + calculator.BirthDate.ToShortDateString();
            this.Title.Text = calculator.CurrentDate.ToShortDateString();
            this.Invalidate();
        }

        private void BuildGraphs()
        {
            Graphics graph = Graphics.FromImage(graphImage);
            Font font = new Font(FontFamily.GenericSerif, 10, FontStyle.Regular);

            graph.FillRectangle(new SolidBrush(Color.Black), 0, 0, 176, 126);

            int top = 100;
            int x = 16;
            int[] physical = calculator.GetPhysical();
            int[] emotional = calculator.GetEmotional();
            int[] intellectual = calculator.GetIntellactual();
            Point[] graphPhysical = new Point[physical.Length];
            Point[] graphEmotional = new Point[emotional.Length];
            Point[] graphIntellectual = new Point[intellectual.Length];

            Pen linePen = new Pen(Color.FromArgb(37,37,37));
            
            for (int i = 0; i < graphPhysical.Length; i++) {
                int xpos = x * i;

                if (i == 5 || i == 0 || i == 11)
                    graph.DrawLine(new Pen(Color.LightGray), xpos, 0, xpos, 110);
                else
                    graph.DrawLine(linePen, xpos, 0, xpos, 100);

                graphPhysical[i] = new Point();
                graphPhysical[i].Y = top - physical[i];
                graphPhysical[i].X = xpos;

                graphEmotional[i] = new Point();
                graphEmotional[i].Y = top - emotional[i];
                graphEmotional[i].X = xpos;

                graphIntellectual[i] = new Point();
                graphIntellectual[i].Y = top - intellectual[i];
                graphIntellectual[i].X = xpos;
            }

            graph.DrawLine(new Pen(Color.LightGray), 175, 0, 175, 110);

            string beginDate = calculator.CurrentDate.AddDays(-5).ToString("d-M");
            string nowDate = calculator.CurrentDate.ToString("d-M");
            string endDate = calculator.CurrentDate.AddDays(5).ToString("d-M");

            SizeF left = graph.MeasureString(endDate, font);
            graph.DrawString(beginDate, font, new SolidBrush( Color.DarkGray), 0, 103 );
            graph.DrawString(nowDate, font, new SolidBrush(Color.DarkGray), 80, 103);
            graph.DrawString(endDate, font, new SolidBrush(Color.DarkGray), (176 - left.Width), 103);


            graph.DrawLines(new Pen(Color.Red), graphPhysical);
            graph.DrawString("Physical", font, new SolidBrush(Color.Red), 0, 110);
            graph.DrawLines(new Pen(Color.Green), graphEmotional);
            graph.DrawString("Emotional", font, new SolidBrush(Color.Green), 50, 110);
            graph.DrawLines(new Pen(Color.Yellow), graphIntellectual);
            graph.DrawString("Intellectual", font, new SolidBrush(Color.Yellow), 112, 110);
        }

        protected void DoPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(graphImage, 0,26);
            
            base.OnPaint(e);
        }
    }
}
