using Classes.LIB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classes.LIB
{
    public class ServiceSoap
    {
        public string pathCsv = @"Person.csv";
        public string pathSoap = @"Person.soap";

        Person p = new Person();
        public void PersonService()
        {
            FileInfo file = new FileInfo(pathCsv);

            using (StreamReader sr = new StreamReader(pathCsv))
            {
                string temp = sr.ReadLine();
                var m = temp.Split(' ');
                p.Name = m[0];
                p.LastName = m[1];
                p.TellephoneNumber = m[2];
                p.DateOfBirth = m[3];
                p.person.Add(p);
            }
            SoapSerialize();
        }

        public void SoapSerialize()
        {
            SoapFormatter formater = new SoapFormatter();

            using (FileStream fs = new FileStream(pathSoap, FileMode.OpenOrCreate))
            {
                Console.WriteLine();
                formater.Serialize(fs, p);
                Console.WriteLine("Коллекия сериализована в Soap формат!");
                Console.WriteLine();
            }
        }
    }
}