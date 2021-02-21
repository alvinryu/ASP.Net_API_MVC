using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories.Interfaces
{
    interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();

        Task<IEnumerable<Supplier>> Get(int id);

        int Create(Supplier supplier);

        int Update(int id, Supplier supplier);

        int Delete(int id);
    }
}