using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercisesDAL;
using ExercisesViewModels;

namespace Exercises_Tests
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void EmployeeDAOReturnByLastnameShouldReturnEmployee()
        //{
        //    EmployeeDAO dao = new EmployeeDAO();
        //    Employee someEmployee = dao.GetByLastName("Smartypants");
        //    Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        //}

        //[TestMethod]
        //public void EmployeeDAOReturnByEmailShouldReturnEmployee()
        //{
        //    EmployeeDAO dao = new EmployeeDAO();
        //    Employee someEmployee = dao.GetByEmail("jakeojero@hotmail.com");
        //    Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        //}

        //[TestMethod]
        //public void EmployeeViewModelReturnBySurnameShouldLoadFirstname()
        //{
        //    EmployeeViewModel vm = new EmployeeViewModel();
        //    vm.Lastname = "Smartypants";
        //    vm.GetByLastname();
        //    Assert.IsTrue(vm.Firstname.Length > 0);
        //}

        //[TestMethod]
        //public void DepartmentDAOReturnByIdShouldReturnDepartment()
        //{
        //    DepartmentDAO dao = new DepartmentDAO();
        //    Department someDepartment = dao.GetById("57e4857e669f1c20c00087cc");
        //    Assert.IsInstanceOfType(someDepartment, typeof(Department));
        //}

        //[TestMethod]
        //public void DepartmentViewModelReturnByIdShouldLoadDepartmentName()
        //{
        //    DepartmentViewModel vm = new DepartmentViewModel();
        //    vm.Id = "57e4857e669f1c20c00087cc";
        //    vm.GetById();
        //    Assert.IsTrue(vm.Name.Length > 0);
        //}

        [TestMethod]
        public void UpdateSameEmployeeTwiceInDalShouldBeStaleStatus()
        {
            EmployeeDAO dao = new EmployeeDAO();
            //simulate 1 user
            Employee user1Employee = dao.GetByLastName("Ojero");
            //simulate 2nd user
            Employee user2Employee = dao.GetByLastName("Ojero");

            user1Employee.Phoneno = "(555)555-1111";

            //user 1 makes update
            UpdateStatus status = dao.Update(user1Employee);
            if (status == UpdateStatus.Ok) // Should be ok for first update
            {
                //change phone for num 2
                user2Employee.Phoneno = "555-555-2222";
                // concurrency exception status should be stale'
                status = dao.Update(user2Employee);
            }
            Assert.IsTrue(status == UpdateStatus.Stale);
        }

        [TestMethod]
        public void UpdateSameEmployeeTwiceInVMShouldBeStaleInt()
        {
            int rowsUpdated = 0;
            EmployeeViewModel user1Vm = new EmployeeViewModel();

            // simulate user 1 getting an employee
            user1Vm.Lastname = "Ojero";
            user1Vm.GetByLastname();
            // simulate user 2
            EmployeeViewModel user2Vm = new EmployeeViewModel();
            user2Vm.Lastname = "Ojero";
            user2Vm.GetByLastname();

            // Change phone# for user 1
            user1Vm.Phoneno = "555-555-5551";

            //user 1 makes update
            rowsUpdated = user1Vm.Update();

            if(rowsUpdated == 1)
            {
                //change phoneno for user 2
                user2Vm.Phoneno = "555-555-5552";
                //concurrency exception rowsUpdated should = 02 for Stale
                rowsUpdated = user2Vm.Update();
            }
            Assert.IsTrue(rowsUpdated == -2);
        }
    }
}
