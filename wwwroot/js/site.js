// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.addEventListener('DOMContentLoaded', function () {
    const roles = [
    'Backend Developer',
    'Frontend Engineer',
    'Full-Stack Developer',
    'Software Engineer',
    'DevOps Engineer',
    'QA Engineer',
    'Marketing Manager',
    'Graphic Designer',
    'Sales Representative',
    'Customer Success Manager',
    'Operations Coordinator',
    'HR Generalist',
    'Financial Analyst',
    'Project Manager',
    'Content Writer',
    'Data Analyst',
    'Executive Assistant',
    'Account Manager',
    'Recruiter',
    'Product Manager',
    'Social Media Manager',
    'Warehouse Associate',
    'Office Manager',
    'Business Development Rep'
    ];

    const roleEl = document.getElementById('hiring-role');
    if (!roleEl) return;

    let index = 0;

    setInterval(function () {
        index = (index + 1) % roles.length;
        roleEl.style.opacity = 0;

        setTimeout(function () {
            roleEl.textContent = roles[index];
            roleEl.style.opacity = 1;
        }, 300);
    }, 2200);
});

dropdown = document.getElementById('statusFilter');

dropdown.addEventListener('change', function (event) {
    for (const row of document.querySelectorAll('.ledger-row')) {
        if (event.target.value === 'All') {
            row.style.display = '';
        }
        else if (row.getAttribute('data-status') !== event.target.value) {
            row.style.display = 'none';
        }
        else {
            row.style.display = '';
        }
    }
}
);