using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

using Newtonsoft.Json;

using Steve.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steve.DatabaseLogger
{

    public class DatabaseOptions
    {
        public string Server { get; set; }

        public string Database { get; set; }

        public string User { get; set; }
        
        public string Password { get; set; }
    
    }

    internal class LogContext :DbContext
    {
        private readonly DatabaseOptions _options;

        public virtual DbSet<LogMessageModel> Messages { get; set; }

        public LogContext(DatabaseOptions options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogMessageModel>(entity =>
            {
                entity.Property(e => e.Parameters)
                      .HasConversion(p => JsonConvert.SerializeObject(p), p => JsonConvert.DeserializeObject<Dictionary<string,object>?>(p));

                entity.Property(e => e.Exception)
                      .HasConversion(p => JsonConvert.SerializeObject(p), p => JsonConvert.DeserializeObject<Exception?>(p));

                entity.Property(e => e.Object)
                      .HasConversion(o => JsonConvert.SerializeObject(o), o => JsonConvert.DeserializeObject<object?>(o));
            });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server={_options.Server};database={_options.Database};user={_options.User};password={_options.Password};Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        public static void ApplyMigrations(DatabaseOptions options)
        {
            using var context = new LogContext(options);

            var migrator = context.GetService<IMigrator>();

            migrator.Migrate();
        }

    }
}
