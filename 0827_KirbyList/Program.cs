namespace _0827_KirbyList {
    class Kirby<T> {
        T[] _stomach = new T[1];
        public int Count { get; private set; }
        public int arrLength { get { return _stomach.Length; } }

        public T this[int index] {
            get {
                if (0 <= index && index < Count)
                    return _stomach[index]; 
                else throw new ArgumentOutOfRangeException("index");
            }
            //set {
            //    if (index < 0 || index >= count)
            //        throw new ArgumentOutOfRangeException("index");
            //    stomach[index] = value;
            //}
        }

        public void Add(T elem) {
            EnsureCapacity(1);
            _stomach[Count] = elem;
            Count++;
        }

        public void RemoveAt(int index) {
            if (0 <= index && index < Count) {
                for (int i = index; i < Count - 1; i++) {
                    _stomach[i] = _stomach[i + 1];
                }
                _stomach[Count - 1] = default(T);
                Count--;
            }
            else throw new ArgumentOutOfRangeException("index");
        }

        public T[] Vomit() {
            T[] newStomach = new T[Count];
            for (int i = 0; i < Count; i++) newStomach[i] = _stomach[i];

            return newStomach;
        }

        void EnsureCapacity(int needSize) {
            if (arrLength - Count < needSize) {
                T[] newStomach = new T[arrLength * 2];

                for (int i = 0; i < Count; i++) newStomach[i] = _stomach[i];

                _stomach = newStomach;
            }
        }
    }
    internal class Program {
        static void Main(string[] args) {
            Kirby<int> myList = new Kirby<int>();
            myList.Add(9);
            myList.Add(10);
            myList.Add(11);
            myList.Add(12);
            myList.RemoveAt(2);
            Console.WriteLine(myList[2]);
            Console.WriteLine(string.Join(", ", myList.Vomit()));
            Console.WriteLine(myList.Count);
        }
    }
}