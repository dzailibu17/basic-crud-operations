using Model.Enums;

namespace Model.Exceptions
{
    public abstract class BaseException : System.Exception
    {
        public StatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public BaseException()
        {

        }
        public BaseException(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
