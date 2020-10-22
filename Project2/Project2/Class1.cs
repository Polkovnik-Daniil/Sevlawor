using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class Class1
    {

        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] str = new string[5];
            str[4] = "anything";
            try
            {
                str[4] = "anything";
                Console.WriteLine("It's OK");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                int x = 5;
                int y = x / 0;  // DivideByZeroException
                Console.WriteLine($"Результат: {y}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Возникло исключение DivideByZeroException");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception");
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            int[] values = { 10, 7 };
            foreach (var value in values)
            {
                try
                {
                    Console.WriteLine("{0} divided by 2 is {1}", value, DivideByTwo(value));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
                }
                Console.WriteLine();
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            try
            {
                Exclusion somePerson = new Exclusion("Иван", -21);
            }
            catch (Exception ex)
            {
                //Обработка ошибок
                Console.WriteLine("Произошла ошибка: " + ex.Message + "; с кодом: " + Exclusion.ErrorCode);
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            Console.Read();
        }

        static int DivideByTwo(int num)
        {
            // If num is an odd number, throw an ArgumentException.
            if ((num & 1) == 1)
                throw new ArgumentException(String.Format("{0} is not an even number", num), "num");
            // num is even, return half of its value.
            return num / 2;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Класс, для описания пользовательского типа ошибок
    class Exclusion : Exception //Используем наследование
    {
        //Принимает сообщение с описание ошибки, и код ошибки
        public Exclusion(string aMessage, int aCode)
            : base(aMessage) //Вызываем конструктор базового класса
        {
            errorCode = aCode;
        }

        //Возвращает код ошибки
        public int ErrorCode { get { return errorCode; } }

        //Код ошибки
        private int errorCode;
    }
}