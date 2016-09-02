using Ivl.Common;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private DelegateCommand<Type> _setItemContextCommand;
        public DelegateCommand<Type> SetItemContextCommand
        {
            get { return _setItemContextCommand ?? (_setItemContextCommand = new DelegateCommand<Type>(contextType => SetItemContext(contextType))); }
        }

        private ItemsControlBase _itemsContext;
        public ItemsControlBase ItemsContext
        {
            get { return _itemsContext; }
            set { SetProperty(ref _itemsContext, value); }
        }

        private DirectoryInfo _currentDirectory;
        public DirectoryInfo CurrentDirectory
        {
            get { return _currentDirectory; }
            set
            {
                if (SetProperty(ref _currentDirectory, value))
                {
                    ItemsContext?.UpdateItems(value);
                }
            }
        }

        public PreviewViewModel()
        {
            SetItemContext(typeof(NameListViewModel));
        }

        private void SetItemContext(Type itemsContextType)
        {
            var newItemsContext = (Activator.CreateInstance(itemsContextType) as ItemsControlBase);
            Debug.Assert(newItemsContext != null);

            newItemsContext.SelectionChanged += info => SelectionChanged?.Invoke(info);
            newItemsContext.Items = ItemsContext?.Items;
            newItemsContext.SelectedItem = ItemsContext?.SelectedItem;

            ItemsContext = newItemsContext;
        }
    }
}
