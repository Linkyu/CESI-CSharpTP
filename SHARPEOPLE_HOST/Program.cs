using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using SHARPEOPLE_LIB;

namespace SHARPEOPLE_HOST
{
    class Program  
    {
        private static void Main(string[] args)  
        {  
            // Step 1 Create a URI to serve as the base address.  
            var baseAddress = new Uri("http://localhost:8000/SHARPEOPLE/");  

            // Step 2 Create a ServiceHost instance  
            var selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);  

            try  
            {  
                // Step 3 Add a service endpoint.  
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");  

                // Step 4 Enable metadata exchange.  
                var smb = new ServiceMetadataBehavior {HttpGetEnabled = true};

                selfHost.Description.Behaviors.Add(smb);  

                // Step 5 Start the service.  
                selfHost.Open();

                var calculator = new CalculatorService();
                calculator.GetPeople();
                
                Console.WriteLine("The service is ready.");  
                Console.WriteLine("Press <ENTER> to terminate service.");  
                Console.WriteLine(); 
                //Console.ReadLine();  

                // Close the ServiceHostBase to shutdown the service.  
                selfHost.Close();  
                Console.WriteLine("BYE!");  
            }  
            catch (CommunicationException ce)  
            {  
                Console.WriteLine("An exception occurred: {0}", ce.Message);  
                selfHost.Abort();  
            }  
        }  
    }  
}