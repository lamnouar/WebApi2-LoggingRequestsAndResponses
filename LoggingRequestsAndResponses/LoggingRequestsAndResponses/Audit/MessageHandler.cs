using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoggingRequestsAndResponses.Audit
{
    public abstract class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var dateRequete = DateTime.Now;
            var requestInfo = $"{request.Method} {request.RequestUri}";
            var requestMessage = await request.Content.ReadAsByteArrayAsync();

            await IncommingMessageAsync(dateRequete, requestInfo, requestMessage);
            var response = await base.SendAsync(request, cancellationToken);

            var dateReponse = DateTime.Now;
            byte[] responseMessage;

            if (response.IsSuccessStatusCode)
                responseMessage = await response.Content.ReadAsByteArrayAsync();
            else
                responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);

            await OutgoingMessageAsync(dateReponse, requestInfo, responseMessage);

            return response;
        }


        protected abstract Task IncommingMessageAsync(DateTime dateTime, string requestInfo, byte[] message);
        protected abstract Task OutgoingMessageAsync(DateTime dateTime, string requestInfo, byte[] message);
    }
}