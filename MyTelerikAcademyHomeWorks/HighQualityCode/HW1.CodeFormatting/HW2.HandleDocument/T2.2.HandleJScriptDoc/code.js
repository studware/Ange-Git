var navigatorName = navigator.appName;
var addScroll = false;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
        (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}
var mouseX = 0;
var mouseY = 0;
var theLayer;

document.onmousemove = mouseMove;
if (navigatorName === 'Netscape') {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(netScapeEvent) {
    if (navigatorName === 'Netscape') {
        mouseX = netScapeEvent.pageX - 5;
        mouseY = netScapeEvent.pageY;
    } else {
        mouseX = event.x - 5;
        mouseY = event.y;
    }

    if (navigatorName === 'Netscape') {
        if (document.layers.ToolTip.visibility === 'show') {
            popTip();
        }
    } else {
        if (document.all.ToolTip.style.visibility === 'visible') {
            popTip();
        }
    }
}

function popTip() {
    if (navigatorName === 'Netscape') {
        theLayer = document.layers.ToolTip;
        if ((mouseX + 120) > window.innerWidth) {
            mouseX = window.innerWidth - 150;
        }
        theLayer.left = mouseX + 10;
        theLayer.top = mouseY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.ToolTip;
        if (theLayer) {
            mouseX = event.x - 5;
            mouseY = event.y;
            if (addScroll) {
                mouseX = mouseX + document.body.scrollLeft;
                mouseY = mouseY + document.body.scrollTop;
            }
            if ((mouseX + 120) > document.body.clientWidth) {
                mouseX = mouseX - 150;
            }
            theLayer.style.pixelLeft = mouseX + 10;
            theLayer.style.pixelTop = mouseY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function hideTip() {
    if (navigatorName === 'Netscape') {
        document.layers.ToolTip.visibility = 'hide';
    } else {
        document.all.ToolTip.style.visibility = 'hidden';
    }
}

function hideMenu1() {
    if (navigatorName === 'Netscape') {
        document.layers.menu1.visibility = 'hide';
    } else {
        document.all.menu1.style.visibility = 'hidden';
    }
}

function showMenu1() {
    if (navigatorName === 'Netscape') {
        theLayer = document.layers.menu1;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu1;
        theLayer.style.visibility = 'visible';
    }
}

function hideMenu2() {
    if (navigatorName === 'Netscape') {
        document.layers.menu2.visibility = 'hide';
    } else {
        document.all.menu2.style.visibility = 'hidden';
    }
}

function showMenu2() {
    if (navigatorName === 'Netscape') {
        theLayer = document.layers.menu2;
        theLayer.visibility = 'show';
    } else {
        theLayer = document.all.menu2;
        theLayer.style.visibility = 'visible';
    }
}