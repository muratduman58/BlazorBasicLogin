function SweetError(baslik, govde, html) {
    Swal.fire({
        icon: 'error',
        title: baslik,
        text: govde,
        html: html,
        allowOutsideClick: false,
        confirmButtonText: "Tamam",
        /* customClass: "SweetCustom"*/
        customClass: {
            container: 'custom-sweetalert-container',
            title: 'custom-sweetalert-title',
            content: 'custom-sweetalert-content',
            confirmButton: 'custom-sweetalert-button confirm',
            cancelButton: 'custom-sweetalert-button cancel'
        }

    })
}
function SweetInfo(baslik, govde) {
    Swal.fire({
        icon: 'info',
        title: baslik,
        text: govde,
        allowOutsideClick: false,
        confirmButtonText: "Tamam",
        /* customClass: "SweetCustom"*/
        customClass: {
            container: 'custom-sweetalert-container',
            title: 'custom-sweetalert-title',
            content: 'custom-sweetalert-content',
            confirmButton: 'custom-sweetalert-button confirm',
            cancelButton: 'custom-sweetalert-button cancel'
        }

    })
}
function SweetSucces(baslik, govde) {
    Swal.fire({
        icon: 'success',
        title: baslik,
        text: govde,
        allowOutsideClick: false,
        confirmButtonText: "Tamam",
        /* customClass: "SweetCustom"*/
        customClass: {
            container: 'custom-sweetalert-container',
            title: 'custom-sweetalert-title',
            content: 'custom-sweetalert-content',
            confirmButton: 'custom-sweetalert-button confirm',
            cancelButton: 'custom-sweetalert-button cancel'
        }

    })
}

