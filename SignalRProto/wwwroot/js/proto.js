﻿// The following sample code uses modern ECMAScript 6 features 
// that aren't supported in Internet Explorer 11.
// To convert the sample for environments that do not support ECMAScript 6, 
// such as Internet Explorer 11, use a transpiler such as 
// Babel at http://babeljs.io/. 
//
// See Es5-chat.js for a Babel transpiled version of the following code:

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/protohub")
    .build();

connection.on("Paused", (user, message) => {
    const encodedMsg = new Date() + " Pause received";
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("joinButton").addEventListener("click", event => {
    const testerId = document.getElementById("testerId").value;
    const sessionId = document.getElementById("sessionId").value;
    connection.invoke("JoinSession", testerId, sessionId).catch(err => console.error(err.toString()));
    event.preventDefault();
});

connection.start().catch(err => console.error(err.toString()));