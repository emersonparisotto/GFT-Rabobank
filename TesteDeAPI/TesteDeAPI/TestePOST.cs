namespace TesteDeAPI
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using RestSharp;

    [TestClass]
    public class TestePOST : TesteBase
    {
        [TestMethod]
        public void PostData_ReturnsCorrectResponse()
        {
            // Carregar dados de teste do arquivo JSON
            var testData = LoadTestData("user_data_POST.json");
            
            Console.WriteLine(testData);

            // Verificar se os dados de teste foram carregados corretamente
            Assert.IsNotNull(testData, "Os dados de teste n�o foram carregados.");
            Assert.IsNotNull(testData["user"], "Os dados do usu�rio n�o foram encontrados no arquivo de teste.");

            // Criar o corpo da requisi��o
            var requestBody = new
            {
                email = testData["user"]["email"],
                first_name = testData["user"]["first_name"],
                last_name = testData["user"]["last_name"],
                avatar = testData["user"]["avatar"]
            };

            // Executar a requisi��o
            var response = ExecuteRequestPOST("/api/users", Method.Post, requestBody);

            // Validar a resposta
            ValidateResponse(response, System.Net.HttpStatusCode.Created);
        }
    }
}