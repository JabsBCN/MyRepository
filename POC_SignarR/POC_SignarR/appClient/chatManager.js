function ChatManager(input, button, container) {

    var connection = $.hubConnection();
    var myHomeHubProxy = connection.createHubProxy("myHomeHub");

    myHomeHubProxy.on('onUserNameConnect', function (userName) {
        container.append(jQuery("<div class='user-connected'></div>").html(userName + ' se conecta'));
    });

    myHomeHubProxy.on('onMessageReceived', function (message, userName) {
        container.append(jQuery("<div class='user-message'></div>").html(userName + ':<span>' + message + '</span>'));
    });

    var userName = prompt("tu nombre", "nombre aquí....");

    connection.start().done(function () {

        myHomeHubProxy.invoke("SendUserNameConnectToClients", userName);

        button.click(function () {

            var message = input.val();
            myHomeHubProxy.invoke("SendMessageToClients", message, userName);

            input.val("");
            input.focus();

        });

    });

    this.connection = connection;
    this.hub = myHomeHubProxy;
    this.userName = userName;
}