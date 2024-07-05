/// <reference types="cypress" />
import {Given, When, Then, And} from "cypress-cucumber-preprocessor/steps"
import addUser from "../../Pages/Admin/AddUserPage.cy";

When("Acessar página de inclusão de usuário", () => {
	addUser.accessAdminPage();
	addUser.accessAddUserPage();
});
And("Entrar com os dados de formulário válidos", (datatable) => {
	datatable.hashes().forEach((element) => {
		addUser.fillAddUserPage(element.userRole, element.employeeName, element.status, element.username, element.password);
	});
});
And("Clicar no botão Salvar", () => {
	addUser.clickSubmitButton();
});
Then("Validar o usuário {string}", (username) => {
	addUser.verifySuccessfulMessage(username);
});