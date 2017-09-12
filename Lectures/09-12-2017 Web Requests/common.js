var mainUrl = "http://localhost:59331/api/values";

var azureUrl = "http://simpleserver2017.azurewebsites.net/api/values";

/* HttpMethod, HttpVerbs

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