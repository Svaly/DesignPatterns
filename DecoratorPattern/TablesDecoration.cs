using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorations
{
    public sealed class TablesDecoration : IDecoration
    {
        private readonly IDecoration _baseDecoration;

        public TablesDecoration(IDecoration baseDecoration)
        {
            _baseDecoration = baseDecoration;
        }

        public IEnumerable<string> GetTasks()
        {
            var tasks = new List<string>
            {
                "Pack flowers",
            };

          return _baseDecoration.GetTasks().Concat(tasks);
        }
    }
}
