using Microsoft.EntityFrameworkCore;
using Todo.Model;

namespace Todo.Data {
    public class AppDbContext : DbContext {
        public DbSet<TodoModel> todos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlServer("Server=localhost,1433;Database=App;User ID=sa;Password=@Haus3521#;trustServerCertificate=true;");
    }
}
