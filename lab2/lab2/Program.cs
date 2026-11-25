
using Lab2;

// Создаём библиотеку
Library library = new Library();

// Создаём книги
Book book1 = new Book(
    "Война и мир",
    "Лев Толстой",
    1225);

Book book2 = new Book(
    "Преступление и наказание",
    "Фёдор Достоевский",
    672);

// Создаём журналы
Magazine magazine1 = new Magazine(
    "Наука и жизнь",
    "Редакция",
    5);

Magazine magazine2 = new Magazine(
    "Вокруг света",
    "Редакция",
    8);

// Создаём электронные издания
ElectronicPublication electronic1 =
    new ElectronicPublication(
        "C# для начинающих",
        "Иван Иванов",
        "PDF");

ElectronicPublication electronic2 =
    new ElectronicPublication(
        "Основы программирования",
        "Пётр Петров",
        "EPUB");

// Добавляем все публикации
library.AddPublication(book1);
library.AddPublication(book2);
library.AddPublication(magazine1);
library.AddPublication(magazine2);
library.AddPublication(electronic1);
library.AddPublication(electronic2);

// Демонстрация всех публикаций
Console.WriteLine("========== ВСЕ ПУБЛИКАЦИИ ==========");

foreach (Publication publication in library.Publications)
{
    Console.WriteLine(publication);
}

// Поиск по автору
Console.WriteLine("\n========== ПОИСК ПО АВТОРУ ==========");

string searchAuthor = "Толстой";

List<Publication> searchResults =
    library.FindByAuthor(searchAuthor);

if (searchResults.Count > 0)
{
    Console.WriteLine($"Результаты поиска по запросу \"{searchAuthor}\":");

    foreach (Publication publication in searchResults)
    {
        Console.WriteLine(publication);
    }
}
else
{
    Console.WriteLine("Публикации не найдены.");
}

// Выдача публикации
Console.WriteLine("\n========== ВЫДАЧА ПУБЛИКАЦИИ ==========");

library.IssuePublication("Война и мир");

Console.WriteLine("Книга выдана читателю.");

// Показываем состояние после выдачи
foreach (Publication publication in library.Publications)
{
    Console.WriteLine(publication);
}

// Возврат публикации
Console.WriteLine("\n========== ВОЗВРАТ ПУБЛИКАЦИИ ==========");

library.ReturnPublication("Война и мир");

Console.WriteLine("Книга возвращена в библиотеку.");

// Показываем состояние после возврата
foreach (Publication publication in library.Publications)
{
    Console.WriteLine(publication);
}