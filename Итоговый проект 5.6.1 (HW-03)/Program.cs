using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Итоговый_проект_5._6._1__HW_03_
{
    internal class Program
    {
        static string[] mass;
        static (string Name, string LastName, int Age, bool HasPets, string[] favcolors) EnterUser()
        {
            (string Name, string LastName, int Age, bool HasPets, string[] favcolors) User;
            Console.WriteLine("Введите имя");
            User.Name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            User.LastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();
            } while(CheckNum(age, out intage));
            User.Age = intage;

            Console.WriteLine("Есть ли у вас домашние животные?тветьте в формате \"да\" или \"нет\"");
            string answer = Console.ReadLine();
            string numberPets;
            int count;
            if (answer == "да")
            {
                User.HasPets = true;
                do
                {
                    Console.WriteLine("Сколько у вас домашних животных?");
                    numberPets = Console.ReadLine();
                } while (CheckNum(numberPets, out count));
                if (User.HasPets)
                {
                    string[] array = CreateArrayPets(count);
                    mass = array;
                    for (int i = 0; i < array.Length; i++)
                        Console.Write(array[i] + "; ");
                }
            }
            else User.HasPets = false;

            string numberOfColors;
            int numcolors;
            do
            {
                Console.WriteLine("\nНапишите количество ваших любимых цветов");
                numberOfColors = Console.ReadLine();
            } while (CheckNum(numberOfColors, out numcolors));
            User.favcolors = new string[numcolors];
            for (int i = 0; i < User.favcolors.Length; i++)
            {
                User.favcolors[i] = ShowColor();
            }
            Console.WriteLine("Ваши любимые цвета: ");
            foreach(string color in User.favcolors)
            {
                Console.WriteLine(color);
            }

            return User;
        }

        static string[] CreateArrayPets(int num)
        {
            var result = new string[num];
            Console.WriteLine("Какие у питомцев клички?");
            for (int i = 0; i < num; i++)
            {
                result[i] = Console.ReadLine();
            }
            return result;
        }

        static bool CheckNum(string number, out int corrnumber)
        {
            if(int.TryParse(number, out int intnum))
            {
                if(intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                Console.WriteLine("Некорректное значение");
                return true;
            }
        }

        static string ShowColor()
        {
            Console.WriteLine("\nНапишите свой любимый цвет на английском с маленькой буквы");
            var color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Your color is yellow!");
                    break;
            }
            return color;
        }
        
        static void Show((string Name, string LastName, int Age, bool HasPets, string[] favcolors) corteg)
        {
            Console.WriteLine("Ваши данные: \nИмя: {0}, \nФамилия: {1}, \nВозраст: {2}, \nНаличие питомцев: {3} \nЛюбимые цвета: ", corteg.Name, corteg.LastName, corteg.Age, corteg.HasPets);
            foreach(var colors in corteg.favcolors) 
                Console.WriteLine(colors);
            if(mass != null)
            {
                Console.WriteLine("Любимые питомцы: ");
                foreach(var pets in mass)
                    Console.WriteLine(pets);
            }
        }

        static void Main()
        {
            var variable = EnterUser();
            Show(variable);
        }
    }
}
