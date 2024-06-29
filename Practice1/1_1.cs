using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace _1kp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("C:\\Users\\56\\Desktop\\1kp.json");
            var jObject = JObject.Parse(json);
            Console.Write("Введите код студента: ");
            var i = int.Parse(Console.ReadLine());
            var r = jObject["University"]["Schedule"].Where(g => g["students_code"].Value<int>() == i).FirstOrDefault();
            if (r != null)
            {
                Console.Write("Введите 1, если хотите добавить оценку, иначе 0: ");
                var k = int.Parse(Console.ReadLine());
                if (k == 1)
                {
                    Console.Write("Введите последовательно код предмета и оценку: ");
                    var i1 = int.Parse(Console.ReadLine());
                    var i2 = int.Parse(Console.ReadLine());
                    var test1 = jObject["University"]["Schedule"].Where(g => g["students_code"].Value<int>() == i).Where(g => g["subjects_code"].Value<int>() == i1).FirstOrDefault();
                    while (test1 != null)
                    {
                        Console.Write("Код предмета совпадает, введите другой: ");
                        i1 = int.Parse(Console.ReadLine());
                    }
                    JObject one = new JObject();
                    one["students_code"] = i.ToString();
                    one["subjects_code"] = i1.ToString();
                    one["score"] = i2.ToString();
                    ((JArray)jObject["University"]["Schedule"]).Add(one);

                }
                var firstname = jObject["University"]["Students"].Where(g => g["students_code"].Value<int>() == i).First()["firstname"].Value<String>();
                var surname = jObject["University"]["Students"].Where(g => g["students_code"].Value<int>() == i).First()["surname"].Value<String>();
                var middlename = jObject["University"]["Students"].Where(g => g["students_code"].Value<int>() == i).First()["middlename"].Value<String>();
                var student = jObject["University"]["Students"].Where(g => g["students_code"].Value<int>() == i);
                var schedule = jObject["University"]["Schedule"].Where(g => g["students_code"].Value<int>() == i);
                Console.WriteLine("Студент: " + student.Select(g => g["surname"]).First() + " " + student.Select(g => g["firstname"]).First() + " " + student.Select(g => g["middlename"]).First());
                Console.WriteLine();
                foreach (var rr in schedule)
                {
                    var subjects = jObject["University"]["Subjects"].Where(g => g["subjects_code"].Value<int>() == rr["subjects_code"].Value<int>());
                    foreach (var rrr in subjects)
                    {
                        Console.WriteLine("Предмет: " + rrr["subjects_name"].Value<String>());
                        Console.WriteLine("Оценка: " + rr["score"].Value<String>());
                        Console.WriteLine();
                    }
                }
                var whole = schedule.Select(g => g["score"]).Count();
                Console.WriteLine("Общее количество оценок: " + whole);
                Console.WriteLine("Процент оценок хорошо: " + schedule.Where(g => g["score"].Value<int>() == 4).Count() * 100 / whole + "%");
                Console.WriteLine("Процент оценок отлично: " + schedule.Where(g => g["score"].Value<int>() == 5).Count() * 100 / whole + "%");
                Console.WriteLine("Процент оценок удовлетворительно: " + schedule.Where(g => g["score"].Value<int>() == 3).Count() * 100 / whole + "%");
                File.WriteAllText("C:\\Users\\56\\Desktop\\1kp.json", jObject.ToString());
            }
            else
            {
                Console.WriteLine("Студент не найден");
            }
        }
    }
}
