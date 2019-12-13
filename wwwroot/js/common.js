window.Alert = (message) => {
    window.alert(message);
}

window.Log = (message) => {
    console.log(message);
}

window.ShowModal = (id) => {
    $(id).modal('show');
}

window.HideModal = (id) => {
    $(id).modal('hide');
    console.log(id);
}

window.InitNotePad = (notepadId) => {
    var quill = new Quill(notepadId, {
        modules: {
            toolbar: [
                ['bold', 'italic'],
                ['link', 'blockquote', 'code-block', 'image'],
                [{ list: 'ordered' }, { list: 'bullet' }]
            ]
        },
        placeholder: 'Compose an epic...',
        theme: 'snow'
    });

    window.quill = quill;
}

window.GetNotePadContents = () => {
    var quill = window.quill;
    var contents = quill.getContents();
    return JSON.stringify(contents);
}

window.ClearQuickNoteContent = () => {
    var quill = window.quill;
    quill.setContents([]);
}