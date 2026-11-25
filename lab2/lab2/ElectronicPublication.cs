
namespace Lab2;

// Класс электронного издания
public class ElectronicPublication : Publication
{
    public string FileFormat { get; }

    public override string PublicationType => "Электронное издание";

    public ElectronicPublication(
        string title,
        string author,
        string fileFormat)
        : base(title, author)
    {
        if (string.IsNullOrWhiteSpace(fileFormat))
            throw new ArgumentException(
                "Формат файла не может быть пустым.",
                nameof(fileFormat));

        FileFormat = fileFormat;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, формат: {FileFormat}";
    }
}
