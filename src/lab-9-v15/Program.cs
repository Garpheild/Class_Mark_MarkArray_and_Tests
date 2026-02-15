using lab_9_v15;

namespace Lab9.Demo
{
    class Program
    {
        static int GetInt(string startMessage, string erorrMessage, int minValue = 1, int maxValue = 100)
        {
            bool isNumber = false;
            int n;
            do
            {
                Console.Write(startMessage);
                isNumber = int.TryParse(Console.ReadLine(), out n);
                if (!isNumber || (n < minValue || n > maxValue))
                {
                    Console.WriteLine(erorrMessage);
                }
            } while (!isNumber || (n < minValue || n > maxValue));

            return n;
        }
        static string GetStr(string startMessage, string erorrMessage)
        {
            bool isStr = false;
            string str;
            do
            {
                Console.Write(startMessage);
                str = Console.ReadLine();
                bool hasLetter = false;
                foreach (char c in str) { if (char.IsLetter(c)) hasLetter = true; break; }
                if (!hasLetter)
                {
                    Console.WriteLine(erorrMessage);
                }
                else isStr = true;
            } while (!isStr);

            return str;
        }

        static void Main()
        {
            Console.WriteLine("Работа с классом Mark:");
            DemoMarkClass();

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Console.WriteLine("Демонстрация работы с классом MarkArray:");
            DemoMarkArrayClass();


        }

        static void DemoMarkClass()
        {
            Console.WriteLine("1. Создание объектов Mark:");

            Mark mark1 = new Mark(); 
            Console.WriteLine($"   Конструктор по умолчанию: {mark1.Show()}");

            Mark mark2 = new Mark("Программирование", 10); 
            Console.WriteLine($"   Параметризованный конструктор: {mark2.Show()}");


            Console.WriteLine("\n2. Демонстрация операторов:");

            Mark upperMark = !mark2;
            Console.WriteLine($"   Оператор ! (верхний регистр): {upperMark.Show()}");

            Mark zeroMark = -mark2; 
            Console.WriteLine($"   Оператор - (обнуление оценки): {zeroMark.Show()}");

            Mark renamedMark = mark2 / "Алгебра"; 
            Console.WriteLine($"   Оператор / (изменение имени): {renamedMark.Show()}");


            Console.WriteLine("\n3. Демонстрация преобразований:");

            Mark testMark = new Mark("АБВГД123456789", 7);
         
            Console.WriteLine($"   Явное преобразование в int: '{testMark.Name_}' = {(int)testMark} букв");

            bool isPassing = testMark; 
            Console.WriteLine($"   Неявное преобразование в bool: оценка {testMark.Mark_} = {isPassing}");

            
            Console.WriteLine("\n4. Демонстрация сравнения:");

            Mark mark3 = new Mark("Физика", 6);
            Mark mark4 = new Mark("Химия", 8);

            Console.WriteLine($"   {mark3.Show()} >= {mark4.Show()} : {mark3 >= mark4}");
            Console.WriteLine($"   {mark3.Show()} <= {mark4.Show()} : {mark3 <= mark4}");

            
            Console.WriteLine("\n5. Пятибалльная система:");

            for (int i = 0; i <= 10; i += 2)
            {
                Mark m = new Mark($"Предмет{i}", i);
                Console.WriteLine($"   Оценка {i}: {m.ToFivePointScale()}");
                Console.WriteLine($"   Оценка {i}: {Mark.ToFivePointScale(m)}");
            }

            Console.WriteLine($"\n   Всего создано объектов Mark: {Mark.CountObjects()}");
        }

        static void DemoMarkArrayClass()
        {
            Console.WriteLine("1. Создание массива вручную:");

            
            MarkArray manualArray = CreateManualArray(GetInt("Введите длину коллекции MarkArray: ", "Неверная длина "));
            Console.WriteLine("\n   Содержимое массива (созданного вручную):");
            Console.WriteLine(manualArray.Display());

            Console.WriteLine("\n2. Создание массива случайными значениями:");

            int randLen = GetInt("Введите длину случайного массива: ", "Неверная длина ", 0, 10), randMin = GetInt("Введите минммальную оценку: ", "Неверная оценка", 1, 10);
            int randMax = GetInt("Введите максимальную оценку: ", "Неверная оценка ", randMin, 10);
            MarkArray randomArray = new MarkArray(randLen, randMin, randMax);
            Console.WriteLine("\n   Содержимое массива (случайная генерация):");
            Console.WriteLine(randomArray.Display());

            string subs = FindSubjectAboveAvarage(randomArray);
            if (subs == "") Console.WriteLine("\n    Нет дисциплин с оценками выше средней");
            else Console.WriteLine($"\n   Дисциплины с оценками выше средней: {subs}");
            Console.ReadLine();

            Console.WriteLine("\n3. Глубокое копирование массива:");

           
            MarkArray copiedArray = new MarkArray(randomArray);
            Console.WriteLine("\n   Содержимое оригинального массива:");
            Console.WriteLine(randomArray.Display());

            Console.WriteLine("\n   Содержимое скопированного массива:");
            Console.WriteLine(copiedArray.Display());

            
            Console.WriteLine("\n4. Демонстрация глубокого копирования:");
            Console.WriteLine("   Изменен первый элемнт оригинального массива");

            if (randomArray.Length > 0)
            {
                randomArray[0] = new Mark("ИЗМЕНЕННЫЙ", 10);

                Console.WriteLine("\n   Оригинальный массив после изменения:");
                Console.WriteLine(randomArray.Display());

                Console.WriteLine("\n   Скопированный массив (не должен измениться):");
                Console.WriteLine(copiedArray.Display());
            }

            
            Console.WriteLine("\n5. Работа с индексатором:");

            if (copiedArray.Length > 0)
            {
                Console.WriteLine($"   Первый элемент: {copiedArray[0]?.Show()}");
                Console.WriteLine($"   Последний элемент: {copiedArray[copiedArray.Length - 1]?.Show()}");


                Console.WriteLine($"   До изменения второго элемента:");
                Console.WriteLine(copiedArray.Display());
                copiedArray[1] = new Mark("ОБНОВЛЕННЫЙ", 9);
                Console.WriteLine($"   После изменения второго элемента:");
                Console.WriteLine(copiedArray.Display());
                Console.WriteLine($"   Попытка получить элемент по индексу за границами массива:");
                try
                {
                    copiedArray[copiedArray.Length].Show();
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"   Попытка присвоить элемент по индексу за границами массива:");
                try
                {
                    copiedArray[copiedArray.Length] = copiedArray[1];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static MarkArray CreateManualArray(int length)
        {
            MarkArray array = new MarkArray(length);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Mark(GetStr($"Введите название предмета оценки {i + 1}: ", "Некорректное название предмета "), GetInt($"Введите оценку {i+1}: ", "Ошибка ввода оценки ", 0, 10));
            }
            return array;

        }

        static string FindSubjectAboveAvarage(MarkArray markArray)
        {
            int sum = 0;
            string subjects = "";

            for (int i = 0; i < markArray.Length; i++)
            {
                sum += markArray[i].Mark_;
            }
            float average = sum / markArray.Length;

            for (int i = 0; i < markArray.Length; i++)
            {
                if (markArray[i].Mark_ > average) subjects += $"{markArray[i].Name_}, ";
            }
            return subjects;
        }


    }
}
