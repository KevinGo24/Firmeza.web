using Firmeza.AppWeb.Models;

namespace Firmeza.AppWeb.ViewModels;

public class DepartmentIndexViewModel
{
    public List<Department> Departments { get; set; } = new();

    public int TotalCount { get; set; }
    public int ActiveCount { get; set; }
    public int InactiveCount { get; set; }
    public decimal TotalBudget { get; set; }

    public string? SearchCode { get; set; }
}