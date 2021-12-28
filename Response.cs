namespace WebApiWithDynamoDB
{
    public class Response<T>
    {
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public T Data { get; set; }

    }

}
