const loadMoreBtn = document.querySelector(".load-more")

loadMoreBtn.addEventListener("click", LoadMore)

function LoadMore() {
    fetch.("/Pricing/LoadMore")
        .then(response => response.text())
        .then(text => {
            $(".services").append(text)
        })
}