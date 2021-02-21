using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IItemRepository
    {
        IEnumerable<ItemViewModel> Get();

        Task<IEnumerable<ItemViewModel>> Get(int id);

        int Create(Item item);

        int Update(int id, Item item);

        int Delete(int id);
    }
}
