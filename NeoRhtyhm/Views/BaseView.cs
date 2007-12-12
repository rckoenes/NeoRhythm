using System;
using System.Collections.Generic;
using System.Text;
using Neonode.Forms;
using System.ComponentModel;
using System.Windows.Forms;

namespace TripleSoftware.NeoRhtyhm.Views
{
    class BaseView : CustomView
    {

        protected override void OnCloseViewSweep(CancelEventArgs e)
        {
            Application.Exit();
        }

    }
}
