const chB = document.getElementsByClassName('customCheckboxes');

for (var i = 0; i < chB.length; i++) {
	chB[i].addEventListener('change', (e) => {
		if (e.target.checked) {
			$('#add').prop('disabled', false)
		}
	})
}

var checked = document.querySelectorAll('input:checked');
if (checked.length === 0) {
	$('#add').prop('disabled', true)
}

if ($('#add')) {
	$('#add').on('click', addMovies)
}

function addMovies() {
	var json = [];
	let table = document.getElementById('movieTable');
	for (let i = 1;i < table.rows.length; i++) {
		if (chB[i - 1].checked) {
			let id = table.rows[i].cells[0].innerText;
			json.push(id);
		}
	}
	submitJSON(json);
}

//not in use
function addMoviesOld() {
	var json = [];

	let description;
	let title;
	let image;

	let table = document.getElementById('movieTable');
	for (let i = 1;i < table.rows.length; i++) {
		if (chB[i - 1].checked) {
			let item = {};

			for (let j = 0; j < table.rows[i].cells.length; j++) {
				if (j === 0) {
					title = table.rows[i].cells[j].innerText;
					item["title"] = title;

				}
				else if (j === 1) {
					description = table.rows[i].cells[j].innerText;
					item["description"] = description;

				}
				else if (j === 2) {
					image = table.rows[i].cells[j].firstChild.currentSrc;
					item["image"] = image;

				}

			}
			json.push(item);
		}
	}

	submitJSON(json);
}

function submitJSON(data) {
	const postChangesRequest = new XMLHttpRequest();
	postChangesRequest.open("POST", "/api/movie");
	postChangesRequest.setRequestHeader("Content-Type", "application/json");
	var temp = JSON.stringify({ "moviesIdsList": data });
	postChangesRequest.send(temp);
}




