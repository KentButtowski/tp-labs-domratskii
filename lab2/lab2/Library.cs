
namespace Lab2;

// Класс библиотеки
public class Library
{
    // Список всех публикаций
    private readonly List<Publication> _publications = new();

    // Получение списка публикаций
    public IReadOnlyList<Publication> Publications =>
        _publications.AsReadOnly();

    // Добавление публикации
    public void AddPublication(Publication publication)
    {
        if (publication == null)
            throw new ArgumentNullException(nameof(publication));

        _publications.Add(publication);
    }

    // Поиск публикаций по автору
    public List<Publication> FindByAuthor(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException(
                "Имя автора не может быть пустым.");

        List<Publication> result = new();

        foreach (Publication publication in _publications)
        {
            if (publication.Author.Contains(
                author,
                StringComparison.OrdinalIgnoreCase))
            {
                result.Add(publication);
            }
        }

        return result;
    }

    // Выдача публикации по названию
    public void IssuePublication(string title)
    {
        Publication? publication = FindByTitle(title);

        if (publication == null)
            throw new ArgumentException("Публикация не найдена.");

        publication.Issue();
    }

    // Возврат публикации по названию
    public void ReturnPublication(string title)
    {
        Publication? publication = FindByTitle(title);

        if (publication == null)
            throw new ArgumentException("Публикация не найдена.");

        publication.Return();
    }

    // Внутренний поиск по названию
    private Publication? FindByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException(
                "Название не может быть пустым.");

        foreach (Publication publication in _publications)
        {
            if (string.Equals(
                publication.Title,
                title,
                StringComparison.OrdinalIgnoreCase))
            {
                return publication;
            }
        }

        return null;
    }
}
