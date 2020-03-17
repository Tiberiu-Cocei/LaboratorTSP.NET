using System;
using System.Linq;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lab5_Scenariu1();

            //Lab5_Scenariu2();

            //Lab5_Scenariu3();

            //Lab5_Scenariu4();

            Lab5_Scenariu5();

            Console.ReadKey();
        }

        static void Lab5_Scenariu1()
        {
            using(ModelSelfReferences context = new ModelSelfReferences())
            {
                SelfReference selfRef1 = new SelfReference()
                {
                    Name = "first self reference"
                };
                SelfReference selfRef2 = new SelfReference()
                {
                    Name = "second self reference"
                };
                selfRef1.References.Add(selfRef2);
                //selfRef1.References.Add(selfRef1);
                context.SelfReferences.Add(selfRef1);
                context.SelfReferences.Add(selfRef2);
                context.SaveChanges();

                var items = context.SelfReferences;
                foreach (var x in items)
                {
                    Console.WriteLine("Reference: {0}", x.Name);
                    foreach (var ox in x.References)
                    {
                        Console.WriteLine("\tOrders: {0}", ox.Name);
                    }
                }
            }
        }

        static void Lab5_Scenariu2()
        {
            using(ModelScenariu2 context = new ModelScenariu2())
            {
                var product = new Product
                {
                    SKU = 148,
                    Description = "Expandable Hydration Pack",
                    Price = 19.97M,
                    ImageURL = "/pack147.jpg"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 179,
                    Description = "Rugged Ranger Duffel Bag",
                    Price = 39.97M,
                    ImageURL = "/pack178.jpg"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 187,
                    Description = "Range Field Pack",
                    Price = 98.97M,
                    ImageURL = "/noimage.jpg"
                };
                context.Products.Add(product);
                product = new Product
                {
                    SKU = 203,
                    Description = "Small Deployment Backpack",
                    Price = 29.97M,
                    ImageURL = "/pack202.jpg"
                };
                context.Products.Add(product);
                context.SaveChanges();
            }

            using(ModelScenariu2 context = new ModelScenariu2())
            {
                foreach(var p in context.Products)
                {
                    Console.WriteLine("{0} {1} {2} {3}", p.SKU, p.Description, p.Price.ToString("C"), p.ImageURL);
                }
            }
        }

        static void Lab5_Scenariu3()
        {
            byte[] thumbBits = new byte[100];
            byte[] fullBits = new byte[2000];
            using (var context = new ModelScenariu3())
            {
                var photo = new Photograph
                {
                    Title = "My Dog",
                    ThumbnailBits = thumbBits
                };
                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits = fullBits
                };
                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();
            }
            using (var context = new ModelScenariu3())
            {
                foreach (var photo in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes",
                    photo.Title, photo.ThumbnailBits.Length);
                    context.Entry(photo).Reference(p => p.PhotographFullImage).Load();
                    Console.WriteLine("Full Image Size: {0} bytes",
                    photo.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }

        static void Lab5_Scenariu4()
        {
            using (var context = new ModelScenariu4())
            {
                var business = new Business
                {
                    Name = "Corner Dry Cleaning",
                    LicenseNumber = "100x1"
                };
                context.Businesses.Add(business);
                var retail = new Retail
                {
                    Name = "Shop and Save",
                    LicenseNumber = "200C",
                    Address = "101 Main",
                    City = "Anytown",
                    State = "TX",
                    ZIPCode = "76106"
                };
                context.Businesses.Add(retail);
                var web = new eCommerce
                {
                    Name = "BuyNow.com",
                    LicenseNumber = "300AB",
                    URL = "www.buynow.com"
                };
                context.Businesses.Add(web);
                context.SaveChanges();
            }
            using (var context = new ModelScenariu4())
            {
                Console.WriteLine("\n--- All Businesses ---");
                foreach (var b in context.Businesses)
                {
                    Console.WriteLine("{0} (#{1})", b.Name, b.LicenseNumber);
                }
                Console.WriteLine("\n--- Retail Businesses ---");
                foreach (var r in context.Businesses.OfType<Retail>())
                {
                    Console.WriteLine("{0} (#{1})", r.Name, r.LicenseNumber);
                    Console.WriteLine("{0}", r.Address);
                    Console.WriteLine("{0}, {1} {2}", r.City, r.State, r.ZIPCode);
                }
                Console.WriteLine("\n--- eCommerce Businesses ---");
                foreach (var e in context.Businesses.OfType<eCommerce>())
                {
                    Console.WriteLine("{0} (#{1})", e.Name, e.LicenseNumber);
                    Console.WriteLine("Online address is: {0}", e.URL);
                }
            }
        }

        static void Lab5_Scenariu5()
        {
            using (var context = new ModelScenariu5())
            {
                var fte = new FullTimeEmployee
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Salary = 71500M
                };
                context.Employees.Add(fte);
                fte = new FullTimeEmployee
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Salary = 62500M
                };
                context.Employees.Add(fte);
                var hourly = new HourlyEmployee
                {
                    FirstName = "Tom",
                    LastName = "Jones",
                    Wage = 8.75M
                };
                context.Employees.Add(hourly);
                context.SaveChanges();
            }
            using (var context = new ModelScenariu5())
            {
                Console.WriteLine("--- All Employees ---");
                foreach (var emp in context.Employees)
                {
                    bool fullTime = emp is HourlyEmployee ? false : true;
                    Console.WriteLine("{0} {1} ({2})", emp.FirstName, emp.LastName,
                    fullTime ? "Full Time" : "Hourly");
                }
                Console.WriteLine("--- Full Time ---");
                foreach (var fte in context.Employees.OfType<FullTimeEmployee>())
                {
                    Console.WriteLine("{0} {1}", fte.FirstName, fte.LastName);
                }
                Console.WriteLine("--- Hourly ---");
                foreach (var hourly in context.Employees.OfType<HourlyEmployee>())
                {
                    Console.WriteLine("{0} {1}", hourly.FirstName,
                    hourly.LastName);
                }
            }
        }
    }
}
