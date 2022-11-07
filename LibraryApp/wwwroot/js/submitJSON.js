export function submitJSON(jsonData) {
	jQuery.ajax({
		type: "POST",
		url: "/api/test/content",
		dataType: "json",
		contentType: "application/json; charset=utf-8",
		data: JSON.stringify({ movieResults: jsonData }),
		success: function (successMsg) {
			console.log(successMsg);
		},
		failure: function (errMsg) {
			console.log(errMsg);
		}
	});
}