namespace _0828_Int64List {
    class Int64List<T> {
        T[] arr = new T[64];
        public int Count { get; private set; }
        public int arrLength { get { return arr.Length; } }

        public void Add(params T[] elemArr) {
            EnsureCapacity(elemArr.Length);
            for (int i = 0; i < elemArr.Length; i++) {
                arr[Count] = elemArr[i];
                Count++;
            }
        }
        public void RemoveAt(int index) {
            if (0 <= index && index < Count) {
                for (int i = index; i < Count - 1; i++) {
                    arr[i] = arr[i + 1];
                }
                arr[Count - 1] = default(T);
                Count--;
            }
            else throw new ArgumentOutOfRangeException("index");
        }

        public T GetData(int index) => arr[index];

        public T[] GetAllData() {
            T[] newArr = new T[Count];
            for (int i = 0; i < Count; i++) newArr[i] = arr[i];

            return newArr;
        }

        void EnsureCapacity(int needSize) {
            if (arrLength - Count < needSize) {
                T[] newArr = new T[arrLength + 64];

                for (int i = 0; i < Count; i++) newArr[i] = arr[i];

                arr = newArr;
            }
        }
    }
    internal class Program {
        static void Main(string[] args) {
            Int64List<int> myList = new Int64List<int>();

            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);
            myList.Add(1, 3, 5, 7, 8, 10, 12, 145, 1, 3, 5, 7, 8, 10, 12, 145, 3, 3245, 523, 4553, 2345623, 3246234, 324624564, 635456, 4563, 6, 435634576, 345);

            Console.WriteLine(string.Join(", ", myList.GetAllData()));

            myList.RemoveAt(10);
            myList.RemoveAt(20);
            myList.RemoveAt(30);
            myList.RemoveAt(40);

            Console.WriteLine(myList.GetData(25));

        }
    }
}
