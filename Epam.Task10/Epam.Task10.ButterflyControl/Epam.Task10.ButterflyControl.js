function ButterflyControl(){
	var arr = [];
	for(var i = 0; i < 5; i++){
		arr.push('Option ' + (i+1));
	}

	for(var i = 0; i < arr.length; i++){
		var newLi = document.createElement('li');
		newLi.innerHTML = arr[i];
		newLi.setAttribute("name", "option" + (i+1));
		newLi.setAttribute("class", "");

		document.getElementById("leftList").appendChild(newLi);
		}
}	

function MoveAllToRight(){
	var selected = document.querySelectorAll('#leftList > li');
	
	if(selected.length == 0){
		alert('The left list is empty');
		return;
	}

	for(var i = 0; i < selected.length; i++){
		document.getElementById("rightList").appendChild(selected[i]);
	}
}

function MoveAllToLeft(){
	var selected = document.querySelectorAll('#rightList > li');

	if(selected.length == 0){
		alert('The right list is empty');
		return;
	}

	for(var i = 0; i < selected.length; i++){
		document.getElementById("leftList").appendChild(selected[i]);
	}
}

function RemoveChildren(element){
	while (element.lastChild){
		element.removeChild(element.lastChild);
	}
}

function MoveOneToRight(){
	var selected = document.querySelectorAll('#leftList .selected');

	if(selected.length < 1){
		alert("No one in the list is not selected");
		return;
	}

	for(var i = 0; i < selected.length; i++){
		selected[i].setAttribute('class', '');
		document.getElementById("rightList").appendChild(selected[i]);
	}
}

function MoveOneToLeft(){
	var selected = document.querySelectorAll('#rightList .selected');

	if(selected.length < 1){
		alert("No one in the list is not selected");
		return;
	}

	for(var i = 0; i < selected.length; i++){
		selected[i].setAttribute('class', '');
		document.getElementById("leftList").appendChild(selected[i]);
	}
}

function SetMarked(current){
	if(current.getAttribute('class') == 'selected'){
		current.setAttribute('class', '');
	}
	else{
		current.setAttribute('class', 'selected')
	}
}

ButterflyControl();
document.getElementById("allToRight").addEventListener("click", MoveAllToRight);
document.getElementById("allToLeft").addEventListener("click", MoveAllToLeft);
document.getElementById("leftList").addEventListener("click", function(event){SetMarked(event.target);});
document.getElementById("rightList").addEventListener("click", function(event){SetMarked(event.target);});
document.getElementById("oneToRight").addEventListener("click", MoveOneToRight);
document.getElementById("oneToLeft").addEventListener("click", MoveOneToLeft);