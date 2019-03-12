using System;
using System.Collections.Generic;

namespace ObjectResultValidationApp.Validation
{
    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; set; }
    }
}