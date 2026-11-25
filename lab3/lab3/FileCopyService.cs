
using System;
using System.IO;

namespace Lab3;

public class FileCopyService
{
    public bool CopyFile(string sourcePath, string destinationFolder, string newFileName)
    {
        // Проверяем, что исходный путь указан
        if (string.IsNullOrWhiteSpace(sourcePath))
        {
            Console.WriteLine("Ошибка: путь к исходному файлу не указан.");
            return false;
        }

        // Проверяем, что папка назначения указана
        if (string.IsNullOrWhiteSpace(destinationFolder))
        {
            Console.WriteLine("Ошибка: папка назначения не указана.");
            return false;
        }

        // Проверяем новое имя файла
        if (string.IsNullOrWhiteSpace(newFileName))
        {
            Console.WriteLine("Ошибка: новое имя файла не указано.");
            return false;
        }

        try
        {
            // Проверяем существование исходного файла
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Ошибка: исходный файл не найден.");
                return false;
            }

            // Проверяем существование папки назначения
            if (!Directory.Exists(destinationFolder))
            {
                Console.WriteLine("Ошибка: папка назначения не существует.");
                return false;
            }

            // Получаем расширение исходного файла
            string extension = Path.GetExtension(sourcePath);

            // Формируем новое имя с исходным расширением
            string finalFileName = Path.HasExtension(newFileName)
                ? newFileName
                : newFileName + extension;

            // Формируем полный путь к новому файлу
            string destinationPath = Path.Combine(destinationFolder, finalFileName);

            // Проверяем, существует ли файл с таким именем
            if (File.Exists(destinationPath))
            {
                Console.Write($"Файл уже существует. Перезаписать его? (да/нет): ");
                string? answer = Console.ReadLine();

                if (!string.Equals(answer?.Trim(), "да", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Копирование отменено.");
                    return false;
                }
            }

            // Выполняем копирование
            File.Copy(sourcePath, destinationPath, overwrite: true);

            Console.WriteLine("Файл успешно скопирован!");
            Console.WriteLine($"Новый путь: {destinationPath}");

            return true;
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Ошибка: недостаточно прав для выполнения операции.");
            return false;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            return false;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Некорректный путь или имя файла: {ex.Message}");
            return false;
        }
        catch (NotSupportedException ex)
        {
            Console.WriteLine($"Операция не поддерживается: {ex.Message}");
            return false;
        }
    }
}
