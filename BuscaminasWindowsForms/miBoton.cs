using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasWindowsForms
{
    class miBoton : Button
    {
        public int f;
        public int c;

        public miBoton(int i, int j) : base()
        {
            f = i;
            c = j;
        }
    }
}
