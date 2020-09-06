<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebLeanMaint._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
		<h1>LeadMaint</h1>
		<p class="lead">LeadMaint is a ... .</p>
		<%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
	</div>

	<div class="row">
		<div class="col-md-4">
			<h2>Maintenance Web Service</h2>
			<p>
				Documentation regarding the web services.
			</p>
			<p>
				<a class="btn btn-default" href="./WS/Config.asmx">Config learn more &raquo;</a>
			</p>
			<p>
				<a class="btn btn-default" href="./WS/Maintenance.asmx">Maintenance learn more &raquo;</a>
			</p>
			<p>
				<a class="btn btn-default" href="./WS/Planning.asmx">Planning learn more &raquo;</a>
			</p>
		</div>
		<div class="col-md-4">
			<h2>KPI Web Service</h2>
			<p>
				Documentation regarding the KPI web service.
			</p>
			<p>
				<a class="btn btn-default" href="./WS/KPI.asmx">Learn more &raquo;</a>
			</p>
		</div>
		<div class="col-md-4">
			<h2>Management Web Site</h2>
			<p>
				Management web site access.
			</p>
			<p>
				<a class="btn btn-default" href="./Home/Login">Login &raquo;</a>
			</p>
		</div>
	</div>

</asp:Content>
