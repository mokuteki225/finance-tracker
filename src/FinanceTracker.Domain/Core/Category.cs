using FinanceTracker.Domain.Core.Enums;

namespace FinanceTracker.Domain.Core;

public class Category
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid BudgetId { get; private set; }

    private readonly List<Source> _sources;

    public Category(string name, Guid budgetId)
    {
        Name = name;
        BudgetId = budgetId;
        _sources = new List<Source>();
    }

    public int CalculateTotalIncome()
    {
        return _sources
            .Where(source => source.Type == SourceTypes.Income)
            .Sum(source => source.Amount);
    }
}
