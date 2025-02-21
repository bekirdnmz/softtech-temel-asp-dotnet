using FluentValidation;
using SimpleEshop.Application.DataTransferObjects;

namespace SimpleEshop.MinimalAPI.Validators
{
    public class CreateNewProductValidator : AbstractValidator<CreateNewProduct>
    {
        public CreateNewProductValidator() {

            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad alanı boş olamaz")
                              .MinimumLength(3).WithMessage("Ad alanı en az 3 karakter olmalıdır")
                              .MaximumLength(200).WithMessage("Ad alanı en fazla 200 karakter olmalıdır");




        }

    }
}
