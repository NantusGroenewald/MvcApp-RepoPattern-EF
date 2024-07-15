(function () {
    var actionToConfirm;

    function handleDeleteAuthorClick() {
        actionToConfirm = this;
        var authorName = $(this).data("name");
        showConfirmationModal("Are you sure you want to detele <strong>" + authorName + "</strong>?");
    }

    function deleteAuthor() {
        var $button = $(actionToConfirm);
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '/Author/DeleteAuthor',
            data: { id: $button.data("id") },
            success: function () {
                showActionResponseModal('<h2 class="modal-title" id="responseModaLabel">Deleting Author</h2>', '<div class="text-center"><h1 class="text-success fa-5x fa fa-check-circle"></h1><h2>Success</h2></div>');
            },
            error: function (error) {
                var json = $.parseJSON(error.responseText);
                showActionResponseModal('<h2 class="modal-title" id="responseModaLabel">Deleting Author</h2>', '<div class="text-center"><h1 class="text-danger fa-5x fa fa-times-circle"></h1><h2>Failed</h2><p>' + json.message + '</p></div>', json.books);
            }
        });
    }

    function handleConfirmation() {
        $('#confirmationModal').modal('hide');
        if ($(actionToConfirm).attr('id') === 'deleteAuthor') {
            deleteAuthor();
        }
    }

    function showConfirmationModal(message) {

        $('#confirmationModalBody').html(message);
        $('#confirmationModal').modal('show');
    }

    function showActionResponseModal(heading, message, books) {
        console.log(books)
        var bookList = "";
        if (books && books.length > 0) {
            bookList = "<ul>";
            books.forEach(function (book) {
                bookList += "<li>" + book + "</li>";
            });
            bookList += "</ul>";
        }
        $('#responseModal .modal-header').html(heading);
        $('#responseModal .modal-body').html(message + bookList);
        $('#responseModal').modal('show');
    }

    $('#responseModal').on('hidden.bs.modal', function () {
        location.reload();
    })

    function bindEvents() {
        $(".deleteAuthor").on("click", handleDeleteAuthorClick);
        $('#confirmYes').on('click', handleConfirmation);
    }

    $(document).ready(function () {
        bindEvents();
    });
})();