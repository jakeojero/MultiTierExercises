using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ExercisesDAL
{
    // DbContext - abstraction of connection, database and entity collections
    public class DbContext
    {
        IMongoDatabase Db;

        public DbContext()
        {
            MongoClient client = new MongoClient(); // Connect to localhost
            Db = client.GetDatabase("HelpdeskDB");
        }

        public IMongoCollection<Employee> Employees
        {
            get
            {
                return this.Db.GetCollection<Employee>("employees");
            }
        }

        public IMongoCollection<Department> Departments
        {
            get
            {
                return this.Db.GetCollection<Department>("departments");
            }
        }
    }

}
