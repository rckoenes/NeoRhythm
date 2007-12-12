using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TripleSoftware.NeoRhtyhm.Data
{
    class MyDate
    {
        private Font font;


        public MyDate(){
            font = new Font("Tahoma", 12, FontStyle.Bold);
        }

        public Font Font
        {
            get { return font; }
        }

        public string Date
        {
            get { return "23-06-1981"; }
        }
    }
}
