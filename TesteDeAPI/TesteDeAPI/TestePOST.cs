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
            // Cria a solicita��o, especificando o m�todo POST e o endpoint
            var request = new RestRequest("/api/users", Method.Post);

            // Adicionando o corpo da requisi��o
            // Aqui, estamos enviando um objeto JSON com nome e cargo do usu�rio
            var requestBody = new { name = "Emerson Parisotto", job = "QA" };

            // Adiciona o objeto requestData como um JSON no corpo da solicita��o
            request.AddJsonBody(requestBody);

            // Executando a requisi��o
            var response = client.Execute(request);

            // Verificando se o status da resposta � 201 Created
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode, "A cria��o do usu�rio falhou ou o status code est� incorreto.");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Assert.Fail("A solicita��o retornou status 404 - Not found");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Assert.Fail("A solicita��o retornou status 500 - Internal Server Error.");
            }

            // Opcional: Verificar se os dados retornados est�o corretos
            // Para isso, podemos deserializar o corpo da resposta e verificar os valores
            var responseBody = JObject.Parse(response.Content);
            Assert.AreEqual("Emerson Parisotto", responseBody["name"].ToString(), "O nome do usu�rio retornado est� incorreto.");
            Assert.AreEqual("QA", responseBody["job"].ToString(), "O cargo do usu�rio retornado est� incorreto.");
        }
    }
}