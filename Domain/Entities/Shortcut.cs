using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Shortcut
    {
        public Shortcut(IEnumerable<int> nodes, int value)
        {
            Nodes = nodes;
            Value = value;
        }

        public IEnumerable<int> Nodes { get; }

        public int Value { get; }
    }
}