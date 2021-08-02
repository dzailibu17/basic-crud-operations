using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string errorMassage) : base(errorMassage)
        {
            base.StatusCode = 404;
        }
    }
}