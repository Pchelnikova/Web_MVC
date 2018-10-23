using System.Data.Entity;

namespace WebApplication_MVC
{
    internal class MyInitializer<T> : DropCreateDatabaseAlways<Model1>
    {
        protected override void Seed(Model1 context)
        {
            Pizza Caprissiosa = new Pizza()
            {
                Name = "Three acorn",
                Price = 50
            };

            Pizza Quatro = new Pizza()
            {
                Name = "Peanits",
                Price = 70
            };
            Pizza Diablo = new Pizza()
            {
                Name = "Nuts",
                Price = 100
            };

            Squirrel Ben = new Squirrel()
            {
                Name = "Ben",
                Tail_Color = "Red",
                isAdmin = false

            };

            Squirrel Dolly = new Squirrel()
            {
                Name = "Ten",
                Tail_Color = "Orange",
                isAdmin = false

            };
            Squirrel Admin = new Squirrel()
            {
                Name = "Admin",
                Tail_Color = "Black",
                isAdmin = true

            };
        }
    }

}
