using Model.Enums;


namespace Model.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
            base.StatusCode = StatusCode.NotFound;
        }
    }
}