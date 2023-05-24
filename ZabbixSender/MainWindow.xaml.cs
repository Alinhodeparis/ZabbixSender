using System;
using System.Timers;
using ZabbixSender;
using Newtonsoft.Json;


namespace ZabbixSender
{
    
    class Program
    {
        static void Main(String[] args)
        {
            //Connection Zabbix 

           /* var url = "home.vicdmitrienko.com/api_jsonrpc.php";
            var request = HttpWebResponse;
            request.ContentType = "application/json";
            request.Method = "POST";
            request.ContentType = "application/json";*/


            
            var sender = new ZabbixSender("home.vicdmitrienko.com\", 10051");
           
            Timer time = new Timer(10000);  // timer tyo send the data every 10 s
            timer.Elapsed += (sender, e) =>
            {

                var host = new ZabbixHost("ru.indorsoft.bali");
                var item = new ZabbixItem("zabbix-trapper", "numeric");

                var result = sender.send(item, host);
                if (result.succes)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Failed to send item:");
                    Console.WriteLine("result.ErrorMessage");
                }

            };
            sender.Start();

            Console.ReadLine();           
            

        }

        private static void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    internal class timer
    {
        internal static Action<object, object> Elapsed;
    }
}


