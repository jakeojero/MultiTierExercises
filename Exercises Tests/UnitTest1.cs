using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExercisesDAL;
using ExercisesViewModels;

namespace Exercises_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeDAOReturnByLastnameShouldReturnEmployee()
        {
            EmployeeDAO dao = new EmployeeDAO();
            Employee someEmployee = dao.GetByLastName("Smartypants");
            Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        }

        [TestMethod]
        public void EmployeeDAOReturnByEmailShouldReturnEmployee()
        {
            EmployeeDAO dao = new EmployeeDAO();
            Employee someEmployee = dao.GetByEmail("jakeojero@hotmail.com");
            Assert.IsInstanceOfType(someEmployee, typeof(Employee));
        }

        [TestMethod]
        public void EmployeeViewModelReturnBySurnameShouldLoadFirstname()
        {
            EmployeeViewModel vm = new EmployeeViewModel();
            vm.Lastname = "Smartypants";
            vm.GetByLastname();
            Assert.IsTrue(vm.Firstname.Length > 0);
        }
    }
}
