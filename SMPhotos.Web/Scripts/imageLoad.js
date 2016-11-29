var $ = jQuery.noConflict();

$(document).ready(function() {
	var maxFiles = 10;
	var errMessage = 0;
	var defaultUploadBtn = $('#uploadbtn');
	var dataArray = [];
	$('#uploaded-files').hide();
	
	defaultUploadBtn.on('change', function() {
   		var files = $(this)[0].files;
		if (files.length <= maxFiles) {
			loadInView(files);
            $('#frm').each(function(){
	        	    this.reset();
			});
		} else {
			alert('You can not upload more than '+maxFiles+' images!'); 
			files.length = 0;
		}
	});
	function loadInView(files) {
		$('#uploaded-holder').show();
		$.each(files, function(index, file) {
		    if (!files[index].type.match('image.*')) {
		        var obj = document.getElementById('upload-button');
		        obj.style.display = "none";
				
				if(errMessage == 0) {
					$('#drop-files p').html('Just images!');
					++errMessage
				}
				else if(errMessage == 1) {
				    $('#drop-files p').html('Just images! Do you understand?');
					++errMessage
				}
				else if (errMessage == 2) {
				    showHide("joke");
				    $('#drop-files p').html('Are you kidding?');
					++errMessage
				}
				return false;
			}

			if((dataArray.length+files.length) <= maxFiles) {
				$('#upload-button').css({'display' : 'block'});
			} 
			else { alert('You can not upload more than '+maxFiles+' images!'); return; }
			var fileReader = new FileReader();
				fileReader.onload = (function(file) {
					
					return function(e) {
						dataArray.push({name : file.name, value : this.result});
						addImage((dataArray.length-1));
					}; 
						
				})(files[index]);
			fileReader.readAsDataURL(file);
		});
		return false;
	}
	function addImage(ind) {
		if (ind < 0 ) { 
		start = 0; end = dataArray.length; 
		} else {
		start = ind; end = ind+1; } 
		if(dataArray.length == 0) {
			$('#upload-button').hide();
			$('#uploaded-holder').hide();
		} else if (dataArray.length == 1) {
			$('#upload-button span').html("You chose 1 file");
		} else {
			$('#upload-button span').html("You chose "+ dataArray.length+" files");
		}
		for (i = start; i < end; i++) {
			if($('#dropped-files > .image').length <= maxFiles) { 
				$('#dropped-files').append('<div id="img-'+i+'" class="image" style="background: url('+dataArray[i].value+'); background-size: cover;"> <a href="#" id="drop-'+i+'" class="drop-button">Remove image</a></div>'); 
			}
		}
		return false;
	}
	
	function restartFiles() {

		$('#loading-bar .loading-color').css({'width' : '0%'});
		$('#loading').css({'display' : 'none'});
		$('#loading-content').html(' ');
		
		$('#upload-button').hide();
		$('#dropped-files > .image').remove();
		$('#uploaded-holder').hide();

		dataArray.length = 0;
		
		return false;
	}

	$("#dropped-files").on("click","a[id^='drop']", function() {
 		var elid = $(this).attr('id');
		var temp = new Array();
		temp = elid.split('-');
		dataArray.splice(temp[1],1);
		$('#dropped-files > .image').remove();
		addImage(-1);		
	});
	 
	$('#dropped-files #upload-button .delete').click(restartFiles);
	
});
function showHide(element_id) {
    if (document.getElementById(element_id)) {
        var obj = document.getElementById(element_id);
        if (obj.style.display != "block") {
            obj.style.display = "block";
            joke.onclick = function () {
                obj.style.display = "none";
            }
        }
    }
}