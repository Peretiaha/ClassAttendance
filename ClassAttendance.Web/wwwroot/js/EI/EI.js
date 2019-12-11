//var selectedCountry = document.getElementById("country-select");
//var strUser = selectedCountry.options[selectedCountry.selectedIndex].value;
//console.log(strUser);
//selectedCountry.addEventListener("change", function(event) {
//    if (event.target.dataset.priorityinput) {
//        console.log(selectedCountry.value);
//        let item = {
//            Country : 3
//        }
//        changeNumberOfOrderDetails(item);
//    }
//});

function sendCountry() {
    var selectedCountry = document.getElementById("country-select");
    var strUser = selectedCountry.options[selectedCountry.selectedIndex].value;
    let item = {
        Country: +strUser
    };
    let form = document.getElementById("form");
    form.submit();
}