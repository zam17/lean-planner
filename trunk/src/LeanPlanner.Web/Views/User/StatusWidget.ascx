<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<LeanPlanner.Web.ViewModels.User.UserStatusViewModel>" %>

<div id="statusWidget">
Welcome <%= Model.DisplayName %><img src="<%= Model.AvatarUrl %>" alt="User Avatar"/>
</div>

