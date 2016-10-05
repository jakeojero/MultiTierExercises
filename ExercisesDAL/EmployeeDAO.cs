﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public UpdateStatus Update(Employee emp)
        {
            UpdateStatus retVal = UpdateStatus.Failed;

            try
            {
                if (Exists(emp.Id))
                {
                    DbContext ctx = new DbContext();
                    var builder = Builders<Employee>.Filter;
                    var filter = builder.Eq("Id", emp.Id) & builder.Eq("Version", emp.Version);
                    var update = Builders<Employee>.Update
                        .Set("DepartmentId", emp.DepartmentId)
                        .Set("Email", emp.Email)
                        .Set("Firstname", emp.Firstname)
                        .Set("Lastname", emp.Lastname)
                        .Set("Phoneno", emp.Phoneno)
                        .Set("Title", emp.Title)
                        .Inc("Version", 1);
                        
                    var result = ctx.Employees.UpdateOne(filter, update);

                    if(result.MatchedCount == 0)
                    {
                        retVal = UpdateStatus.Stale;
                    }
                    else if(result.ModifiedCount == 1)
                    {
                        retVal = UpdateStatus.Ok;
                    }
                    else
                    {
                        retVal = UpdateStatus.Failed;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown in EmployeeDAO.Update " + ex.Message);
                retVal = UpdateStatus.Failed;
            }

            return retVal;

        }

        public UpdateStatus UpdateWithRepo(Employee emp)
        {
            UpdateStatus status = UpdateStatus.Failed;
            HelpdeskRepository repo = new HelpdeskRepository(new DbContext());

            try
            {
                var builder = Builders<Employee>.Filter;
                var filter = builder.Eq("Id", emp.Id) & builder.Eq("Version", emp.Version);
                var update = Builders<Employee>.Update
                    .Set("DepartmentId", emp.DepartmentId)
                    .Set("Email", emp.Email)
                    .Set("Firstname", emp.Firstname)
                    .Set("Lastname", emp.Lastname)
                    .Set("Phoneno", emp.Phoneno)
                    .Set("Title", emp.Title)
                    .Inc("Version", 1);

                status = repo.Update(emp.Id.ToString(), filter, update);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception thrown in EmployeeDAO.UpdateWithRepo " + ex.Message);
            }

            return status;

        }

        private bool Exists(ObjectId id)
        {
            DbContext ctx = new DbContext();
            var collection = ctx.Employees;
            var filter = Builders<Employee>.Filter.Eq("Id", id);
            var emps = ctx.Employees.Find(filter);
            return (emps.Count() > 0);
        }
    }
}
