using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;
using UploadWcfService;

namespace UpLoadConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {            
            AppDomain.CreateDomain("Image").DoCallBack(delegate {
                string url = "http://127.0.0.1:8080/UpLoadService.svc";
                ServiceHost host = new ServiceHost(typeof(UpLoadService),new Uri(url));
                host.Open();
                Console.WriteLine("WCF服务开启成功，地址：" + url);
            });
            Console.WriteLine("按任意建退出服务");
            Console.ReadKey();
        }
    }
}
