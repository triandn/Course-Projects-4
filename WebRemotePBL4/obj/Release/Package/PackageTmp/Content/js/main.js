const activeImg = (i) => {
    const listZoomImage = document.querySelectorAll(".zoom-item");
    let activeElement = document.querySelector(".zoom-item.active");
    if(activeElement) activeElement.classList.remove("active");
    listZoomImage[i].classList.add("active");
}

const listDataItem = document.querySelectorAll(".data-image");
const listZoomImg = document.querySelectorAll(".zoom-item");
for(let i = 0; i < listDataItem.length; i++) {
    listDataItem[i].addEventListener("click", () => {
        const zoomDiv = document.querySelector(".zoom");
        zoomDiv.style.display = "block"; 
        activeImg(i);
    })
}

const closeBtn = document.querySelector(".slick-btn.close");
closeBtn.addEventListener("click", function() {
    document.querySelector(".zoom").style.display = "none";
});

const nextBtn = document.querySelector(".slick-btn.next-arrow");
nextBtn.addEventListener("click", function() {
    let activeElement = document.querySelector(".zoom-item.active");
    let currentIndex = Number(activeElement.getAttribute("index"));
    nextIndex = (currentIndex + 1) % listZoomImg.length;
    activeImg(nextIndex);
});

const prevBtn = document.querySelector(".slick-btn.prev-arrow");
prevBtn.addEventListener("click", function() {
    let activeElement = document.querySelector(".zoom-item.active");
    let currentIndex = Number(activeElement.getAttribute("index"));
    prevIndex = (currentIndex - 1 + listZoomImg.length) % listZoomImg.length;
    activeImg(prevIndex);
});