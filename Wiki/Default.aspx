﻿<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="Wiki.Default" %>

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
        <asp:ScriptManager runat="server" />
        <div>
            <div class="row form-group">
                <label for="txtTitle">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server" />
            </div>

            <div class="row form-group">
                <label for="txtContent">Content:</label>
                <asp:TextBox ID="txtContent" TextMode="MultiLine" runat="server" />
            </div>
        </div>

        <div>
            <p>Categories: </p>
            <asp:ListBox ID="lbCategories" CssClass="form-control js-categories" SelectionMode="Multiple" runat="server"></asp:ListBox>
        </div>

        <div>
            <p>Tags: </p>
            <asp:ListBox ID="lbTags" CssClass="form-control js-tags" SelectionMode="Multiple" runat="server"></asp:ListBox>
        </div>

        <div>
            <asp:Button Text="Create" ID="btnCreate" CssClass="js-btncreate" OnClientClick="SaveCategoriesAndTags()" OnClick="btnCreate_Click" runat="server" />
        </div>
        <a href="javascript:void(0)" class="showselection">show</a>

    </form>

    <script type="text/javascript">

        function SaveCategoriesAndTags() {
            SaveCategories();
            SaveTags();
        }

        function SaveCategories() {
            var selectData = JSON.stringify($('.js-categories').select2('data'));

            $.ajax({
                url: 'Default.aspx/SaveCategories',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ categories: selectData }),
                success: function (result) {
                }
            });
        }

        function SaveTags() {
            var selectData = JSON.stringify($('.js-tags').select2('data'));

            $.ajax({
                url: 'Default.aspx/SaveTags',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify({ tags: selectData }),
                success: function (result) {
                }
            });
        }

        $('.js-categories').select2({
            minimumInputLength: 1,
            tags: true,
            ajax: {
                type: 'GET',
                url: 'Default.aspx/GetCategories',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: function (search) {
                    return {
                        search: JSON.stringify(search.term)
                    }
                },
                processResults: function (data) {
                    SaveCategories();

                    return {
                        results: JSON.parse(data.d)
                    };
                }
            },
        });

        $('.js-tags').select2({
            minimumInputLength: 1,
            tags: true,
            ajax: {
                type: 'GET',
                url: 'Default.aspx/GetTags',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: function (search) {
                    return {
                        search: JSON.stringify(search.term)
                    }
                },
                processResults: function (data) {
                    SaveTags();

                    return {
                        results: JSON.parse(data.d)
                    };
                }
            }
        });
    </script>
</body>
</html>
