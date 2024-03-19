using System;

namespace ConsoleAppTask1
{
    public struct KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    public class MyDictionary<TKey, TValue>
    {
        private int count;
        private KeyValuePair<TKey, TValue>[] items;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public MyDictionary(int capacity)
        {
            items = new KeyValuePair<TKey, TValue>[capacity];
            count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                Console.WriteLine("Ключ уже существует в словаре.");
                return;
            }

            if (count >= items.Length)
            {
                Console.WriteLine("Словарь заполнен.");
                return;
            }

            items[count] = new KeyValuePair<TKey, TValue> { Key = key, Value = value };
            count++;
        }

        public void Remove(TKey key)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Key.Equals(key))
                {
                    Array.Copy(items, i + 1, items, i, count - i - 1);
                    count--;
                    return;
                }
            }
            Console.WriteLine("Элемент с указанным ключом не найден.");
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = 0; i < count; i++)
            {
                if (items[i].Key.Equals(key))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            count = 0;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (items[i].Key.Equals(key))
                        return items[i].Value;
                }
                throw new Exception("Элемент с указанным ключом не найден.");
            }
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Ключ: {items[i].Key}, Значение: {items[i].Value}");
            }
        }
    }

    public class Program
    {
        static MyDictionary<string, int> myDictionary;

        static void Main(string[] args)
        {
            myDictionary = new MyDictionary<string, int>(5);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Удалить элемент");
                Console.WriteLine("3. Проверить наличие элемента");
                Console.WriteLine("4. Очистить словарь");
                Console.WriteLine("5. Вывести содержимое словаря");
                Console.WriteLine("6. Выйти из программы");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddElement();
                        break;
                    case "2":
                        RemoveElement();
                        break;
                    case "3":
                        CheckElement();
                        break;
                    case "4":
                        ClearDictionary();
                        break;
                    case "5":
                        PrintDictionary();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте еще раз.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddElement()
        {
            Console.Write("Введите ключ: ");
            string key = Console.ReadLine();
            Console.Write("Введите значение: ");
            int value = int.Parse(Console.ReadLine());
            myDictionary.Add(key, value);
            Console.WriteLine("Элемент успешно добавлен.");
        }

        static void RemoveElement()
        {
            Console.Write("Введите ключ элемента для удаления: ");
            string key = Console.ReadLine();
            if (myDictionary.ContainsKey(key))
            {
                myDictionary.Remove(key);
                Console.WriteLine("Элемент успешно удален.");
            }
            else
            {
                Console.WriteLine("Элемент с указанным ключом не найден.");
            }
        }

        static void CheckElement()
        {
            Console.Write("Введите ключ элемента для проверки: ");
            string key = Console.ReadLine();
            if (myDictionary.ContainsKey(key))
            {
                Console.WriteLine("Элемент с указанным ключом найден.");
            }
            else
            {
                Console.WriteLine("Элемент с указанным ключом не найден.");
            }
        }

        static void ClearDictionary()
        {
            myDictionary.Clear();
            Console.WriteLine("Словарь успешно очищен.");
        }

        static void PrintDictionary()
        {
            Console.WriteLine("Содержимое словаря:");
            myDictionary.Print();
        }
    }
}



