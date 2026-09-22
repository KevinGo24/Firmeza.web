using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firmeza.AppWeb.data;
using Firmeza.AppWeb.Models;
using Firmeza.AppWeb.ViewModels;

namespace Firmeza.AppWeb.Controllers;

public class DepartmentController(ApplicationsDbContext context) : Controller
{
    /// <summary>
    ///  Se crea una propiedad privada para el constructor
    /// </summary>
    private readonly ApplicationsDbContext _context = context;

    /// <summary>
    /// Creamos una función o método asíncrono lo cual nos devolverá los datos que le pidamos a la Db
    /// </summary>
    // GET
    
    public async Task<IActionResult> Index(string? code)
    {
        var allDepartments = _context.Departments.AsQueryable();

        var query = allDepartments;
        if (code != null)
        {
            query = query.Where(d => d.Code != null && d.Code.Contains(code));
        }

        var viewModel = new DepartmentIndexViewModel
        {
            Departments = await query.OrderBy(d => d.Name).ToListAsync(),
            TotalCount = await allDepartments.CountAsync(),
            ActiveCount = await allDepartments.CountAsync(d => d.IsActive),
            InactiveCount = await allDepartments.CountAsync(d => !d.IsActive),
            TotalBudget = await allDepartments.SumAsync(d => d.Budget ?? 0),
            SearchCode = code
        };

        return View(viewModel);
    }
// GET
    public IActionResult Create()
    {
        return View();
    }

// POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department)
    {
        if (!ModelState.IsValid)
        {
            return View(department);
        }

        department.Id = Guid.NewGuid();
        department.CreatedAt = DateTime.UtcNow;
        department.UpdatedAt = DateTime.UtcNow;

        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        TempData["Success"] = "Departamento creado correctamente";   // ← esta línea es la única nueva
        return RedirectToAction(nameof(Index));
    }
    // GET
    public async Task<IActionResult> Update(Guid id)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

// POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Guid id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(department);
        }

        var existing = await _context.Departments.FindAsync(id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.Code = department.Code;
        existing.Name = department.Name;
        existing.Description = department.Description;
        existing.Location = department.Location;
        existing.Budget = department.Budget;
        existing.Phone = department.Phone;
        existing.Email = department.Email;
        existing.IsActive = department.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;
        // CreatedAt NO se toca, se conserva el original

        await _context.SaveChangesAsync();
        TempData["Success"] = "Departamento actualizado correctamente";  
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var department = await _context.Departments.FindAsync(id);

        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Departamento eliminado correctamente";
        }

        return RedirectToAction(nameof(Index));
    }
}