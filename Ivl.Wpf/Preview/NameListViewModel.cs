using Ivl.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Preview
{
    class NameListViewModel : ItemsControlBase
    {
        public override ItemsControlBase UpdateItems(DirectoryInfo directory)
        {
            if (directory != null)
            {
                Items = directory.EnumerateDirectories().Select(info => info as FileSystemInfo)
                    .Concat(directory.EnumerateFiles())
                    .ToArray();
            }
            return this;
        }
    }
}
