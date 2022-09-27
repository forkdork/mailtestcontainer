using MailContainerTest.Types;

namespace MailContainerTest.Data
{
    public class MailContainerDataStore
    {
        public MailContainer GetMailContainer(string mailContainerNumber)
        {
            // Access the database and return the retrieved mail container. Implementation not required for this exercise.
            return new DefaultMailContainer(mailContainerNumber);
        }
    }
}