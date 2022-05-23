using FluentValidation;
using System;

namespace RCM.API.Support
{
	public static class RcmValidators
	{
		public static IRuleBuilderOptions<T, TElement> IsBoolean<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is bool).WithMessage("{PropertyName} should be a Boolean");
		}

		public static IRuleBuilderOptions<T, TElement> IsDateTime<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is DateTime).WithMessage("{PropertyName} should be a DateTime");
		}

		public static IRuleBuilderOptions<T, TElement> IsDouble<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is double).WithMessage("{PropertyName} should be a Double");
		}

		public static IRuleBuilderOptions<T, TElement> IsInteger<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is int).WithMessage("{PropertyName} should be an Integer");
		}

		public static IRuleBuilderOptions<T, TElement> IsLong<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is long).WithMessage("{PropertyName} should be a Long");
		}

		public static IRuleBuilderOptions<T, TElement> IsString<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
		{
			return ruleBuilder.Must(property => property is string).WithMessage("{PropertyName} should be a String");
		}
	}
}
