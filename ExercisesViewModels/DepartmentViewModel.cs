using System;
using ExercisesDAL;

namespace ExercisesViewModels
{
    public class DepartmentViewModel
    {
        private DepartmentDAO _dao;

        public string Id { get; set; }
        public string Name { get; set; }


        public DepartmentViewModel()
        {
            _dao = new DepartmentDAO();
        }

        public void GetById()
        {
            try
            {
                Department dep = _dao.GetById(Id);
                Id = dep.GetIdAsString();
                Name = dep.DepartmentName;
            }
            catch (Exception ex)
            {
                Name = "not found";
                Console.WriteLine("error in DepartmentViewModel.GetById - " + ex.Message);
            }
        }
    }
}
