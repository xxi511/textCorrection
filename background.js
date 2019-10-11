// When the extension is installed or upgraded ...
chrome.runtime.onInstalled.addListener(removeOldRule);

function removeOldRule() {
    chrome.declarativeContent.onPageChanged.removeRules(undefined, setNewRule);
}

function setNewRule() {
    // With a new rule ...
    chrome.declarativeContent.onPageChanged.addRules([
        {
            // That fires when a page's URL contains a 'g' ...
            conditions: [
                new chrome.declarativeContent.PageStateMatcher({
                    pageUrl: {
                        hostEquals: "woodo.epizy.com",
                        urlContains: "action",
                    },
                }),
            ],
            // And shows the extension's page action.
            actions: [new chrome.declarativeContent.ShowPageAction()],
        },
    ]);
}

// Called when the user clicks on the page action.
chrome.pageAction.onClicked.addListener(function(tab) {
    chrome.tabs.executeScript({
        file: "execute.js",
    });
});
