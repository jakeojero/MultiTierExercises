using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ExercisesDAL
{
    public class Employee
    {
        //The employee entity/document class
     
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public string Entity64 { get; set; }
        public ObjectId DepartmentId { get; set; }
        public int Version { get; set; }
       
    }
}
