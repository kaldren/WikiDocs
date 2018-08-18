<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Services" %>
<script type="text/C#" runat="server">
    [WebMethod]
    public static string SayHello(string name)
    {
        return "Hello " + name;
    }
</script>
<!DOCTYPE html>
<html>
<head>
    <title></title>
    <script
        src="https://code.jquery.com/jquery-3.3.1.min.js"
        integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
        crossorigin="anonymous"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                url: 'WebForm1.aspx/sayhello',
                data: JSON.stringify({ name: 'John' }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (msg) {
                    // Notice that msg.d is used to retrieve the result object
                    alert(msg.d);
                }
            });
        });
    </script>
</head>
<body>
    <form id="Form1" runat="server">

    </form>
</body>
</html>