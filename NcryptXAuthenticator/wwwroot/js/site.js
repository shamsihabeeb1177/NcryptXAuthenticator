// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function unhide() {
    document.getElementById('server').readOnly = false;
    document.getElementById('port').readOnly = false;
    document.getElementById('bind').readOnly = false;
    document.getElementById('binduser').readOnly = false;
    document.getElementById('bindpass').readOnly = false;
    document.getElementById('xmlbox').readOnly = false;
    document.getElementById('JSONbox').readOnly = false;
    document.getElementById('textbox').readOnly = false;
}

setTimeout(() => {
    const box = document.getElementById('box');

    // 👇️ removes element from DOM
    box.style.display = 'none';

    // 👇️ hides element (still takes up space on page)
    // box.style.visibility = 'hidden';
}, 3000);

function howform() {
    document.getElementById('smsformtarget').readOnly = false;
    document.getElementById('smsformport').readOnly = false;
    document.getElementById('smsformheader').readOnly = false;
    document.getElementById('smsformbody').readOnly = false;
    
}

function howform1() {
    document.getElementById('radname').readOnly = false;
    document.getElementById('radport').readOnly = false;
    document.getElementById('radsecret').readOnly = false;

}