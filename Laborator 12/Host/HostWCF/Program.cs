using System;
using System.ServiceModel;
using ObjectWCF;
using System.ServiceModel.Description;

namespace HostWCF
{
    /// <summary>
    /// Nume si prenume: Cocei Tiberiu
    /// Laborator: Miercuri 16-18
    /// Tema proiect: MyPhotos Proiectul 2
    /// Data predare proiect: 08.04.2020
    /// Bibliografie, surse de inspiratie: https://profs.info.uaic.ro/~iasimin/Laborator%20C%20S%20H/Laborator%20WCF%202020.pdf
    /// Rolul clasei: Host ce permite clientului sa se foloseasca
    /// de serviciul din proiectul ObjectWCF. De asemenea, se
    /// poate extrage metadata necesara pentru client.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lansare server WCF...");
            ServiceHost host = new ServiceHost(typeof(FileProperty), new Uri("http://localhost:8000/FP"));
            foreach (ServiceEndpoint se in host.Description.Endpoints)
                Console.WriteLine("A (address): {0} \nB (binding): {1}\nC(Contract): {2}\n", se.Address, se.Binding.Name, se.Contract.Name);
            host.Open();
            Console.WriteLine("Server in executie. Se asteapta conexiuni...");
            Console.WriteLine("Apasati Enter pentru a opri serverul!");
            Console.ReadKey();
            host.Close();
        }
    }
}
