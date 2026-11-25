
using Lab3;

Console.WriteLine("==================================");
Console.WriteLine("     КОПИРОВАНИЕ С ПЕРЕИМЕНОВАНИЕМ");
Console.WriteLine("==================================");
Console.WriteLine();

// Создаём объект для работы с файлами
FileCopyService copyService = new FileCopyService();

// Запрашиваем путь к исходному файлу
Console.Write("Введите полный путь к исходному файлу: ");
string sourcePath = Console.ReadLine() ?? string.Empty;

// Запрашиваем папку назначения
Console.Write("Введите путь к папке назначения: ");
string destinationFolder = Console.ReadLine() ?? string.Empty;

// Запрашиваем новое имя файла
Console.Write("Введите новое имя файла: ");
string newFileName = Console.ReadLine() ?? string.Empty;

Console.WriteLine();
Console.WriteLine("========== РЕЗУЛЬТАТ ==========");

// Выполняем копирование
bool success = copyService.CopyFile(
    sourcePath,
    destinationFolder,
    newFileName
);

if (success)
{
    Console.WriteLine("Операция завершена успешно.");
}
else
{
    Console.WriteLine("Не удалось выполнить копирование.");
}

Console.WriteLine();
Console.WriteLine("Нажмите Enter для выхода.");
Console.ReadLine();
