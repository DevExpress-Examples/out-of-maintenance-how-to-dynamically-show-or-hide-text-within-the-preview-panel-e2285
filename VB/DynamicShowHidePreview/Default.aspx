<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DynamicShowHidePreview._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>How to dynamically show or hide text within the preview panel</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" KeyFieldName="ID" >
			<Templates>
				<PreviewRow>
				<table runat="server">
				<tr visible="<%#Not IsPreviewVisible(Container.KeyValue)%>"><td>
					<asp:ImageButton ID="btnExpand" runat="server" ImageUrl="~/Images/plus.png" OnClick="btnExpand_Click" />
					<dxe:ASPxLabel ID="lblShortDescription" runat="server" Text="<%#GetShortDescriptionText(Container.VisibleIndex)%>" />
				</td></tr>
				<tr visible="<%#IsPreviewVisible(Container.KeyValue)%>"><td>
					<asp:ImageButton ID="btnCollapse" runat="server" ImageUrl="~/Images/minus.png" OnClick="btnExpand_Click" /><br />
					<dxe:ASPxLabel ID="lblFullDescription" runat="server" Text='<%#Eval("Description")%>' /><br />
					<dxe:ASPxLabel ID="lblAdditionalField" runat="server" Text='<%#Eval("AdditionalField")%>' />
				</td></tr>
				</table>
				</PreviewRow>
			</Templates>
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
			</Columns>
			<Settings ShowPreview="True" />
		</dxwgv:ASPxGridView>  
	</div>
	</form>
</body>
</html>