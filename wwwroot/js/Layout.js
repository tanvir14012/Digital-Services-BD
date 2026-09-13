(function () {
    "use strict";
    const search = document.getElementById("searchInput");
    const submit = document.getElementById("searchSubmit");
    if (search && submit) {
        const update = () => { submit.disabled = search.value.trim().length < 2; };
        search.addEventListener("input", update);
        update();
    }
    const header = document.querySelector("header.fixed-top");
    const main = document.getElementById("main_container");
    if (header && main && window.ResizeObserver) {
        new ResizeObserver(() => {
            main.style.setProperty("padding-top", `${header.getBoundingClientRect().height + 16}px`, "important");
            main.style.setProperty("margin-top", "0", "important");
        }).observe(header);
    }
})();
