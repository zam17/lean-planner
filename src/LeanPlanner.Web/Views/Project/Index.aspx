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

</asp:Content>
