namespace Firmeza.AppWeb.Models;

public class Employees
{
    public Guid Id { get; set; }
    public string? Document { get; set; }
    public string? FirtsName { get; set; }
    public string? LastName { get; set; }
    public int Phone { get; set; }
    public string? Email { get; set; }
    public string? Position { get; set; }
    public int Salary { get; set; }
}