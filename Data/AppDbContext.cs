using Microsoft.EntityFrameworkCore;
using Todo.Model;

namespace Todo.Data {
    public class AppDbContext : DbContext {
        public DbSet<TodoModel> todos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("DataSource=app.db;Cache=shared");
    }
}
