var connection = new signalR.HubConnectionBuilder().withUrl("/Messagehub").build();
connection.on("sendToUser", (title, message) => {
    var heading = document.createElement("h3");
    heading.textContent = title;
    var p = document.createElement("p");
    p.innerText = message;

    var div = document.createElement("div");
    div.appendChild(heading);
    div.appendChild(p);

    document.getElementById("messageList").appendChild(div);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});