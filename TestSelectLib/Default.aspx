<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestSelectLib.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.1/css/select2.min.css" />
    <script
        src="https://code.jquery.com/jquery-3.3.1.min.js"
        integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
        crossorigin="anonymous"></script>

    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.1/js/select2.full.min.js"></script>
    <style>
        .js-categories {
            display: block;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <p>Categories: </p>
                <asp:ListBox ID="lbCategories" CssClass="form-control js-categories" SelectionMode="Multiple" runat="server"></asp:ListBox>
            </div>

            <input type="submit" id="testbtn" title="TEST" />
        </div>
        <script type="text/javascript">

            $(document).ready(function () {
                //var data = [
                //    {
                //        id: 0,
                //        text: 'enhancement'
                //    },
                //    {
                //        id: 1,
                //        text: 'bug'
                //    },
                //    {
                //        id: 2,
                //        text: 'duplicate'
                //    },
                //    {
                //        id: 3,
                //        text: 'invalid'
                //    },
                //    {
                //        id: 4,
                //        text: 'wontfix'
                //    }
                //];

                //$('.js-categories').select2({
                //    data: data
                //});

                //$('.js-categories').val(0).trigger('change');

                $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    url: 'Default.aspx/GetCategories',
                    dataType: 'json',
                    success: function (data) {
                        var jsCat = $(".js-categories").select2({
                            tags: true,
                            data: $.parseJSON(data.d)
                        });
                        var jsonData = $.parseJSON(data.d);
                        var jsonArrayIndexes = new Array();

                        $.each(jsonData, function (index) {
                            jsonArrayIndexes.push(index);
                        });

                        $('.js-categories').val(jsonArrayIndexes).trigger("change");
                    }
                });
            });
        </script>
    </form>
</body>
</html>
