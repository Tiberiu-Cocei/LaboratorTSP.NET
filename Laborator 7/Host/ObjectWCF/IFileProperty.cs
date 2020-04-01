using System.ServiceModel;

namespace ObjectWCF
{
    [ServiceContract]
    interface IFileProperty : IFile, IProperty
    {
    }
}
