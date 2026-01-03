let deferredPrompt = null;

window.addEventListener("beforeinstallprompt", (e) => {
    e.preventDefault();
    deferredPrompt = e;
});

window.installPwa = async () => {
    if (!deferredPrompt) {
        alert("Installation aktuell nicht verfügbar");
        return;
    }
    deferredPrompt.prompt();
    await deferredPrompt.userChoice;
    deferredPrompt = null;
};
