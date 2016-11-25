var $ = jQuery.noConflict();

$(document).ready(function() {
	var maxFiles = 6;
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
				
				if(errMessage == 0) {
					$('#drop-files p').html('Just images!');
					++errMessage
				}
				else if(errMessage == 1) {
					$('#drop-files p').html('Just images! You understood?');
					++errMessage
				}
				else if(errMessage == 2) {
					$('#drop-files p').html("Oh my GOD! JUST IMAGES!!!");
					++errMessage
				}
				else if(errMessage == 3) {
					$('#drop-files p').html("Ok...you winn..");
					errMessage = 0;
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
	
	// Удаление только выбранного изображения 
	$("#dropped-files").on("click","a[id^='drop']", function() {
		// получаем название id
 		var elid = $(this).attr('id');
		// создаем массив для разделенных строк
		var temp = new Array();
		// делим строку id на 2 части
		temp = elid.split('-');
		// получаем значение после тире тоесть индекс изображения в массиве
		dataArray.splice(temp[1],1);
		// Удаляем старые эскизы
		$('#dropped-files > .image').remove();
		// Обновляем эскизи в соответсвии с обновленным массивом
		addImage(-1);		
	});
	
	// Удалить все изображения кнопка 
	$('#dropped-files #upload-button .delete').click(restartFiles);
	

	
	// Простые стили для области перетаскивания
	$('#drop-files').on('dragenter', function() {
		$(this).css({'box-shadow' : 'inset 0px 0px 20px rgba(0, 0, 0, 0.1)', 'border' : '4px dashed #bb2b2b'});
		return false;
	});
	
	$('#drop-files').on('drop', function() {
		$(this).css({'box-shadow' : 'none', 'border' : '4px dashed rgba(0,0,0,0.2)'});
		return false;
	});
});