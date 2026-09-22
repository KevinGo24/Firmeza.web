using Microsoft.EntityFrameworkCore;
using Firmeza.AppWeb.Models;

namespace Firmeza.AppWeb.data;

public class ApplicationsDbContext : DbContext
{
    public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}