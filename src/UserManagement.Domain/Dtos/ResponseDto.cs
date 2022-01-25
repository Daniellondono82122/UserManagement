namespace UserManagement.Domain.Dtos
{
    public class ResponseDto<TResult>
    {
        public ResponseDto() { }
        public ResponseDto(string message, TResult result, object error)
        {
            Message = message;
            Result = result;
            Errors = error;
        }

        public string Message { get; set; }
        public TResult Result { get; set; }
        public object Errors { get; set; }
    }
}
