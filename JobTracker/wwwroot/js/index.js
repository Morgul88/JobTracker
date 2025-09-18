document.querySelectorAll('.titleFilter').forEach(input => {
    input.addEventListener('input', () => {
        const filter = input.value.toLowerCase();
        document.querySelectorAll('.job-card').forEach(card => {
            const title = (card.dataset.title || "").toLowerCase();
            const company = (card.dataset.company || "").toLowerCase();
            card.style.display = (title.includes(filter) || company.includes(filter)) ? "block" : "none";
        });
    });
});

document.addEventListener('DOMContentLoaded', () => {
    const sortSelect = document.getElementById('sortSelect');
    const jobsGrid = document.querySelector('.jobs-grid');

    sortSelect.addEventListener('change', () => {
        const order = sortSelect.value;

        // Hämta alla kort som array
        const jobCards = Array.from(jobsGrid.querySelectorAll('.job-card'));

        // Sortera korten efter data-date
        jobCards.sort((a, b) => {
            const dateA = new Date(a.dataset.date);
            const dateB = new Date(b.dataset.date);

            if (order === 'latest') {
                return dateB - dateA; // nyast först
            } else {
                return dateA - dateB; // äldst först
            }
        });

        // Rensa grid och lägg till sorterade kort igen
        jobsGrid.innerHTML = '';
        jobCards.forEach(card => jobsGrid.appendChild(card));
    });
});

document.addEventListener('DOMContentLoaded', () => {
    const input = document.getElementById('titleFilter');
    const maxSelect = document.getElementById('maxJobs');
    const sortSelect = document.getElementById('sortSelect');
    const container = document.querySelector('.jobs-grid');
    const cards = Array.from(container.querySelectorAll('.job-card'));

    function updateJobs() {
        const filter = input.value.toLowerCase();
        const max = parseInt(maxSelect.value, 10);
        const sort = sortSelect.value;

        let filtered = cards.filter(card => {
            const title = (card.dataset.title || "").toLowerCase();
            return title.includes(filter);
        });

        // Sortera
        filtered.sort((a, b) => {
            const dateA = new Date(a.dataset.date);
            const dateB = new Date(b.dataset.date);
            return sort === 'latest' ? dateB - dateA : dateA - dateB;
        });

        // Visa max antal
        cards.forEach(card => card.style.display = 'none'); // göm alla
        filtered.slice(0, max).forEach(card => card.style.display = 'block'); // visa de som ska visas
    }

    // Event listeners
    input.addEventListener('input', updateJobs);
    maxSelect.addEventListener('change', updateJobs);
    sortSelect.addEventListener('change', updateJobs);

    // Init
    updateJobs();
});

const button = document.getElementById("btn-toggle-view");
const jobClass = document.querySelectorAll(".job-card");

let isActive = false;

button.addEventListener('click', () => {
    isActive = !isActive
    jobClass.forEach(card => {
        if (isActive) {
            card.classList.remove('job-card');
            card.classList.add('job-card-small');
        } else {
            card.classList.remove('job-card-small');
            card.classList.add('job-card');
        }
    });
});

//const buttonForm = document.getElementById("add-job");
//console.log(buttonForm)
//let formActive = false;
//console.log(formActive)
//const formLetter = document.querySelector(".form-section")
//console.log(formLetter)
//buttonForm.addEventListener('click', () => {
//    formActive = !formActive;
//    console.log("hello")
//    console.log(formActive)
//    if (!formActive) {
//        formLetter.classList.add('form-section-remove');
//    } else {
//        formLetter.classList.remove('form-section-remove');
//    }
    

//});


