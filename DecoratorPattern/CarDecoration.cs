using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decorations
{
    public sealed class CarDecoration : IDecoration
    {
        private readonly IDecoration _baseDecoration;

        public CarDecoration(IDecoration baseDecoration)
        {
            _baseDecoration = baseDecoration;
        }

        public IEnumerable<string> GetTasks()
        {
            var tasks = new List<string>
            {
                "Pack car decoration set 1",
                "Go to address popular 12/2 and decorate"
            };

          return _baseDecoration.GetTasks().Concat(tasks);
        }
    }
}
