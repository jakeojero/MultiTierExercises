using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ExercisesDAL
{
    public class Problem
    {
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
    }
}
