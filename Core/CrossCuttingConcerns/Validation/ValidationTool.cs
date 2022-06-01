using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator valiator,object entity)
        {
            //parametreden gelen <object> Tüm veri tiplerinin Base'i object oldugu için veriyoruz.Daha sonra parametreden gelen object ile bir dogrulama yapıyoruz.Çalişicagımız tipi ise parametreden gelen(entity) verdik.
            ValidationContext<object> context = new ValidationContext<object>(entity);

            //Parametreden gelen validate ise girilen Validator sınıfın referansini tutucak Interface e karşılık gelen yapıdır.Girilen validator'e dogrulama kodları için (context) e bir bak ve kontrol et.
            var result = valiator.Validate(context);

            //result geçerli degilse bir hata fırlatıcaktır.
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }



    }
}

