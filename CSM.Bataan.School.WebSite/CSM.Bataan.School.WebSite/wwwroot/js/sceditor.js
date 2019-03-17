sceditor.command.set('attachimage', {
    exec: function () {
        $("#modal-attach-image").modal("show");
    },
    txtExec: function () {
        $("#modal-attach-image").modal("show");
    },
    tooltip: 'Insert an image from your computer'
});

var textarea = document.getElementById('content');
sceditor.create(textarea, {
    format: 'bbcode',
    icons: 'monocons',
    toolbar: 'bold,italic,underline,strike,subscript,superscript|' +
        'left,center,right,justify|font,size,color,removeformat|' +
        'cut,copy,pastetext|bulletlist,orderedlist,indent,outdent|' +
        'table|code,quote,horizontalrule|' +
        'emoticon,youtube,date,time|ltr,rtl|image,attachimage',
    style: '/vendor/sceditor/themes/content/default.min.css'
});

function attachImage() {
    var data = new FormData();
    var file = $("#attachedImage").prop('files')[0];
    data.append("image", file);
    data.append("id", '@Model.Id');
    $.ajax({
        type: "POST",
        url: attachImageUrl,
        processData: false,
        contentType: false,
        data: data,
        success: function (rsp) {
            response = rsp.split(':');
            if (response[0] === "OK") {
                sceditor.instance(textarea).insert('[img]' + response[1] + '[/img]');
            };
        },
        error: function (xhr) {
            var response = JSON.parse(xhr.responseText);
            alert("Error Occured : " + response.errors[0]);
            location.reload();
        }
    });
    $("#modal-attach-image").modal("hide");
}