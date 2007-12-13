using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using System.Drawing;
using TripleSoftware.NeoRhtyhm.Data;


namespace TripleSoftware.NeoRhtyhm.Views
{
    class PercentageView : BaseView
    {

        protected override void DoPaint(PaintEventArgs e)
        {
            Font font = new Font("Tahoma", 8f, FontStyle.Regular);

            e.Graphics.DrawString("Physical: ", font, new SolidBrush(Color.Red), 4, 25);
            e.Graphics.DrawString("Emotinal: ", font, new SolidBrush(Color.Green), 4, 40);
            e.Graphics.DrawString("Intellectua: ", font, new SolidBrush(Color.Yellow), 4, 54);

            base.OnPaint(e);
        }
    }
}
