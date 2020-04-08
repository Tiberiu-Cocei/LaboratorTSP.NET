using ModelAndAPI;
using System.Collections.Generic;

namespace ObjectWCF
{
    /// <summary>
    /// Nume si prenume: Cocei Tiberiu
    /// Laborator: Miercuri 16-18
    /// Tema proiect: MyPhotos Proiectul 2
    /// Data predare proiect: 08.04.2020
    /// Declaratie: Subsemnatul Cocei Tiberiu declar pe propria raspundere 
    /// ca acest cod nu a fost copiat din Internet sau din alte surse.
    /// Bibliografie, surse de inspiratie: https://profs.info.uaic.ro/~iasimin/Laborator%20C%20S%20H/Laborator%20WCF%202020.pdf
    /// Rolul clasei: un serviciu ce apeleaza metodele din API.
    /// </summary>
    public class FileProperty : IFileProperty
    {
        /// <summary>
        /// Aceasta metoda adauga un fisier primit in baza de date.
        /// De asemenea, creeaza legaturi cu propietatile primite ca id-uri.
        /// </summary>
        /// <param name="file">Obiectul de tip fisier.</param>
        /// <param name="propertyIndices">O lista cu id-urile propietatilor pentru fisier.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IFile.AddFile(File file, List<int> propertyIndices)
        {
            return FileAPI.AddFile(file, propertyIndices);
        }

        /// <summary>
        /// Aceasta metoda permite adaugarea unei propietati in baza de date.
        /// </summary>
        /// <param name="description">Descrierea propietatii.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IProperty.AddProperty(string description)
        {
            return PropertyAPI.AddProperty(description);
        }

        /// <summary>
        /// Aceasta metoda permite stergerea de propietati.
        /// </summary>
        /// <param name="propertyIndices">Lista cu id-uri pentru propietatile ce doresc a fi sterse.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IProperty.DeleteProperties(List<int> propertyIndices)
        {
            return PropertyAPI.DeleteProperties(propertyIndices);
        }

        /// <summary>
        /// Aceasta metoda permite cautarea fisierelor ce contin anumite propietati
        /// primite in forma de lista de id-uri.
        /// </summary>
        /// <param name="propertyIndices">Lista cu id-urile propietatilor.</param>
        /// <returns>Lista cu obiecte de tip fisier dupa filtrare.</returns>
        List<File> IFile.FileSearch(List<int> propertyIndices)
        {
            return FileAPI.FileSearch(propertyIndices);
        }

        /// <summary>
        /// In functie de boolean-ul primit, aceasta metoda apeleaza
        /// metoda de stergere sau de anulare a stergerii fisierelor marcate.
        /// </summary>
        /// <param name="cancel">Flag-ul de stergere.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IFile.FinishDeletion(bool cancel)
        {
            return FileAPI.FinishDeletion(cancel);
        }

        /// <summary>
        /// Aceasta metoda permite obtinerea tuturor propietatilor din baza de date.
        /// </summary>
        /// <returns>Lista cu obiecte de tip propietate ce reprezinta
        /// toate propietatile din baza de date.</returns>
        List<Property> IProperty.GetAllProperties()
        {
            return PropertyAPI.GetAllProperties();
        }

        /// <summary>
        /// Metoda aceasta permite obtinerea tuturor propietatilor unui fisier.
        /// </summary>
        /// <param name="fileIndex">Id-ul fisierului.</param>
        /// <returns>Lista cu propietati pe care le are fisierul primit.</returns>
        List<Property> IFile.GetFileProperties(int fileIndex)
        {
            return FileAPI.GetFileProperties(fileIndex);
        }

        /// <summary>
        /// Aceasta metoda marcheaza fisierele primite ca id pentru a fi sterse 
        /// atunci cand butonul "Confirm Delete" este apasat de catre utilizator.
        /// </summary>
        /// <param name="fileIndices">Lista cu id-urile fisierelor ce vor fi marcate.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IFile.MarkForDeletion(List<int> fileIndices)
        {
            return FileAPI.MarkForDeletion(fileIndices);
        }

        /// <summary>
        /// Aceasta metoda permite modificarea unui fisier si propietatile lui.
        /// </summary>
        /// <param name="file">Fisierul primit ca obiect. Campurile care nu sunt
        /// goale vor inlocui pe cele din baza de date.</param>
        /// <param name="propertyIndices">Lista cu id-urile propietatilor. Initial,
        /// toate propietatile vor fi sterse din fisier ca apoi sa fie inlocuite de acestea.</param>
        /// <returns>Un boolean care spune daca adaugarea a fost realizata cu succes.</returns>
        bool IFile.ModifyFile(File file, List<int> propertyIndices)
        {
            return FileAPI.ModifyFile(file, propertyIndices);
        }
    }
}
