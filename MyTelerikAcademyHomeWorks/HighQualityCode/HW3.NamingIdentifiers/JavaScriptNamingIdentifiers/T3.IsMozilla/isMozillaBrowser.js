function isMozillaBrowser() {
    var currentWindow = window,
        theBrowser = currentWindow.navigator.appCodeName,
        isMozilla = theBrowser === "Mozilla";

    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
