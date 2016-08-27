using Ivl.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Explorer
{
    class ExplorerViewModel : ViewModelBase
    {
        public delegate void OnSelectionChanged(DirectoryInfo info);
        public event OnSelectionChanged SelectionChanged;

        public IEnumerable<DirectoryInfo> Directories
        {
            set
            {
                if (value != null)
                {
                    Items = value.Select(item => new DirectoryItem(item, this)).ToArray();
                }
                else
                {
                    Items = null;
                }
            }
        }

        private IEnumerable<DirectoryItem> _items;
        public IEnumerable<DirectoryItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public void Select(DirectoryItem item)
        {
            SelectionChanged?.Invoke(item.DirectoryInfo);
        }
    }
}
