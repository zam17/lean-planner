<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<LeanPlanner.Web.ViewModels.LogOnInputModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LogOn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="logon" class="ui-widget ui-widget-content ui-corner-all">
        <div class="ui-widget-header ui-corner-all">Log On</div>
        
        <% using (Html.BeginForm()) { %>
        OpenId:<%=Html.EditorFor(x => x.OpenIdIdentifier)%>
        <%= Html.Button("logon","Log On",HtmlButtonType.Submit) %>
        <br />
        <%= Html.ValidationMessageFor(x=>x.OpenIdIdentifier) %>
        <% } %>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            $("button[name='logon']").button();
        });
    </script>
</asp:Content>
