using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {

        public MessageValidator()
        {
            RuleFor(x => x.Receivermail).NotEmpty().WithMessage("Alıcı adresini adını boş geçemessiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemessiniz");
            RuleFor(x => x.MesaageContent).NotEmpty().WithMessage("Mesajı boş geçemessiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 en az  karekter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karekterden fazla giriş yapmayınız");

        }
    }
}
