const CACHE_NAME = "lendory-cache-v1";
const OFFLINE_URL = "/";

self.addEventListener("install", event => {
    event.waitUntil(
        caches.open(CACHE_NAME).then(cache =>
            cache.addAll([
                "/",
                "/index.html"
            ])
        )
    );
});

self.addEventListener("fetch", event => {
    event.respondWith(
        caches.match(event.request).then(response =>
            response || fetch(event.request)
        )
    );
});
