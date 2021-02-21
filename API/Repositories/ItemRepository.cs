using API.Models;
using API.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(Item item)
        {
            var SP_Name = "SP_insertItem";
            parameters.Add("@Name", item.Name);
            parameters.Add("@Quantity", item.Quantity);
            parameters.Add("@Price", item.Price);
            parameters.Add("@SupplierId", item.SupplierId);

            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Create;
        }

        public int Delete(int id)
        {
            var SP_Name = "SP_deleteItem";
            parameters.Add("@Id", id);

            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Delete;
        }

        public IEnumerable<ItemViewModel> Get()
        {
            var SP_Name = "SP_RetrieveAllItem";
            var Get = connection.Query<ItemViewModel>(SP_Name, commandType: CommandType.StoredProcedure);

            return Get;
        }

        public Task<IEnumerable<ItemViewModel>> Get(int id)
        {
            var SP_Name = "SP_RetriveItemById";
            parameters.Add("@Id", id);
            var Get = connection.QueryAsync<ItemViewModel>(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Get;
        }

        public int Update(int id, Item item)
        {
            var SP_Name = "SP_updateItem";
            parameters.Add("@Id", id);
            parameters.Add("@Name", item.Name);
            parameters.Add("@Quantity", item.Quantity);
            parameters.Add("@Price", item.Price);
            parameters.Add("@SupplierId", item.SupplierId);

            var Update = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Update;
        }

    }
}