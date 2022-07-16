@BuyEnergy
Feature: BuyFuel
	As a user I want to buy some energy
	And check if my stock is up to date

Scenario Outline: Successfully buy each type of Fuel if available
Given I am an 'authorised' user
When When I buy <EnergyType> for <Quantity> unit
And I check the order
Then it should return success response
And new item should be added
Examples: 
|EnergyType	|Quantity|
|gas		|1		|
|nuclear	|2		|
|elec		|3		|
|oil		|4		|

Scenario: Successfully informed if fuel is unavailable
Given I am an 'authorised' user
When When I buy nuclear for 1 unit
Then "There is no nuclear fuel to purchase!" message is displayed 
