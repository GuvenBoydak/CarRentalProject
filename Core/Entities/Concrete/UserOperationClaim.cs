using Core.Entities;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

        //Relational Property
        public virtual User User { get; set; }

        public virtual OperationClaim OperationClaim { get; set; }
    }
}
