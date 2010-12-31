using System;
using System.Collections;
using NAnt.Core.Types;
using NAnt.NUnit2.Types;

namespace NAnt.Contrib.Types
{
    [Serializable]
    public class LoadBalancedNUnit2TestCollection : NUnit2TestCollection
    {

        public LoadBalancedNUnit2TestCollection()
        {
            
        }

        public LoadBalancedNUnit2TestCollection(LoadBalancedNUnit2TestCollection value)
        {
            AddRange(value);
        }

        public LoadBalancedNUnit2TestCollection(LoadBalancedNUnit2Test[] value)
        {
            AddRange(value);
        }
        
        [System.Runtime.CompilerServices.IndexerName("Item")]
        public LoadBalancedNUnit2Test this[int index]
        {
            get { return ((LoadBalancedNUnit2Test)(base.List[index])); }
            set { base.List[index] = value; }
        }

        public int Add(LoadBalancedNUnit2Test item)
        {
            return base.List.Add(item);
        }

        public void AddRange(LoadBalancedNUnit2Test[] items)
        {
            for (int i = 0; (i < items.Length); i = (i + 1))
            {
                Add(items[i]);
            }
        }

        public void AddRange(LoadBalancedNUnit2TestCollection items)
        {
            for (int i = 0; (i < items.Count); i = (i + 1))
            {
                Add(items[i]);
            }
        }

        public bool Contains(LoadBalancedNUnit2Test item)
        {
            return base.List.Contains(item);
        }

        public void CopyTo(LoadBalancedNUnit2Test[] array, int index)
        {
            base.List.CopyTo(array, index);
        }

        public int IndexOf(LoadBalancedNUnit2Test item)
        {
            return base.List.IndexOf(item);
        }

        public void Insert(int index, LoadBalancedNUnit2Test item)
        {
            base.List.Insert(index, item);
        }

        public new LoadBalancedNUnit2TestEnumerator GetEnumerator()
        {
            return new LoadBalancedNUnit2TestEnumerator(this);
        }

        public void Remove(LoadBalancedNUnit2Test item)
        {
            base.List.Remove(item);
        }

    }

    public class LoadBalancedNUnit2TestEnumerator : IEnumerator
    {
        private IEnumerator _baseEnumerator;

        internal LoadBalancedNUnit2TestEnumerator(LoadBalancedNUnit2TestCollection arguments)
        {
            var temp = (IEnumerable)(arguments);
            _baseEnumerator = temp.GetEnumerator();
        }

        public LoadBalancedNUnit2Test Current
        {
            get { return (LoadBalancedNUnit2Test)_baseEnumerator.Current; }
        }

        object IEnumerator.Current
        {
            get { return _baseEnumerator.Current; }
        }

        public bool MoveNext()
        {
            return _baseEnumerator.MoveNext();
        }

        bool IEnumerator.MoveNext()
        {
            return _baseEnumerator.MoveNext();
        }

        public void Reset()
        {
            _baseEnumerator.Reset();
        }

        void IEnumerator.Reset()
        {
            _baseEnumerator.Reset();
        }
    }
}
