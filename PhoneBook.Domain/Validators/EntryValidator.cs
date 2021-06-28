using System;
using FluentValidation;

namespace PhoneBook.Domain.Validators
{
	public class EntryValidator : AbstractValidator<Entry>
	{
		public EntryValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(1, 50);
			RuleFor(x => x.Number).Length(1, 12);
		}
	}
}
