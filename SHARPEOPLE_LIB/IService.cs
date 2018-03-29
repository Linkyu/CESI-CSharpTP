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
	    
	    [OperationContract]  
	    People GetPeople(int id); 
	    
	    [OperationContract]  
	    void DelPeople(int id);
	    
	    [OperationContract]  
	    void AddPeople(string name, float height, float weight);
	    
	    [OperationContract]  
	    List<People> SetPeople(int id, string name, float height, float weight);
    }
}  