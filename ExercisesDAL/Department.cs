using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ExercisesDAL
{
    public class Department
    {
        public ObjectId Id { get; set; }
        public string DepartmentName { get; set; }
        public int Version { get; set; }
    }
}
