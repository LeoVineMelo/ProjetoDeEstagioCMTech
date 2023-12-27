namespace ProjetoCMTech.Wrapper
{
    public class PaginatedResponse<T>
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }

        public PaginatedResponse(int index, int size, int total, T data)
        {
            Index = index;
            Size = size;
            Total = total;
            Data = data;
        }
    }
}
