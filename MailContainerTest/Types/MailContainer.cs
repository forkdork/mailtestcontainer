namespace MailContainerTest.Types;

public abstract class MailContainer
{
    protected MailContainer(string mailContainerNumber)
    {
        MailContainerNumber = mailContainerNumber;
    }

    private string MailContainerNumber { get; set; }
    public int Capacity { get; set; }
    public MailContainerStatus Status { get; set; }
    public AllowedMailType AllowedMailType { get; set; }
}