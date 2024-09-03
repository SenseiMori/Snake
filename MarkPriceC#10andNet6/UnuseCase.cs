using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkPriceC_10andNet6
{
    internal class UnuseCase
    {
        public static void ReverseStack(char[] array, int start, int end)
        {
            while (start < end)
            {
                char temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }


            //test
        }
        public static Stack<char> ReverveArray(Stack<char> stack, int shift)
        {

            char[] array = stack.ToArray();
            int length = array.Length;
            shift = shift % length;
            if (shift < 0) shift += length;

            ReverseStack(array, 0, length - 1);
            ReverseStack(array, 0, shift - 1);
            ReverseStack(array, shift, length - 1);

            // Создание нового стека и заполнение его из массива
            Stack<char> newStack = new Stack<char>();
            for (int i = 0; i < length; i++)
            {
                newStack.Push(array[i]);
            }

            return newStack;

        }

        //Сопоставление с образцом при помощи switch
        public static void LearnSwitch()
        {
            string path = @"C:\Users\1311971\source\repos\MarkPriceC#10andNet6\MarkPriceC#10andNet6";

            Console.Write(" R для чтения, W для записи");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            Stream? s;

            if (key.Key == ConsoleKey.R)
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Read
                    );
            }
            else
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Write);

            }

            string message;
            //Операторы case могут содержать ключевое слово when для выполнения
            //более точного сопоставления с образцом. В первом операторе case в предыдущем
            //коде совпадение было бы установлено только в том случае, если поток — это
            //FileStream, а его свойство CanWrite истинно
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "Файл можно прочитать";
                    break;
                case FileStream readableFile when s.CanRead:
                    message = "Файл можно изменить. кейс 2";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;
                default:
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null.";
                    break;

            }
            Console.Write(message);


            //Выражения switch
            //символ _ обозначает выполнение default
            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                => "The stream is a file that I can write to.",
                FileStream readOnlyFile
                => "The stream is a read-only file.",
                MemoryStream ms
                => "The stream is a memory address.",
                null
                => "The stream is null.",
                _
                => "The stream is some other type."
            };
            Console.WriteLine(message);
        }

        //Оператор  do While
        //оператор do выполняет выражение в конце блока кода, что означает,
        // что код выполнится хотя бы один раз

        public static void LearnDoWhile()
        {
            string? password;
            int count = 10;
            do
            {
                Console.Write("Enter your password: ");
                password = Console.ReadLine();
                count++;


            }
            while (password != "password");
            {
                Console.WriteLine("Correct!");



            }
            if (count == 10)
                Console.WriteLine("Not Correct!");


        }



        public static void TryCatch()
        {
            Console.WriteLine("Before parsing");
            Console.Write("What is your age? ");
            string? input = Console.ReadLine();
            try
            {
                int age = int.Parse(input);
                Console.WriteLine($"You are {age} years old.");
            }
            catch (FormatException form)
            {
                Console.WriteLine($"Format exception {form}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.GetType} says {exception.Message}");
            }

            Console.Write("Enter an amount: ");
            string? amount = Console.ReadLine();
            try
            {
                decimal amountValue = decimal.Parse(amount);
            }
            catch (FormatException) when (amount.Contains("$"))
            {
                Console.WriteLine("exception dollar");
            }



        }

    }
}
