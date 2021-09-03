using Model.Enums;

namespace Model.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException() : base()
        {
            base.StatusCode = StatusCode.BadRequest;
        }
        public BadRequestException(string errorMessage) : base(errorMessage)
        {
            base.StatusCode = StatusCode.BadRequest;
        }
    }
}
