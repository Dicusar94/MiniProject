using ErrorOr;
using FluentValidation;
using Mag.Domain.Common.Models;

namespace Mag.Api.Common.Validations.Extensions;

public static class ValueObjectExtensions
{
    public static IRuleBuilderOptions<T, string> MustBeValueObject<T, TValueObject>(
        this IRuleBuilder<T, string> ruleBuilder,
        Func<string, ErrorOr<TValueObject>> factoryMethod)
        where TValueObject : ValueObject
    {
        return (IRuleBuilderOptions<T, string>)ruleBuilder.Custom((value, context) =>
        {
            ErrorOr<TValueObject> result = factoryMethod(value);

            if (result.IsError)
            {
                context.AddFailure(result.FirstError.Description);
            }
        });
    }

    public static IRuleBuilderOptions<T, int> MustBeValueObject<T, TValueObject>(
    this IRuleBuilder<T, int> ruleBuilder,
    Func<int, ErrorOr<TValueObject>> factoryMethod)
    where TValueObject : ValueObject
    {
        return (IRuleBuilderOptions<T, int>)ruleBuilder.Custom((value, context) =>
        {
            ErrorOr<TValueObject> result = factoryMethod(value);

            if (result.IsError)
            {
                context.AddFailure(result.FirstError.Description);
            }
        });
    }
}