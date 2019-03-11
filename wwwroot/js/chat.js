"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/WebJackpot/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    document.getElementById("jackpotWin").value = msg;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("playerName").value;
    var message = "PlayGame";
    connection.invoke("PlayGame", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});