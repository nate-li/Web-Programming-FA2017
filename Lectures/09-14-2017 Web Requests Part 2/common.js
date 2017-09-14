var mainUrl = "http://localhost:59331/api/values";

var azureUrl = "http://simpleserver2017.azurewebsites.net/api/values";

/* 
REST
 Representational State Transfer
 
 1. Convention over Configuration 
 2. Stateless

HTTP
How to talk to a server ("The Request") - Three ways:

1. The URL
 - Tell the server WHERE we want the data from/to
 - Use the URL when the user should be able to "link" to it
2. The Body - Request Data - Payload
 - Used to send user data, such as name, address, favorite color, etc. - i.e. form data entered by the user
3. Headers
 - Used to sent metadata
 - Usually not controlled by the user, done with code
 
How the server talks to us "The Response":

1. StatusCode
 - An integer about how the request was receieved
2. The Body
 - Send the result of our request, again usually user data, or errors
3. Headers
 - Metadata of the response

 
StatusCodes
General
	-First digit equals the type.
	-Other two digits are the specific type
	-It's best to not use the generic 200, 300, etc. Use the more specific ones when you can.

100 - Continue
	- Http Protocol, Not Important
	Continue - You request is too big, go get more

200/2xx - OK
 - 201 - Created, often on POST requests
 - 202 - Accepted, often on long running tasks
 - 204 - NoContent, i.e. the Body of the response is empty, used mainly on DELETE requests

300 - Redirect
 - 301 Moved Permanently 
	www.myblog.com -> www.myblog2.com
 - 307 Moved Temporarily
	Used when the server needs to generate a new URL each time the response is sent
 
400 - Bad Request
 It's the users fault
 - 401 - Unauthorized 
	The users credentials were not accepted, i.e. wrong password
 - 403 - Forbidden
   The users credentials WERE accepted, but not allowed for that resource
 - 404 - NotFound
  Couldn't find, based on the URL

500 - Server Error
 - It's the server's fault
	- 503 Server Unavailable
		Temporarily down, try your request again!

Headers
 - Location
  Url where you are supposed to go instead, used with any 300 level StatusCode
 - Authorization
	The user sends their password (in a token)
 - Content-Type
	The actual type of the data being sent (or received!) to/from the server
 - Content-Length
	An integer value of how many bytes long your body (payload) is
	
HttpMethod, HttpVerbs

CRUD
Create, Read, Update, Delete

GET - Read data from the server
POST - Send/Create data to the server
PUT - Update (cross-fingers behind back, sometimes create) data on the server
DELETE - Remove/Delete data from the server
*/

function simpleResult(data) {
	document.getElementById("result").innerHTML = JSON.stringify(data);
}

function simpleError(data) {
	document.getElementById("error").innerHTML = JSON.stringify(data);
}

function runGet() {
	
	$.ajax(mainUrl,
	{
		method: "GET",
		success: simpleResult,
		error: simpleError
	});
}

function runGetOne() {
	
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value,
	{
		method: "GET",
		success: simpleResult,
		error: simpleError
	});
}

function runPost() {
	
	$.ajax(mainUrl, 
	{
		method: "POST",
		success: simpleResult,
		error: simpleError,
		contentType: "application/json",
		processData: false,
		data: JSON.stringify(
		{
			Value: document.getElementById("userInput").value
		})
	});
}

function runPut() {
	
	// for example URL: (a userIndex of 3)
	// http://localhost:59331/api/values/3
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value, 
	{
		method: "PUT",
		success: simpleResult,
		error: simpleError,
		contentType: "application/json",
		headers: {
			Authorization: "Some password",
			"SomeSillyString": "hhaha"
		},
		processData: false,
		data: JSON.stringify(
		{
			Value: document.getElementById("userInput").value
		})
	});
}

function runDelete() {
	$.ajax(mainUrl + "/" + document.getElementById("userIndex").value, 
	{
		method: "DELETE",
		success: simpleResult,
		error: simpleError
	});
	
}