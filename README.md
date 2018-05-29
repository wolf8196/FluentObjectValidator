# FluentObjectValidator
FluentObjectValidator is a small and simple validation library that provides fluent interface for rule configuration.

The library is meant to provide an alternative to the attribute-based validation of a model (RequiredAttribute, StringLengthAttribute, etc.).

## Prerequisites
The library targets .NET Standart 1.0, .NET 4.0, .NET 4.5

## Getting Started
Here are the steps that will help you configure the validation in your app.
- [Choose the result](#choose-the-result)
- [Configure the rules](#configure-the-rules)
- [Validate](#validate)

### Choose the result
First things first, you'll need to decide what information you would like to receive, when a certain model didn't pass the validation.

The main classes that provides the validation functionality are:

- `Validator` - returns a boolean value which indicates wheter the validation passed or not.
- `Validator<TError>` - returns an instance of `ValidationResult<TError>` object, which contains a boolean value, and a collection of custom `TError` objects that will show you exactly, which of the rules didn't pass.

After you decide which validator to use, all you have to do is inherit from it, and add the configurations, like so:

```csharp
public class MyValidator : Validator
{
    public MyValidator()
    {
        AddConfiguration(new ProductDTOConfiguration());
        AddConfiguration(new UserDTOConfiguration());
    }
}
```
```csharp
public class MyValidator : Validator<MyCustomError>
{
    public MyValidator()
    {
        AddConfiguration(new ProductDTOConfiguration());
        AddConfiguration(new UserDTOConfiguration());
    }
}
```

This brings us to the next step.

### Configure the rules

To configure the rules that your objects should follow, you need to create configuration classes for each of the types you want to validate.

Depending on the chosen validator, all configurations inherit from `ValidationConfiguration<TObject>` or `ValidationConfiguration<TObject, TError>`.

#### `ValidationConfiguration<TObject>`

```csharp
public class ProductDTOConfiguration : ValidationConfiguration<ProductDTO>
{
    public ProductDTOConfiguration()
    {
        Property(x => x.Title)
            .IsRequired()
            .HasRule(x => x.Length <= 10);
    }
}
```

After selecting the property, you can add the validation rules in a fluent manner.

You can define any rules with a `HasRule` method, but there are several predefined shortcuts like `IsRequired` available to all objects,
and `HasMinLength`, `HasMaxLength`, `HasLengthInRange`, `MatchesRegex` available only to strings.

The validation occurs sequentially in an order the rules were defined, and returns `false` as soon as one of the rules didn't pass, or `true` if all of them passed.

#### `ValidationConfiguration<TObject, TError>`

```csharp
public class ProductDTOConfiguration : ValidationConfiguration<ProductDTO, MyCustomError>
{
    public ProductDTOConfiguration()
    {
        Property(x => x.Title)
            .IsRequired(() => new MyCustomError("Title is required"))
            .HasRule(
                x => x.Length <= 10,
                () => new MyCustomError("Title is too long"));
    }
}
```

Configuring the validation, which returns custom errors in case of failures is a little bit more complex.

After selecting a property and defining a rule, you now need to add a delegate that will be used to create the error object if the rule doesn't pass.

The validation also occurs sequentially in an order the rules were defined, but if one of the rules doesn't pass, the error is added to the result, and the validation continues.

You can configure the validation to skip the rest of the rules for a current property, or for entire object, in case a specific rule doesn't pass. It can be done by passing corresponding optional boolean parameters `stopValidationOnError` and `terminateValidationOnError` into `HasRule` method. Both of them are false by default.

`IsRequired` method always skips the the rest of the rules for a property, as we don't need to check other rules if the property is for example equal to null.

Shortcut rules like `IsRequired`, `HasMaxLength` are implemented via extension methods, so you can easily add your own shortcuts to your project.

### Validate

After configuring the rules, you can now create the instance of your validator and use it wherever you'd like.
```csharp
var res = validator.Validate(obj);
```

Each validator exposes a single public 'Validate' method, which is available via interfaces:
```csharp
public interface IValidator<TError>
{
    ValidationResult<TError> Validate<TObject>(TObject target);
}
    
public interface IValidator
{
    bool Validate<TObject>(TObject target);
}
```

That's why you can easily use it with dependency injection:
```csharp
services.AddSingleton<IValidator, MyValidator>()
```
```csharp
container.Register<IValidator<MyCustomError>, MyValidator>(Lifestyle.Singleton);
```

All the configurations are loaded and validated during the creation of the validator instance, so to my opinion it is best to use it as a singleton.

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/wolf8196/FluentObjectValidator/blob/master/LICENSE) file for details

## Acknowledgments
The way in which the rule configuration occurs was inspired by [Entity Framework 6](https://docs.microsoft.com/en-us/ef/ef6/), and its way of configuring the relationships between entities.
