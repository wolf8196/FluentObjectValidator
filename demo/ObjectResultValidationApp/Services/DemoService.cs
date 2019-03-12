using DemoApps.DTOs;
using FluentObjectValidator;
using ObjectResultValidationApp.Validation;

namespace ObjectResultValidationApp.Services
{
    public class DemoService
    {
        private readonly IValidator<ValidationError> validator;

        public DemoService(IValidator<ValidationError> validator)
        {
            this.validator = validator;
        }

        public void AddProduct(ProductDTO product)
        {
            Validate(product);
        }

        public void AddUser(UserDTO user)
        {
            Validate(user);
        }

        private void Validate<T>(T obj)
        {
            var res = validator.Validate(obj);

            if (!res.IsValid)
            {
                throw new ValidationException(res.Errors);
            }
        }
    }
}