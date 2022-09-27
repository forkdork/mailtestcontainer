namespace MailContainerTest.Types;

public class MakeMailTransferRequest
{
    public MakeMailTransferRequest(string sourceMailContainerNumber, string destinationMailContainerNumber,
        int numberOfMailItems, DateTime transferDate, MailType mailType)
    {
        SourceMailContainerNumber = sourceMailContainerNumber;
        DestinationMailContainerNumber = destinationMailContainerNumber;
        NumberOfMailItems = numberOfMailItems;
        TransferDate = transferDate;
        MailType = mailType;
    }

    public string SourceMailContainerNumber { get; set; }
    public string DestinationMailContainerNumber { get; set; }
    public int NumberOfMailItems { get; set; }
    public DateTime TransferDate { get; set; }
    public MailType MailType { get; set; }
}