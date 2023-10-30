namespace Core.Entities;

public class Dept_Emp
{
    public int  EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public Char  DepartamentId { get; set; }
    public Departament Departament { get; set; }
    public DateTime From_Date { get; set; }
    public DateTime To_Date { get; set; }
}