namespace ProyectoCrud.Common.Responses
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Result { get; set; }
        public List<T> ListResult { get; set; }
    }
}
