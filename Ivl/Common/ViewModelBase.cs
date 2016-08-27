using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivl.Common
{
    public class ViewModelBase : BindableBase
    {
        public virtual ViewModelBase Initialize() { return this; }
    }
}
