using System;

namespace BooleanResultValidationApp.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Object is invalid")
        {
        }
    }
}