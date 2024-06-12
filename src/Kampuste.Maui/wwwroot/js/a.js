// wwwroot/js/scrollToBottom.js
function adjustContentHeight() {
    const content = document.querySelector('.content');
    if (content) {
        const footerHeight = document.querySelector('.footer').offsetHeight;
        const windowHeight = window.innerHeight;
        content.style.minHeight = (windowHeight - footerHeight) + 'px';
    }
}

window.addEventListener('resize', adjustContentHeight);
window.addEventListener('orientationchange', adjustContentHeight);

document.addEventListener('DOMContentLoaded', function () {
    adjustContentHeight();
});
