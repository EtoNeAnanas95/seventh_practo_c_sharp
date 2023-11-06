using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class function
    {
        public static void PrintHat(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int width = Console.WindowWidth;

            Console.SetCursorPosition((width / 2) - name.Length, 0);
            Console.WriteLine(name);
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
        }

        public static int ArrowMenuFirst(int length)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int position = 2;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (position > 2) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position <= length) position++;
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key != ConsoleKey.Enter);
            Console.Clear();
            return position - 2;
        }

        public static int ArrowMenuMain(FileSystemInfo[] allItems)
        {
            int length = allItems.Length;
            Console.ForegroundColor = ConsoleColor.White;
            int position = 2;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey().Key;

                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                switch (key)
                {
                    case ConsoleKey.UpArrow:ы
                        if (position > 2) position--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (position <= length) position++;
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                }
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
            }
            while (key != ConsoleKey.Enter);

            Open(allItems[position - 2]);
            return 1;
        }

        public static void OpenFolder(DirectoryInfo mainDirectory)
        {
            int wait;
            do
            {
                Console.Clear();
                FileSystemInfo[] items = mainDirectory.GetFileSystemInfos();

                PrintHat(mainDirectory.Name);

                foreach (var item in items)
                {
                    if ((item.Attributes & FileAttributes.ReparsePoint) == 0)
                    {
                        Console.WriteLine($"  {item.Name}");
                    }
                }
                wait = ArrowMenuMain(items);
            }
            while (wait != -1);
        }

        public static void OpenFile(FileInfo file)
        {

        }

        public static void Open(FileSystemInfo item)
        {
            PrintHat(item.Name);

            if (item is DirectoryInfo directory)
            {
                OpenFolder(directory);
            }
            else if (item is FileInfo file)
            {
                OpenFile(file);
            }
        }
    }
}
