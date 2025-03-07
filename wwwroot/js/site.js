// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function searchRecipe() {
    let input = document.getElementById("search-bar").value.toLowerCase();
    let recipes = document.querySelectorAll(".recipe-item");

    recipes.forEach((recipe) => {
        let text = recipe.textContent.toLowerCase();
        if (text.includes(input)) {
            recipe.style.display = "block";
        } else {
            recipe.style.display = "none";
        }
    });
}
