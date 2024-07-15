(function () {
    var actionToConfirm;


    function handleDeleteBookClick() {
        actionToConfirm = this;
        var bookName = $(this).data("name");
        showConfirmationModal("Are you sure you want to detele <strong>" + bookName + "</strong>?");
    }

    function deleteBook() {
        var $button = $(actionToConfirm);
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Book/DeleteBook',
            data: { id: $button.data("id") },
        });
    }

    function handleConfirmation() {
        $('#confirmationModal').modal('hide');
        console.log($(actionToConfirm).attr('id'))
        if ($(actionToConfirm).attr('id') === 'deleteBook') {
            deleteBook();
        }
    }

    function showConfirmationModal(message) {
        console.log("Book conformation")
        $('#confirmationModalBody').html(message);
        $('#confirmationModal').modal('show');
    }

    function bindEvents() {
        $(".deleteBook").on("click", handleDeleteBookClick);
        $('#confirmYes').on('click', handleConfirmation);
    }

    $(document).ready(function () {
        bindEvents();
    });
})();