using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public int UserId { get; set; }

        //Relational Property
        public virtual User User { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
