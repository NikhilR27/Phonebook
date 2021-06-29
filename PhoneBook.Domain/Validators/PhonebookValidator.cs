using System;
using FluentValidation;

namespace PhoneBook.Domain.Validators
{
	public class PhonebookValidator : AbstractValidator<Phonebook>
	{
		public PhonebookValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(1, 50).NotNull();
		}
	}
}
