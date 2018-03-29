// IService.cs  

using System.Collections.Generic;
using System.ServiceModel;

namespace SHARPEOPLE_LIB
{  
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
    public interface IPeople  
    {  
        [OperationContract]  
        List<People> GetPeople(); 
    }  
}  