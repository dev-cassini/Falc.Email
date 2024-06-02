namespace Falc.Email.Infrastructure.Integrations.Mailgun.Exceptions;

public class MailgunUnauthorisedRequestException(HttpResponseMessage httpResponseMessage) 
    : Exception(
        string.Format("Request sent to Mailgun was rejected as unauthorised: RequestUrl={0}, ResponseMessage={1}.", 
            httpResponseMessage.RequestMessage?.RequestUri,
            await httpResponseMessage.Content.ReadAsStringAsync()));