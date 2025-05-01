function scrollToBottom() {
    window.scrollTo({ top: document.body.scrollHeight, behavior: 'smooth' });
}

function scrollToElement(id) {
    document.getElementById(id)?.scrollIntoView({ behavior: 'smooth' }); 
}