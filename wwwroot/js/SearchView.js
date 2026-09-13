(function () {
    "use strict";
    const form = document.getElementById("searchForm");
    if (!form) return;
    const page = document.getElementById("pageNoInput");
    document.getElementById("goPrice").addEventListener("click", () => {
        const from = document.getElementById("priceFrom");
        const to = document.getElementById("priceTo");
        to.setCustomValidity(Number(to.value) < Number(from.value) ? "Maximum price must be at least the minimum price." : "");
        if (!form.reportValidity()) return;
        document.getElementById("priceRangeInput").value = `${from.value}to${to.value}`;
        page.value = "1";
        form.requestSubmit();
    });
    document.getElementById("sortBy").addEventListener("change", () => { page.value = "1"; form.requestSubmit(); });
    form.querySelectorAll("[data-page]").forEach(button => button.addEventListener("click", () => {
        page.value = button.dataset.page;
        form.requestSubmit();
    }));
})();
