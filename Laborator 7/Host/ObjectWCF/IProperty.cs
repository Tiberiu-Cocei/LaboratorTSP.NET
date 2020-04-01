using System.Collections.Generic;
using ModelAndAPI;
using System.ServiceModel;

namespace ObjectWCF
{
    [ServiceContract]
    interface IProperty
    {
        [OperationContract]
        bool AddProperty(string description);

        [OperationContract]
        List<Property> GetAllProperties();

        [OperationContract]
        bool DeleteProperties(List<int> propertyIndices);
    }
}
