namespace Commander.Models
{
    public class ReturnResult<T>
    {
        public bool success { get; set; }
        public T data { get; set; }
    }
}