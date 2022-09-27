using MailContainerTest.Services;

namespace MailContainerTest.Types;

public class DataStoreOptions
{
    public DataStoreType DataStoreType { get; set; }
    public string Info { get; set; } = null!;
}