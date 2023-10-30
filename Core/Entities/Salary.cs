namespace Core.Entities;

public class Salary
{
    public DateTime From_DateId { get; set; }
    public int Emp_Salary { get; set; }
    public DateTime To_Date { get; set; }
    public int Emp_NoId { get; set; }
    public Employee Employee { get; set; }
}