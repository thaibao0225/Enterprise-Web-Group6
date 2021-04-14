using Album.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Album.Data {
    // Kế thừa từ IdentityDbContext nên có sẵn các DbSet
    // UserRoles Roles RoleClaimsUsers UserClaims UserLogins UserTokens
    public class AppDbContext : IdentityDbContext<AppUser> {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create (builder => {
            builder
                // .AddFilter (DbLoggerCategory.Database.Command.Name, LogLevel.Warning)
                // .AddFilter (DbLoggerCategory.Query.Name, LogLevel.Debug)
                .AddConsole ();
        });

        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring (optionsBuilder);
            // optionsBuilder
            //     .UseLoggerFactory (loggerFactory);
        }

        protected override void OnModelCreating (ModelBuilder builder) {

            base.OnModelCreating (builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in builder.Model.GetEntityTypes ()) {
                var tableName = entityType.GetTableName ();
                if (tableName.StartsWith ("AspNet")) {
                    entityType.SetTableName (tableName.Substring (6));
                }
            }
        }

        public DbSet<Article> Article { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Deadline> Deadline { set; get; }
        public DbSet<DeadlineCate> DeadlineCate { set; get; }
        public DbSet<File> File { set; get; }
        public DbSet<RegisterComment> RegisterComment { set; get; }
        public DbSet<RegisterDeadline> RegisterDeadline { set; get; }
        public DbSet<RegisterEvent> RegisterEvent { set; get; }

    }
}