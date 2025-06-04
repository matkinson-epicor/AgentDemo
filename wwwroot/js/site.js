// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// News Carousel Functionality
function initNewsCarousel() {
    const carousel = document.querySelector('.news-carousel');
    const items = document.querySelectorAll('.news-item');
    const indicators = document.querySelectorAll('.carousel-indicators button');
    
    if (!carousel || items.length === 0) return;
    
    let currentIndex = 0;
    const totalItems = items.length;
    const autoScrollInterval = 5000; // 5 seconds between slides
    let autoScrollTimer;
    
    // Function to show a specific slide
    function showSlide(index) {
        // Handle index bounds
        if (index < 0) index = totalItems - 1;
        if (index >= totalItems) index = 0;
        
        // Update current index
        currentIndex = index;
        
        // Move the carousel
        carousel.style.transform = `translateX(-${currentIndex * 100}%)`;
        
        // Update indicators
        indicators.forEach((indicator, i) => {
            if (i === currentIndex) {
                indicator.classList.add('active');
                indicator.setAttribute('aria-current', 'true');
            } else {
                indicator.classList.remove('active');
                indicator.setAttribute('aria-current', 'false');
            }
        });
    }
    
    // Set up click handlers for indicators
    indicators.forEach((indicator, i) => {
        indicator.addEventListener('click', () => {
            showSlide(i);
            resetAutoScroll();
        });
    });
    
    // Function to advance to the next slide
    function nextSlide() {
        showSlide(currentIndex + 1);
    }
    
    // Function to reset the auto-scroll timer
    function resetAutoScroll() {
        clearInterval(autoScrollTimer);
        autoScrollTimer = setInterval(nextSlide, autoScrollInterval);
    }
    
    // Initialize auto-scrolling
    resetAutoScroll();
    
    // Pause auto-scrolling when hovering over the carousel
    carousel.parentElement.addEventListener('mouseenter', () => {
        clearInterval(autoScrollTimer);
    });
    
    // Resume auto-scrolling when mouse leaves the carousel
    carousel.parentElement.addEventListener('mouseleave', () => {
        resetAutoScroll();
    });
}