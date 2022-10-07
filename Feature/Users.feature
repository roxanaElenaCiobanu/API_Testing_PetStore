Feature: Test User API

A short summary of the feature



Scenario: Create new user
	Given I input id as '3'
	And I input username as 'username_test'
	And I input firstname  'firstname_test'
	And I input lastname 'lastname_test'
	And I input email 'x@x.com'
	And I input password 'password_test'
	And I input phone '123456'
	And I input userstatus '0'
	When I send create new user request
	Then I see that a valid user is created



Scenario:  Get user By username
	Given I input username as 'username_test'
	When I send get user by username request
	Then I receive status code '200' 
	And  I receive the details for the requested username
		| id	|	username		|	firstname		|	lastname		|	email	|	password		|	phone	|	userstatus	|
		| 3		|	username_test	|	firstname_test	|	lastname_test	|	x@x.com	|	password_test	|	123456	|	0			|



