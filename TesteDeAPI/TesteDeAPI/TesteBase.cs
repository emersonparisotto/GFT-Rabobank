using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;
using System.IO;

namespace TesteDeAPI
{
    public class TesteBase
    {
        protected RestClient client;

        [TestInitialize]
        public void Initialize()
        {
            client = new RestClient("https://reqres.in");
        }

        protected JObject LoadTestData(string fileName)
        {
            var filePath = Path.Combine("Data", fileName);
            if (!File.Exists(filePath))
            {
                Assert.Fail($"Arquivo de dados de teste não encontrado: {filePath}");
            }
            var jsonData = File.ReadAllText(filePath);
            var jsonObject = JObject.Parse(jsonData);
            Assert.IsNotNull(jsonObject, "Falha ao fazer parse do JSON.");
            return jsonObject;
        }

        protected RestResponse ExecuteRequestGET(string endpoint, Method method)
        {
            var request = new RestRequest(endpoint, method);
            return client.Execute(request);
        }

        protected RestResponse ExecuteRequestPOST(string endpoint, Method method, object body = null)
        {
            var request = new RestRequest(endpoint, method);
            if (body != null)
            {
                request.AddJsonBody(body);
            }
            return client.Execute(request);
        }

        protected void ValidateResponse(RestResponse response, System.Net.HttpStatusCode expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, response.StatusCode, $"A solicitação falhou ou o status code está incorreto. Status retornado: {response.StatusCode}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Assert.Fail("A solicitação retornou status 404 - Not found");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Assert.Fail("A solicitação retornou status 500 - Internal Server Error.");
            }
        }
    }
}