import Swal from 'sweetalert2'

export default {
    success(message,time) {   
        Swal.fire({
            position: 'top-end',
            icon: 'success',
            titleText: message,
            timer: time || 1000,
            toast:true,
            timerProgressBar:true,
            showConfirmButton:false,
            showCloseButton:true
          });
    },
    error(message) {
        Swal.fire({
            position: 'top-end',
            icon: 'error',
            titleText: message,
            timer: 3000,
            toast:true,
            timerProgressBar:true,
            showConfirmButton:false,
            showCloseButton:true
          });
    }
}