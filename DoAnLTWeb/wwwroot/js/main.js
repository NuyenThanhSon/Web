
document.querySelector('#mob-menu-toggle').addEventListener('click', () => document.querySelector('#header-wrapper').classList.add('active'))

document.querySelector('#mob-menu-close').addEventListener('click', () => document.querySelector('#header-wrapper').classList.remove('active'))

// product

document.addEventListener("DOMContentLoaded", function() {
    const blogRow = document.getElementById("blogRow");
    const nextButton = document.getElementById("nextButton");
    const prevButton = document.getElementById("prevButton");

    const cols = blogRow.querySelectorAll(".col-12");
  
    let currentIndex = 0;
    const numColsToShow = 3;
  
    function showColumns() {
        for (let i = 0; i < cols.length; i++) {
            if (i >= currentIndex && i < currentIndex + numColsToShow) {
                cols[i].style.display = "block";
            } else {
                cols[i].style.display = "none";
            }
        }
    }
  
    function handleNextButtonClick() {
        if (currentIndex + numColsToShow < cols.length) {
            currentIndex += numColsToShow;
            showColumns();
        }
    }
  
    function handlePrevButtonClick() {
        if (currentIndex - numColsToShow >= 0) {
            currentIndex -= numColsToShow;
            showColumns();
        }
    }

    nextButton.addEventListener("click", handleNextButtonClick);
    prevButton.addEventListener("click", handlePrevButtonClick);
  
    showColumns();
});





function menuToggle(isHovered) {
    const toggleMenu = document.querySelector('.dropdown-menu-list');
    if (isHovered) {
        toggleMenu.classList.add('active');
    } else {
        toggleMenu.classList.remove('active');
    }
}

