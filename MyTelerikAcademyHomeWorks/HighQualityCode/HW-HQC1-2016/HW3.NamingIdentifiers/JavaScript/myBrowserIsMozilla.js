// open the index.html page to view the result

function onButtonClick(event, args) {
    var browser = window.navigator.userAgent;
    var couldBeMozilla = browser.includes("Mozilla");
    // Some browsers often use fake names, and could be revealed by thorough check :) 
    var isAnotherBrowser = browser.includes("AppleWebKit")||
        browser.includes("Chrome")||
        browser.includes("Safari");
    var isMozilla = couldBeMozilla&&!(isAnotherBrowser);
    
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}