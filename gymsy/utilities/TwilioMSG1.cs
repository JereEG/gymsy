using gymsy.Models;
using gymsy.Context;
using gymsy.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;
using Twilio.Types;
using ClientModel = gymsy.Models.Usuario;

namespace gymsy.utilities
{
    internal class TwilioMSG
    {
        public static void SendMessageComprobante(string path)
        {
            MessageBox.Show("SENDING MESSAGE...");
            var accountSid = Resources.accountSidTwiio;
            var authToken = Resources.authTokenTwilio;
            TwilioClient.Init(accountSid, authToken);
            var multimedia = new[] {
            new Uri(path)
        }.ToList();
            var messageOptions = new CreateMessageOptions(
                new PhoneNumber($"whatsapp:{AppState.person.NumeroTelefono}"));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = "Nuevo comprobante Emitido";
            messageOptions.MediaUrl = multimedia;
            var message = MessageResource.Create(messageOptions);
            MessageBox.Show("Comprobante enviado correctamente");
        }


        public static void SendAlertClients(List<ClientModel> clients)
        {
            List<string> numerosDestino = new List<string>();
            clients.ForEach(client =>
            {
                numerosDestino.Add(client.NumeroTelefono);
            });

            MessageBox.Show("SENDING MESSAGE...");
            var accountSid = Resources.accountSidTwiio;
            var authToken = Resources.authTokenTwilio;
            TwilioClient.Init(accountSid, authToken);
            var multimedia = new[] {
            new Uri("https://thumbs.dreamstime.com/b/oficial-de-polic%C3%ADa-hombre-en-la-forma-de-vigilancia-la-polic%C3%ADa-sirve-adentro-bodybuild-65477932.jpg")
        }.ToList();

            foreach (string phone in numerosDestino) {
                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($"whatsapp:{phone}")
                );;
                messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = @"*ALTO !!!*
Te recordamos que tu cuota vence esta semana 💀
                

*BY Equipo Gymsy*  🦍
                
                ";
                messageOptions.MediaUrl = multimedia;
                MessageResource.Create(messageOptions);
            }
        }

    }
}