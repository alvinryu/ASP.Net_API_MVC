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
    public class SupplierRepository : ISupplierRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(Supplier supplier)
        {
            var SP_Name = "SP_insertSupplier";
            parameters.Add("@SupplierName", supplier.SupplierName);

            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Create;
        }

        public int Delete(int id)
        {
            var SP_Name = "SP_deleteSupplier";
            parameters.Add("@Id", id);

            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Delete;
        }

        public int Update(int id, Supplier supplier)
        {
            var SP_Name = "SP_updateSupplier";
            parameters.Add("@Id", id);
            parameters.Add("@SupplierName", supplier.SupplierName);

            var Update = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Update;
        }

        public IEnumerable<Supplier> Get()
        {
            var SP_Name = "SP_printAllSupplier";
            var Get = connection.Query<Supplier>(SP_Name, commandType: CommandType.StoredProcedure);

            return Get;
        }

        public async Task<IEnumerable<Supplier>> Get(int id)
        {
            var SP_Name = "SP_printSupplier";
            parameters.Add("@Id", id);
            var Get = await connection.QueryAsync<Supplier>(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Get;
        }

    }
}