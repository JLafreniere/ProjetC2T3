using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace APP_Presentation.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }

    }



    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("MyDbContextConnectionString")
        {
            Database.SetInitializer<MyDbContext>(new MyDbInitializer());
        }

        public DbSet<Utilisateur> users { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            // create 3 students to seed the database
            context.users.Add(new Utilisateur {  Username = "Mark",Password="123456" });
            context.SaveChanges();
            base.Seed(context);
        }
    }




}