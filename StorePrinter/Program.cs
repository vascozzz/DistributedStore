using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace StorePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:1337/Printer");

            //Create the Service Host
            ServiceHost host = new ServiceHost(typeof(StorePrinter.PrinterServ), address);

            //Enable metadata publishing
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            host.Description.Behaviors.Add(smb);

            //Open the Service Host
            host.Open();


            Console.WriteLine("Printer now active. Press <Enter> to close.");
            Console.ReadLine();

            host.Close();
        }
    }
}
