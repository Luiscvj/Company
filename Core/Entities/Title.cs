namespace Core.Entities;

public class Title
{
    public string Title_Id { get; set; }
    public DateTime To_Date { get; set; }
    public DateTime From_Date { get; set; }
    public int Emp_NoId { get; set; }
    public Employee Employee { get; set; }
}