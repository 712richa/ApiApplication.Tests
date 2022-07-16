@Reset
Feature: Reset the test data
        As a user I want to reset test data
        So that I can buy more energy

Scenario: Reset Test Data
Given I am an 'authorised' user
When I hit reset endpoint with authorised token
And I check the order
Then it should return success response
And data should be rest

Scenario: Reset Test Data with invalid token
Given I am an 'unauthorised' user
When I hit reset endpoint with unauthorised token
Then it should return unauthorised response