////@if (Model.MovieList?.Results != null) {
////		<h1>Found Movies</h1>
////		<table class="table mt-5" id="movieTable">
////			<thead>
////				<tr>
////					<th scope="col">Id</th>
////					<th scope="col">Title</th>
////					<th scope="col">Description</th>
////					<th scope="col">Poster</th>
////					<th scope="col">Add</th>
////				</tr>
////			</thead>
////			@foreach (var movie in Model.MovieList.Results) {
////				<tr>
////					<td>@movie.Id</td>
////					<td>@movie.Title</td>
////					<td>@movie.Description</td>
////					<td><img src=@movie.Image></td>
////					<td><input type="checkbox" class="customCheckboxes" value="some" /></td>
////				</tr>
////			}
////		</table>
////		<script type="module" src="~/js/addSelectedMovie.js"> </script>
////		<div class="col-md-4">
////			<div class="form-group">
////				<input type="submit" value="Add movies" class="btn btn-primary" id="add" />
////			</div>
////		</div>
////}

$('#searchMovie').click(function () {
	if ($('#movieTitle').val().length === 0) {
		alert("Provide movie title");
		return;
	}
	let title = $('#movieTitle').val();
	$.ajax({
		type: "GET",
		url: "/api/movie?movieTitle=" + title,
		dataType: "json",
		success: function (result) {
			let table = $('table').addClass('movieResult');
			for (var i = 0; i < result.length; i++) {
				let content = $('thead').append($('tr').append('th'))
			}
		},
		failure: function (errMsg) {
			console.log(errMsg);
		}
	});
})

