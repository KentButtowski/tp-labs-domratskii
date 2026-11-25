
namespace Lab2;

// Класс книги
public class Book : Publication
{
    public int PageCount { get; }

    public override string PublicationType => "Книга";

    public Book(string title, string author, int pageCount)
        : base(title, author)
    {
        if (pageCount <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(pageCount),
                "Количество страниц должно быть положительным.");

        PageCount = pageCount;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, страниц: {PageCount}";
    }
}
