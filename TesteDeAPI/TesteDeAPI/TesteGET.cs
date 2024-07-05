namespace TesteDeAPI
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class TesteGET
    {
        private RestClient client;

        [TestInitialize]
        public void Initialize()
        { 
            // Inicializa o RestClient com a URL base do HTTPBin
            client = new RestClient("https://reqres.in");
        }

        [TestMethod]
        public void PostData_ReturnsCorrectResponse()
        {
            // Definindo o endpoint e o método da requisição
            var request = new RestRequest("/api/users/2", Method.Get);

            // Executando a requisição
            var response = client.Execute(request);

            // Verificando se o status da resposta é 200 OK
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode, "A solicitação falhou ou o status code está incorreto.");
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Assert.Fail("A solicitação retornou status 404 - Not found");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Assert.Fail("A solicitação retornou status 500 - Internal Server Error.");
            }

            // Opcional: Verificar se os dados do usuário retornados estão corretos
            // Para isso, podemos deserializar o corpo da resposta e verificar os valores
            var responseBody = JObject.Parse(response.Content);
            Assert.IsNotNull(responseBody["data"], "Os dados do usuário não foram retornados.");
            Assert.AreEqual(2, (int)responseBody["data"]["id"], "O ID do usuário retornado está incorreto.");
        }
    }
}