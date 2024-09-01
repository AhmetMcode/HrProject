$(document).ready(function () {
    console.log("Ben de�i�keni:", ben); // De�i�keni kontrol et

    function getUserStatus(user) {
        // Bu fonksiyon �rnekte sabit veri d�nd�r�r, ger�ekte kullan�c�n�n durumu kontrol edilmelidir
        return  "online" ;
    }

    $.ajax({
        url: '/Message/AllUsersJson', // Endpoint'in do�ru yolunu buraya yaz�n
        type: 'GET',
        success: function (data) {
            var userList = $("#user-list");
            userList.empty(); // �nceki veriyi temizle
            data.forEach(function (user) {
                var statusClass = getUserStatus(user) === "online" ? "online" : "offline";

                var userItem = `
                        <li class="clearfix user-item" data-user-id="${user.Id}" style="border: 1px solid #ccc; padding: 10px; margin-bottom: 5px; border-radius: 5px;">
                            <img style="width:55px;height:55px;border-radius:50%;" src="https://erpelfbeton.com.tr/ProfilPhoto/${user.ProfilPhoto}" alt="avatar" />
                            <div class="about">
                                <div class="name">${user.Name}  ${user.SurName}</div>
                                <div class="status">
                                    <i class="fa fa-circle ${statusClass}"></i> 
                                </div>
                            </div>
                        </li>
                    `;
                userList.append(userItem);
            });

            // Kullan�c� ��elerine t�klama olay�n� ekleyin
            $(".user-item").click(function () {
                $(".user-item").removeClass("selected");
                $(this).addClass("selected");
                selectedUserId = $(this).data("user-id");

                // Son 10 mesaj� almak i�in AJAX iste�i g�nder
                loadLastTenMessages(selectedUserId);
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
    function loadLastTenMessages(alanId) {
        $.ajax({
            url: '/Message/SonOnMesajGetir', // Endpoint'in do�ru yolunu buraya yaz�n
            type: 'GET',
            data: { AlanId: alanId },
            success: function (response) {
                var chatHistory = $(".chat-history ul");
                chatHistory.empty(); // �nceki mesajlar� temizle
                if (response.User) {
                    $("#username").text("" + response.User.Name + " " + response.User.SurName);
                    $(".chat-header img").attr("src", "https://erpelfbeton.com.tr/ProfilPhoto/" + response.User.ProfilePictureUrl);
                    $(".chat-num-messages").text(response.Messages.length + " mesaj");
                }
                
                response.Messages.forEach(function (message) {
                    debugger;
                    if (message.GonderenId == ben) {
                        var messageItem = `
                    <li class="clearfix">
                        <div class="message-data">
                            <span class="message-data-name">${benNesne.Name}</span>
                            <span class="message-data-time">${new Date(message.GonderilmeZamani).toLocaleString()}</span>
                        </div>
                        <div class="message my-message  other-message float-right">${message.Mesaj}</div>
                    </li> `;
                        chatHistory.append(messageItem);

                    }
                    else {
                        var messageItem = `
                    <li class="clearfix">
                        <div class="message-data">
                            <span class="message-data-name">${response.User.Name}</span>
                            <span class="message-data-time">${new Date(message.GonderilmeZamani).toLocaleString()}</span>
                        </div>
                        <div class="message my-message">${message.Mesaj}</div>
                    </li> `;
                        chatHistory.append(messageItem);

                    }
                    
                });
            },
            error: function (error) {
                console.log("Error loading messages:", error);
            }
        });
    }
    $("#send-button").click(function () {
        var mesajIcerik = $("#message-to-send").val();
        if (mesajIcerik.trim() === "") {
            alert("Mesaj bo� olamaz.");
            return;
        }

        $.ajax({
            url: '/Message/SendMessage',
            type: 'POST',
            data: {
                gonderilcekUserId: selectedUserId,
                mesajIcerik: mesajIcerik
            },
            success: function (response) {
                if (response === "Tamam") {
                    $("#message-to-send").val(""); // Mesaj kutusunu temizle
                    loadLastTenMessages(selectedUserId); // Son 10 mesaj� tekrar y�kle
                } else {
                    alert("Mesaj g�nderme ba�ar�s�z.");
                }
            },
            error: function (error) {
                console.log("Error sending message:", error);
            }
        });
    });
});