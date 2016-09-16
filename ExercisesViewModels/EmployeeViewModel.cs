using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisesDAL;

namespace ExercisesViewModels
{
    public class EmployeeViewModel
    {
        private EmployeeDAO _dao;

        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phoneno { get; set; }
        public int Version { get; set; }
        public string DepartmentID { get; set; }
        public string Id { get; set; }

        /// <summary>
        /// constructor
        /// <summary>
        
        public EmployeeViewModel()
        {
            _dao = new EmployeeDAO();
        }

        //
        // Find employee using Lastname property
        //
        public void GetByLastname()
        {
            try
            {
                Employee emp = _dao.GetByLastName(Lastname);
                Title = emp.Title;
                Firstname = emp.Firstname;
                Lastname = emp.Lastname;
                Phoneno = emp.Phoneno;
                Email = emp.Email;
                Id = emp.Id.ToString();
                DepartmentID = emp.DepartmentId.ToString();
                Version = emp.Version;
            }
            catch (Exception ex)
            {
                Lastname = "not found";
                Console.WriteLine("error in EmployeeViewModel.GetByLastname - " + ex.Message);
            }
        }


    }
}
