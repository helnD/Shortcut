using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Common;
using System.Linq;

namespace Domain.Entities
{
    public class AdjacencyMatrix
    {
        private readonly ImmutableArray<ImmutableArray<int>> _matrix;

        public AdjacencyMatrix(IEnumerable<IEnumerable<int>> matrix)
        {
            _matrix = matrix.Select(it => it.ToImmutableArray()).ToImmutableArray();
        }
        
        public int Height =>  _matrix.Length;
        
        public int Width => _matrix.FirstOrDefault().Length;
        
        public int this[int row, int column] => _matrix[row][column];

        public IEnumerable<int> this[int row] => _matrix[row];
    }
}