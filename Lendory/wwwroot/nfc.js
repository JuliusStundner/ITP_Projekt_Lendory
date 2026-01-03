window.openNfcToolsApp = function (itemUrl) {
    alert(
        "NFC Tools wird geöffnet.\n\n" +
        "In NFC Tools:\n" +
        "• Write auswählen\n" +
        "• URL einfügen:\n\n" +
        itemUrl
    );

    window.location.href =
        "intent://#Intent;package=com.wakdev.wdnfc;end";
};
