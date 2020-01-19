using System;
using System.Collections.Generic;
using System.Text;

namespace Decorations
{
    public interface IDecoration
    {
        IEnumerable<string> GetTasks();
    }
}
