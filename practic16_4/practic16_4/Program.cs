using System;
using System.Collections;

namespace practic16_4
{
    class Program
    {
        static Hashtable catalog = new Hashtable();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nВыберите действие:"
                    + "\n1. Добавление диска."
                    + "\n2. Удаление диска."
                    + "\n3. Добавление музыки."
                    + "\n4. Удаление музыки."
                    + "\n5. Просмотреть содержимое каталога"
                    + "\n6. Просмотреть содержимое диска"
                    + "\n7. Поиск всех записей заданного исполнителя\n");
                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "1": AddDisk();
                        break;
                    case "2": DeleteDisk();
                        break;
                    case "3": AddSong(); 
                        break;
                    case "4": DeleteSong(); 
                        break;
                    case "5": DisplayCatalog(); 
                        break;
                    case "6": DisplayDisk(); 
                        break;
                    case "7": SearchByArtist();
                        break;
                    default:
                    {
                        Console.Clear(); Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    }
                    break;
                }
            }
        }
        private static void AddDisk()
        {
            Console.Write("Введите название диска: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                Console.WriteLine("Диск с таким именем уже существует.");
            }
            else
            {
                catalog[diskName] = new ArrayList();
                Console.WriteLine("Диск был добавлен!");
            }
        }
        private static void DeleteDisk()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
            }
            else
            {
                Console.Write("Введите название диска для удаления: ");
                string diskName = Console.ReadLine();
                if (catalog.ContainsKey(diskName))
                {
                    catalog.Remove(diskName);
                    Console.WriteLine("Диск был удален!");
                }
                else
                {
                    Console.WriteLine("Диска с таким именем нет.");
                }
            }
        }
        private static void AddSong()
        {
            Console.Write("Введите название диска, на который хотите добавить песню: ");
            string diskName = Console.ReadLine();
            if (catalog.ContainsKey(diskName))
            {
                ArrayList music = (ArrayList)catalog[diskName];

                Console.Write("Введите название песни: ");
                string musicName = Console.ReadLine();
                
                Console.Write("Введите имя исполнителя: ");
                string artistName = Console.ReadLine();


                if (diskName.Contains(musicName))
                {
                    Console.WriteLine("Песня с таким именем уже существует на диске.");
                }
                else
                {
                    music.Add(string.Concat(musicName, " - ", artistName));
                    Console.WriteLine("Песня была добавлена!");
                }
            }
            else
            {
                Console.WriteLine("Диска с таким именем не существует.");
            }
        }
        private static void DeleteSong()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
            }
            else
            {
                Console.Write("Введите название диска, с которого нужно удалить песню: ");
                string diskName = Console.ReadLine();

                if (catalog.Contains(diskName))
                {

                    ArrayList music = (ArrayList)catalog[diskName];
                    if (music.Count == 0)
                    {
                        Console.WriteLine($"Диск {diskName} уже пустой.");
                    }
                    else
                    {
                        Console.Write("Введите название песни: ");
                        string musicName = Console.ReadLine();

                        if (music.Contains(musicName))
                        {
                            music.Remove(musicName);
                            Console.WriteLine("Песня была удалена!");
                        }
                        else
                        {
                            Console.WriteLine($"Песня с таким именем не существует на диске {diskName}.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Диска с таким именем не существует.");
                }
            }
        }
        private static void DisplayCatalog()
        {
            if (catalog.Keys.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
            }
            else
            {
                Console.WriteLine("Содержимое каталога:");

                int i = 1;
                foreach (string diskName in catalog.Keys) { Console.WriteLine($"{i}: {diskName}"); i++; }
            }
        }
        private static void DisplayDisk()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
            }
            else
            {
                Console.Write("Введите название диска для просмотра его содержимого: ");
                string diskName = Console.ReadLine();

                if (catalog.ContainsKey(diskName))
                {
                    ArrayList music = (ArrayList)catalog[diskName];

                    if (music.Count == 0)
                    {
                        Console.WriteLine($"Содержимое диска {diskName} пустое.");
                    }
                    else
                    {

                        Console.WriteLine($"Содержимое диска {diskName}: ");

                        int i = 1;
                        foreach (string musicName in music) { Console.WriteLine($"{i}: {musicName}"); i++; }
                    }
                }
                else
                {
                    Console.WriteLine("Диска с таким именем не существует.");
                }
            }
        }
        private static void SearchByArtist()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
            }
            else
            {
                Console.Write("Введите имя исполнителя для поиска записей: ");
                string artistName = Console.ReadLine();
                bool found = false;
                int i = 0;

                foreach (ArrayList songs in catalog.Values)
                {

                    foreach (string songName in songs)
                    {
                        if (songName.Contains(artistName))
                        {
                            Console.WriteLine($"{songName}");
                            found = true; i++;
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Записи исполнителя не найдены.");
                }
                else
                {
                    Console.WriteLine($"Найдены записи в количестве: {i}");
                }
            }
        }
    }
}
