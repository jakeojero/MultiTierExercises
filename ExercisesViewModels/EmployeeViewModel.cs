using System;
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
                Id = emp.GetIdAsString();
                DepartmentID = emp.GetDepartmentIdAsString();
                Version = emp.Version;
            }
            catch (Exception ex)
            {
                Lastname = "not found";
                Console.WriteLine("error in EmployeeViewModel.GetByLastname - " + ex.Message);
            }
        }

        public int Update()
        {
            UpdateStatus opStatus;

            try
            {
                Employee emp = new Employee();
                emp.SetIdFromString(Id);
                emp.SetDepartmentIdFromString(DepartmentID);
                emp.Title = Title;
                emp.Firstname = Firstname;
                emp.Lastname = Lastname;
                emp.Phoneno = Phoneno;
                emp.Email = Email;
                emp.Version = Version;
                opStatus = _dao.UpdateWithRepo(emp);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                opStatus = UpdateStatus.Failed;
            }

            return Convert.ToInt16(opStatus); // Web Layer we dont know the enum

        }


    }
}
