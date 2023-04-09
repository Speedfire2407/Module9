namespace Task2
{
    class MyException : Exception
    { }
    class Numberreader
    {
        public delegate void NumberreaderDelegate(int value, string[] names);
        public event NumberreaderDelegate NumberEvent;

        public void Read(string[] names)
        {
            Console.WriteLine("Введите число 1 если хотите отсортировать от А до Я или число 2 от Я до А");

            int number = Convert.ToInt32(Console.ReadLine());

            if ((number != 1) && (number != 2))
            {
                throw new MyException();
            }

            NumberEntered(number, names);
        }

        public virtual void NumberEntered(int number, string[] names)
        {
            NumberEvent?.Invoke(number, names);
        }

    }
    internal class Program
    {
        const string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя.";
        public static void Sort1(string[] surnames)
        {
            var orderredPeople = from p in surnames orderby p select p;

            foreach (var sur in orderredPeople.ToArray())
            {
                Console.WriteLine(sur);
            }
        }

        public static void Sort2(string[] surnames)
        {
            var orderredPeople = from p in surnames orderby p select p;
            foreach (var sur in orderredPeople.Reverse().ToArray())
            {
                Console.WriteLine(sur);
            }
        }
        public static void RunMethod (int number, string[] surnames)
        {
            switch (number)
            {
                case 1: Sort1(surnames);
                        break;
                case 2: Sort2(surnames);
                        break;      
            }
        }


        static void Main(string[] args)
        {
            string[] surnames = new string[5];
            Console.WriteLine("Задайте массив фамилий");
            for (int i=0; i<surnames.Length; i++)
            {
                while (true)
                {
                    Console.Write(@"{0} фамилия ", i + 1);
                    try
                    {
                        surnames[i] = Console.ReadLine();
                        for (int j = 0; j < surnames[i].Length; j++)
                        {
                            for (int z = 0; z < Alphabet.Length; z++)
                            {
                                if (z == 66)
                                {
                                    throw new MyException();
                                }
                                if (Alphabet[z] == surnames[i][j])
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    catch (MyException ex)
                    {
                        Console.WriteLine("Введен запрещенный символ. " +
                            "Пожалуйста повторите ввод используя исключительно русский алфавит");
                    }
                }
            }
            Numberreader numberreader = new Numberreader();
            numberreader.NumberEvent += RunMethod;
            try
            {
                numberreader.Read(surnames);
                    
            }
            catch (MyException ex)
            {
                Console.WriteLine("Введино некоректное значение");
            }
            Console.ReadKey();
        }
    }
}