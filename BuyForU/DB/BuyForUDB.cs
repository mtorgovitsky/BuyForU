namespace BuyForU.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BuyForUDB : DbContext
    {
        public BuyForUDB()
            : base("name=BuyForUDB")
        {
            Database.CreateIfNotExists();
        }


        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<BuyForUDB>(new DBInitializer());

        //    base.OnModelCreating(modelBuilder);
        //}
    }


    public class DBInitializer : DropCreateDatabaseIfModelChanges<BuyForUDB>
    {
        protected override void Seed(BuyForUDB context)
        {
            context.Users.Add(new User
            {
                FirstName = "Moshe",
                LastName = "Levi",
                BirthDate = DateTime.Now.AddYears(-30),
                Email = "moshe.levi@mail.com",
                UserName = "moshelevi",
                Password = "1"
            });

            base.Seed(context);
        }
    }


    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}