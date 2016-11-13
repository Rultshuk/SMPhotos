$('#file-fr').fileinput({
	language: 'fr',
	uploadUrl: '#',
	allowedFileExtensions : ['jpg', 'png','gif','jpeg'],
});
$(document).ready(function() {
	$("#test-upload").fileinput({
		'showPreview' : false,
		'allowedFileExtensions' : ['jpg', 'png','gif','jpeg'],
		'elErrorContainer': '#errorBlock'
	});
});