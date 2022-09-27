using MailContainerTest.Services;

namespace MailContainerTest.Interfaces;

public interface IMailContainerStrategy
{
    IMailContainerDataStore GetDataStore(DataStoreType storeType);
}