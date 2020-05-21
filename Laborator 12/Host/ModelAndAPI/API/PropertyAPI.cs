using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ModelAndAPI
{
    /// <summary>
    /// Nume si prenume: Cocei Tiberiu
    /// Laborator: Miercuri 16-18
    /// Tema proiect: MyPhotos Proiectul 1
    /// Data predare proiect: 16.03.2020
    /// Declaratie: Subsemnatul Cocei Tiberiu declar pe propria raspundere 
    /// ca acest cod nu a fost copiat din Internet sau din alte surse.
    /// Bibliografie, surse de inspiratie:
    /// Rolul clasei: permite mai multe actiuni asupra bazei de date, cum
    /// ar fi: Adaugarea si stergerea de propietati, obtinerea tuturor 
    /// propietatilor din baza de date.
    /// </summary>
    public static class PropertyAPI
    {
        /// <summary>
        /// Aceasta metoda permite adaugarea unei propietati in baza de date.
        /// </summary>
        /// <param name="description">Descrierea propietatii.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool AddProperty(string description)
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                Property property = new Property()
                {
                    Description = description
                };
                context.Properties.Add(property);
                context.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Aceasta metoda permite obtinerea tuturor propietatilor din baza de date.
        /// </summary>
        /// <returns>Lista cu obiecte de tip propietate ce reprezinta
        /// toate propietatile din baza de date.</returns>
        public static List<Property> GetAllProperties()
        {
            List<Property> toReturn = new List<Property>();
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                var properties = context.Properties;
                foreach(var auxProperty in properties)
                    toReturn.Add(auxProperty);
            }
            return toReturn;
        }

        /// <summary>
        /// Aceasta metoda permite stergerea de propietati.
        /// </summary>
        /// <param name="propertyIndices">Lista cu id-uri pentru propietatile ce doresc a fi sterse.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool DeleteProperties(List<int> propertyIndices)
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                foreach(var propertyIndex in propertyIndices)
                {
                    Property property = context.Properties.Find(propertyIndex);
                    var propertyLists = context.PropertyLists.Where(x => x.PropertyId == property.Id);

                    foreach(var propertyList in propertyLists)
                        context.PropertyLists.Remove(propertyList);

                    context.Properties.Remove(property);
                }
                context.SaveChanges();
            }
            return true;
        }
    }
}
