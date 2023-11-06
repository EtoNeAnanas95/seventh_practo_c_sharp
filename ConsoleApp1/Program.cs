using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void PrintDrives()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int width = Console.WindowWidth;
            Console.SetCursorPosition((width / 2) - 7, 0);
            Console.WriteLine("Этот компьютер");
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (DriveInfo driveInfo in allDrives)
            {
                Console.WriteLine($"  {driveInfo.Name} свободно: {driveInfo.TotalFreeSpace / 1073741824} GB из {driveInfo.TotalSize / 1073741824} GB");
            }
            Console.ResetColor();
            DirectoryInfo mainDirectory = new DirectoryInfo(allDrives[function.ArrowMenuFirst(allDrives.Length)].Name);
            function.Open(mainDirectory);
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            PrintDrives();
            Console.Clear();
        }
    }
}