using MailContainerTest.Interfaces;
using MailContainerTest.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MailContainerTestTests.Services;

public class MailContainerStrategyTests
{
    private readonly ServiceCollection _services = new();

    private ServiceProvider _serviceProvider = null!;

    [SetUp]
    public void Init()
    {
        _services.AddTransient<IMailContainerStrategy, MailContainerStrategy>();
        _services.AddTransient<IMailContainerDataStore, BackupMailContainerDataStore>();
        _services.AddTransient<IMailContainerDataStore, MailContainerDataStore>();
        _serviceProvider = _services.BuildServiceProvider();
    }

    [Test]
    public void GetDefaultDataStoreTest()
    {
        const DataStoreType storeType = DataStoreType.Normal;
        var service = _serviceProvider.GetService<IMailContainerStrategy>();

        var result = service?.GetDataStore(storeType);
        Assert.AreEqual(typeof(MailContainerDataStore), result?.GetType());
    }

    [Test]
    public void GetBackupDataStoreTest()
    {
        const DataStoreType storeType = DataStoreType.Backup;

        var service = _serviceProvider.GetService<IMailContainerStrategy>();

        var result = service?.GetDataStore(storeType);
        Assert.AreEqual(typeof(BackupMailContainerDataStore), result?.GetType());
    }
}