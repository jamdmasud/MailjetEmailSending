using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MailjetEmailSending
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }
        static async Task RunAsync()
        {
            MailjetClient client = new MailjetClient("ad20d684d9e6ffdab7755782036ce15b", "ab920ccb239c91bd3c4049466def3e6a")
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
             new JObject {
              {
               "From",
               new JObject {
                {"Email", "jamdmasud@gmail.com"},
                {"Name", "Muhammad Masud"}
               }
              }, {
               "To",
               new JArray {
                new JObject {
                 {
                  "Email",
                  "masud@bs-23.net"
                 }, {
                  "Name",
                  "Md. Masud"
                 }
                }
               }
              }, {
               "Subject",
               "Greetings from Mailjet."
              }, {
               "TextPart",
               "My first Mailjet email"
              }, {
               "HTMLPart",
               "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
              }, {
               "CustomID",
               "AppGettingStartedTest"
              }
             }
             });
            MailjetResponse response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
            Console.ReadKey();
        }
    }
}
