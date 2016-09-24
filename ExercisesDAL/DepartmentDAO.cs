using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ExercisesDAL
{
    public class DepartmentDAO
    {

        public Department GetById(string id)
        {
            Department dep = new Department();

            try
            {
                DbContext ctx = new DbContext();
                var filter = Builders<Department>.Filter.Eq("Id", new ObjectId(id));
                dep = ctx.Departments.Find(filter).SingleOrDefault();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Problem in DepartmentDAO.GetById " + ex.Message);
            }

            return dep;
        }

    }
}
