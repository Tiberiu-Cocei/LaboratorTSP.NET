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
    /// ar fi: Cautarea de fisere cu filtre, Adaugarea, modificarea si 
    /// stergerea fisierelor specificate precum si obtinerea
    /// propietatilor unui fisier.
    /// </summary>
    public static class FileAPI
    {
        /// <summary>
        /// Aceasta metoda adauga un fisier primit in baza de date.
        /// De asemenea, creeaza legaturi cu propietatile primite ca id-uri.
        /// </summary>
        /// <param name="file">Obiectul de tip fisier.</param>
        /// <param name="propertyIndices">O lista cu id-urile propietatilor pentru fisier.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool AddFile(File file, List<int> propertyIndices)
        {
            using(ModelBDContainer1 context = new ModelBDContainer1())
            {
                context.Files.Add(file);
                foreach(var propertyIndex in propertyIndices)
                {
                    Property property = context.Properties.Find(propertyIndex);
                    PropertyList auxPropertyList = new PropertyList()
                    {
                        FileId = file.Id,
                        PropertyId = property.Id
                    };
                    context.PropertyLists.Add(auxPropertyList);
                }
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Aceasta metoda permite cautarea fisierelor ce contin anumite propietati
        /// primite in forma de lista de id-uri.
        /// </summary>
        /// <param name="propertyIndices">Lista cu id-urile propietatilor.</param>
        /// <returns>Lista cu obiecte de tip fisier dupa filtrare.</returns>
        public static List<File> FileSearch(List<int> propertyIndices)
        {
            List<File> returnList = new List<File>();
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                var files = context.Files;
                foreach(var file in files)
                {
                int matchingPropertyCount = 0;
                    foreach (var propertyIndex in propertyIndices)
                    {
                        Property property = context.Properties.Find(propertyIndex);
                        if (context.PropertyLists.Where(x => x.FileId == file.Id && x.PropertyId == property.Id).Count() == 0)
                            break;

                        matchingPropertyCount++;
                    }
                    if (matchingPropertyCount == propertyIndices.Count())
                        returnList.Add(file);
                }
            }
            return returnList;
        }

        /// <summary>
        /// Aceasta metoda permite modificarea unui fisier si propietatile lui.
        /// </summary>
        /// <param name="file">Fisierul primit ca obiect. Campurile care nu sunt
        /// goale vor inlocui pe cele din baza de date.</param>
        /// <param name="propertyIndices">Lista cu id-urile propietatilor. Initial,
        /// toate propietatile vor fi sterse din fisier ca apoi sa fie inlocuite de acestea.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool ModifyFile(File file, List<int> propertyIndices)
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                var dbFile = context.Files.Find(file.Id);
                if (dbFile != null)
                {
                    if(file.Description.Length != 0)
                        dbFile.Description = file.Description;
                    if (file.Name.Length != 0)
                        dbFile.Name = file.Name;
                    if (file.Path.Length != 0)
                        dbFile.Path = file.Path;

                    var presentProperties = GetFileProperties(dbFile.Id);

                    var propertyList = context.PropertyLists.Where(x => x.FileId == file.Id);
                    foreach (var _propertyList in propertyList)
                        context.PropertyLists.Remove(_propertyList);

                    foreach (var propertyIndex in propertyIndices)
                    {
                        var property = context.Properties.Find(propertyIndex);
                        PropertyList newPropertyList = new PropertyList()
                        {
                            FileId = file.Id,
                            PropertyId = property.Id
                        };
                        context.PropertyLists.Add(newPropertyList);
                    }
                    context.SaveChanges();
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda aceasta permite obtinerea tuturor propietatilor unui fisier.
        /// </summary>
        /// <param name="fileIndex">Id-ul fisierului.</param>
        /// <returns>Lista cu propietati pe care le are fisierul primit.</returns>
        public static List<Property> GetFileProperties(int fileIndex)
        {
            List<Property> toReturn = new List<Property>();

            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                File file = context.Files.Find(fileIndex);
                var propertyLists = context.PropertyLists.Where(x => x.FileId == file.Id);
                foreach(var propertyList in propertyLists)
                {
                    toReturn.Add(context.Properties.Where(x => x.Id == propertyList.PropertyId).FirstOrDefault());
                }
                return toReturn;
            }
        }

        /// <summary>
        /// Aceasta metoda marcheaza fisierele primite ca id pentru a fi sterse 
        /// atunci cand butonul "Confirm Delete" este apasat de catre utilizator.
        /// </summary>
        /// <param name="fileIndices">Lista cu id-urile fisierelor ce vor fi marcate.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool MarkForDeletion(List<int> fileIndices)
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                foreach(var fileIndex in fileIndices)
                {
                    File file = context.Files.Find(fileIndex);
                    var auxFile = context.Files.Find(file.Id);
                    if (auxFile == null)
                        return false;

                    auxFile.ToDelete = true;
                }
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Aceasta metoda anuleaza stergerea fisierelor. 
        /// Flag-ul "ToDelete" va deveni fals pentru toate fisierele.
        /// </summary>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        private static bool CancelDeletion()
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                var files = context.Files.Where(x => x.ToDelete == true);
                foreach(var file in files)
                {
                    file.ToDelete = false;
                }
                context.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Aceasta metoda realizeaza stergerea fisierelor marcate.
        /// </summary>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        private static bool AcceptDeletion()
        {
            using (ModelBDContainer1 context = new ModelBDContainer1())
            {
                var files = context.Files.Where(x => x.ToDelete == true);
                foreach(var file in files)
                {
                    var propertyLists = context.PropertyLists.Where(x => x.FileId == file.Id);
                    foreach(var propertyList in propertyLists)
                    {
                        context.PropertyLists.Remove(propertyList);
                    }
                    context.Files.Remove(file);
                }
                context.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// In functie de boolean-ul primit, aceasta metoda apeleaza
        /// metoda de stergere sau de anulare a stergerii fisierelor marcate.
        /// </summary>
        /// <param name="cancel">Flag-ul de stergere.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        public static bool FinishDeletion(bool cancel)
        {
            if (cancel)
                return CancelDeletion();
            else
                return AcceptDeletion();
        }
    }
}
