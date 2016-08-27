using Ivl.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf.Explorer
{
    class DirectoryItem : ViewModelBase
    {
        public string Name { get { return DirectoryInfo?.Name; } }
        public DirectoryInfo DirectoryInfo { get; private set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                SetProperty(ref _isSelected, value);
                if (value)
                {
                    _owner?.Select(this);
                }
            }
        }

        public IEnumerable<DirectoryItem> _children;
        public IEnumerable<DirectoryItem> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }

        private bool _isHierarchyExpanded;
        public bool IsHierarchyExpanded
        {
            get { return _isHierarchyExpanded; }
            set
            {
                if (SetProperty(ref _isHierarchyExpanded, value))
                {
                    ExpandHierarchy(value);
                }
            }
        }

        public DirectoryItem(DirectoryInfo info = null, ExplorerViewModel owner = null)
        {
            _owner = owner;
            DirectoryInfo = info;

            if (info != null)
            {
                Children = new DirectoryItem[] { new DirectoryItem() };
            }
        }

        private void ExpandHierarchy(bool isExpanded)
        {
            if(DirectoryInfo == null)
            {
                return;
            }

            if(!isExpanded)
            {
                Children = new DirectoryItem[] { new DirectoryItem() };
            }
            else
            {
                Children = DirectoryInfo.EnumerateDirectories()
                    .Select(dir => new DirectoryItem(dir, _owner))
                    .ToArray();
            }
        }

        private ExplorerViewModel _owner;
    }
}
