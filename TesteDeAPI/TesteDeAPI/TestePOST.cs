namespace TesteDeAPI
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class TestePOST
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
            // Cria a solicitação, especificando o método POST e o endpoint
            var request = new RestRequest("/api/users", Method.Post);

            // Adicionando o corpo da requisição
            // Aqui, estamos enviando um objeto JSON com nome e cargo do usuário
            var requestBody = new { name = "Emerson Parisotto", job = "QA" };

            // Adiciona o objeto requestData como um JSON no corpo da solicitação
            request.AddJsonBody(requestBody);

            // Executando a requisição
            var response = client.Execute(request);

            // Verificando se o status da resposta é 201 Created
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode, "A criação do usuário falhou ou o status code está incorreto.");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Assert.Fail("A solicitação retornou status 404 - Not found");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Assert.Fail("A solicitação retornou status 500 - Internal Server Error.");
            }

            // Opcional: Verificar se os dados retornados estão corretos
            // Para isso, podemos deserializar o corpo da resposta e verificar os valores
            var responseBody = JObject.Parse(response.Content);
            Assert.AreEqual("Emerson Parisotto", responseBody["name"].ToString(), "O nome do usuário retornado está incorreto.");
            Assert.AreEqual("QA", responseBody["job"].ToString(), "O cargo do usuário retornado está incorreto.");
        }
    }
}