namespace Falc.Email.Infrastructure.Integrations.Mailgun.Exceptions;

public class MailgunUnexpectedErrorException(HttpResponseMessage httpResponseMessage) 
    : Exception(
        string.Format("Request sent tp Mailgun unexpectedly failed: RequestUrl={0}, ResponseMessage={1}.", 
            httpResponseMessage.RequestMessage?.RequestUri,
            await httpResponseMessage.Content.ReadAsStringAsync()));