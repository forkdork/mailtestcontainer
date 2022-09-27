using MailContainerTest.Interfaces;

namespace MailContainerTest.Services;

public class MailContainerStrategy : IMailContainerStrategy
{
    private readonly IEnumerable<IMailContainerDataStore> _operators;

    public MailContainerStrategy(IEnumerable<IMailContainerDataStore> operators)
    {
        _operators = operators;
    }

    public IMailContainerDataStore GetDataStore(DataStoreType storeType)
    {
        var result = _operators.FirstOrDefault(x => x.StoreType == storeType) ??
                     throw new ArgumentNullException(nameof(storeType));
        return result;
    }
}