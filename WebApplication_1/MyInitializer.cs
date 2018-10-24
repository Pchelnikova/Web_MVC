using System.Data.Entity;

namespace WebApplication_MVC
{
    internal class MyInitializer<T> : DropCreateDatabaseAlways<Model1>
    {
        protected override void Seed(Model1 context)
        {
            Pizza Acorn = new Pizza()
            {
                Name = "Three acorn",
                Price = 50
            };
            context.Pizzas.Add(Acorn);
            context.SaveChanges();

            Pizza QuatroNuts = new Pizza()
            {
                Name = "QuatroNuts",
                Price = 70
            };
            context.Pizzas.Add(QuatroNuts);
            context.SaveChanges();
            Pizza Mix = new Pizza()
            {
                Name = "NutsMix",
                Price = 100
            };
            context.Pizzas.Add(Mix);
            context.SaveChanges();

            Squirrel Chip = new Squirrel()
            {
                Login = "Chip",
                Password = "C",
                Tail_Color = "Red",
                isAdmin = false

            };
            context.Squirrels.Add(Chip);
            context.SaveChanges();
            Squirrel Deil = new Squirrel()
            {
                Login = "Deil",
                Password = "D",
                Tail_Color = "Orange",
                isAdmin = false

            };
            context.Squirrels.Add(Deil);
            context.SaveChanges();
            Squirrel Admin = new Squirrel()
            {
                Login = "Admin",
                Password = "Admin",
                Tail_Color = "Black",
                isAdmin = true

            };
            context.Squirrels.Add(Admin);
            context.SaveChanges();
        }
    }

}
