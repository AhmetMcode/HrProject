/**
* Template Name: NiceAdmin
* Updated: Sep 18 2023 with Bootstrap v5.3.2
* Template URL: https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/
$(document).ready(function () {
    updateNotificationCount();
    getMyLast4Notifications();
});

function updateNotificationCount() {
    $.ajax({
        url: '/Notification/GetMyNotReadNotificationCount', // ControllerName, kontrolc�n�z�n ad�n� temsil etmelidir
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            // AJAX iste�i ba�ar�l�ysa, gelen say�y� HTML i�ine yerle�tir
            $('#notification-count').text(data);
            $('#youHaveNot').text("Okunmayan " + data + " bildiriminiz bulunmakta");
        },
        error: function () {
            // Hata durumunda buraya gerekli i�lemleri ekleyebilirsiniz
            console.error('Bildirim say�s� al�namad�.');
        }
    });
}
function getMyLast4Notifications() {
    $.ajax({
        url: '/Notification/GetMyLast4Notif',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            // AJAX iste�i ba�ar�l�ysa, bildirimleri listeleyen fonksiyonu �a��r
            displayNotifications(data);
        },
        error: function () {
            // Hata durumunda buraya gerekli i�lemleri ekleyebilirsiniz
            console.error('Bildirimler al�namad�.');
        }
    });
}

function displayNotifications(notifications) {
    var $notificationList = $('#notLu');
    $.each(notifications, function (index, notification) {
        // Yeni bir li eleman� olu�tur
        var $newNotification = $('<li b-w8a3doqtyq class="notification-item"></li>');

        // li eleman�n�n i�eri�ini doldur
        $newNotification.append(
            '<i class="bi bi-exclamation-circle text-primary"></i>' +
            '<div class="notification-content">' +
            '<h4>' + notification.Notification.Title + '</h4>' +
            '<p>' + notification.Notification.Content + '</p>' +
            '<p>' + formatNotificationDate(notification.Notification.NotificationDate) + '</p>' +
            '</div>'
        );

        // Olu�turulan li eleman�n� listeye ekle
        $notificationList.append($newNotification);
        $notificationList.append('<li><hr class= "dropdown-divider" ></li > ');
    });
}
function formatNotificationDate(notificationDate) {
    var now = new Date();
    var notificationDateTime = new Date(notificationDate);

    var diffInMilliseconds = now - notificationDateTime;
    var diffInSeconds = Math.floor(diffInMilliseconds / 1000);
    var diffInMinutes = Math.floor(diffInSeconds / 60);
    var diffInHours = Math.floor(diffInMinutes / 60);
    var diffInDays = Math.floor(diffInHours / 24);

    if (diffInMinutes < 60) {
        return diffInMinutes + ' dakika once';
    } else if (diffInHours < 24) {
        return diffInHours + ' saat once';
    } else {
        // Daha fazla g�n varsa orijinal tarihi g�ster
        return notificationDateTime.toLocaleDateString() + ' ' + notificationDateTime.toLocaleTimeString();
    }
}
$(document).ready(function () {
    // Target the notification bell icon
    var notificationIcon = $("#notification");

    // Target the notification dropdown menu
    var notificationDropdown = $(".notifications");

    // Add a click event to the notification bell icon
    notificationIcon.click(function (e) {
        // Prevent the default behavior of the link
        e.preventDefault();

        // Toggle the visibility of the notification dropdown
        notificationDropdown.toggleClass("show");

        // You may need additional logic to handle cases such as clicking outside the dropdown to close it
    });
});
(function () {
    "use strict";

    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        if (all) {
            select(el, all).forEach(e => e.addEventListener(type, listener))
        } else {
            select(el, all).addEventListener(type, listener)
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
     * Sidebar toggle
     */
    // Check if the toggle-sidebar-btn element exists


    // Handle sidebar toggle
    $(document).ready(function () {
        // Add click event listener to the toggle-sidebar-btn elements
        $(document).on('click', '.toggle-sidebar-btn', function () {
            // Toggle the 'toggle-sidebar' class on the body element
            $('body').toggleClass('toggle-sidebar');
        });
    });

    $(document).ready(function () {
        if ($(window).width() < 700) {
            $("body").removeClass("toggle-sidebar");
        }
    });



    $(document).on('click', '.nav-link.collapsed', function (e) {
        e.preventDefault();

        // Get the submenu related to the clicked item
        var submenu = $(this).next('.nav-content');

        // If this submenu is currently open, close it
        if (submenu.hasClass('show')) {
            submenu.slideUp(200).removeClass('show');
            $(this).addClass('collapsed');
        } else {
            // Otherwise, close all other open submenus
            $('.nav-content.show').slideUp(200).removeClass('show');
            $('.nav-link').addClass('collapsed');

            // Open the clicked submenu
            submenu.slideDown(200).addClass('show');
            $(this).removeClass('collapsed');
        }
    });


    /**
     * Search bar toggle
     */
    if (select('.search-bar-toggle')) {
        on('click', '.search-bar-toggle', function (e) {
            select('.search-bar').classList.toggle('search-bar-show')
        })
    }

    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    /**
     * Toggle .header-scrolled class to #header when page is scrolled
     */
    let selectHeader = select('#header')
    if (selectHeader) {
        const headerScrolled = () => {
            if (window.scrollY > 100) {
                selectHeader.classList.add('header-scrolled')
            } else {
                selectHeader.classList.remove('header-scrolled')
            }
        }
        window.addEventListener('load', headerScrolled)
        onscroll(document, headerScrolled)
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Initiate tooltips
     */
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

    /**
     * Initiate quill editors
     */
    if (select('.quill-editor-default')) {
        new Quill('.quill-editor-default', {
            theme: 'snow'
        });
    }

    if (select('.quill-editor-bubble')) {
        new Quill('.quill-editor-bubble', {
            theme: 'bubble'
        });
    }

    if (select('.quill-editor-full')) {
        new Quill(".quill-editor-full", {
            modules: {
                toolbar: [
                    [{
                        font: []
                    }, {
                        size: []
                    }],
                    ["bold", "italic", "underline", "strike"],
                    [{
                        color: []
                    },
                    {
                        background: []
                    }
                    ],
                    [{
                        script: "super"
                    },
                    {
                        script: "sub"
                    }
                    ],
                    [{
                        list: "ordered"
                    },
                    {
                        list: "bullet"
                    },
                    {
                        indent: "-1"
                    },
                    {
                        indent: "+1"
                    }
                    ],
                    ["direction", {
                        align: []
                    }],
                    ["link", "image", "video"],
                    ["clean"]
                ]
            },
            theme: "snow"
        });
    }

    /**
     * Initiate TinyMCE Editor
     */
    const useDarkMode = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const isSmallScreen = window.matchMedia('(max-width: 1023.5px)').matches;

    tinymce.init({
        selector: 'textarea.tinymce-editor',
        plugins: 'preview importcss searchreplace autolink autosave save directionality code visualblocks visualchars fullscreen image link media template codesample table charmap pagebreak nonbreaking anchor insertdatetime advlist lists wordcount help charmap quickbars emoticons',
        editimage_cors_hosts: ['picsum.photos'],
        menubar: 'file edit view insert format tools table help',
        toolbar: 'undo redo | bold italic underline strikethrough | fontfamily fontsize blocks | alignleft aligncenter alignright alignjustify | outdent indent |  numlist bullist | forecolor backcolor removeformat | pagebreak | charmap emoticons | fullscreen  preview save print | insertfile image media template link anchor codesample | ltr rtl',
        toolbar_sticky: true,
        toolbar_sticky_offset: isSmallScreen ? 102 : 108,
        autosave_ask_before_unload: true,
        autosave_interval: '30s',
        autosave_prefix: '{path}{query}-{id}-',
        autosave_restore_when_empty: false,
        autosave_retention: '2m',
        image_advtab: true,
        link_list: [{
            title: 'My page 1',
            value: 'https://www.tiny.cloud'
        },
        {
            title: 'My page 2',
            value: 'http://www.moxiecode.com'
        }
        ],
        image_list: [{
            title: 'My page 1',
            value: 'https://www.tiny.cloud'
        },
        {
            title: 'My page 2',
            value: 'http://www.moxiecode.com'
        }
        ],
        image_class_list: [{
            title: 'None',
            value: ''
        },
        {
            title: 'Some class',
            value: 'class-name'
        }
        ],
        importcss_append: true,
        file_picker_callback: (callback, value, meta) => {
            /* Provide file and text for the link dialog */
            if (meta.filetype === 'file') {
                callback('https://www.google.com/logos/google.jpg', {
                    text: 'My text'
                });
            }

            /* Provide image and alt text for the image dialog */
            if (meta.filetype === 'image') {
                callback('https://www.google.com/logos/google.jpg', {
                    alt: 'My alt text'
                });
            }

            /* Provide alternative source and posted for the media dialog */
            if (meta.filetype === 'media') {
                callback('movie.mp4', {
                    source2: 'alt.ogg',
                    poster: 'https://www.google.com/logos/google.jpg'
                });
            }
        },
        templates: [{
            title: 'New Table',
            description: 'creates a new table',
            content: '<div class="mceTmpl"><table width="98%%"  border="0" cellspacing="0" cellpadding="0"><tr><th scope="col"> </th><th scope="col"> </th></tr><tr><td> </td><td> </td></tr></table></div>'
        },
        {
            title: 'Starting my story',
            description: 'A cure for writers block',
            content: 'Once upon a time...'
        },
        {
            title: 'New list with dates',
            description: 'New List with dates',
            content: '<div class="mceTmpl"><span class="cdate">cdate</span><br><span class="mdate">mdate</span><h2>My List</h2><ul><li></li><li></li></ul></div>'
        }
        ],
        template_cdate_format: '[Date Created (CDATE): %m/%d/%Y : %H:%M:%S]',
        template_mdate_format: '[Date Modified (MDATE): %m/%d/%Y : %H:%M:%S]',
        height: 600,
        image_caption: true,
        quickbars_selection_toolbar: 'bold italic | quicklink h2 h3 blockquote quickimage quicktable',
        noneditable_class: 'mceNonEditable',
        toolbar_mode: 'sliding',
        contextmenu: 'link image table',
        skin: useDarkMode ? 'oxide-dark' : 'oxide',
        content_css: useDarkMode ? 'dark' : 'default',
        content_style: 'body { font-family:Helvetica,Arial,sans-serif; font-size:16px }'
    });

    /**
     * Initiate Bootstrap validation check
     */
    var needsValidation = document.querySelectorAll('.needs-validation')

    Array.prototype.slice.call(needsValidation)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })

    /**
     * Initiate Datatables
     */
    const datatables = select('.datatable', true)
    datatables.forEach(datatable => {
        new simpleDatatables.DataTable(datatable);
    })

    /**
     * Autoresize echart charts
     */
    const mainContainer = select('#main');
    if (mainContainer) {
        setTimeout(() => {
            new ResizeObserver(function () {
                select('.echart', true).forEach(getEchart => {
                    echarts.getInstanceByDom(getEchart).resize();
                })
            }).observe(mainContainer);
        }, 200);
    }

})();