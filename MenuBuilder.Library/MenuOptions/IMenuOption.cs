using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBuilder
{
    public interface IMenuOption
    {
        string Label { get; }
        IAction Action { get; }
        IMenu SubMenu { get; }
        void PerformAction();
    }
}
