using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace LoggingRequestsAndResponses.Audit
{
    public class MessageLoggingHandler : MessageHandler
    {
        protected override async Task IncommingMessageAsync(DateTime dateTime, string requestInfo, byte[] message)
        {
            await Task.Run(() =>
                Trace.WriteLine($"{dateTime.ToString("yyyy-MM-dd hh:mm:ss")} - Requete: {requestInfo}\r\n{Encoding.UTF8.GetString(message)}"));
        }


        protected override async Task OutgoingMessageAsync(DateTime dateTime, string requestInfo, byte[] message)
        {
            await Task.Run(() =>
                Trace.WriteLine($"{dateTime.ToString("yyyy-MM-dd hh:mm:ss")} - Reponse: {requestInfo}\r\n{Encoding.UTF8.GetString(message)}"));
        }
    }
}