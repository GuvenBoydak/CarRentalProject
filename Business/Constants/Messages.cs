using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string CarsListed = "Araçlar Listelendi";
        public static string CarAdded = "Araç Eklendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarDetailListed = "Araç Detayları Listelendi";
        public static string CarNameInvalid = "Araç ismi en az 2 karakter olmalı";

        public static string BrandsListed = "Markalar Listelendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";

        public static string ColorsListed = "Renkler Listelendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";

        public static string UserAdded = "Kulanıcı Eklendi";
        public static string UserDeleted = "Kulanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listelendi";

        public static string RentalAdded = "Kiralama Eklendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string RentalsListed = "Kiralamalar Listelendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string RentalInvalid = "Kiralama Başarısız";

        public static string CarImageLimitsInvalid = "Araç Resmi 5 den fazla olamaz";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserRegistered = "Kulanıcı başarılı bir şekilde kayıt oldu!!!";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Böyle bir Kullanıcı var";
        public static string AccessTokenCreated = "Başarılı Token üretildi";
    }
}
