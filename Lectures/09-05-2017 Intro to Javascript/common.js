

function doStuff() {
	// DOM - Document Object Model
	//document.getElementById("firstdiv").style.color = "red";
	
	//document.getElementById("firstdiv").style.backgroundColor = "white";

	
	// Here is a better way:
	
	// document.getElementById("firstdiv").classList.add("big");
	
	// An even better way!
	var firstDivElement = document.getElementById("firstdiv");
	
	// debugger;
	
	firstDivElement.classList.toggle("big");
	firstDivElement.classList.toggle("underline");
	
	// talk to the web browser
	// window.
	// alert('test');
	
	
}

