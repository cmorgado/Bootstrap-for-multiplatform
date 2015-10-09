namespace Bootstrap.REST.Models
{
    public class RESTResult<T>
    {
        public Error Error { get; set; }
        public T DATA { get; set; }
        public string RAW { get; set; }

        public RESTResult()
        {
            Error = new Error();
        }
    }
}
