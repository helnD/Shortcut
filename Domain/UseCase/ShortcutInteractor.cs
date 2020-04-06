using System.Collections.Generic;
using System.Collections.Immutable;
using Domain.Entities;

namespace Domain.UseCase
{
    public class ShortcutInteractor
    {
        public IReadOnlyCollection<Shortcut> GetShortcuts(int[][] matrix, int start)
        {
            var adjacencyMatrix = new AdjacencyMatrix(matrix);
            var calculator = new ShortcutCalculator();

            return calculator.Shortcuts(adjacencyMatrix, start).ToImmutableList();
        }
    }
}