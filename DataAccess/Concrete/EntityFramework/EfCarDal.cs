using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public IQueryable<CarDetailDto> GetByCarDetails()
        {
            CarRentalContext context = new CarRentalContext();

                var carDetail = from c in context.Cars
                                join b in context.Brands
                                on c.BrandId equals b.Id
                                join co in context.Colors
                                on c.ColorId equals co.Id
                                select new CarDetailDto
                                {
                                    CarId = c.Id,
                                    BrandName = b.Name,
                                    CarName = c.Name,
                                    ColorName = co.Name,
                                    DailyPrice = c.DailyPrice,
                                    ModelYear = c.ModelYear
                                };
                return carDetail.AsQueryable();                                             
            
        }
    }
}
