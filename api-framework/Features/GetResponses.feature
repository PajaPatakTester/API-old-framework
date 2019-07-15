Feature: GetResponses
	In order to create API framework
	Sending adequate requests
	I want to get responses requested in the API task

@authorization
Scenario: Get HTTP response Status 200
	Given I am connected
	And I created request
	And I passed parameter q and its value Sombor
	And I passed API key
	When I send request
	Then  result should be response Status 200

@authorization
Scenario: Get HTTP response Status 401
	Given I am connected
	And I created request
	And I passed parameter q and its value Sombor
	When I send request
	Then  result should be response Status 401

Scenario: Get HTTP response Status 304
	Given I am requesting resource that is cached by browser
	And I created request
	And I set that resource is up to date with server
	When I send request
	Then result should be response Status 304
