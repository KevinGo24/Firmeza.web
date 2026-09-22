import "./styles/app.css";
import Swal from 'sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

window.Swal = Swal;

// Confirmación antes de eliminar
window.confirmDelete = function (id, name) {
    Swal.fire({
        title: '¿Eliminar registro?',
        text: `Estás a punto de eliminar "${name}". Esta acción no se puede deshacer.`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#dc2626',
        cancelButtonColor: '#64748b',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            document.getElementById('delete-form-' + id).submit();
        }
    });
};

// Alerta de éxito (usada después de Create/Update/Delete)
window.showSuccessAlert = function (message) {
    Swal.fire({
        icon: 'success',
        title: '¡Listo!',
        text: message,
        timer: 2200,
        showConfirmButton: false
    });
};

// Alerta de error genérica (por si la necesitas luego)
window.showErrorAlert = function (message) {
    Swal.fire({
        icon: 'error',
        title: 'Algo salió mal',
        text: message
    });
};

// Al cargar cualquier página, si el layout dejó un mensaje pendiente, lo muestra
document.addEventListener('DOMContentLoaded', function () {
    const successMsg = document.body.dataset.successMessage;
    if (successMsg) {
        window.showSuccessAlert(successMsg);
    }
});