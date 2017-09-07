

function parseJSON() {
	var resultsDiv = document.getElementById("results");
	resultsDiv.innerHTML = "";
	var errorDiv = document.getElementById("error");
	errorDiv.innerHTML = "";
	
	try {
		var userInput = JSON.parse(document.getElementById("userInput").value);
	} catch (error) {
		displayError("Your JSON didn't parse.");
		return;
	}
	
	/*
	{"userArray": ["steven", "amanda", "terry"], "userString": "zelda"}
	
	*/
	var ol = document.createElement("ol");
	resultsDiv.appendChild(ol);
	
	if (userInput.userArray) {
		if (Array.isArray(userInput.userArray)) {
			userInput.userArray.forEach(function (arrayElement) {
				var li = document.createElement("li");
				li.appendChild(document.createTextNode(arrayElement));
				ol.appendChild(li);
			});
		} else {
			displayError("userArray was not an array.");
		}
	} else {
		displayError("userArray was not set in your JSON.");
	}
	
	// typeof {"test": "value"} would be "object"
	if (userInput.userString) {
		if (typeof userInput.userString === "string" || typeof userInput.userString === "number") {
			resultsDiv.appendChild(document.createTextNode("Your string was: " + userInput.userString));
		} else {
			displayError("userString was not a string or number.");
		}
	} else {
		displayError("userString was not set in your JSON.");
	}
}

function displayError(errorString) {
	var errorDiv = document.getElementById("error");
	errorDiv.innerHTML = errorString;
}

