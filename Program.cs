using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zadanie2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строки разделенные пробелом");
            string input = Console.ReadLine();
            string[] arr = input.Split(' ');

            // А) Определения количество содержащихся в ней цифр и вывода их на экран и их количества
            var digits = arr.Select(s => s.Where(ch => char.IsDigit(ch))).ToList(); //для каждой строки отбираем только цифры
            var allDigits = new List<char>(); // Список для хранения всех цифр из всех строк
            for (int i = 0; i < digits.Count; i++)
            {
                allDigits.AddRange(digits[i]);// Объеденям все цифры из всех строк в один список
            }
            Console.WriteLine($"Количество цифр в строках: {allDigits.Count}");
            Console.WriteLine($"Цифры в строках: {string.Join(" ", allDigits)}");

            // Б)  Вывода на экран всех элементов массива, пока не встретится символ “/”
            Console.WriteLine("Элементы до символа '/': ");
            var beforeSlash = arr.TakeWhile(s => !s.Contains('/')).ToList(); //перебераем строки массива и включаем их в результат, пока строка не содержит "/"
            Console.WriteLine(string.Join(", ", beforeSlash));

            // В) Вывода на экран всех элементов массива, которые содержатся после символа “/” и с заменой у всех этих элементов букв на верхний регистр (если они в нижнем регистре и в нижний регистр (если они в верхнем регистре). 
            var modified = arr
                .SkipWhile(s => !s.Contains('/')) // Пропускаем строки до символа "/"
                .Select(s => new string(s.Select(ch => //Если символ буква, то меняем регистр: если в верхнем,делаем его нижним, если нижнем - верхним
                char.IsLetter(ch) ? (char.IsUpper(ch) ? char.ToLower(ch) : char.ToUpper(ch)) : ch).ToArray())).ToList(); // Получаем список измненных строк
            string file = "mod.txt"; // сохраняем в файл
            File.WriteAllLines(file, modified);
            Console.WriteLine($"Строки с измененным регистром: {string.Join(" ",modified)}");
            Console.ReadKey();
        }
    }
}
