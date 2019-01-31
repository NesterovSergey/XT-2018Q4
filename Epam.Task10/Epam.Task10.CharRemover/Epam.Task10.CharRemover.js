var element = document.getElementById("submit");

element.addEventListener("click", CharRemover);

function CharRemover(){
	var str = document.getElementById("input").value;
	if(str == ""){
		alert("You cannot leave the field empty");
		return;
	}

	var letter,
		word;

	var tempStr = str.split(/[ \?!:;,\.]/);
		for(tempItem in tempStr){
			word = tempStr[tempItem];

			for (var i = 0; i < word.length; i++) {
				letter = word[i];

				if(word.indexOf(letter) != word.lastIndexOf(letter) && word.indexOf(letter) != -1){
					while(str.indexOf(letter) != -1){
						str = str.replace(letter, '');
					}
				}
			}
		}

		alert(str);
	}
