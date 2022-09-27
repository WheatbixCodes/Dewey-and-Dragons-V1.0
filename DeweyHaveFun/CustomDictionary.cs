using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyHaveFun
{
    class CustomDictionary<K,V>
    {
        // create 2 lists
        List<K> keys = new List<K>();
        List<V> values = new List<V>();

        public void Add(K key, V value)
        {
            // checks
            if (key == null)
            {
                throw new ArgumentException("Key cannot be null!");
            }

            if (!keys.Contains(key))
            {
                // add the itme --> key ++ value
                keys.Add(key);
                values.Add(value);
            }
           
        }

        public bool Remove(K key)
        {
            if (keys.Contains(key))
            {
                values.RemoveAt(keys.IndexOf(key));
                keys.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            keys.Clear();
            values.Clear();
        }

        public int Size()
        {
            return keys.Count();
        }

        public V this[K key]
        {
            get
            {
                if (keys.Contains(key))
                    return values[keys.IndexOf(key)];
                else
                    throw new KeyNotFoundException("Key does not exist!");
            }

            set
            {
                if (keys.Contains(key))
                    values[keys.IndexOf(key)] = value;
                else
                    Add(key, value);
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < keys.Count(); i++)
            {
                s += "[keys: " + keys[i] + ", Value: " + values[i] + "]\n";
            }

            return s;
        }

        public void Sort()
        {
            var keyArray = keys.ToArray();
            var valueArray = values.ToArray();

            //Array.Sort(keyArray, valueArray);

            Array.Sort(valueArray);

            keys = new List<K>(keyArray);
            values = new List<V>(valueArray);
        }
    }
}
