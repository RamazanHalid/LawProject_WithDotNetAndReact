import Swal from 'sweetalert2';

export default class ToastService {
    AlertErrorMessage(message) {
        Swal.fire({
            text: message,
            target: '#custom-target',
            customClass: {
                container: 'position-absolute'
            },
            toast: true,
            position: 'bottom-right',
            title: 'Error!',
            icon: 'error',
            confirmButtonText: 'Close',
            hideOnOverlayClick: true,
            hideOnContentClick: true
        })
    }

    AlertSuccessMessage(message) {
        return    Swal.fire({
            text: message,
            target: '#custom-target',
            customClass: {
                container: 'position-absolute'
            },
            toast: true,
            position: 'bottom-right',
            title: 'Success!',
            icon: 'success',
            confirmButtonText: 'Close'
        })
    }

    AlertInfoMessage(message) {
        Swal.fire({
            text: message,
            target: '#custom-target',
            customClass: {
                container: 'position-absolute'
            },
            toast: true,
            position: 'bottom-right',
            title: 'Info!',
            icon: 'info',
            confirmButtonText: 'Close'
        })
    }
}
