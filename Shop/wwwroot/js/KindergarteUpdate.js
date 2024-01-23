var cUpdate = document.getElementById("myCanvasUpdate");
var ctxUpdate = cUpdate.getContext("2d");
var maskUpdate;

var pointCount = 500;
var str = "Update";
var fontStr = "bold 128pt Helvetica Neue, Helvetica, Arial, sans-serif";

ctxUpdate.font = fontStr;
ctxUpdate.textAlign = "center";
cUpdate.width = ctxUpdate.measureText(str).width;
cUpdate.height = 128; // Set to font size

var whitePixels = [];
var points = [];
var point = function (x, y, vx, vy) {
    this.x = x;
    this.y = y;
    this.vx = vx || 1;
    this.vy = vy || 1;
}
point.prototype.update = function () {
    ctxUpdate.beginPath();
    ctxUpdate.fillStyle = "white";
    ctxUpdate.arc(this.x, this.y, 1, 0, 2 * Math.PI);
    ctxUpdate.fill();
    ctxUpdate.closePath();

    // Change direction if running into black pixel
    if (this.x + this.vx >= cUpdate.width || this.x + this.vx < 0 || maskUpdate.data[coordsToI(this.x + this.vx, this.y, maskUpdate.width)] != 255) {
        this.vx *= -1;
        this.x += this.vx * 2;
    }
    if (this.y + this.vy >= cUpdate.height || this.y + this.vy < 0 || maskUpdate.data[coordsToI(this.x, this.y + this.vy, maskUpdate.width)] != 255) {
        this.vy *= -1;
        this.y += this.vy * 2;
    }

    for (var k = 0, m = points.length; k < m; k++) {
        if (points[k] === this) continue;

        var d = Math.sqrt(Math.pow(this.x - points[k].x, 2) + Math.pow(this.y - points[k].y, 2));
        if (d < 5) {
            ctxUpdate.lineWidth = .2;
            ctxUpdate.beginPath();
            ctxUpdate.moveTo(this.x, this.y);
            ctxUpdate.lineTo(points[k].x, points[k].y);
            ctxUpdate.stroke();
        }
        if (d < 20) {
            ctxUpdate.lineWidth = .1;
            ctxUpdate.beginPath();
            ctxUpdate.moveTo(this.x, this.y);
            ctxUpdate.lineTo(points[k].x, points[k].y);
            ctxUpdate.stroke();
        }
    }

    this.x += this.vx;
    this.y += this.vy;
}

function loop() {
    ctxUpdate.clearRect(0, 0, cUpdate.width, cUpdate.height);
    for (var k = 0, m = points.length; k < m; k++) {
        points[k].update();
    }
}

function init() {
    // Draw text
    ctxUpdate.beginPath();
    ctxUpdate.fillStyle = "none";
    ctxUpdate.rect(0, 0, cUpdate.width, cUpdate.height);
    ctxUpdate.fill();
    ctxUpdate.font = fontStr;
    ctxUpdate.textAlign = "left";
    ctxUpdate.fillStyle = "#fff";
    ctxUpdate.fillText(str, 0, cUpdate.height / 2 + (cUpdate.height / 2));
    ctxUpdate.closePath();

    // Save mask
    maskUpdate = ctxUpdate.getImageData(0, 0, cUpdate.width, cUpdate.height);

    // Draw background
    ctxUpdate.clearRect(0, 0, cUpdate.width, cUpdate.height);

    // Save all white pixels in an array
    for (var i = 0; i < maskUpdate.data.length; i += 4) {
        if (maskUpdate.data[i] == 255 && maskUpdate.data[i + 1] == 255 && maskUpdate.data[i + 2] == 255 && maskUpdate.data[i + 3] == 255) {
            whitePixels.push([iToX(i, maskUpdate.width), iToY(i, maskUpdate.width)]);
        }
    }

    for (var k = 0; k < pointCount; k++) {
        addPoint();
    }
}

function addPoint() {
    var spawn = whitePixels[Math.floor(Math.random() * whitePixels.length)];

    var p = new point(spawn[0], spawn[1], Math.floor(Math.random() * 2 - 1), Math.floor(Math.random() * 2 - 1));
    points.push(p);
}

function iToX(i, w) {
    return ((i % (4 * w)) / 4);
}
function iToY(i, w) {
    return (Math.floor(i / (4 * w)));
}
function coordsToI(x, y, w) {
    return ((maskUpdate.width * y) + x) * 4;

}

setInterval(loop, 50);
init();