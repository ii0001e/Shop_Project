// Use different canvas element and variable names for the second animation
var cCreate = document.getElementById("myCanvasCreate");
var ctxCreate = cCreate.getContext("2d");
var maskCreate;

var pointCount = 500;
var str = "Create";
var fontStr = "bold 128pt Helvetica Neue, Helvetica, Arial, sans-serif";

ctxCreate.font = fontStr;
ctxCreate.textAlign = "center";
cCreate.width = ctxCreate.measureText(str).width;
cCreate.height = 128; // Set to font size

var whitePixels = [];
var points = [];

// Use different function names for the second animation
var pointCreate = function (x, y, vx, vy) {
    this.x = x;
    this.y = y;
    this.vx = vx || 1;
    this.vy = vy || 1;
}
pointCreate.prototype.update = function () {
    ctxCreate.beginPath();
    ctxCreate.fillStyle = "white";
    ctxCreate.arc(this.x, this.y, 1, 0, 2 * Math.PI);
    ctxCreate.fill();
    ctxCreate.closePath();

    // Change direction if running into black pixel
    if (this.x + this.vx >= cCreate.width || this.x + this.vx < 0 || maskCreate.data[coordsToI(this.x + this.vx, this.y, maskCreate.width)] != 255) {
        this.vx *= -1;
        this.x += this.vx * 2;
    }
    if (this.y + this.vy >= cCreate.height || this.y + this.vy < 0 || maskCreate.data[coordsToI(this.x, this.y + this.vy, maskCreate.width)] != 255) {
        this.vy *= -1;
        this.y += this.vy * 2;
    }

    for (var k = 0, m = points.length; k < m; k++) {
        if (points[k] === this) continue;

        var d = Math.sqrt(Math.pow(this.x - points[k].x, 2) + Math.pow(this.y - points[k].y, 2));
        if (d < 5) {
            ctxCreate.lineWidth = .2;
            ctxCreate.beginPath();
            ctxCreate.moveTo(this.x, this.y);
            ctxCreate.lineTo(points[k].x, points[k].y);
            ctxCreate.stroke();
        }
        if (d < 20) {
            ctxCreate.lineWidth = .1;
            ctxCreate.beginPath();
            ctxCreate.moveTo(this.x, this.y);
            ctxCreate.lineTo(points[k].x, points[k].y);
            ctxCreate.stroke();
        }
    }

    this.x += this.vx;
    this.y += this.vy;
}

function loopCreate() {
    ctxCreate.clearRect(0, 0, cCreate.width, cCreate.height);
    for (var k = 0, m = points.length; k < m; k++) {
        points[k].update();
    }
}

function initCreate() {
    // Draw text
    ctxCreate.beginPath();
    ctxCreate.fillStyle = "none";
    ctxCreate.rect(0, 0, cCreate.width, cCreate.height);
    ctxCreate.fill();
    ctxCreate.font = fontStr;
    ctxCreate.textAlign = "left";
    ctxCreate.fillStyle = "#fff";
    ctxCreate.fillText(str, 0, cCreate.height / 2 + (cCreate.height / 2));
    ctxCreate.closePath();

    // Save mask
    maskCreate = ctxCreate.getImageData(0, 0, cCreate.width, cCreate.height);

    // Draw background
    ctxCreate.clearRect(0, 0, cCreate.width, cCreate.height);

    // Save all white pixels in an array
    for (var i = 0; i < maskCreate.data.length; i += 4) {
        if (maskCreate.data[i] == 255 && maskCreate.data[i + 1] == 255 && maskCreate.data[i + 2] == 255 && maskCreate.data[i + 3] == 255) {
            whitePixels.push([iToX(i, maskCreate.width), iToY(i, maskCreate.width)]);
        }
    }

    for (var k = 0; k < pointCount; k++) {
        addPointCreate();
    }
}

function addPointCreate() {
    var spawn = whitePixels[Math.floor(Math.random() * whitePixels.length)];

    var p = new pointCreate(spawn[0], spawn[1], Math.floor(Math.random() * 2 - 1), Math.floor(Math.random() * 2 - 1));
    points.push(p);
}

function iToX(i, w) {
    return ((i % (4 * w)) / 4);
}
function iToY(i, w) {
    return (Math.floor(i / (4 * w)));
}
function coordsToI(x, y, w) {
    return ((maskCreate.width * y) + x) * 4;

}

setInterval(loopCreate, 50);
initCreate();