$(function () {

    function ini_events(ele) {
        ele.each(function () {

            var eventObject = {
                title: $.trim($(this).text())
            }

            $(this).data('eventObject', eventObject)

            $(this).draggable({
                zIndex: 1070,
                revert: true, // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            })

        })
    }

    ini_events($('#external-events div.external-event'))

    var date = new Date()
    var d = date.getDate(),
        m = date.getMonth(),
        y = date.getFullYear()

    var Calendar = FullCalendar.Calendar;
    var Draggable = FullCalendar.Draggable;

    var containerEl = document.getElementById('external-events');
    var checkbox = document.getElementById('drop-remove');
    var calendarEl = document.getElementById('calendar');


    new Draggable(containerEl, {
        itemSelector: '.external-event',
        eventData: function (eventEl) {
            return {
                title: eventEl.innerText,
                backgroundColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                borderColor: window.getComputedStyle(eventEl, null).getPropertyValue('background-color'),
                textColor: window.getComputedStyle(eventEl, null).getPropertyValue('color'),
            };
        }
    });

    var calendar = new Calendar(calendarEl, {
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        lang: 'tr',
        themeSystem: 'bootstrap',
        events: [
        ],
        editable: true,
        droppable: true, // this allows things to be dropped onto the calendar !!!
        drop: function (info) {
            debugger;
            if (checkbox.checked) {
                info.draggedEl.parentNode.removeChild(info.draggedEl);
            }
        },
        eventDrop: function (info) {
            var dropDate = info.event.start;

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (dropDate < today) {
                Swal.fire({
                    icon: "error",
                    title: "Oops...",
                    text: "Bugünden Önceki Planlama Değiştirilemez!",
                    footer: '<a href="#">Why do I have this issue?</a>'
                });
                        info.revert();
            } else {
                var myModal = new bootstrap.Modal(document.getElementById('exampleModal'));

                var oldEvent;

                myModal._element.addEventListener('show.bs.modal', function () {
                    oldEvent = info;
                });

                // Modal kapatıldığında eski eventi geri yerine koy
                myModal._element.addEventListener('hidden.bs.modal', function () {
                    info = oldEvent;
                    info.revert();
                });

                myModal.show();
                $('.modal-footer .btn-primary').on('click', function () {
                    // Seçilen etkileme seçeneğini al
                    var selectedOption = $('input[name="etkiler"]:checked');

                    // Seçilen etkinliğin kimliğini al
                    var eventId = info.event._def.extendedProps.Id;
                    debugger;
                    // Seçim ve etkinlik kimliğini alert ile göster
                    if (selectedOption.length > 0 && eventId) {
                        var message = "Seçiminiz: " + selectedOption.next('label').text() + "\n" +
                            "Etkinlik ID: " + eventId + dropDate;

                        $.ajax({
                            url: '/Planing/RePlanProduct', // İstek gönderilecek URL
                            type: 'GET', // İstek türü
                            data: {
                                productId: eventId,
                                newDate: dropDate, // newDate değişkeni burada atanmalı
                                secim: "asd" // secim değişkeni burada atanmalı
                            },
                            success: function (response) {
                                // İstek başarılı olduğunda gelen cevaba göre işlem yap
                                if (response.success) {
                                    Swal.fire({
                                        position: "top-end",
                                        icon: "success",
                                        title: "İşlem Başarılı: " + response.message,
                                        showConfirmButton: false,
                                        timer: 1500
                                    });
                                } else {
                                    Swal.fire({
                                        position: "top-end",
                                        icon: "error",
                                        title: "Hata: " + response.message,
                                        showConfirmButton: true
                                    });
                                }
                            },
                            error: function (xhr, status, error) {
                                // İstek başarısız olduğunda burası çalışır
                                console.error('İstek hatası:', status, error);
                                Swal.fire({
                                    position: "top-end",
                                    icon: "error",
                                    title: "Bilinmeyen bir hata oluştu",
                                    showConfirmButton: true
                                });
                            }
                        });
                    } else {
                        alert("Lütfen seçim yapınız.");
                    }
                });
            }
        }

    });


    $("#btnGetDailyPlan").click(function () {
        var patternId = $("#patternId").val(); // Seçilen desenin değerini al
        $.ajax({
            url: '/Planing/ProductPlanJson?patternId=' + patternId, // Günlük planları alacak olan API endpointiniz
            type: 'GET',
            success: function (data) {
                calendar.removeAllEvents(); // Tüm etkinlikleri temizler

                // Başarılı olduğunda yapılacak işlemler
                console.log(data); // Gelen veriyi konsola yazdırabilirsiniz
                // Burada gelen veriyi takvime eklemek için uygun işlemleri yapmalısınız
                debugger;
                var colorMap = {};
                data.DailyPlans.forEach(function (event) {
                    debugger;
                    var color = colorMap[event.ProductPlanDailyPlannedId];
                    var manifact = data.Manifacts.find(x => x.ProductPlanProductPlannedId == event.Id);
                    if (!manifact) {
                        calendar.addEvent({
                            title: event.Name,
                            start: event.StartTime,
                            Id: event.Id,
                            allDay: true,
                            backgroundColor: '#000000',
                            borderColor: '#000000',
                            url: "/Planing/OpenManifact/" + event.Id
                        });
                        return;
                    }
                    var demir = manifact.ProductManifactDetail.find(x => x.ProjectElementStep.LastStep == true);
                    var color;
                    debugger;
                    if (!manifact || !demir) {
                        color = '#000000'; // Siyah renk
                    } 
                   else  if (manifact && manifact.Uretildi === true) {
                        color = '#00FF00'; // Yeşil renk
                    }

                    else if (manifact && demir.ProductStepEnum == 3) {
                        color = 'blue';
                    }
                    else {
                        color = '#FF0000'; // Kırmızı renk
                    }

                    calendar.addEvent({
                        title: event.Name,
                        start: event.StartTime,
                        Id: event.Id,
                        allDay: true,
                        backgroundColor: color,
                        borderColor: color,
                        url: "/Planing/OpenManifact/" + event.Id
                    });
                });
                calendar.render();
            },
            error: function (xhr, status, error) {
                // Hata durumunda yapılacak işlemler
                console.error(error); // Hata mesajını konsola yazdırabilirsiniz
            }
        });
    });

    calendar.render();
    var currColor = '#3c8dbc' 
    $('#color-chooser > li > a').click(function (e) {
        e.preventDefault()
        // Save color
        currColor = $(this).css('color')
        $('#add-new-event').css({
            'background-color': currColor,
            'border-color': currColor
        })
    })
    $('#add-new-event').click(function (e) {
        e.preventDefault()
        var val = $('#new-event').val()
        if (val.length == 0) {
            return
        }

        // Create events
        var event = $('<div />')
        event.css({
            'background-color': currColor,
            'border-color': currColor,
            'color': '#fff'
        }).addClass('external-event')
        event.text(val)
        $('#external-events').prepend(event)

        ini_events(event)

        $('#new-event').val('')
    })
})
