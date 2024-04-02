$(document).ready(function () {
    loadInventoryChart();
    loadDonationChart();
});

function loadInventoryChart() {
    $.ajax({
        type: "GET",
        url: '/Home/InventoryChart',
        success: function (res) {
            const ctx = document.getElementById('inventoryChart');
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: res.labels,
                    datasets: [{
                        label: 'Inventory',
                        data: res.data,
                        borderWidth: 2,
                        backgroundColor: [
                            '#D50000',
                            '#FF1744',
                            '#FF5252',
                            '#FF8A80',
                            '#B71C1C',
                            '#C62828',
                            '#D32F2F',
                            '#E53935',
                            '#F44336',
                            '#EF5350',
                            '#E57373'

                        ]
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

function loadDonationChart() {
    $.ajax({
        type: "GET",
        url: '/Home/DonationChart',
        success: function (res) {
            const ctx2 = document.getElementById('donationChart');
            new Chart(ctx2, {
                type: 'bar',
                data: {
                    labels: res.labels,
                    datasets: [{
                        label: 'Donations',
                        data: res.data,
                        borderWidth: 2,
                        backgroundColor: [
                            '#EA80FC',
                            '#E040FB',
                            '#D500F9',
                            '#AA00FF',
                        ]
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}
