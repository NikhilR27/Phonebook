using FluentValidation;

namespace PhoneBook.Domain.Validators
{
    public class EntryValidator : AbstractValidator<Entry>
	{
		public EntryValidator()
		{
			RuleFor(x => x.Id).NotNull();
			RuleFor(x => x.Name).Length(1, 50).NotNull();
			RuleFor(x => x.Number).Length(1, 20).NotNull().Must(x => int.TryParse(x, out var val) && val > 0).WithMessage("Invalid Phone Number."); ;
		}
	}
}
