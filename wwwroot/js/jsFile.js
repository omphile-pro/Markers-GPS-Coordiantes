(function () {
    'use strict'
  
    window.addEventListener('load', function () {
      // Fetch all the forms we want to apply custom Bootstrap validation styles to
      var forms = document.getElementsByClassName('needs-validation')
  
      // Loop over them and prevent submission
      Array.prototype.filter.call(forms, function (form) {
        form.addEventListener('submit', function (event) {
          if (form.checkValidity() === false) {
            event.preventDefault()
            event.stopPropagation()
          }
          form.classList.add('was-validated')
        }, false)
      })
    }, false)
  }())

  $(document).ready(function(){

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;

    $('.markerOnList a').click(function(){
      let section = $(this).attr('id')
      console.log("fieldset #" + section);

      $("fieldset #" + section).show();
    })
    
    $(".next").click(function(){
    
    current_fs = $(this).parent();
    console.log(current_fs);
    next_fs = $(this).parent().next();
    console.log(next_fs);
    
    //Add Class Active
    $(".markerOnList a").eq($("fieldset").index(current_fs)).removeClass().addClass("done");
      $(".markerOnList i").eq($("fieldset").index(current_fs)).removeClass().addClass("fas fa-circle");
    $(".markerOnList a").eq($("fieldset").index(next_fs)).addClass("active");

    
    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate({opacity: 0}, {
    step: function(now) {
    // for making fielset appear animation
    opacity = 1 - now;
    
    current_fs.css({
    'display': 'none',
    'position': 'relative'
    });
    next_fs.css({'opacity': opacity});
    },
    duration: 600
    });
    });
    
    $(".previous").click(function(){
    
    current_fs = $(this).parent();
    previous_fs = $(this).parent().prev();
    
    //Remove class active
    $(".markerOnList a").eq($("fieldset").index(previous_fs)).removeClass().addClass("active");
    $(".markerOnList i").eq($("fieldset").index(previous_fs)).removeClass().addClass("far fa-circle");
    $(".markerOnList a").eq($("fieldset").index(current_fs)).removeClass("active");
    
    //show the previous fieldset
    previous_fs.show();
    
    //hide the current fieldset with style
    current_fs.animate({opacity: 0}, {
    step: function(now) {
    // for making fielset appear animation
    opacity = 1 - now;
    
    current_fs.css({
    'display': 'none',
    'position': 'relative'
    });
    previous_fs.css({'opacity': opacity});
    },
    duration: 600
    });
    });
    
    // $('.radio-group .radio').click(function(){
    // $(this).parent().find('.radio').removeClass('selected');
    // $(this).addClass('selected');
    // });
    
    $(".submit").click(function(){
    return false;
    })
    
    });
  