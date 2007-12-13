using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using System.ComponentModel;
using System.Windows.Forms;
using TripleSoftware.NeoRhtyhm.Data;
using System.Drawing;

namespace TripleSoftware.NeoRhtyhm.Views
{
    abstract class BaseView : CustomView
    {
        protected MyDate mydate;

        protected override void OnCloseViewSweep(CancelEventArgs e)
        {
            Application.Exit();
        }


        protected override void OnPaint(Neonode.Forms.PaintEventArgs e)
        {
            mydate = new MyDate();

            e.Graphics.DrawString(mydate.Date, mydate.Font, new SolidBrush(Color.White), 20, 2);
            
            DoPaint(e);

            base.OnPaint(e);
        }

        protected virtual void DoPaint( Neonode.Forms.PaintEventArgs e){

        }
    }
}
