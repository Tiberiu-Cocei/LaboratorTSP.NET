using ModelAndAPI;
using System.Collections.Generic;

namespace ObjectWCF
{
    public class FileProperty : IFileProperty
    {
        bool IFile.AddFile(File file, List<int> propertyIndices)
        {
            return FileAPI.AddFile(file, propertyIndices);
        }

        bool IProperty.AddProperty(string description)
        {
            return PropertyAPI.AddProperty(description);
        }

        bool IProperty.DeleteProperties(List<int> propertyIndices)
        {
            return PropertyAPI.DeleteProperties(propertyIndices);
        }

        List<File> IFile.FileSearch(List<int> propertyIndices)
        {
            return FileAPI.FileSearch(propertyIndices);
        }

        bool IFile.FinishDeletion(bool cancel)
        {
            return FileAPI.FinishDeletion(cancel);
        }

        List<Property> IProperty.GetAllProperties()
        {
            return PropertyAPI.GetAllProperties();
        }

        List<Property> IFile.GetFileProperties(int fileIndex)
        {
            return FileAPI.GetFileProperties(fileIndex);
        }

        bool IFile.MarkForDeletion(List<int> fileIndices)
        {
            return FileAPI.MarkForDeletion(fileIndices);
        }

        bool IFile.ModifyFile(File file, List<int> propertyIndices)
        {
            return FileAPI.ModifyFile(file, propertyIndices);
        }
    }
}
