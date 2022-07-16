Feature: CheckStock
        As a user I want to make sure when I order energy
        my stock is getting updated so I can inform customer
        when it's unavailable.


Scenario: Verify stock is up to date when you order a fuel
Given I am an 'authorised' user
And I hit reset endpoint with authorised token
And I check the energy stock
When When I buy <EnergyType> for <Quantity> unit
Then it should display upto date stock


Scenario: Verify stock is up to date when fuel is unavailable
Given I am an 'authorised' user
And I hit reset endpoint with authorised token
And I check the energy stock
When When I buy <EnergyType> for <Quantity> unit
Then it should display no changes in stock