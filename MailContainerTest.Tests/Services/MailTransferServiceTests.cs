using MailContainerTest.Interfaces;
using MailContainerTest.Services;
using MailContainerTest.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace MailContainerTestTests.Services;

public class MailTransferServiceTests
{
    private readonly ServiceCollection _services = new();

    [Test]
    public void MakeMailTransferTest_WhenRequestInValid_ShouldBeFalse()
    {
        _services.AddTransient<IMailContainerStrategy, MailContainerStrategy>();
        _services.AddTransient<IMailContainerDataStore, BackupMailContainerDataStore>();
        _services.AddTransient<IMailContainerDataStore, MailContainerDataStore>();
        var serviceProvider = _services.BuildServiceProvider();
        var strategyService = serviceProvider.GetService<IMailContainerStrategy>();

        if (strategyService == null) Assert.Fail();
        var options = GetOptionsDataStore();
        var service = new MailTransferService(options, strategyService);
        Assert.AreEqual(options.Value.DataStoreType, service.ContainerDataStore.StoreType);


        var result = service.MakeMailTransfer(CreateInvalidRequest());
        Assert.AreEqual(false, result.Success);
    }

    private static IOptions<DataStoreOptions> GetOptionsDataStore()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

        return Options.Create(configuration.GetSection("DataStoreOptions").Get<DataStoreOptions>());
    }

    private static MakeMailTransferRequest CreateInvalidRequest()
    {
        return new MakeMailTransferRequest(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), 145, DateTime.Now,
            MailType.LargeLetter);
    }
}