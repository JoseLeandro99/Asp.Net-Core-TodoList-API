using Microsoft.EntityFrameworkCore;
using todolistapi.Models;

namespace todolistapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TodoItem> Todos { get; set; }
    }
}