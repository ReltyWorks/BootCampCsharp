namespace _0805_03 {
    internal class Program {

        enum Test {
            None,
            ASMR,
        }

        static void Main(string[] args) {
            Test testA = Test.None;
            Test testB = Test.ASMR;

            testB = testA;
            testA = Test.ASMR;

            Console.WriteLine(testB);
            
        }
    }
}
