
namespace Lab2;

// Абстрактный базовый класс публикации
public abstract class Publication
{
    // Внутреннее состояние публикации
    private bool _isIssued;

    // Общие свойства всех публикаций
    public string Title { get; }
    public string Author { get; }
    public bool IsIssued => _isIssued;

    // Каждый наследник должен определить свой тип
    public abstract string PublicationType { get; }

    // Конструктор
    protected Publication(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым.");

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Автор не может быть пустым.");

        Title = title;
        Author = author;
        _isIssued = false;
    }

    // Метод выдачи публикации
    public void Issue()
    {
        if (_isIssued)
            throw new InvalidOperationException("Публикация уже выдана.");

        _isIssued = true;
    }

    // Метод возврата публикации
    public void Return()
    {
        if (!_isIssued)
            throw new InvalidOperationException("Публикация ещё не выдана.");

        _isIssued = false;
    }

    // Текстовое представление объекта
    public override string ToString()
    {
        string status = _isIssued ? "Выдана" : "Доступна";

        return $"{PublicationType}: {Title}, автор: {Author}, статус: {status}";
    }
}
