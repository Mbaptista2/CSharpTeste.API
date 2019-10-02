using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Application.CasosDeUso.Hotel.Base.Validations
{
    public class HotelInserirValidation : AbstractValidator<InserirHotelRequest> 
    {
        public HotelInserirValidation()
        {
            ValidateId();
            ValidateNome();
        }
        protected void ValidateId()
        {
            RuleFor(r => r.Classificacao)
                .NotEqual(0)
                .WithMessage("A Classificação precisa ser maior do que 0");           
        }

        protected void ValidateNome()
        {
            RuleFor(r => r.Nome)
               .MaximumLength(50)
               .WithMessage("O nome do hotel tem que ter no máximo 50 caracteres");
        }
    }
}
