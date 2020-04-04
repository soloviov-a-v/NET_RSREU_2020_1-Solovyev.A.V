using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Watcher
    {
        public Watcher()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"FileSystem";
                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.Size;
                watcher.Filter = "*.txt";
                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.IncludeSubdirectories = true;
                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Для выхода нажмите q");
                while (Console.Read() != 'q') ;
            }
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"Файл: {e.FullPath} изменен {e.ChangeType}");
            CopyInArchiveDirectory("FileSystem", "FileSystem" + DateTime.Now.ToString("dd.MM.yyy hh-mm-ss"));
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"Файл {e.OldFullPath} переименован в {e.FullPath}");
            CopyInArchiveDirectory("FileSystem", "FileSystem" + DateTime.Now.ToString("dd.MM.yyy hh-mm-ss"));
        }
        public static void CopyInArchiveDirectory(string sourceDirectory, string archiveDirectory)
        {
            DirectoryInfo sourceDir = new DirectoryInfo(sourceDirectory);
            DirectoryInfo archiveDir = new DirectoryInfo(archiveDirectory);
            if (!archiveDir.Exists)
                archiveDir.Create();
            FileInfo[] files = sourceDir.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(archiveDir.FullName, file.Name));
            }
            DirectoryInfo[] directories = sourceDir.GetDirectories();
            foreach (DirectoryInfo directory in directories)
            {
                string archDir = Path.Combine(archiveDir.FullName, directory.Name);
                CopyInArchiveDirectory(directory.FullName, archDir);
            }
        }
    }
    class Changer
    {
        public Changer(string archiveDate)
        {
            string sourceDirectory = "FileSystem" + archiveDate;
            Console.WriteLine("E:FileSystem");
            if (Directory.Exists("FileSystem"))
                Directory.Delete("FileSystem", true);
            Watcher.CopyInArchiveDirectory(sourceDirectory, "FileSystem");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char x;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Меню программы.\n   1 - наблюдатель;\n   2 - откатить изменения");
                x = Console.ReadKey().KeyChar;
            }
            while (x != '1' && x != '2');
            Console.WriteLine();
            if (x == 49)
            {
                Console.WriteLine("Включен режим наблюдения.");
                Watcher watch = new Watcher();
            }
            if (x == 50)
            {
                Console.Write("Введите дату отката: ");
                string date = Console.ReadLine();
                Changer change = new Changer(date);
            }
            Console.ReadLine();
        }
    }
}
