using Core.Entities;

namespace API.Dtos.EmployeeDTO;

public class EmployeeDto
{
     public DateTime Birth_Date { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public Gender Gender {get;set;}
    public DateTime Hire_Date   { get; set; }
}