using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            StartService();
            Console.ReadLine();
            StopService();
        }

        internal static ServiceHost myServiceHost = null;

        internal static void StartService()
        {
            //Consider putting the baseAddress in the configuration system
            //and getting it here with AppSettings
            Uri baseAddress = new Uri("http://localhost:8080/WCFQNTableSubscriptionService");

            //Instantiate new ServiceHost 
            myServiceHost = new ServiceHost(typeof(wcfService.WCFQNTableSubscription), baseAddress);

            // start the SqlDependency stuff
            wcfService.WCFQNTableSubscription.Start();

            //Open myServiceHost
            myServiceHost.Open();
        }

        internal static void StopService()
        {
            //Call StopService from your shutdown logic (i.e. dispose method)
            if (myServiceHost.State != CommunicationState.Closed)
                myServiceHost.Close();
        }
    }
}
