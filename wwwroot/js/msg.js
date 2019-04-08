"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/WebJackpot/MessageHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

function UpdateJackpot(obj) {
    $("#jpTable").find("tr:gt(0)").remove();
    $.each(obj,
        function (key, value) {
            var markup = "<tr><td>" + value.JackpotID + "</td><td>" + value.Name + "</td><td>" + value.CurrentWin + "</td><td>" + value.CurrentTime + "</td></tr>";
            $("#jpTable").append(markup);
        });
}

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    UpdateJackpot($.parseJSON(msg));
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = "PlayGame";
    connection.invoke("PlayGame", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});