using Ivl.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Inspector
{
    class InspectorViewModel : ViewModelBase
    {
        private FileSystemInfo _info;
        public FileSystemInfo Info
        {
            get { return _info; }
            set { SetProperty(ref _info, value); }
        }
    }
}
