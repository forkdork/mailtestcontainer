using MailContainerTest.Services;
using MailContainerTest.Types;

namespace MailContainerTest.Interfaces;

public interface IMailContainerDataStore
{
    DataStoreType StoreType { get; }
    public MailContainer GetMailContainer(string mailContainerNumber);
    public bool UpdateMailContainer(MailContainer mailContainer);
}