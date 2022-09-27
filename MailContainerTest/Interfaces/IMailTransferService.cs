using MailContainerTest.Types;

namespace MailContainerTest.Interfaces;

public interface IMailTransferService
{
    IMailContainerDataStore ContainerDataStore { get; set; }

    MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request);
}