document.addEventListener("DOMContentLoaded", () => {
    function getRandomColor() {
        return '#' + Math.floor(Math.random() * 16777215).toString(16);
    }
    debugger;
    $.ajax({
        url: '/Home/OfferReportByUser', // İsteğin gönderileceği adresi buraya ekleyin
        method: 'GET',
        success: function (response) {
            debugger;
            let series1 = [];
            let processedUsers = []; // Daha önce işlenen kullanıcıları saklamak için dizi
            let offerDates = [];
            let userColors = [];

            // response.$values içindeki tekliflerin tarihlerini alarak offerDates dizisine ekleyin
            response.$values.forEach(offer => {
                offerDates.push(offer.CreatedTime); // Burada OfferDate, teklifin tarihini temsil eden özellik adı olmalı
            });
            response.$values.forEach(offer => {
                if (offer.ResponsibleUser !== null && !processedUsers.includes(offer.ResponsibleUser.Name)) {
                    series1.push({
                        name: offer.ResponsibleUser.Name + offer.ResponsibleUser.SurName ,
                        data: [offer.Id]
                    });
                    processedUsers.push(offer.ResponsibleUser.Name); // İşlenen kullanıcıyı listeye ekle
                    userColors.push(getRandomColor()); // İşlenen kullanıcıyı listeye ekle

                }
            });
    new ApexCharts(document.querySelector("#reportsChart"), {

        series: series1,
        chart: {
            height: 350,
            type: 'area',
            toolbar: {
                show: false
            },
        },
        markers: {
            size: 4
        },
        colors: userColors,
        fill: {
            type: "gradient",
            gradient: {
                shadeIntensity: 1,
                opacityFrom: 0.3,
                opacityTo: 0.4,
                stops: [0, 90, 100]
            }
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            curve: 'smooth',
            width: 2
        },
        xaxis: {
            type: 'datetime',
            categories: offerDates
        },
        tooltip: {
            x: {
                format: 'dd/MM/yy HH:mm'
            },
        }
    }).render();

        },
        error: function (error) {
            console.log(error);
        }
    });
    $.ajax({
        url: '/Home/OfferReportBy', // İsteğin gönderileceği adresi buraya ekleyin
        method: 'GET',
        success: function (data) {
            let chartData = data.map(item => ({
                value: parseInt(item.Key),
                name: item.Value
            }));
            echarts.init(document.querySelector("#trafficChart")).setOption({
                tooltip: {
                    trigger: 'item'
                },
                legend: {
                    top: '5%',
                    left: 'center'
                },
                series: [{
                    name: 'Tamamlanan Teklifler',
                    type: 'pie',
                    radius: ['40%', '70%'],
                    avoidLabelOverlap: false,
                    label: {
                        show: false,
                        position: 'center'
                    },
                    emphasis: {
                        label: {
                            show: true,
                            fontSize: '18',
                            fontWeight: 'bold'
                        }
                    },
                    labelLine: {
                        show: false
                    },
                    data: chartData
                }]
            });
        },
        error: function (error) {
            console.log(error);
        }
    });
   
});
