using FarmeExp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmExp.Data.Interface
{
   public interface IUserDAL: IRepository<FarmExp.Models.Customer>
    {

    }
}
