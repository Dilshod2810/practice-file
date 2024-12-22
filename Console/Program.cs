// // DriveInfo[] drives = DriveInfo.GetDrives();
// //  
// // foreach (DriveInfo drive in drives)
// // {
// //     Console.WriteLine($"Название: {drive.Name}");
// //     Console.WriteLine($"Тип: {drive.DriveType}");
// //     if (drive.IsReady)
// //     {
// //         Console.WriteLine($"Объем диска: {drive.TotalSize}");
// //         Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
// //         Console.WriteLine($"Метка диска: {drive.VolumeLabel}");
// //     }
// //     Console.WriteLine();
// // }
// //
// // public DirectoryInfo (string path);
//
// string dirName = "D:\\";
// // если папка существует
// if (Directory.Exists(dirName))
// {
//     Console.WriteLine("Подкаталоги:");
//     string[] dirs = Directory.GetDirectories(dirName);
//     foreach (string s in dirs)
//     {
//         Console.WriteLine(s);
//     }
//     Console.WriteLine();
//     Console.WriteLine("Файлы:");
//     string[] files = Directory.GetFiles(dirName);
//     foreach (string s in files)
//     {
//         Console.WriteLine(s);
//     }
// }

using System;
using System.IO;


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Показать информацию о дисках");
            Console.WriteLine("2. Управление каталогами");
            Console.WriteLine("3. Управление файлами");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт меню: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowDriveInfo();
                    break;
                case "2":
                    ManageDirectories();
                    break;
                case "3":
                    ManageFiles();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    

    static void ShowDriveInfo()
    {
        foreach (DriveInfo drive in DriveInfo.GetDrives())
        {
            if (drive.IsReady)
            {
                Console.WriteLine($"Диск {drive.Name}");
                Console.WriteLine($"  Метка тома: {drive.VolumeLabel}");
                Console.WriteLine($"  Тип файловой системы: {drive.DriveFormat}");
                Console.WriteLine($"  Общий размер: {drive.TotalSize / 1024 / 1024 / 1024} ГБ");
                Console.WriteLine($"  Доступное место: {drive.AvailableFreeSpace / 1024 / 1024 / 1024} ГБ");
            }
            else
            {
                Console.WriteLine($"Диск {drive.Name} не готов.");
            }
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ManageDirectories()
    {
        Console.Write("Введите путь к каталогу: ");
        string path = Console.ReadLine();
        if (Directory.Exists(path))
        {
            Console.WriteLine("1. Создать новый каталог");
            Console.WriteLine("2. Удалить каталог");
            Console.WriteLine("3. Показать содержимое каталога");
            Console.WriteLine("4. Показать свойства каталога");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Введите имя нового каталога: ");
                    Directory.CreateDirectory(Path.Combine(path, Console.ReadLine()));
                    break;
                case "2":
                    Directory.Delete(path, true);
                    Console.WriteLine("Каталог удален.");
                    break;
                case "3":
                    foreach (var entry in Directory.GetFileSystemEntries(path))
                    {
                        Console.WriteLine(entry);
                    }
                    break;
                case "4":
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    Console.WriteLine($"Полный путь: {dirInfo.FullName}");
                    Console.WriteLine($"Дата создания: {dirInfo.CreationTime}");
                    Console.WriteLine($"Последнее изменение: {dirInfo.LastWriteTime}");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Каталог не существует.");
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

    static void ManageFiles()
    {
        Console.Write("Введите путь к файлу: ");
        string filePath = Console.ReadLine();

        Console.WriteLine("1. Создать и записать текст в файл");
        Console.WriteLine("2. Прочитать содержимое файла");
        Console.WriteLine("3. Переименовать файл");
        Console.WriteLine("4. Удалить файл");
        Console.WriteLine("5. Показать свойства файла");
        Console.Write("Выберите действие: ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Введите текст для записи: ");
                File.WriteAllText(filePath, Console.ReadLine());
                break;
            case "2":
                if (File.Exists(filePath))
                {
                    Console.WriteLine(File.ReadAllText(filePath));
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
                break;
            case "3":
                Console.Write("Введите новое имя файла: ");
                string newPath = Path.Combine(Path.GetDirectoryName(filePath), Console.ReadLine());
                File.Move(filePath, newPath);
                break;
            case "4":
                File.Delete(filePath);
                Console.WriteLine("Файл удален.");
                break;
            case "5":
                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    Console.WriteLine($"Имя: {fileInfo.Name}");
                    Console.WriteLine($"Полный путь: {fileInfo.FullName}");
                    Console.WriteLine($"Размер: {fileInfo.Length} байт");
                    Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
                break;
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }

