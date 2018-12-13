namespace Khan.Common.ViewModel
{
    public class ResponseViewModel<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }

        public ResponseViewModel()
        {
            this.IsSuccess = false;
            this.Message = string.Empty;
        }
    }
}
