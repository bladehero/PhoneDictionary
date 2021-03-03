using System;

namespace PhoneDictionary.Data.Views
{
    public class ErrorResponseVM
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ErrorResponseVM(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;
#if DEBUG
            StackTrace = ex.ToString();
#endif
        }
    }
}