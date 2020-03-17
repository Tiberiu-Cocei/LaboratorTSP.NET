using System;
using System.Linq;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestPerson();

            //TestOneToMany();

            TestManyToMany();

            Console.ReadKey();
        }

        static void TestManyToMany()
        {
            Console.WriteLine("Many to many association.");
            using(Model3Container context = new Model3Container())
            {
                Artist ar1 = new Artist()
                {
                    FirstName = "John",
                    LastName = "Doe"
                };
                Artist ar2 = new Artist()
                {
                    FirstName = "Jane",
                    LastName = "Doe"
                };
                Album al1 = new Album()
                {
                    AlbumName = "Sonata",
                    Artists =
                    {
                        ar1, ar2
                    }
                };
                Album al2 = new Album()
                {
                    AlbumName = "Test",
                    Artists =
                    {
                        ar1, ar2
                    }
                };
                ar1.Albums.Add(al1);
                ar1.Albums.Add(al2);
                ar2.Albums.Add(al1);
                ar2.Albums.Add(al2);
                context.Albums.Add(al1);
                context.Albums.Add(al2);
                context.Artists.Add(ar1);
                context.Artists.Add(ar2);
                context.SaveChanges();

                var items = context.Artists;
                foreach (var x in items)
                {
                    Console.WriteLine("Artist: {0}, {1}, {2}", x.ArtistId, x.FirstName, x.LastName);
                    foreach (var ox in x.Albums)
                    {
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.AlbumId, ox.AlbumName, ox.Artists);
                        foreach (var oy in ox.Artists)
                            Console.WriteLine("\tArtist: {0}, {1}, {2}", x.ArtistId, x.FirstName, x.LastName);
                    }

                }
            }
        }

        static void TestOneToMany()
        {
            Console.WriteLine("One to many association");
            using(Model2Container context = new Model2Container())
            {
                Console.WriteLine("Please type the person's name.");
                string firstName = ReadAndValidateStringInput(10);

                Console.WriteLine("Please type the person's city.");
                string city = ReadAndValidateStringInput(10);

                Console.WriteLine("Please type the value of the first order.");
                double firstValue = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please type the value of the second order.");
                double secondValue = Convert.ToDouble(Console.ReadLine());

                Customer c = new Customer()
                {
                    Name = firstName,
                    City = city
                };
                Order o1 = new Order()
                {
                    TotalValue = firstValue,
                    Date = DateTime.Now,
                    Customer = c
                };
                Order o2 = new Order()
                {
                    TotalValue = secondValue,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();

                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer: {0}, {1}, {2}", x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static string ReadAndValidateStringInput(int maxSize)
        {
            string input;
            do
            {
                input = Convert.ToString(Console.ReadLine());
                if (input.Length > maxSize)
                    Console.WriteLine("Error. Input must be {0} characters or shorter.", maxSize);
            }
            while (input.Length > 10);
            return input;
        }

        static void TestPerson()
        {
            Console.WriteLine("Test Model Designer First");

            Console.WriteLine("Please type the person's first name.");
            string firstName = ReadAndValidateStringInput(10);

            Console.WriteLine("Please type the person's middle name.");
            string middleName = ReadAndValidateStringInput(10);

            Console.WriteLine("Please type the person's last name.");
            string lastName = ReadAndValidateStringInput(10);

            Console.WriteLine("Please type the person's phone number.");
            string phoneNumber = ReadAndValidateStringInput(10);

            using (Model1Container context = new Model1Container())
            {
                Person p = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    PhoneNumber = phoneNumber
                };
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
            }
        }
    }
}
