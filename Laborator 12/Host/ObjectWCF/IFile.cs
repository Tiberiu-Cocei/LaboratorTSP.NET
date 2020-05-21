using System.Collections.Generic;
using System.ServiceModel;
using ModelAndAPI;

namespace ObjectWCF
{
    [ServiceContract]
    interface IFile
    {
        [OperationContract]
        bool AddFile(File file, List<int> propertyIndices);

        [OperationContract]
        List<File> FileSearch(List<int> propertyIndices);

        [OperationContract]
        bool ModifyFile(File file, List<int> propertyIndices);

        [OperationContract]
        List<Property> GetFileProperties(int fileIndex);

        [OperationContract]
        bool MarkForDeletion(List<int> fileIndices);

        [OperationContract]
        bool FinishDeletion(bool cancel);
    }
}
