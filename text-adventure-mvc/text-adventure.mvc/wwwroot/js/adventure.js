document.querySelector("form").addEventListener("submit", async function (e) {
    e.preventDefault();
    const command = document.querySelector("input[name='command']").value;
    const response = await fetch('/Adventure/ProcessCommand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
        body: new URLSearchParams({ command })
    });
    const html = await response.text();
    document.body.innerHTML = html;
});