using System;
using DockerPublish.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerPublish.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Student { get; set; }
    }
}
