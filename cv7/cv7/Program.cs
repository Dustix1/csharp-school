namespace cv7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 1, 2, 3 };
            int[] arr2 = { 3, 2, 1 };

            ArrayHelper<int>.Swap(arr1, 1, 2);

            int[] concatArr = ArrayHelper<int>.Concat(arr1, arr2);


            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < concatArr.Length; i++)
            {
                Console.Write(concatArr[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            TreeMap<int, string> treeMap = new TreeMap<int, string>();
            treeMap[1] = "hello";
            treeMap[2] = " ";
            treeMap[3] = "world";

            Console.WriteLine(treeMap[1] + treeMap[2] + treeMap[3]);

            Console.WriteLine(treeMap.Count);
        }
    }
}
