using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace USBDetector
{
    class Program
    {
        private static string command;
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------- USB WATCHER -------------------------");
            Console.WriteLine("Enter 'clear' to clear console");
            USBHandler usbHandler = new USBHandler();
            usbHandler.UsbAdded += UsbHandler_UsbAdded;
            usbHandler.UsbRemoved += UsbHandler_UsbRemoved;
            usbHandler.Start();

            while (true)
            {
                command = Console.ReadLine();
                if (command.Equals("clear", StringComparison.OrdinalIgnoreCase))
                    Console.Clear();
            }

        }

        private static void UsbHandler_UsbRemoved(object sender, EventArgs e)
        {

            Console.WriteLine("----------------------USB REMOVED----------------------------------------------------");
            EventArrivedEventArgs ea = (EventArrivedEventArgs)e;
            ManagementBaseObject instance = (ManagementBaseObject)ea.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                Console.WriteLine(property.Name + " = " + property.Value);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");

        }

        private static void UsbHandler_UsbAdded(object sender, EventArgs e)
        {
            Console.WriteLine("----------------------USB INSERTED----------------------------------------------------");
            EventArrivedEventArgs ea = (EventArrivedEventArgs)e;
            ManagementBaseObject instance = (ManagementBaseObject)ea.NewEvent["TargetInstance"];
            foreach (var property in instance.Properties)
            {
                Console.WriteLine(property.Name + " = " + property.Value);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------");
        }
    }
}
