<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<LeanPlanner.Web.ViewModels.Project.ProjectListViewModel>>" MasterPageFile="~/Views/Shared/Site.Master" %>
<%@ Import Namespace="LeanPlanner.Web.Controllers" %>
<asp:Content runat="server" ID="Content" ContentPlaceHolderID="TitleContent">
    Projects
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">

<div id="header">
    <h1>Lean Planner</h1>
    
    <% Html.RenderAction<UserController>(x=>x.StatusWidget()); %>
</div>

<ul id="menu" class="ui-widget ui-widget-content">
    <li><a>Projects</a></li>
    <li><a>Settings</a></li>
</ul>

<div id="mainContent">

    <span id="toolbar" class="ui-widget-header ui-corner-all">
        <span id="toolbarTitle">Projects:</span>
        
        <button id="addProject">Add</button>
    </span>
    
</div>

<script>
    $(document).ready(function() {
        $("#menu a").button();

        $("#addProject").button({
            icons: {
                primary: 'ui-icon-circle-plus'    
            }
        });
    });
</script>

</asp:Content>
