
namespace Lab2;

// Класс журнала
public class Magazine : Publication
{
    public int IssueNumber { get; }

    public override string PublicationType => "Журнал";

    public Magazine(string title, string author, int issueNumber)
        : base(title, author)
    {
        if (issueNumber <= 0)
            throw new ArgumentOutOfRangeException(
                nameof(issueNumber),
                "Номер выпуска должен быть положительным.");

        IssueNumber = issueNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, номер выпуска: {IssueNumber}";
    }
}
