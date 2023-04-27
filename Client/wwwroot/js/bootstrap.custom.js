function ShowToast(toastElement) {
  const toast = new bootstrap.Toast(toastElement);
  toast.show();
}
function ShowModal(modalElement) {
  const myModal = new bootstrap.Modal(modalElement);
  myModal.show();
}

function changerStyle(element) {
  element.style.visibility = "visible";
}
