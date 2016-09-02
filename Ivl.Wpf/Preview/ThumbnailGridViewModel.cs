using Ivl.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ivl.Wpf.Preview
{
    class ThumbnailGridViewModel : ItemsControlBase
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
