using BooleanResultValidationApp.Validation;
using DemoApps.DTOs;
using FluentObjectValidator;

namespace BooleanResultValidationApp.Services
{
    public class DemoService
    {
        private readonly IValidator validator;

        public DemoService(IValidator validator)
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
            if (!validator.Validate(obj))
            {
                throw new ValidationException();
            }
        }
    }
}