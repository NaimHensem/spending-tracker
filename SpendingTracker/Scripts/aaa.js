
document.addEventListener("DOMContentLoaded", () => {
    // Amount input validation
    const amountInput = document.getElementById("amountInput");
    if (amountInput) {
        amountInput.addEventListener("input", () => {
            amountInput.value = amountInput.value.replace(/[^0-9.]/g, '');
            const dotIndex = amountInput.value.lastIndexOf('.');
            if (dotIndex !== amountInput.value.indexOf('.')) {
                amountInput.value = amountInput.value.substring(0, dotIndex);
            }
        });
        amountInput.addEventListener("blur", () => {
            if (amountInput.value) amountInput.value = parseFloat(amountInput.value).toFixed(2);
        });
    }

    // Delete button confirmation
    document.querySelectorAll('.delete-btn').forEach(button =>
        button.addEventListener('click', event => {
            if (!confirm("Delete this record?")) event.preventDefault();
        })
    );

    // Table sorting
    const amountArrow = document.getElementById("amountArrow");
    const tableBody = document.getElementById("spendingTableBody");
    if (amountArrow && tableBody) {
        amountArrow.addEventListener("click", () => {
            const order = amountArrow.dataset.order;
            const rows = [...tableBody.rows];

            rows.sort((a, b) => {
                const amountA = parseFloat(a.cells[2].textContent) || 0;
                const amountB = parseFloat(b.cells[2].textContent) || 0;
                return order === "asc" ? amountA - amountB : amountB - amountA;
            }).forEach(row => tableBody.appendChild(row));

            amountArrow.textContent = order === "asc" ? "▲" : "▼";
            amountArrow.dataset.order = order === "asc" ? "desc" : "asc";
        });
    }

    // Background toggle switch
    const toggleSwitch = document.getElementById("bgToggleSwitch");
    const body = document.body;

    if (toggleSwitch) {
        const mode = localStorage.getItem('backgroundMode') || 'light';
        body.className = `${mode}-mode`;
        toggleSwitch.checked = (mode === 'dark');

        toggleSwitch.addEventListener("change", () => {
            const newMode = toggleSwitch.checked ? 'dark' : 'light';
            body.className = `${newMode}-mode`;
            localStorage.setItem('backgroundMode', newMode);
        });
    }

    // Modal
    const modal = document.getElementById("spendingLimitModal");
    document.getElementById("setLimitBtn").addEventListener("click", () => modal.style.display = "flex");  // Open
    document.querySelector(".modal .close").addEventListener("click", () => modal.style.display = "none"); // Close button
    modal.addEventListener("click", event => event.target === modal && (modal.style.display = "none"));    // Close on outside clicking
});
