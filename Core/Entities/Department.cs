namespace Core.Entities;


public class Departament
{
    public Char Dept_NoId { get; set; }
    public string Dept_Name { get; set; }
    public List<Dept_Emp> Dept_Emps { get; set; }
    public List<Employee> Employees { get; set; }
    public List<Dept_Manager> Dept_Managers { get; set; }

}