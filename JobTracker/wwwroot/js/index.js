// =========================
// Filter och max per kolumn (utan sortering)
// =========================
document.querySelectorAll('.columns').forEach(column => {
    const input = column.querySelector('.titleFilter');
    const maxSelect = column.querySelector('.maxJobs');
    const jobsGrid = column.querySelector('.jobs-grid');
    const cards = Array.from(jobsGrid.querySelectorAll('.job-card'));

    function updateJobs() {
        const filter = input.value.toLowerCase();
        const max = parseInt(maxSelect.value, 10);

        // Filtrera kort
        let filtered = cards.filter(card => {
            const title = (card.dataset.title || "").toLowerCase();
            const company = (card.dataset.company || "").toLowerCase();
            return title.includes(filter) || company.includes(filter);
        });

        // Visa max antal kort
        cards.forEach(card => card.style.display = 'none'); // göm alla
        filtered.slice(0, max).forEach(card => card.style.display = 'block'); // visa filtrerade
    }

    // Event listeners
    input.addEventListener('input', updateJobs);
    maxSelect.addEventListener('change', updateJobs);

    // Init
    updateJobs();
});

// =========================
// Toggle view: stora/små kort
// =========================
const toggleButton = document.getElementById("btn-toggle-view");
let isSmallView = false;

toggleButton?.addEventListener('click', () => {
    isSmallView = !isSmallView;
    document.querySelectorAll(".job-card, .job-card-small").forEach(card => {
        if (isSmallView) {
            card.classList.remove('job-card');
            card.classList.add('job-card-small');
        } else {
            card.classList.remove('job-card-small');
            card.classList.add('job-card');
        }
    });
});

// =========================
// OBS: Formulärkod är bortkommenterad
// =========================
// const buttonForm = document.getElementById("add-job");
// const formLetter = document.querySelector(".form-section");
// let formActive = false;

// buttonForm?.addEventListener('click', () => {
//     formActive = !formActive;
//     if (!formActive) {
//         formLetter.classList.add('form-section-remove');
//     } else {
//         formLetter.classList.remove('form-section-remove');
//     }
// });
