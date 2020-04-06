using System.Collections.Generic;

namespace WebApplication.Controllers.ViewEntities
{

    public class Shortcut
    {
        public Shortcut(Domain.Entities.Shortcut shortcut)
        {
            Vertices = shortcut.Nodes;
            Length = shortcut.Value;
        }

        public IEnumerable<int> Vertices { get; }
        public int Length { get; }
    }
}