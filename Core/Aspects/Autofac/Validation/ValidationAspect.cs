using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{

    public class ValidationAspect : MethodInterception
    {
        //ValidationAspect Atrribute'ine parametre olarak Typeof((validatorType)) validatorType veriyoruz. 
        //Attributlerin Tiplerine Type olarak vermek zorundayız.
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //ValidationAspect Atrribute'ine parametre olarak Typeof((validatorType)) ile verilen nesne IValidator(AbstractValidator) degilse Hata fırlatıcaktır. 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir Dogrulama sınıfı degil");
            }
            //Gönderilen validatorType bir Ivalidator ise _validatorType field propertye atanır.
            _validatorType = validatorType;
        }

        //ValidationAspect attribute'nu OnBefore() Metod'un başında çalışsın diyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            //Çalişma anında Activator.CreateInstance() ile ValidationAspect'e parametre olarak girilen nesneyi çalışma anında instance'ini oluşturuyoruz.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //BaseType.GetGenericArguments()[0] ile _validatorType'in BaseType'ini bul ve onun Generic argumanın 0. indexteki tipi buluyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //Method'un parametlerine gez bir üstte yazılan entityType a bak  method'dan gelen parametre ile eşit ise entities e ata.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //entities e gelen tipi tek tek gez.
            foreach (var entity in entities)
            {
                // ValidationTool.Validate kullanarak parametre olarak, instance alınan _validatorType nensnesini ve entity veriyoruz ve validate ediyoruz.
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
