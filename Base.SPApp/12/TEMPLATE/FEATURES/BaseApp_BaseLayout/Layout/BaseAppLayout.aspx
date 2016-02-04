<%@ Page language="C#"   Inherits="Microsoft.SharePoint.Publishing.PublishingLayoutPage,Microsoft.SharePoint.Publishing,Version=12.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:webpartpageexpansion="full" meta:progid="SharePoint.WebPartPage.Document" %>
<%@ Register Tagprefix="SharePointWebControls" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingWebControls" Namespace="Microsoft.SharePoint.Publishing.WebControls" Assembly="Microsoft.SharePoint.Publishing, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="PublishingNavigation" Namespace="Microsoft.SharePoint.Publishing.Navigation" Assembly="Microsoft.SharePoint.Publishing, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<asp:Content ContentPlaceholderID="PlaceHolderPageTitle" runat="server">
    <SharePointWebControls:FieldValue id="PageTitle" FieldName="Title" runat="server"/>
</asp:Content>

<asp:Content ContentPlaceholderID="PlaceHolderMain" runat="server">
	<PublishingWebControls:EditModePanel runat="server" id="EditModePanel2" PageDisplayMode="Edit">
        <SharePointWebControls:TextField ID="TextField1" FieldName="Title" runat="server">
		</SharePointWebControls:TextField>
		<PublishingWebControls:RichHtmlField FieldName="PublishingPageContent" runat="server" id="RichHtmlField1" />
    </PublishingWebControls:EditModePanel>

    <div class="col-md-9" role="main">
        <PublishingWebControls:EditModePanel runat="server" id="EditModePanelMain" SuppressTag="true" PageDisplayMode="Edit">
            <div class="space"></div>
            <div class="edit-WPZone">
             </PublishingWebControls:EditModePanel>
                <WebPartPages:WebPartZone runat="server" AllowPersonalization="false" FrameType="TitleBarOnly" ID="WebPart_Main" PartChromeType="None" Title="Main Panel" Orientation="Vertical"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>		    
                <PublishingWebControls:EditModePanel runat="server" id="EditModePanelMain2" SuppressTag="true" PageDisplayMode="Edit">
	        </div>
        </PublishingWebControls:EditModePanel>
    </div>


    <div class="col-md-3" role="complementary">
		<PublishingWebControls:EditModePanel runat="server" id="EditModePanelComplementary" SuppressTag="true" PageDisplayMode="Edit">
            <div class="space"></div>
            <div class="edit-WPZone">
             </PublishingWebControls:EditModePanel>
                <WebPartPages:WebPartZone runat="server" AllowPersonalization="false" FrameType="TitleBarOnly" ID="WebPart_Complementary" PartChromeType="None" Title="Complementary Panel" Orientation="Vertical"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>		    
                <PublishingWebControls:EditModePanel runat="server" id="EditModePanelComplementary2" SuppressTag="true" PageDisplayMode="Edit">
	        </div>
        </PublishingWebControls:EditModePanel>
    </div>

</asp:Content>