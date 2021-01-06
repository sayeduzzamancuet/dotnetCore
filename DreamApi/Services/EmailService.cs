using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamApi.Services
{
    public class EmailService : IEmailService
    {
        public void sendEmail(string from, string to, string subject, string mailBody)
        {
            var client = new RestClient("https://api.mailjet.com/v3.1/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Basic MGIzOTI3ZTQ0M2NmODNlM2M1MTRkOTg5OWQ4NDkwMTI6MDI1YjM3OTA2MGFiOTRjNDU4OThiMjI0NWU0ZWIyYjY=");
            request.AddParameter("undefined", "{\n  \"Messages\":[\n    {\n      \"From\": {\n        \"Email\": \"eliaszamanonline@gmail.com\",\n        \"Name\": \"Sayed\"\n      },\n      \"To\": [\n        {\n          \"Email\": \"eliaszamanonline@gmail.com\",\n          \"Name\": \"Sayed\"\n        }\n      ],\n      \"Subject\": \"My first Mailjet email\",\n      \"TextPart\": \"Greetings from Mailjet.\",\n      \"HTMLPart\": \" blank\",\n      \"CustomID\": \"AppGettingStartedTest\"\n    }\n  ]\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}
