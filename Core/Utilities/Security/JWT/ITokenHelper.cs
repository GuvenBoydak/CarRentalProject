using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcının operationClaim lerine bakıcak ve bir token oluşturacak.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
