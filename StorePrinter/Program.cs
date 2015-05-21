using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace StorePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = "http://localhost/PrinterService.svc";
            BasicHttpBinding binding = new BasicHttpBinding();

            ServiceHost host = new ServiceHost(typeof(StorePrinter.PrinterServ));
            host.AddServiceEndpoint(typeof(IPrinterServ), binding, address);

            host.Open();
            Console.WriteLine("Printer now active. Press <Enter> to close.");
            Console.ReadLine();
            host.Close();
        }
    }
}
