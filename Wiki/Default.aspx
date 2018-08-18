<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wiki.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Default/Styles/Main.css" rel="stylesheet" />
    <%--    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.1/css/select2.min.css" />
    <script
        src="https://code.jquery.com/jquery-3.3.1.min.js"
        integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
        crossorigin="anonymous"></script>

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.1/js/select2.full.min.js"></script>--%>
    <link href="App_Themes/Default/Styles/select2.min.css" rel="stylesheet" />
    <script src="App_Themes/Default/Scripts/jquery-2.1.0.js"></script>
    <script src="App_Themes/Default/Scripts/select2.full.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <select class="form-control js-categories" multiple="multiple">
            </select>
        </div>
    </form>

    <script type="text/javascript">

        $('.js-categories').select2({
            minimumInputLength: 1,
            ajax: {
                type: 'POST',
                url: 'Default.aspx/GetCategories',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: function (params) {
                    var query = JSON.stringify({ search: params.term });

                    return query;
                },
                processResults: function (data) {
                    console.log(data.d)
                    return {
                        results: data.d
                    };
                }
            }
        });
    </script>
</body>
</html>
