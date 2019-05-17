using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Reflectcion.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //Klasik olarak method çağrılması.
            DortIslem dortIslem = new DortIslem(2, 3);
            Console.WriteLine(dortIslem.Topla(10,1));
            Console.WriteLine(dortIslem.Topla2());


            // $$$$$$$$$$$$$$$$$$$$$  Reflection ile method tetiklme $$$$$$$$$$$$$$$$$$$
            { 
                var type = typeof(DortIslem);
                //DortIslem dortsIslem = (DortIslem)Activator.CreateInstance(type,6,7);

                var instance = Activator.CreateInstance(type, 6, 7);
                MethodInfo methodInfo = instance.GetType().GetMethod("Topla2");
                var result = methodInfo.Invoke(instance,null);

            }

            // Reflection ile Method ve parametre bigilerini okumak
            {
                Console.WriteLine("--------------------------------------");
                var type = typeof(DortIslem);
                var methods = type.GetMethods();

                foreach (var methodInfo in methods)
                {
                    Console.WriteLine(methodInfo);
                    foreach (var infoParameter in methodInfo.GetParameters())
                    {
                        Console.WriteLine(" {0}", infoParameter.Name);
                    }
                }
                 

            }

            Console.ReadLine();
        }
    }

    public class DortIslem
    {
        private int _sayi1;
        private int _sayi2;

        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi1 = sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
    }
}
