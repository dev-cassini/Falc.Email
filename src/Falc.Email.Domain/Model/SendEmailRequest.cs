namespace Falc.Email.Domain.Model;

public class SendEmailRequest
{
    public Guid Id { get; }
    public DateTimeOffset CreationTimestampUtc { get; }
    public string EmailType { get; }
    public string RecipientEmailAddress { get; }
    public Dictionary<string, object> Metadata { get; }

    public SendEmailRequest(
        Guid id, 
        DateTimeOffset creationTimestampUtc, 
        string emailType, 
        string recipientEmailAddress, 
        Dictionary<string, object> metadata)
    {
        Id = id;
        CreationTimestampUtc = creationTimestampUtc;
        EmailType = emailType;
        RecipientEmailAddress = recipientEmailAddress;
        Metadata = metadata;
    }
    
    #region EF Constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private SendEmailRequest() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}