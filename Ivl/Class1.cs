using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Ivl
{
    public class Class1
    {
        public static string Test()
        {
            var m = new MediaElement();
            return m.Source?.AbsolutePath ?? string.Empty;
        }
    }
}
