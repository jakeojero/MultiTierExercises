using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ExercisesDAL
{
    public class EmployeeDAO
    {
        public Employee GetByLastName(string lname)
        {
            Employee emp = new Employee();

            try
            {
                DbContext ctx = new DbContext();
                var filter = Builders<Employee>.Filter.Eq("Lastname", lname);
                emp = ctx.Employees.Find(filter).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in EmployeeDAO.GetByLastName " + ex.Message);
            }

            return emp;
        }

        public Employee GetByEmail(string email)
        {
            Employee emp = new Employee();

            try
            {
                DbContext ctx = new DbContext();
                var filter = Builders<Employee>.Filter.Eq("Email", email);
                emp = ctx.Employees.Find(filter).SingleOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem in EmployeeDAO.GetByEmail " + ex.Message);
            }

            return emp;
        }


    }
}
