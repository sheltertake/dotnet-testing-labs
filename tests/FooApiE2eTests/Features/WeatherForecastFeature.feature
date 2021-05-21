Feature: WeatherFeature
	Simple feature

@read
Scenario: Get 5 Weather forecast
	Given an HttpClient
	And a valid Token
	When I Send a Find Weather Request with num "5"
	Then I Should receive "5" Weather items

@read
Scenario: Get 3 Weather forecast
	Given an HttpClient
	And a valid Token
	When I Send a Find Weather Request with num "3"
	Then I Should receive "3" Weather items