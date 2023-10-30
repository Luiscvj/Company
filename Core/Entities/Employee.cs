namespace Core.Entities;

public class Employee
{
    public int Emp_NoId { get; set; }
    public DateTime Birth_Date { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public Gender Gender {get;set;}
    public DateTime Hire_Date   { get; set; }
    public List<Departament> Departaments { get; set; }
    public List<Dept_Emp> Dept_Emps { get; set; }
    public List<Dept_Manager> Dept_Managers { get; set; }
    public List<Salary> Salaries { get; set; }
    public List<Title> Titles { get; set; }
}

public enum Gender 
{
    Male,
    Female
}