using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain.Entities
{
    public class ShortcutCalculator
    {
        public IEnumerable<Shortcut> Shortcuts(AdjacencyMatrix matrix, int start)
        {

            var iterations = CreateIterations(matrix, start).ToList();
            var shortcuts = new List<Shortcut>();

            for (var node = 1; node <= matrix.Width; node++)
            {
                var shortcut = IterationDescent(iterations.ToImmutableList(), node, new List<int>());
                shortcut.Reverse();
                shortcuts.Add(new Shortcut(shortcut, iterations.Last()[node - 1]));
            }

            return shortcuts;
        }

        private List<Iteration> CreateIterations(AdjacencyMatrix matrix, int start)
        {
            var firstIterationState = new List<int>(matrix.Width);
            for (var index = 0; index < matrix.Width; index++)
            {
                firstIterationState.Add(index != start - 1 ? int.MaxValue : 0);
            }
            
            var result = new List<Iteration>
            {
                new Iteration(firstIterationState, 1)
            };
            
            for (var iteration = 1; iteration < matrix.Height; iteration++)
            {
                var currentMinIndex = result.Last().IndexOfMinElement(iteration);
                var currentMinElement = result.Last()[currentMinIndex];
                var currentIterationState = result.Last().Relaxation(matrix[currentMinIndex], currentMinElement);
                result.Add(new Iteration(currentIterationState, iteration + 1));
            }

            return result;
        }

        private List<int> IterationDescent(ImmutableList<Iteration> iterations, int node, List<int> path)
        {
            path.Add(node);
            var top = iterations.Last()[node - 1];
            for (var index = iterations.Count - 1; index > 0; index--)
            {
                if (iterations[index - 1][node - 1] == top) continue;
                var newNode = iterations[index].IndexOfMinElement(index) + 1;
                IterationDescent(iterations, newNode, path);
                break;
            }

            return path;
        }
    }
}