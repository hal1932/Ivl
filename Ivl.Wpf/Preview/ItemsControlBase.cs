using Ivl.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Preview
{
    abstract class ItemsControlBase : ViewModelBase
    {
        public delegate void OnSelectionChanged(FileSystemInfo info);
        public event OnSelectionChanged SelectionChanged;

        private FileSystemInfo[] _items;
        public FileSystemInfo[] Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private FileSystemInfo _selectedItem;
        public FileSystemInfo SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    SelectionChanged?.Invoke(value);
                }
            }
        }

        public abstract ItemsControlBase UpdateItems(DirectoryInfo directory);
    }
}
