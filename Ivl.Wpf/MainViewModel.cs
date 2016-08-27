using Ivl.Common;
using Ivl.Wpf.Explorer;
using Ivl.Wpf.Inspector;
using Ivl.Wpf.Preview;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Wpf
{
    class MainViewModel : ViewModelBase
    {
        public ExplorerViewModel ExplorerContext { get; private set; } = new ExplorerViewModel();
        public PreviewViewModel PreviewContext { get; private set; } = new PreviewViewModel();
        public InspectorViewModel InspectorContext { get; private set; } = new InspectorViewModel();

        public override ViewModelBase Initialize()
        {
            ExplorerContext.Initialize();
            PreviewContext.Initialize();
            InspectorContext.Initialize();

            ExplorerContext.Directories = new DirectoryInfo[]
            {
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Personal)),
            };
            ExplorerContext.SelectionChanged += (directory) =>
            {
                PreviewContext.CurrentDirectory = directory;
            };

            PreviewContext.SelectionChanged += (info) =>
            {
                InspectorContext.Info = info;
            };

            return this;
        }
    }
}
