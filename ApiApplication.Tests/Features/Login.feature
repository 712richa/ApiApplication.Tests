@Login
Feature: Login
	As a User I want to verify
	login functionality work


Scenario: Login with correct credentials
	When User logged in as 'authorised' user
	Then User should get 'success' login

Scenario: Login with incorrect credentials
	When User logged in as 'unauthorised' user
	Then User should get 'unauthorised' error

Scenario: Login with invalid credentials
	When User logged in with invalid request detail
	Then User should get 'Bad Request' error