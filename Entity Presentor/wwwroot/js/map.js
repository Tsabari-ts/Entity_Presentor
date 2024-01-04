"use strict";

var connection = new window.signalR.HubConnectionBuilder().withUrl("/myHub").build();

connection.on("broadcastMessage", function (newCoordinates) {
    const mapContainer = document.getElementById('map-container');
    const mapImage = document.getElementById('map');

    let name = newCoordinates.name;
    let longitude = newCoordinates.longitude;
    let latitude = newCoordinates.latitude;

    const maxX = mapImage.width;
    const maxY = mapImage.height;

    const convertedX = (longitude + 180) * (maxX / 360);
    const convertedY = (90 - latitude) * (maxY / 180);

    const ellipse = document.createElement('div');
    ellipse.className = 'ellipse';

    ellipse.style.left = convertedX + 'px';
    ellipse.style.top = convertedY + 'px';

    const ellipseName = document.createElement('span');
    ellipseName.innerText = name;

    ellipse.appendChild(ellipseName);
    mapContainer.appendChild(ellipse);
});


connection.start().then(function () {
    // Connection successful
    console.log("Connected to SignalR hub");
}).catch(function (error) {
    console.error(error.toString());
});