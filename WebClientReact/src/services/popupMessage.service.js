import Swal from 'sweetalert2';

export default class PopupMessageService {
    // eslint-disable-next-line class-methods-use-this
    AlertErrorMessage(message) {
        Swal.fire({
            title: 'Error!',
            text: message,
            icon: 'error',
            confirmButtonText: 'Close'
        });
    }

    // eslint-disable-next-line class-methods-use-this
    AlertSuccessMessage(message) {
     return   Swal.fire({
            title: 'Success!',
            text: message,
            icon: 'success',
            confirmButtonText: 'Close'
        });
    }

    // eslint-disable-next-line class-methods-use-this
    AlertInfoMessage(message) {
        Swal.fire({
            title: 'Info!',
            text: message,
            icon: 'info',
            confirmButtonText: 'Close'
        });
    }

    AlertAssuranceMessage(message) {
       return Swal.fire({
            title: 'Are you sure?',
            text: message,
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#228a15',
            confirmButtonText: 'Yes, Save it!'
        })
    }
}
