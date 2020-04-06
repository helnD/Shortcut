using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Domain.Entities
{
    public class Iteration
    {
        private ImmutableArray<int> _state;

        internal Iteration(IEnumerable<int> state, int number)
        {
            _state = state.ToImmutableArray();
            Number = number;
        }
        
        public int Number { get; }

        public int IndexOfMinElement(int number)
        {
            var excludedNumbers = new List<int>();

            for (var index = 0; index < number; index++)
                excludedNumbers.Add(_state.Where(it => !excludedNumbers.Contains(it)).Min());

            return _state.IndexOf(excludedNumbers.Last());
        }

        public IEnumerable<int> Relaxation(IEnumerable<int> row, int minElement)
        {
            var resultState = _state.ToArray();
            var rowList = row.ToList();

            for (var index = 0; index < row.Count(); index++)
            {
                var newNumber = rowList[index] == int.MaxValue
                    ? int.MaxValue
                    : rowList[index] + minElement;
                
                resultState[index] = _state[index] > newNumber
                    ? newNumber
                    : _state[index];
            }

            return resultState;
        }


        public int this[int index] => _state[index];
    }
}