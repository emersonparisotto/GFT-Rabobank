# GFT-Rabobank

## cypress-orangeHRM
### Solução de automação End-To-End em Cypress

1. Cypress 13
2. Acessa a página do Orange HRM, um site open para testes de automação.
3. Realiza Login na aplicação
4. Cadastra um novo usuário
5. Não foi possível aplicar a validação da mensagem, no momento, pois a mesma é por completo dinâmica e precisa de estudo mais apurado, em troca, realiza uma consulta para validar se o usuário está cadastrado.

## TesteDeAPI
### Solução de Teste de API

1. C# com RestSharp no Visual Studio
2. End point é o https://reqres.in
3. Possui dois scripts: um para o método GET e outro para o POST.
      
#### TesteBase
1. Classe de reuso de código como melhores práticas
2. Inicializo o client
3. Método para a leitura dos dados de teste
4. Método para Requisição GET
5. Método para Requisição POST
6. Método para validação da mensagem de retorno
	6.1 Valida se o retorno possui o código esperado
	6.2 Valida se o retorno foi 404 - Not Found
	6.3 Valida se o retorno foi 500 - Internal Server Error

#### Data
1. Pasta que contém os dados de teste
	1.1 user_data_GET : Para o método GET
	1.2 user_data_POST : Para o método POST

#### TestePOST
1. End Point: https://reqres.in/api/users
2. Realiza a requisição de cadastramento de um registro com os campos:
	{
	  "user": {
		"email": "teste@QAsite.com",
		"first_name": "Tester",
		"last_name": "Weaver",
		"avatar": "https://reqres.in/img/faces/2-image.jpg"
	  }
	}
3. O código da mensagem de retorno é 201 - Created

#### TesteGET
1. End Point: https://reqres.in/api/users/2
2. Realiza a requisição de consulta do usuário cujo ID é 2
3. O código da mensaem de retorno é 200 - OK
   

