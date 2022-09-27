using MailContainerTest.Interfaces;
using MailContainerTest.Types;

namespace MailContainerTest.Services;

public class MailContainerDataStore : IMailContainerDataStore
{
    public DataStoreType StoreType => DataStoreType.Normal;


    public MailContainer GetMailContainer(string mailContainerNumber)
    {
        // Access the database and return the retrieved mail container. Implementation not required for this exercise.
        return new DefaultMailContainer(mailContainerNumber);
    }

    public bool UpdateMailContainer(MailContainer mailContainer)
    {
        // Update mail container in the database. Implementation not required for this exercise.
        return true;
    }
}