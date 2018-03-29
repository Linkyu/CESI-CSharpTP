// IService.cs  

using System.Collections.Generic;
using System.ServiceModel;

namespace SHARPEOPLE_LIB
{  
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]  
    public interface ICalculator  
    {  
        [OperationContract]  
        List<Dictionary<string, string>> GetPeople(); 
    }  
}  