using MailContainerTest.Interfaces;
using MailContainerTest.Services;
using MailContainerTest.Types;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MailContainerTestTests.Services;

public class MailContainerDataStoreTests
{
    private readonly ServiceCollection _services = new();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetBackupMailContainerTest()
    {
        _services.AddTransient<IMailContainerDataStore, BackupMailContainerDataStore>();
        var serviceProvider = _services.BuildServiceProvider();
        var service = serviceProvider.GetService<IMailContainerDataStore>();

        var result = service?.GetMailContainer(string.Empty);
        Assert.AreEqual(typeof(BackupMailContainer), result?.GetType());
    }
    

    [Test]
    public void GetDefaultMailContainerTest()
    {
        _services.AddTransient<IMailContainerDataStore, MailContainerDataStore>();
        var serviceProvider = _services.BuildServiceProvider();
        var service = serviceProvider.GetService<IMailContainerDataStore>();

        var result = service?.GetMailContainer(string.Empty);
        Assert.AreEqual(typeof(DefaultMailContainer), result?.GetType());
    }


    [Test]
    public void UpdateDefaultMailContainerTest()
    {
        _services.AddTransient<IMailContainerDataStore, MailContainerDataStore>();
        var serviceProvider = _services.BuildServiceProvider();
        var service = serviceProvider.GetService<IMailContainerDataStore>();
        var mailContainer = service?.GetMailContainer(string.Empty);

        var result = mailContainer != null && service != null && service.UpdateMailContainer(mailContainer);
        Assert.IsTrue(result);
    }
}