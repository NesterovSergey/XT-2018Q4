var element = document.getElementById("submit");

element.addEventListener("click", MathCalculator);

function MathCalculator(){
	var str = document.getElementById("input").value;
	if(str == ""){
		alert("You cannot leave the field empty");
		return;
	}

	var validateRegex = RegExp(/^( *([-+])|( )*\d+([.]\d+)? *?[+-\/\*])+ *?\d+(.\d+)? *?=? *?$/);
	var splitRegex = RegExp('(\d+(.\d+)?)|([+*-\/])');

	if(!validateRegex.test(str)){
		alert("You have to enter an expression correctly");
		return;
	}

	var arr = str.split(splitRegex);
	var number,
		result = 0,
		sign = '+';

	for(var i = 0; i < arr.length; i++){
		if(parseFloat(arr[i])){

			number = parseFloat(arr[i]);
			if(sign == '+'){
				result += number;
			}
			else if (sign =='-'){
				result -= number;
			}
			else if (sign == '*'){
				result *= number;
			}
			else if(sign == '/'){
				result /= number;
			}
		}
		else{
			sign = arr[i];
		}
	}

	alert('Result: ' + result.toFixed(2));
}