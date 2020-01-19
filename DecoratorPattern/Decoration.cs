using System;
using System.Collections.Generic;
using System.Text;

namespace Decorations
{
    public sealed class Decoration : IDecoration
    {
        private readonly DateTime _weddingDate;

        public Decoration(DateTime weddingDate)
        {
            _weddingDate = weddingDate;
        }

        public DateTime WeddingDate => _weddingDate;

        public IEnumerable<string> GetTasks()
        {
            return new List<string>
            {
                $"Pack pink decoration to car on {_weddingDate.AddDays(-1)}",
                $"Transfer decoration {_weddingDate}",
                "Decorate style 2",
            };
        }
    }
}
