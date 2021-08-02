namespace Model.Exceptions
{
    public abstract class BaseException : System.Exception
    {
        public int StatusCode { get; set; }

        public string ErrorMassage { get; set; }

        public BaseException(string errorMassage)
        {
            this.ErrorMassage = errorMassage;
        }
    }
}
