// const nxtBtn = document.querySelector('#submitBtn');
// const form1 = document.querySelector('#form1');
// const form2 = document.querySelector('#form2');
// const form3 = document.querySelector('#form3');
// const form4 = document.querySelector('#form4');
// const form5 = document.querySelector('#form5');


// const icon1 = document.querySelector('#icon1');
// const icon2 = document.querySelector('#icon2');
// const icon3 = document.querySelector('#icon3');
// const icon4 = document.querySelector('#icon4');
// const icon5 = document.querySelector('#icon5');


// var viewId = 1;
// function nextForm(){
// console.log("hellonext");
// viewId=viewId+1;
// progressBar();
// displayForms();

// console.log(viewId);

// }

// function prevForm(){
// console.log("helloprev");
// viewId=viewId-1;
// console.log(viewId);
// progressBar1();
// displayForms();
// }
// function progressBar1(){
// if(viewId===1){
// icon2.classList.add('active');
// icon2.classList.remove('active');
// icon3.classList.remove('active');
// icon4.classList.remove('active');
// icon5.classList.remove('active');
// }
// if(viewId===2){
// icon2.classList.add('active');
// icon3.classList.remove('active');
// icon4.classList.remove('active');
// icon5.classList.remove('active');
// }
// if(viewId===3){
// icon3.classList.add('active');
// icon4.classList.remove('active');
// icon5.classList.remove('active');
// }
// if(viewId===4){
// icon4.classList.add('active');
// icon5.classList.remove('active');
// }
// if(viewId===5){
// icon5.classList.add('active');
// nxtBtn.innerHTML = "Submit"
// }
// if(viewId>5){
// icon2.classList.remove('active');
// icon3.classList.remove('active');
// icon4.classList.remove('active');
// icon5.classList.remove('active');

// }
// }

// function progressBar(){
// if(viewId===2){
// icon2.classList.add('active');
// }
// if(viewId===3){
// icon3.classList.add('active');
// }
// if(viewId===4){
// icon4.classList.add('active');
// }
// if(viewId===5){
// icon5.classList.add('active');
// nxtBtn.innerHTML = "Submit"
// }
// if(viewId>5){
// icon2.classList.remove('active');
// icon3.classList.remove('active');
// icon4.classList.remove('active');
// icon5.classList.remove('active');

// }
// }

// function displayForms(){

// if(viewId>5){
// viewId=1;
// }

// if(viewId ===1){
// form1.style.display = 'block';
// form2.style.display = 'none';
// form3.style.display = 'none';
// form4.style.display = 'none';
// form5.style.display = 'none';


// }else if(viewId === 2){
// form1.style.display = 'none';
// form2.style.display = 'block';
// form3.style.display = 'none';
// form4.style.display = 'none';
// form5.style.display = 'none';

// }else if(viewId === 3){
// form1.style.display = 'none';
// form2.style.display = 'none';
// form3.style.display = 'block';
// form4.style.display = 'none';
// form5.style.display = 'none';
// }else if(viewId === 4){
// form1.style.display = 'none';
// form2.style.display = 'none';
// form3.style.display = 'none';
// form4.style.display = 'block';
// form5.style.display = 'none';

// }else if(viewId === 5){
// form1.style.display = 'none';
// form2.style.display = 'none';
// form3.style.display = 'none';
// form4.style.display = 'none';
// form5.style.display = 'block';

// }
// }

// // for slider

// var slider = document.querySelector(".slider");
// var output = document.querySelector(".output__value");
// output.innerHTML = slider.value ;

// slider.oninput = function() {
// output.innerHTML = this.value ;


// }








var current_fs, next_fs, previous_fs; //fieldsets
var opacity;
var current = 1;
var steps = $("fieldset").length;

setProgressBar(current);

$(".next").click(function(){

current_fs = $(this).parent();
next_fs = $(this).parent().next();

//Add Class Active
$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

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
duration: 500
});
setProgressBar(++current);
});

$(".previous").click(function(){

current_fs = $(this).parent();
previous_fs = $(this).parent().prev();

//Remove class active
$("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

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
duration: 500
});
setProgressBar(--current);
});

function setProgressBar(curStep){
var percent = parseFloat(100 / steps) * curStep;
percent = percent.toFixed();
$(".progress-bar")
.css("width",percent+"%")
}

$(".submit").click(function(){
return false;
})
