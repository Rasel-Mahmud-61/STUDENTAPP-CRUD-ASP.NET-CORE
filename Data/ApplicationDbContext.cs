using CRUDOFSTUDENT.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDOFSTUDENT.Data
{
    public class ApplicationDbContext:DbContext
    {

        // create connection wiht database of outside 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
          {
            
        }

        //  create table into the database

      public   DbSet<Student> HELLOAllStudents { get; set; }   

    }
}
