using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static double f(double x)
            {
                try
                {
                  if (x == Math.Sqrt(2) || x == Math.Sqrt(-2) || x < 1) //если условие выполняется возникает исключение
                    {
                        throw new Exception();
                    }
                  else
                    {
                        return (x+4)/(Math.Pow(x, 2) - 2) + Math.Sqrt(Math.Pow(x, 3) - 1);
                    }
                }
                catch
                {
                    throw;  //Исключение передано внешнему блоку catch
                }
            }

            try
            {
                Console.WriteLine("Введите a (нижняя граница)");
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите b (верхняя граница)");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите h (шаг)");
                double h = double.Parse(Console.ReadLine());

                if (a > b)
                {
                    Console.WriteLine("Ошибка. Начало диапозона не может быть больше конца диапозона. Повторите попытку!");
                }

                for (double i = a; i <= b; i += h)
                {
                    if (h <= 0)
                    {
                        Console.WriteLine("Ошибка. Шаг не может быть отрицательным или равным 0. Повторите попытку.");
                        break;
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("y({0}) = {1:f4}", i, f(i));
                        }
                        catch
                        {
                            Console.WriteLine("y({0}) = Возникло исключение! Переменная x имеет недопустимое значение", i);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Неверный формат ввода данных");  //внешний catch
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка!");
            }

        }
    }
}

