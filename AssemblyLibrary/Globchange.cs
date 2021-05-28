using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssemblyLibrary
{
    public class Globchange
    {
        public void ChangeCulture(string culture)
        {
            CultureInfo en = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = en;
            Thread.CurrentThread.CurrentUICulture = en;
        }
    }
}
