(function () {
    var actionToConfirm;

    function deleteBook() {
        var $button = $(actionToConfirm);
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Book/DeleteBook',
            data: { id: $button.data("id") },
        });
    }

    function showConfirmationModal(message) {
        $('#confirmationModalBody').text(message);
        $('#confirmationModal').modal('show');
    }

    function handleDeleteBookClick() {
        actionToConfirm = this;
        var bookName = $(this).data("name");
        showConfirmationModal("Are you sure you want to detele" + bookName + "?");
    }

    function handleConfirmation() {
        $('#confirmationModal').modal('hide');
        if ($(actionToConfirm).attr('id') === 'deleteBook') {
            deleteBook();
        } 
    }

    function bindEvents() {
        $("#deleteBook").on("click", handleDeleteBookClick);
        $('#confirmYes').on('click', handleConfirmation);
    }

    $(document).ready(function () {
        bindEvents();
    });
})();