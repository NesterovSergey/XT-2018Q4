var counter = 0;
var toNextTime = 10;
var timer = setInterval(ManageTimer, 1000);

var content = [
			["\"You seen 'em, you play 'em\" sneered the bard man.",
			'Cowboy'
			],
			['"Pan-shot!" cried the old man.',
			'The old man covered with pans',
			],
			['The quality of mercy is not strained, it droppeth as the gentle rain from heaven',
			'A boy'
			],
			['And in all that mighty sweep of earth he saw no sign of man nor the handiwork of man.',
			'Man on a tree'
			],
			['Mr. Arthur had no idea what he would say to Billy Knapp',
			'The unknown'
			],];

function ToFillPage(){
	var tag = document.querySelectorAll('.container > .dynContent');

		tag[0].setAttribute('src', counter + '.jpg');
		tag[0].setAttribute('alt', content[counter][1]);
		tag[1].innerHTML = content[counter][0];
	}

function ReturnBack(){
	RestartTimer();

	if(--counter < 0){
		counter = 4;
	}

	ToFillPage();
}

function ManageTimer(){
	toNextTime--;

	if(toNextTime == 0){
		GoToNextPage();
	}

	var time = document.getElementById('timer');
	time.innerHTML = toNextTime;
}

function GoToNextPage(){
	if(++counter > 4){
		if(confirm("Do You want to start over?"))
		{
			counter = 0;
		}
		else{
			ToEnd();
			return;
		}
	}

	RestartTimer();
	ToFillPage();
}

function ToStopTimer(){
	clearInterval(timer);
}

function RestartTimer(){
	ToStopTimer();
	toNextTime = 10;
	timer = setInterval(ManageTimer, 1000);
}

function ToEnd(){
	ToStopTimer();

	var end = document.getElementsByTagName('body');
	end[0].innerHTML = "";
}

document.getElementById("right").addEventListener("click", GoToNextPage);
document.getElementById("left").addEventListener("click", ReturnBack);
document.getElementById("repeat").addEventListener("click", RestartTimer);
document.getElementById("startTimer").addEventListener("click", ToStopTimer);