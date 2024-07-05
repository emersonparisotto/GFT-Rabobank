class LoginPage {
   enterURL() {
    cy.visit(
      "https://opensource-demo.orangehrmlive.com/"
    );
  }
   enterUserNamePassword(username, password) {
    cy.get('input[name=username').type(username);
    cy.get('input[name=password').type(password);
    return this;
  }
   clickSubmitButton() {
    cy.get('[type="submit"]').eq(0).click();
	cy.wait(3000);
    return this;
  }
}
const login = new LoginPage();
export default login;