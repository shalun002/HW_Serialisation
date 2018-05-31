using Classes.LIB.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;

/// <summary>
/// 1.	Объявить в консольном приложении класс Book с полями: название, стоимость, автор, год. Создать коллекцию элементов Book и заполнить тестовыми данными. С помощью класса BinaryFormatter сохранить состояние приложения в двоичный файл.
///  2.	На основании задания 1 восстановить состояние приложения из двоичного файла.
/// </summary>

namespace Classes.LIB
{
    public class Service
    {
        public string path = @"books.dat";

        public void BookAddService()
        {
            List<Book> listBooks = new List<Book>()
            {
                new Book()
                {
                    Author="Пушкин",
                    Name="Сказки1",
                    Price=100,
                    Year=2017
                },
                new Book()
                {
                    Author="Пушкин",
                    Name="Сказки2",
                    Price=200,
                    Year=2019
                },
                new Book()
                {
                    Author="Пушкин",
                    Name="Сказки3",
                    Price=300,
                    Year=2019
                }
            };

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listBooks);
                Console.WriteLine();
                Console.WriteLine("Коллекия сериализована!");
                Console.WriteLine();
            }

            Console.WriteLine("==================================================================================================");

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bookList = (List<Book>)formatter.Deserialize(stream);
                foreach (Book item in bookList)
                {
                    Console.WriteLine("Коллекия десериализована");
                    Console.WriteLine();
                    Console.WriteLine($"Author - {item.Author}, Name - {item.Name}, Price - {item.Price}, Year - {item.Year}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("================================================================================================");
        }
    }
}