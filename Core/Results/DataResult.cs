using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data,bool success,string messag):base(success,messag)
        {
            Data = data;
        }

        public DataResult(T data,bool success):base(success)
        {
            Data=data;
        }
    }
}
