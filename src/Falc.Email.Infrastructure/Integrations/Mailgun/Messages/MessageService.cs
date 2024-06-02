using System.Net;
using System.Text.Json;
using Falc.Email.Infrastructure.Integrations.Mailgun.Exceptions;

namespace Falc.Email.Infrastructure.Integrations.Mailgun.Messages;

public class MessageService(HttpClient httpClient) : IMessageService
{
    public async Task<SendEmail.Response> SendEmailAsync(SendEmail.Request request)
    {
        var httpContent = new MultipartFormDataContent();
        httpContent.Add(new StringContent(request.From), "from");
        httpContent.Add(new StringContent(request.To), "to");
        httpContent.Add(new StringContent(request.Subject), "subject");
        httpContent.Add(new StringContent(request.Html), "html");

        var response = await httpClient.PostAsync("", httpContent);
        
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SendEmail.Response>(responseContent) ?? new SendEmail.Response("Unknown");
        }

        if (response.StatusCode is HttpStatusCode.Unauthorized)
        {
            throw new MailgunUnauthorisedRequestException(response);
        }

        throw new MailgunUnexpectedErrorException(response);
    }
}