using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

       private readonly ICarDal _carDal;

        public CarManager(ICarDal writeCarDal )
        {
            _carDal = writeCarDal;
        }


        public IResult Add(Car car)
        {

            if (car.Name.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
               return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetByCarDetail()
        {
            return new SuccessDataResult<IQueryable<CarDetailDto>>(_carDal.GetByCarDetails(),Messages.CarDetailListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x=>x.Id==id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
