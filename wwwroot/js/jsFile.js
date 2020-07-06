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

$(document).ready(function () {

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;
    $('#nav-tab a').click(function () {

        //   current_fs = $("fieldset");
        //   next_fs =$("fieldset").eq($(this).index());
        $("fieldset").eq($(this).index() - 1).show();
        console.log($("fieldset").eq($(this).index() - 1));
        $(this).addClass("active");

        $("fieldset").css({
            'display': 'none',
            'position': 'relative',
            'opacity': 1
        });

        $("fieldset").eq($(this).index() - 1).css({
            'display': 'block',
            'position': 'relative'
        });
        $("html, body").animate({ scrollTop: 0 }, "slow");
        console.log("works");

    });

    $(".next").click(function () {

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //Add Class Active
        $(".markerOnList a").eq($("fieldset").index(current_fs)).removeClass().addClass("done");
        $(".markerOnList i").eq($("fieldset").index(current_fs)).removeClass().addClass("fas fa-circle");
        $(".markerOnList a").eq($("fieldset").index(next_fs)).addClass("active");


        //show the next fieldset
        next_fs.show();
        
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
        $("html, body").animate({ scrollTop: 0 }, "slow");
        console.log("to top");
    });

    $(".previous").click(function () {

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        //Remove class active
        $(".markerOnList a").eq($("fieldset").index(previous_fs)).removeClass().addClass("active");
        $(".markerOnList i").eq($("fieldset").index(previous_fs)).removeClass().addClass("far fa-circle");
        $(".markerOnList a").eq($("fieldset").index(current_fs)).removeClass("active");

        //show the previous fieldset
        previous_fs.show();

        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
    });

    // $('.radio-group .radio').click(function(){
    // $(this).parent().find('.radio').removeClass('selected');
    // $(this).addClass('selected');
    // });

    $(".submit").click(function () {
        return false;
    })

});





//Autocomplete
function autocomplete(inp, arr) {
    /*the autocomplete function takes two arguments,
    the text field element and an array of possible autocompleted values:*/
    var currentFocus;
    /*execute a function when someone writes in the text field:*/
    inp.addEventListener("input", function (e) {
        var a, b, i, val = this.value;
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        if (!val) { return false; }
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        /*append the DIV element as a child of the autocomplete container:*/
        this.parentNode.appendChild(a);
        /*for each item in the array...*/
        for (i = 0; i < arr.length; i++) {
            /*check if the item starts with the same letters as the text field value:*/
            if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                /*create a DIV element for each matching element:*/
                b = document.createElement("DIV");
                /*make the matching letters bold:*/
                b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                b.innerHTML += arr[i].substr(val.length);
                /*insert a input field that will hold the current array item's value:*/
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                /*execute a function when someone clicks on the item value (DIV element):*/
                b.addEventListener("click", function (e) {
                    /*insert the value for the autocomplete text field:*/
                    inp.value = this.getElementsByTagName("input")[0].value;
                    /*close the list of autocompleted values,
                    (or any other open lists of autocompleted values:*/
                    closeAllLists();
                });
                a.appendChild(b);
            }
        }
    });
    /*execute a function presses a key on the keyboard:*/
    inp.addEventListener("keydown", function (e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
            /*If the arrow DOWN key is pressed,
            increase the currentFocus variable:*/
            currentFocus++;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 38) { //up
            /*If the arrow UP key is pressed,
            decrease the currentFocus variable:*/
            currentFocus--;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 13) {
            /*If the ENTER key is pressed, prevent the form from being submitted,*/
            e.preventDefault();
            if (currentFocus > -1) {
                /*and simulate a click on the "active" item:*/
                if (x) x[currentFocus].click();
            }
        }
    });
    function addActive(x) {
        /*a function to classify an item as "active":*/
        if (!x) return false;
        /*start by removing the "active" class on all items:*/
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        /*add class "autocomplete-active":*/
        x[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(x) {
        /*a function to remove the "active" class from all autocomplete items:*/
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }
    function closeAllLists(elmnt) {
        /*close all autocomplete lists in the document,
        except the one passed as an argument:*/
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inp) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }
    /*execute a function when someone clicks in the document:*/
    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}

/*An array containing all the country names in the world:*/
var countries = [
    "Afrikaans Second Additional Language",
    "Civil Technology (Woodworking)",
    "English First Additional Language",
    "Technical Sciences",
    "Mic",
    "Tourism",
    "Xitsonga Home Language",
    "Electrical Technology (Power Systems)",
    "Physical Sciences",
    "Life Sciences",
    "Setswana Home Language",
    "Visual Arts",
    "Tshivenda Home Language",
    "IsiZulu First Additional Language",
    "IsiXhosa Home Language",
    "Religion Studies",
    "Mechanical Technology (Fitting and Machi",
    "Geography",
    "Mechanical Technology (Automotive)",
    "Consumer Studies",
    "Technical Mathematics",
    "Mechanical Technology (Welding and Metal",
    "Afrikaans Home Language",
    "Agricultural Technology",
    "History",
    "Hospitality Studies",
    "Sesotho Home Language",
    "Civil Technology (Civil Services)",
    "Engineering Graphics and Design",
    "IsiZulu Home Language",
    "Computer Applications Technology",
    "Sepedi First Additional Language",
    "Sepedi Home Language",
    "Setswana First Additional Language",
    "Business Studies",
    "Civil Technology (Construction)",
    "Agricultural Sciences",
    "Electrical Technology (Digital Systems)",
    "English Home Language",
    "Dance Studies",
    "Afrikaans First Additional Language",
    "Information Technology",
    "Mathematics",
    "Design",
    "Dramatic Arts",
    "Electrical Technology (Electronics)",
    "Mathematical Literacy",
    "Accounting",
    "Economics"
];

/*initiate the autocomplete function on the "myInput" element, and pass along the countries array as possible autocomplete values:*/
autocomplete(document.getElementById("MarkingSubject"), countries);


//top drop down
$(document).on('click', '.add', function () {
    $('.qualification-drop').css('display', 'block');
})

$('body').on('click', function () {
    $('.qualification-drop').css('display', 'block');
})

//add qualification
$(document).on('click', '.qua-form-option', function () {
    $('.qualification-form').css('display', 'block');
    $('.top-qualification').hide();
})