namespace cv2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassArray impl3 = new ClassArray();
            impl3.Run();

            JaggedArray impl2 = new JaggedArray();
            impl2.Run();

            MultidimensionalArray impl1 = new MultidimensionalArray();
            impl1.Run();
        }
    }
}
