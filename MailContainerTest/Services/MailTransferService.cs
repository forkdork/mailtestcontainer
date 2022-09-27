using MailContainerTest.Interfaces;
using MailContainerTest.Types;
using Microsoft.Extensions.Options;

namespace MailContainerTest.Services;

public class MailTransferService : IMailTransferService
{
    private readonly IOptions<DataStoreOptions> _options;

    public MailTransferService(IOptions<DataStoreOptions> options, IMailContainerStrategy strategy)
    {
        _options = options;
        ContainerDataStore = strategy.GetDataStore(_options.Value.DataStoreType);
    }

    public IMailContainerDataStore ContainerDataStore { get; set; }

    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
        var mailContainer = ContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

        var result = MakeMailTransferResult(request, mailContainer);

        if (result.Success) ContainerDataStore.UpdateMailContainer(mailContainer);

        return result;
    }
    

    private MakeMailTransferResult MakeMailTransferResult(MakeMailTransferRequest request,
        MailContainer mailContainerDataStore)
    {
        var result = new MakeMailTransferResult();

        if (request.MailType == MailType.StandardLetter)
        {
            if (!mailContainerDataStore.AllowedMailType.HasFlag(AllowedMailType.StandardLetter)) result.Success = false;
        }
        else if (request.MailType == MailType.LargeLetter)
        {
            if (!mailContainerDataStore.AllowedMailType.HasFlag(AllowedMailType.LargeLetter))
                result.Success = false;
            else if (mailContainerDataStore.Capacity < request.NumberOfMailItems) result.Success = false;
        }
        else if (request.MailType == MailType.SmallParcel)
        {
            switch (mailContainerDataStore.AllowedMailType.HasFlag(AllowedMailType.SmallParcel))
            {
                case false:
                    result.Success = false;
                    break;
                default:
                {
                    if (mailContainerDataStore.Status != MailContainerStatus.Operational) result.Success = false;

                    break;
                }
            }
        }

        return result;
    }
}