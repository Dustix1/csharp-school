namespace Stock
{
    public class Stock<T> where T : IProduct
    {
        private List<T> products = new List<T>();

        public void Add(T item)
        {
            foreach (T listItem in products)
            {
                if (object.ReferenceEquals(products.Last(), item))
                {
                    throw new DuplicitProductException() { Product = item };
                }
            }

            products.Add(item);
        }

        public List<T> Filter(FilterEvaluator filterEvaluator)
        {
            List<T> result = new List<T>();
            foreach (T item in products)
            {
                if (filterEvaluator.IsMatch(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
