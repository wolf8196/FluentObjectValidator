namespace ObjectResultValidationApp.Validation
{
    public class ValidationError
    {
        public ValidationError(string msg)
        {
            Message = msg;
        }

        public string Message { get; set; }
    }
}