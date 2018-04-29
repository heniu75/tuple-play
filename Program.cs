using System;
using System.Diagnostics;
using System.Linq;

namespace tuple_play
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        void Run()
        {
            var ints = new int[] { 10, 20, 30};

            var tuple_a = Tally_CountAndSum_A(ints);
            Debug.Assert(Tuple<int,int>.Equals(tuple_a,(60, 3)));

            var tuple_b = Tally_CountAndSum_B(ints);
            Debug.Assert(Tuple<int,int>.Equals(tuple_b,(60, 3)));

            Console.WriteLine($"sum: {tuple_b.sum}, count: {tuple_b.count}");

            var (sum, count) = Tally_CountAndSum_B(ints);
            Debug.Assert(Tuple<int,int>.Equals(tuple_b,(sum, count)));

             Console.WriteLine($"exploded sum: {sum}, exploded count: {count}");
        }

        (int, int) Tally_CountAndSum_A(int[] arrayOfInts)
        {
            var sum_and_count = (0, 0);
            // Item1, Item2 are 'standard' names
            sum_and_count.Item1 = arrayOfInts.Sum();
            sum_and_count.Item2 = arrayOfInts.Length;
            
            Debug.Assert(Tuple<int,int>.Equals(sum_and_count,(60, 3)));

            return sum_and_count;
        }

        (int sum, int count) Tally_CountAndSum_B(int[] arrayOfInts)
        {
            var sum_and_count = (s:0, c:0);
            sum_and_count.s = arrayOfInts.Sum();

            // you can assign tuple parts individually:
            sum_and_count.c = arrayOfInts.Length;
            sum_and_count.s = arrayOfInts.Sum();

            Debug.Assert(Tuple<int,int>.Equals(sum_and_count,(60, 3)));     

            // ... or you can assign them by position
            sum_and_count = (arrayOfInts.Sum(), arrayOfInts.Length);

            Debug.Assert(Tuple<int,int>.Equals(sum_and_count,(60, 3)));

            // ... or you can assign by name => e.g. (s and c)
            sum_and_count = (s: arrayOfInts.Sum(), c: arrayOfInts.Length);

            Debug.Assert(Tuple<int,int>.Equals(sum_and_count,(60, 3)));

            return sum_and_count;
        }

    }
}
