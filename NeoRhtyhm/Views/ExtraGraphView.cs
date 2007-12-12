using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using System.Drawing;
using TripleSoftware.NeoRhtyhm.Data;

namespace TripleSoftware.NeoRhtyhm.Views
{
    class ExtraGraphView : BaseView
    {
        protected override void OnPaint(PaintEventArgs e)
        {

            MyDate mydate = new MyDate();

            e.Graphics.DrawString(mydate.Date, mydate.Font, new SolidBrush(Color.White), 20, 2);

            base.OnPaint(e);
        }
    }
}
