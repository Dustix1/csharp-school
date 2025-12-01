using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial10
{
    internal class NumberEnumerator : IEnumerator<int>
    {
        public int Current => Data[_index];
        private int _index = -2;

        public List<int> Data { get; set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index += 2;
            return _index < Data.Count;
        }

        public void Reset()
        {
            _index = -2;
        }
    }
}
