$(window).load(function () {
    var img = $('.fancybox-thumb img');
    img.each(function () {
        var $this = $(this),
          width = $this.width(),
          height = $this.height();
        console.log(width, height);
        if (width < height) {
            $this.addClass('portrait');
        } else {
            //$this.addClass('landscape');
        }
    });
});