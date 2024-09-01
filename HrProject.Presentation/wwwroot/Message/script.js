$(document).ready(function () {
    console.log("Ben deðiþkeni:", ben); // Deðiþkeni kontrol et

    function getUserStatus(user) {
        // Bu fonksiyon örnekte sabit veri döndürür, gerçekte kullanýcýnýn durumu kontrol edilmelidir
        return  "online" ;
    }

    $.ajax({
        url: '/Message/AllUsersJson', // Endpoint'in doðru yolunu buraya yazýn
        type: 'GET',
        success: function (data) {
            var userList = $("#user-list");
            userList.empty(); // Önceki veriyi temizle
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

            // Kullanýcý öðelerine týklama olayýný ekleyin
            $(".user-item").click(function () {
                $(".user-item").removeClass("selected");
                $(this).addClass("selected");
                selectedUserId = $(this).data("user-id");

                // Son 10 mesajý almak için AJAX isteði gönder
                loadLastTenMessages(selectedUserId);
            });
        },
        error: function (error) {
            console.log("Error:", error);
        }
    });
    function loadLastTenMessages(alanId) {
        $.ajax({
            url: '/Message/SonOnMesajGetir', // Endpoint'in doðru yolunu buraya yazýn
            type: 'GET',
            data: { AlanId: alanId },
            success: function (response) {
                var chatHistory = $(".chat-history ul");
                chatHistory.empty(); // Önceki mesajlarý temizle
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
            alert("Mesaj boþ olamaz.");
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
                    loadLastTenMessages(selectedUserId); // Son 10 mesajý tekrar yükle
                } else {
                    alert("Mesaj gönderme baþarýsýz.");
                }
            },
            error: function (error) {
                console.log("Error sending message:", error);
            }
        });
    });
});