using FortuneWheelLibrary;
using System;
using System.ServiceModel;

namespace FortuneWheelService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost servHost = null;
            try
            {
                // Create the service host 
                servHost = new ServiceHost(typeof(Wheel));

                // Start the service
                servHost.Open();
                Console.WriteLine("Service started. Press a key to quit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                if (servHost != null)
                    servHost.Close();
            }
        }
    }
}
