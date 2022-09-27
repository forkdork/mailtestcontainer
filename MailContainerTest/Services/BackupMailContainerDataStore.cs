using MailContainerTest.Interfaces;
using MailContainerTest.Types;

namespace MailContainerTest.Services;

public class BackupMailContainerDataStore : IMailContainerDataStore
{
    public DataStoreType StoreType => DataStoreType.Backup;


    public MailContainer GetMailContainer(string mailContainerNumber)
    {
        return new BackupMailContainer(mailContainerNumber);
    }

    public bool UpdateMailContainer(MailContainer mailContainer)
    {
        // Update mail container in the database. Implementation not required for this exercise.
        return true;
    }
}