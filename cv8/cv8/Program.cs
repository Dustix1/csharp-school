using Stock;
using Stock.Filters;
using Stock.Products;

namespace cv8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stock<IProduct> stock = new Stock<IProduct>();
            Voucher voucher = new Voucher() { Name = "Test", Price = 2300 };

            try
            {
                stock.Add(voucher);
                stock.Add(voucher);
            }
            catch (DuplicitProductException e)
            {
                Console.WriteLine($"Caught exception duplicate: {e.Product}: {e.Product.Name}");
            }

            stock.Add(new Car() { Name = "Auto", Price = 1_000_000, Width = 200, Height = 150, Length = 300 });
            stock.Add(new MobilePhone() { Name = "Mobil", Price = 10_000, Width = 6, Height = 16, Length = 1 });

            FilterEvaluator filterEvaluator = new FilterEvaluator();
            filterEvaluator.Add(new WidthFilter() { MinWidth = null, MaxWidth = 100 });
            foreach (IProduct product in stock.Filter(filterEvaluator))
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
