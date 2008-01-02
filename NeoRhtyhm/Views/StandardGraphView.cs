using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Neonode.Forms;
using System.Drawing;
using TripleSoftware.NeoRhtyhm.Data;

namespace TripleSoftware.NeoRhtyhm.Views
{
    class StandardGraphView : BaseView
    {
        protected override void DoPaint(PaintEventArgs e)
        {
            base.DoPaint(e);

            Pen _pen = new Pen(Color.Red);
            Point[] _points = new Point[5];
            _points[0].X = 0;
            _points[0].Y = 0;
            _points[1].X = 57;
            _points[1].Y = 83;
            _points[2].X = 59;
            _points[2].Y = 87;
            _points[3].X = 52;
            _points[3].Y = 85;
            _points[4].X = 45;
            _points[4].Y = 95;
            e.Graphics.DrawLines(_pen, _points);

        }
    }
}
