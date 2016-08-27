using Ivl.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Preview
{
    class PreviewViewModel : ViewModelBase
    {
        public delegate void OnSelectionChanged(FileSystemInfo info);
        public event OnSelectionChanged SelectionChanged;

        private DirectoryInfo _currentDirectory;
        public DirectoryInfo CurrentDirectory
        {
            get { return _currentDirectory; }
            set
            {
                if (SetProperty(ref _currentDirectory, value))
                {
                    ChangeDirectory(value);
                }
            }
        }

        private FileSystemInfo[] _items;
        public FileSystemInfo[] Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public FileSystemInfo SelectedItem
        {
            set { SelectionChanged?.Invoke(value); }
        }

        private void ChangeDirectory(DirectoryInfo directory)
        {
            Items = directory.EnumerateDirectories().Select(info => info as FileSystemInfo)
                .Concat(directory.EnumerateFiles())
                .ToArray();
        }
    }
}
