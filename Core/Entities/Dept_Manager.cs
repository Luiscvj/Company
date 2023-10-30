namespace Core.Entities;

public class Dept_Manager
{
    public Char DepartmentId { get; set; }
    public Departament Department { get; set; }
    public int  EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime From_Date { get; set; }
    public DateTime To_Date { get; set; }
}