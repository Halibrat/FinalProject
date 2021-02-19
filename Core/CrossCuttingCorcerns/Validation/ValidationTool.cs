using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingCorcerns.Validation
{
   public static class ValidationTool
    {
        //Bu tip araclar(ValidationTool gibi) genelde static oalrak yapılır ki terkar tekrar incrance üretmeye gerek kalmasın.
        public static void Validate(IValidator validator,object entity)//Bu işlemi yaparken business ile aynı versiyonda olan FluentValidation ı core a da yüklemeyi unutmayın.
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
