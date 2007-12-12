using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using System.Drawing;
using TripleSoftware.NeoRhtyhm.Data;

namespace TripleSoftware.NeoRhtyhm.Views
{
    class StandardGraphView : BaseView
    {
        protected override void OnPaint(PaintEventArgs e)
        {

            MyDate mydate = new MyDate();

            e.Graphics.DrawString(mydate.Date, mydate.Font, new SolidBrush(Color.White), 20, 2);

            Pen pen = new Pen(Color.Red, 2);

            Point[] points = new Point[7];

            points[0] = new Point();
            points[0].X = 4;
            points[0].Y = 4;

            points[1] = new Point();
            points[1].X = 6;
            points[1].Y = 6;

            points[2] = new Point();
            points[2].X = 8;
            points[2].Y = 8;

            points[3] = new Point();
            points[3].X = 9;
            points[3].Y = 9;

            points[4] = new Point();
            points[4].X = 10;
            points[4].Y = 10;

            points[6] = new Point();
            points[5].X = 12;
            points[5].Y = 12;

            points[6] = new Point();
            points[6].X = 14;
            points[6].Y = 14;

            points[7] = new Point();
            points[7].X = 20;
            points[7].Y = 20;

            //e.Graphics.DrawLines(pen, points);

            //e.Graphics.DrawPolygon(pen, points);

            e.Graphics.DrawLine(pen, 4, 14, 40, 40);

            base.OnPaint(e);
        }
    }
}
