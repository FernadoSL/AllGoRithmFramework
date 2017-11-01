using AllGoRithmFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace AllGoRithmFramework.Repository.Contexts
{
    public class BaseContext<T> : DbContext where T : BaseEntity
    {
        private readonly string connectionString;
        private readonly string specifiedSchema;
        private readonly string primaryKeyConvention = "Id";

        public DbSet<T> DbSet { get; set; }

        public BaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public BaseContext(string connectionString, string primaryKeyConvention) : this (connectionString)
        {
            this.primaryKeyConvention = primaryKeyConvention;
        }

        public BaseContext(string connectionString, string primaryKeyConvention, string specifiedSchema) : this (connectionString, primaryKeyConvention)
        {
            this.specifiedSchema = specifiedSchema;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type type = typeof(T);
            PropertyInfo propertyPrimaryKey = type.GetProperties().FirstOrDefault(m => m.Name.Equals(type.Name + primaryKeyConvention, StringComparison.OrdinalIgnoreCase));
            
            if(propertyPrimaryKey != null)
            {
                modelBuilder.Entity<T>().HasKey(propertyPrimaryKey.Name);
            }

            if (!String.IsNullOrEmpty(this.specifiedSchema))
            {
                modelBuilder.Entity<T>().ToTable(type.Name, this.specifiedSchema);
            }
            else
            {
                modelBuilder.Entity<T>().ToTable(type.Name);
            }
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
