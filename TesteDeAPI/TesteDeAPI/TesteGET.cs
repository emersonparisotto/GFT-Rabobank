namespace TesteDeAPI
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [TestClass]
    public class TesteGET : TesteBase
    {
        [TestMethod]
        public void PostData_ReturnsCorrectResponse()
        {
            // Carregar dados de teste do arquivo JSON
            var testData = LoadTestData("user_data_GET.json");

            // Verificar se os dados de teste foram carregados corretamente
            Assert.IsNotNull(testData, "Os dados de teste não foram carregados.");
            Assert.IsNotNull(testData["id"], "Os dados do usuário não foram encontrados no arquivo de teste.");

            var expectedUserId = (int)testData["id"];
            Console.WriteLine(testData);
            // Executar a requisição
            var response = ExecuteRequestGET("/api/users/" + expectedUserId, Method.Get);

            // Validar a resposta
            ValidateResponse(response, System.Net.HttpStatusCode.OK);
        }
    }
}