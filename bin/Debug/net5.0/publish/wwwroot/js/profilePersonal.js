$("#changePasswordForm").submit((e) => {
    e.preventDefault();

    let formData = $("#changePasswordForm").serialize();
    console.log(formData);
    $.ajax(
        '/Account/ChangePassword',
        {
            dataType: 'json',
            method: 'POST',
            data: formData,
            error: (data) => { $("#changePasswordForm").children("span").html("<span class=\"text-danger\">"+data.responseJSON+"</span>"); },
            success: (data) => { $("#changePasswordForm").children("span").html("<span class=\"text-success\">"+data+"</span>"); }
        }
    )
});

$("#changePersonalDataForm").submit((e) => {
    e.preventDefault();

    let formData = $("#changePersonalDataForm").serialize();
    console.log(formData);
    $.ajax(
        '/Account/ChangePersonalData',
        {
            dataType: 'json',
            method: 'POST',
            data: formData,
            error: (data) => { $("#changePersonalDataForm").children("span").html("<span class=\"text-danger\">"+data.responseJSON+"</span>"); },
            success: (data) => { $("#changePersonalDataForm").children("span").html("<span class=\"text-success\">"+data+"</span>"); }
        }
    )
});