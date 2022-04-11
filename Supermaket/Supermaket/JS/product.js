$(document).ready(function () {
    var product =parseInt( $("#product_val").text());
    $("#product_sub").click(function (e) { 
       product-=1;
       if(product < 0) product = 0;
       $("#product_val").text(String(product));
       e.preventDefault();
    });
    $("#product_sum").click(function (e) { 
        product+=1;
        $("#product_val").text(String(product));
        e.preventDefault();
    });
});