<%@ Page language="C#" MasterPageFile="~masterurl/default.master"    Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=12.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" meta:progid="SharePoint.WebPartPage.Document" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitle" runat="server">
	<SharePoint:EncodedLiteral runat="server" text="<%$Resources:wss,multipages_homelink_text%>" EncodeMethod="HtmlEncode" __designer:Preview="Home" __designer:Values="&lt;P N='Text' Bound='True' T='Resources:wss,multipages_homelink_text' /&gt;&lt;P N='ID' ID='1' T='ctl00' /&gt;&lt;P N='Page' ID='2' /&gt;&lt;P N='TemplateControl' R='2' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/> - 
	<SharePoint:ProjectProperty Property="Title" runat="server" __designer:Preview="Wireline" __designer:Values="&lt;P N='Property' T='Title' /&gt;&lt;P N='InDesign' T='False' /&gt;&lt;P N='ID' ID='1' T='ctl01' /&gt;&lt;P N='Page' ID='2' /&gt;&lt;P N='TemplateControl' R='2' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageImage" runat="server"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageTitleInTitleArea" runat="server">
			<label class="ms-hidden">
			<SharePoint:ProjectProperty Property="Title" runat="server" __designer:Preview="Wireline" __designer:Values="&lt;P N='Property' T='Title' /&gt;&lt;P N='InDesign' T='False' /&gt;&lt;P N='ID' ID='1' T='ctl02' /&gt;&lt;P N='Page' ID='2' /&gt;&lt;P N='TemplateControl' R='2' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/></label>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleBreadcrumb" runat="server"/>
<asp:Content ContentPlaceHolderId="PlaceHolderTitleAreaClass" runat="server">
<style type="text/css">
TD.ms-titleareaframe, .ms-pagetitleareaframe {
	height: 10px;
}
Div.ms-titleareaframe {
	height: 100%;
}
.ms-pagetitleareaframe table {
	background: none;
	height: 10px;
}
</style>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderAdditionalPageHead" runat="server">
	<META Name="CollaborationServer" Content="SharePoint Team Web Site">
	<script type="text/javascript">
	var navBarHelpOverrideKey = "wssmain";
	</script>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderSearchArea" runat="server">
	<SharePoint:DelegateControl runat="server"
		ControlId="SmallSearchInputBox" __designer:Preview="&lt;div id=&quot;SRSB&quot;&gt; &lt;div id=&quot;ctl04&quot;&gt;
	&lt;input name=&quot;ctl04$ctl00&quot; type=&quot;hidden&quot; value=&quot;http://sharepoint.majordrilling.com/sites/corporate/wireline&quot; /&gt;&lt;table class=&quot;ms-sbtable ms-sbtable-ex&quot; border=&quot;0&quot;&gt;
		&lt;tr class=&quot;ms-sbrow&quot;&gt;
			&lt;td class=&quot;ms-sbscopes ms-sbcell&quot;&gt;&lt;select name=&quot;ctl04$SBScopesDDL&quot; id=&quot;ctl04_SBScopesDDL&quot; title=&quot;Search Scope&quot; class=&quot;ms-sbscopes&quot;&gt;
				&lt;option value=&quot;This Site&quot;&gt;This Site: Wireline&lt;/option&gt;

			&lt;/select&gt;&lt;/td&gt;&lt;td class=&quot;ms-sbcell&quot;&gt;&lt;input name=&quot;ctl04$InputKeywords&quot; type=&quot;text&quot; maxlength=&quot;200&quot; id=&quot;ctl04_InputKeywords&quot; accesskey=&quot;S&quot; title=&quot;Enter search words&quot; class=&quot;ms-sbplain&quot; alt=&quot;Enter search words&quot; onkeypress=&quot;javascript:return OSBEK(event);&quot; style=&quot;width:170px;&quot; /&gt;&lt;/td&gt;&lt;td class=&quot;ms-sbgo ms-sbcell&quot;&gt;&lt;a id=&quot;ctl04_go&quot; title=&quot;Go Search&quot;&gt;&lt;img title=&quot;Go Search&quot; onmouseover=&quot;this.src='/_layouts/images/gosearch.gif'&quot; onmouseout=&quot;this.src='/_layouts/images/gosearch.gif'&quot; alt=&quot;Go Search&quot; src=&quot;/_layouts/images/gosearch.gif&quot; style=&quot;border-width:0px;&quot; /&gt;&lt;/a&gt;&lt;/td&gt;&lt;td class=&quot;ms-sbLastcell&quot;&gt;&lt;/td&gt;
		&lt;/tr&gt;
	&lt;/table&gt;
&lt;/div&gt;&lt;/div&gt;" __designer:Values="&lt;P N='ControlId' T='SmallSearchInputBox' /&gt;&lt;P N='ID' ID='1' T='ctl03' /&gt;&lt;P N='Page' ID='2' /&gt;&lt;P N='TemplateControl' R='2' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderLeftActions" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderPageDescription" runat="server"/>
<asp:Content ContentPlaceHolderId="PlaceHolderBodyAreaClass" runat="server">
<style type="text/css">
.ms-bodyareaframe {
	padding: 0px;
}
</style>
</asp:Content>
<asp:Content ContentPlaceHolderId="PlaceHolderMain" runat="server">
	<table cellspacing="0" border="0" width="100%">
	  <tr>
	   <td class="ms-pagebreadcrumb">
		<asp:SiteMapPath SiteMapProvider="SPContentMapProvider" id="ContentMap" SkipLinkText="" NodeStyle-CssClass="ms-sitemapdirectional" runat="server" __designer:Templates="&lt;Group Name=&quot;NodeTemplate&quot;&gt;&lt;Template Name=&quot;NodeTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;&lt;Group Name=&quot;CurrentNodeTemplate&quot;&gt;&lt;Template Name=&quot;CurrentNodeTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;&lt;Group Name=&quot;RootNodeTemplate&quot;&gt;&lt;Template Name=&quot;RootNodeTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;&lt;Group Name=&quot;PathSeparatorTemplate&quot;&gt;&lt;Template Name=&quot;PathSeparatorTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;" __designer:Preview="&lt;span id=&quot;ContentMap&quot;&gt;&lt;span&gt;&lt;a class=&quot;ms-sitemapdirectional&quot; href=&quot;/sites/corporate&quot;&gt;Corporate&lt;/a&gt;&lt;/span&gt;&lt;span&gt; &amp;gt; &lt;/span&gt;&lt;span class=&quot;ms-sitemapdirectional&quot;&gt;Wireline&lt;/span&gt;&lt;/span&gt;" __designer:Values="&lt;P N='SiteMapProvider' T='SPContentMapProvider' /&gt;&lt;P N='NodeStyle'&gt;&lt;P N='CssClass' T='ms-sitemapdirectional' /&gt;&lt;P N='IsEmpty' T='False' /&gt;&lt;/P&gt;&lt;P N='SkipLinkText' R='-1' /&gt;&lt;P N='ControlStyle'&gt;&lt;P N='Font' ID='1' /&gt;&lt;/P&gt;&lt;P N='Font' R='1' /&gt;&lt;P N='ID' ID='2' T='ContentMap' /&gt;&lt;P N='Page' ID='3' /&gt;&lt;P N='TemplateControl' R='3' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/>
	   </td>
	  </tr>
	  <tr>
	   <td class="ms-webpartpagedescription">
		<SharePoint:ProjectProperty Property="Description" runat="server" __designer:Preview="Wireline Map" __designer:Values="&lt;P N='Property' T='Description' /&gt;&lt;P N='InDesign' T='False' /&gt;&lt;P N='ID' ID='1' T='ctl05' /&gt;&lt;P N='Page' ID='2' /&gt;&lt;P N='TemplateControl' R='2' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;"/></td>
	  </tr>
	  <tr>
		<td>
		 <table width="100%" cellpadding=0 cellspacing=0 style="padding: 5px 10px 10px 10px;">
		  <tr>
		   <td valign="top" width="70%">
			   <WebPartPages:WebPartZone runat="server" FrameType="TitleBarOnly" ID="Left" Title="loc:Left" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;Left&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Left&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N='FrameType' E='2' /&gt;&lt;P N='Title' ID='1' T='Left' /&gt;&lt;P N='HeaderText' T='loc:Left' /&gt;&lt;P N='DisplayTitle' R='1' /&gt;&lt;P N='MenuPopupStyle'&gt;&lt;P N='CellPadding' T='1' /&gt;&lt;P N='CellSpacing' T='0' /&gt;&lt;/P&gt;&lt;P N='PartChromeType' E='3' /&gt;&lt;P N='ControlStyle'&gt;&lt;P N='BorderColor' T='Gray' /&gt;&lt;P N='BorderWidth' T='1px' /&gt;&lt;P N='BorderStyle' E='4' /&gt;&lt;P N='Font' ID='2' /&gt;&lt;/P&gt;&lt;P N='Font' R='2' /&gt;&lt;P N='ID' R='1' /&gt;&lt;P N='Page' ID='3' /&gt;&lt;P N='TemplateControl' R='3' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate><WebPartPages:DataFormWebPart runat="server" SuppressWebPartChrome="False" Description="" PartImageSmall="" DataSourceID="" MissingAssembly="Cannot import this Web Part." FrameType="Default" ConnectionID="00000000-0000-0000-0000-000000000000" DetailLink="" ExportControlledProperties="True" IsVisible="True" AllowRemove="True" AllowEdit="True" ID="g_4a6621c3_490c_4c39_b8ad_6d1d527d664d" Dir="Default" FrameState="Normal" ViewContentTypeId="" AllowConnect="True" PageSize="-1" ZoneID="Left" AllowMinimize="True" IsIncludedFilter="" ShowWithSampleData="False" HelpMode="Modeless" ExportMode="All" ViewFlag="0" Title="wireline_data on wireline" HelpLink="" AllowHide="True" AllowZoneChange="True" PartOrder="1" UseSQLDataSourcePaging="True" PartImageLarge="" IsIncluded="True" NoDefaultStyle="TRUE" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table TOPLEVEL border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
	&lt;tr&gt;
		&lt;td&gt;&lt;table border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
			&lt;tr class=&quot;ms-WPHeader&quot;&gt;
				&lt;td title=&quot;wireline_data on wireline&quot; id=&quot;WebPartTitleWPQ1&quot; style=&quot;width:100%;&quot;&gt;&lt;div class=&quot;ms-WPTitle&quot;&gt;&lt;nobr&gt;&lt;span&gt;wireline_data on wireline&lt;/span&gt;&lt;span id=&quot;WebPartCaptionWPQ1&quot;&gt;&lt;/span&gt;&lt;/nobr&gt;&lt;/div&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td class=&quot;&quot; valign=&quot;top&quot;&gt;&lt;div WebPartID=&quot;2928ceff-b855-45cb-ab3f-24a9fac2c5a5&quot; HasPers=&quot;false&quot; id=&quot;WebPartWPQ1&quot; width=&quot;100%&quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot;&gt;
			&lt;table TOPLEVEL border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
	&lt;tr&gt;
		&lt;td valign=&quot;top&quot;&gt;&lt;div WebPartID=&quot;2928ceff-b855-45cb-ab3f-24a9fac2c5a5&quot; HasPers=&quot;false&quot; id=&quot;WebPartWPQ1&quot; width=&quot;100%&quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div ID=&quot;WebPartContent&quot;&gt;The DataFormWebPart does not provide a design-time preview.&lt;/div&gt;&lt;/div&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;
		&lt;/div&gt;&lt;/div&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N='ViewFlag' T='0' /&gt;&lt;P N='DataSourcesString' T='&amp;lt;%@ Register TagPrefix=&quot;sharepoint&quot; Namespace=&quot;Microsoft.SharePoint.WebControls&quot; Assembly=&quot;Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&amp;gt;&amp;lt;sharepoint:SPSqlDataSource runat=&quot;server&quot; AllowIntegratedSecurity=&quot;False&quot; ConnectionString=&quot;Data Source=10.0.4.14\MDGBKP01;User ID=wireline_user;Password=w1reline;Initial Catalog=WIRELINE;&quot; ProviderName=&quot;System.Data.SqlClient&quot; SelectCommand=&quot;SELECT job_no, rtrim(hole_id) hole_id, rig_id, rtrim(gps_long) gps_long, rtrim(gps_lat) gps_lat, msg_type, rtrim(msg) msg, rtrim(link) link, rtrim(pin_type) pin_type, id, convert(varchar(19),time_start,126) time_start FROM [wireline_data_pin] &quot; ID=&quot;wireline_data_x0020_on_x0020_wireline1&quot;&amp;gt;&amp;lt;/sharepoint:SPSqlDataSource&amp;gt;&amp;#xD;&amp;#xA;' /&gt;&lt;P N='Xsl' T='&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;lt;xsl:stylesheet xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot; version=&quot;1.0&quot; exclude-result-prefixes=&quot;xsl msxsl ddwrt&quot; xmlns:ddwrt=&quot;http://schemas.microsoft.com/WebParts/v2/DataView/runtime&quot; xmlns:asp=&quot;http://schemas.microsoft.com/ASPNET/20&quot; xmlns:__designer=&quot;http://schemas.microsoft.com/WebParts/v2/DataView/designer&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot; xmlns:msxsl=&quot;urn:schemas-microsoft-com:xslt&quot; xmlns:SharePoint=&quot;Microsoft.SharePoint.WebControls&quot; xmlns:ddwrt2=&quot;urn:frontpage:internal&quot;&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:output method=&quot;html&quot; indent=&quot;no&quot;/&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:decimal-format NaN=&quot;&quot;/&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:param name=&quot;dvt_apos&quot;&amp;gt;&amp;amp;apos;&amp;lt;/xsl:param&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:variable name=&quot;dvt_1_automode&quot;&amp;gt;0&amp;lt;/xsl:variable&amp;gt;&amp;#xD;&amp;#xA;	&amp;#xD;&amp;#xA;	&amp;lt;xsl:template match=&quot;/&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot; xmlns:asp=&quot;http://schemas.microsoft.com/ASPNET/20&quot; xmlns:__designer=&quot;http://schemas.microsoft.com/WebParts/v2/DataView/designer&quot; xmlns:SharePoint=&quot;Microsoft.SharePoint.WebControls&quot;&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;script src=&quot;http://maps.google.com/maps?file=api&amp;amp;amp;v=1&amp;amp;amp;key=ABQIAAAAHsWKdQOVLvpaStdFijUyWxSsBYGvOGNk1qfvEBygY4vpZ0IJYBSiEaQiKN52hlj10hIOPS3yvIRIhA&quot; type=&quot;text/javascript&quot;&amp;gt;&amp;lt;/script&amp;gt; &amp;lt;div id=&quot;map&quot; style=&quot;width: 1000px; height: 750px&quot;&amp;gt;&amp;lt;/div&amp;gt; &amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;        &amp;lt;script language=&quot;javascript&quot;  type=&quot;text/javascript&quot;&amp;gt;&amp;#xD;&amp;#xA;        &amp;#xD;&amp;#xA;        function createMarker(point, titlehtml, commenthtml, markerOptions) {&amp;#xD;&amp;#xA;	     var marker = new GMarker(point, markerOptions);&amp;#xD;&amp;#xA;	    GEvent.addListener(marker, &amp;amp;quot;click&amp;amp;quot;, function() { var myHtml = titlehtml + &amp;amp;quot;&amp;lt;br /&amp;gt;&amp;amp;quot; + commenthtml;  marker.openInfoWindowHtml(myHtml); });&amp;#xD;&amp;#xA;	    return marker;&amp;#xD;&amp;#xA; 	}&amp;#xD;&amp;#xA;                &amp;#xD;&amp;#xA;    function renderMarker()&amp;#xD;&amp;#xA;    {&amp;#xD;&amp;#xA;     &amp;lt;xsl:call-template name=&quot;dvt_1&quot; /&amp;gt;&amp;#xD;&amp;#xA;    }&amp;#xD;&amp;#xA;                    &amp;#xD;&amp;#xA;     var map;&amp;#xD;&amp;#xA;     var toggleState = 1;&amp;#xD;&amp;#xA;     var markerOptions;     &amp;#xD;&amp;#xA;     var alertMarkerOptions;&amp;#xD;&amp;#xA;     var addMarkerOptions;&amp;#xD;&amp;#xA;     var off_markerOptions;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;    &amp;#xD;&amp;#xA;    function Rendermap()&amp;#xD;&amp;#xA;    {&amp;#xD;&amp;#xA;    	if (GBrowserIsCompatible()) {&amp;#xD;&amp;#xA;			map = new GMap2(document.getElementById(&amp;amp;quot;map&amp;amp;quot;));&amp;#xD;&amp;#xA;			//map.setCenter(new GLatLng(44.11,103.48), 5);&amp;#xD;&amp;#xA;			map.setCenter(new GLatLng(33.2951,-111.052), 2);&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;			//the depth or level of the view&amp;#xD;&amp;#xA;			map.addControl(new GLargeMapControl());&amp;#xD;&amp;#xA;			map.addControl(new GMapTypeControl());&amp;#xD;&amp;#xA;			map.setMapType(G_HYBRID_MAP);&amp;#xD;&amp;#xA;			map.enableScrollWheelZoom();&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			var offIcon = new GIcon(G_DEFAULT_ICON);&amp;#xD;&amp;#xA;			offIcon.iconSize = new GSize(20, 20); &amp;#xD;&amp;#xA;			offIcon.image = &amp;amp;quot;http://maps.google.com/mapfiles/kml/pal3/icon21.png&amp;amp;quot;;&amp;#xD;&amp;#xA;			// Set up our GMarkerOptions object&amp;#xD;&amp;#xA;			off_markerOptions = { icon:offIcon };&amp;#xD;&amp;#xA;			renderOffices();&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			var blueIcon = new GIcon(G_DEFAULT_ICON);&amp;#xD;&amp;#xA;			blueIcon.iconSize = new GSize(25, 25); &amp;#xD;&amp;#xA;			blueIcon.image = &amp;amp;quot;http://maps.google.com/mapfiles/kml/pal4/icon21.png&amp;amp;quot;;&amp;#xD;&amp;#xA;					&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			var alertIcon = new GIcon(G_DEFAULT_ICON);&amp;#xD;&amp;#xA;			alertIcon.iconSize = new GSize(25, 25); &amp;#xD;&amp;#xA;			alertIcon.image = &amp;amp;quot;http://maps.google.com/mapfiles/kml/pal3/icon37.png&amp;amp;quot;;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;            		var addIcon = new GIcon(G_DEFAULT_ICON);&amp;#xD;&amp;#xA;			addIcon.iconSize = new GSize(25, 25); &amp;#xD;&amp;#xA;			addIcon.image = &amp;amp;quot;http://maps.google.com/mapfiles/kml/pal3/icon38.png&amp;amp;quot;;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			// Set up our GMarkerOptions object&amp;#xD;&amp;#xA;			markerOptions = { icon:blueIcon };			&amp;#xD;&amp;#xA;			// Set up our GMarkerOptions object&amp;#xD;&amp;#xA;			alertMarkerOptions = { icon:alertIcon };&amp;#xD;&amp;#xA;			// Set up our GMarkerOptions object&amp;#xD;&amp;#xA;			addMarkerOptions = { icon:addIcon };		&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;			renderMarker();&amp;#xD;&amp;#xA;			&amp;#xD;&amp;#xA;		}&amp;#xD;&amp;#xA;	}&amp;#xD;&amp;#xA;                &amp;#xD;&amp;#xA;	function GetMultiLine(sStr)&amp;#xD;&amp;#xA;	{&amp;#xD;&amp;#xA;		var s = sStr;&amp;#xD;&amp;#xA;		s = s.replace(/function\(\){/, &amp;amp;apos;&amp;amp;apos;);&amp;#xD;&amp;#xA;		s = s.replace(/\*\/}/, &amp;amp;apos;&amp;amp;apos;);&amp;#xD;&amp;#xA;		s = s.replace(/\//, &amp;amp;apos;&amp;amp;apos;, -1);&amp;#xD;&amp;#xA;		s = s.replace(/\*/, &amp;amp;apos;&amp;amp;apos;, -1);&amp;#xD;&amp;#xA;		return s;&amp;#xD;&amp;#xA;	}&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;        &amp;#xD;&amp;#xA;        &amp;#xD;&amp;#xA;        &amp;#xD;&amp;#xA;        &amp;lt;/script&amp;gt; &amp;lt;/xsl:template&amp;gt;                &amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1&quot;&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:variable name=&quot;Rows&quot; select=&quot;/dsQueryResponse/NewDataSet/Row&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;#xD;&amp;#xA;		&amp;lt;xsl:call-template name=&quot;dvt_1.body&quot;&amp;gt;&amp;#xD;&amp;#xA;		            &amp;lt;xsl:with-param name=&quot;Rows&quot; select=&quot;$Rows&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;/xsl:call-template&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;	&amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1.body&quot;&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:param name=&quot;Rows&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:for-each select=&quot;$Rows&quot;&amp;gt;&amp;#xD;&amp;#xA;	                &amp;lt;xsl:call-template name=&quot;dvt_1.rowview&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;/xsl:for-each&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;	&amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1.rowview&quot;&amp;gt;&amp;#xD;&amp;#xA;		var point = new GLatLng(&amp;lt;xsl:value-of select=&quot;@gps_lat&quot;/&amp;gt;,&amp;lt;xsl:value-of select=&quot;@gps_long&quot;/&amp;gt;);&amp;#xD;&amp;#xA;   	&amp;#xD;&amp;#xA;	    var f&amp;lt;xsl:value-of select=&quot;@id&quot;/&amp;gt; = function(){/*Start Date/Time: &amp;lt;FONT COLOR=&quot;blue&quot; size=&quot;2&quot; face=&quot;arial&quot;&amp;gt;&amp;lt;xsl:value-of select=&quot;@time_start&quot;/&amp;gt;&amp;lt;/FONT&amp;gt;&amp;lt;br/&amp;gt;Detailed Summary: &amp;lt;a href=&amp;apos;http://10.0.6.11/WebSetup1/Default.aspx?HOLEID={@hole_id}&amp;amp;amp;DATE={@time_start}&amp;apos; target=&quot;_blank&quot;&amp;gt;&amp;lt;FONT COLOR=&quot;blue&quot; size=&quot;2&quot; face=&quot;arial&quot;&amp;gt;Summary Report&amp;lt;/FONT&amp;gt;&amp;lt;br/&amp;gt;&amp;lt;/a&amp;gt;&amp;lt;xsl:value-of select=&quot;@msg&quot;/&amp;gt;&amp;lt;br/&amp;gt;&amp;lt;xsl:value-of select=&quot;@link&quot;/&amp;gt;&amp;lt;br/&amp;gt;*/};&amp;#xD;&amp;#xA;        var htmlComment = GetMultiLine(new String(f&amp;lt;xsl:value-of select=&quot;@id&quot;/&amp;gt;));&amp;#xD;&amp;#xA;        var marker = createMarker(point,&amp;amp;quot;Hole: &amp;lt;xsl:value-of select=&quot;@hole_id&quot;/&amp;gt;&amp;amp;quot;, htmlComment,&amp;lt;xsl:value-of select=&quot;@pin_type&quot;/&amp;gt;);			&amp;#xD;&amp;#xA;      	map.addOverlay(marker);&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/xsl:stylesheet&amp;gt;	' /&gt;&lt;P N='DataFields' T='&amp;#xD;&amp;#xA;@job_no,job_no;@hole_id,hole_id;@rig_id,rig_id;@gps_long,gps_long;@gps_lat,gps_lat;@msg_type,msg_type;@msg,msg;@link,link;@pin_type,pin_type;@id,id;@time_start,time_start;' /&gt;&lt;P N='NoDefaultStyle' T='TRUE' /&gt;&lt;P N='ParameterBindings' T='&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;dvt_apos&quot; Location=&quot;Postback;Connection&quot;/&amp;gt;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;UserID&quot; Location=&quot;CAMLVariable&quot; DefaultValue=&quot;CurrentUserName&quot;/&amp;gt;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;Today&quot; Location=&quot;CAMLVariable&quot; DefaultValue=&quot;CurrentDate&quot;/&amp;gt;&amp;#xD;&amp;#xA;			   ' /&gt;&lt;P N='ParameterValues' Serial='AAEAAAD/////AQAAAAAAAAAMAgAAAFhNaWNyb3NvZnQuU2hhcmVQb2ludCwgVmVyc2lvbj0xMi4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj03MWU5YmNlMTExZTk0MjljBQEAAAA9TWljcm9zb2Z0LlNoYXJlUG9pbnQuV2ViUGFydFBhZ2VzLlBhcmFtZXRlck5hbWVWYWx1ZUhhc2h0YWJsZQEAAAAFX2NvbGwDHFN5c3RlbS5Db2xsZWN0aW9ucy5IYXNodGFibGUCAAAACgs' /&gt;&lt;P N='FilterValues' Serial='AAEAAAD/////AQAAAAAAAAAMAgAAAFhNaWNyb3NvZnQuU2hhcmVQb2ludCwgVmVyc2lvbj0xMi4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj03MWU5YmNlMTExZTk0MjljBQEAAAA9TWljcm9zb2Z0LlNoYXJlUG9pbnQuV2ViUGFydFBhZ2VzLlBhcmFtZXRlck5hbWVWYWx1ZUhhc2h0YWJsZQEAAAAFX2NvbGwDHFN5c3RlbS5Db2xsZWN0aW9ucy5IYXNodGFibGUCAAAACgs' /&gt;&lt;P N='Title' ID='1' T='wireline_data on wireline' /&gt;&lt;P N='ZoneID' T='Left' /&gt;&lt;P N='PartOrder' T='1' /&gt;&lt;P N='ID' T='g_4a6621c3_490c_4c39_b8ad_6d1d527d664d' /&gt;&lt;P N='StorageKey' T='2928ceff-b855-45cb-ab3f-24a9fac2c5a5' /&gt;&lt;P N='UseDefaultStyles' T='False' /&gt;&lt;P N='Qualifier' T='WPQ1' /&gt;&lt;P N='ClientName' T='varPartWPQ1' /&gt;&lt;P N='Permissions' E='0' /&gt;&lt;P N='EffectiveTitle' R='1' /&gt;&lt;P N='EffectiveStorage' E='2' /&gt;&lt;P N='EffectiveFrameType' E='2' /&gt;&lt;P N='DisplayTitle' R='1' /&gt;&lt;P N='ExportMode' E='1' /&gt;&lt;P N='IsShared' T='True' /&gt;&lt;P N='IsStandalone' T='False' /&gt;&lt;P N='IsStatic' T='False' /&gt;&lt;P N='WebBrowsableObject' R='0' /&gt;&lt;P N='ZoneIndex' T='1' /&gt;&lt;P N='Font' ID='2' /&gt;&lt;P N='Page' ID='3' /&gt;&lt;P N='TemplateControl' R='3' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;" __MarkupType="vsattributemarkup" __WebPartId="{2928CEFF-B855-45CB-AB3F-24A9FAC2C5A5}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
<SharePoint:SPSqlDataSource runat="server" AllowIntegratedSecurity="False" ConnectionString="Data Source=10.0.4.14\MDGBKP01;User ID=wireline_user;Password=w1reline;Initial Catalog=WIRELINE;" ProviderName="System.Data.SqlClient" SelectCommand="SELECT job_no, rtrim(hole_id) hole_id, rig_id, rtrim(gps_long) gps_long, rtrim(gps_lat) gps_lat, msg_type, rtrim(msg) msg, rtrim(link) link, rtrim(pin_type) pin_type, id, convert(varchar(19),time_start,126) time_start, active FROM [wireline_data_pin] " ID="wireline_data_x0020_on_x0020_wireline1"></SharePoint:SPSqlDataSource>
</DataSources>
<ParameterBindings>


				   <ParameterBinding Name="dvt_apos" Location="Postback;Connection"/>
				   <ParameterBinding Name="UserID" Location="CAMLVariable" DefaultValue="CurrentUserName"/>
				   <ParameterBinding Name="Today" Location="CAMLVariable" DefaultValue="CurrentDate"/>
			   </ParameterBindings>
<DataFields>

@job_no,job_no;@hole_id,hole_id;@rig_id,rig_id;@gps_long,gps_long;@gps_lat,gps_lat;@msg_type,msg_type;@msg,msg;@link,link;@pin_type,pin_type;@id,id;@time_start,time_start;@active,active;</DataFields>
<Xsl>





<xsl:stylesheet xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" version="1.0" exclude-result-prefixes="xsl msxsl ddwrt" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:SharePoint="Microsoft.SharePoint.WebControls" xmlns:ddwrt2="urn:frontpage:internal">
	<xsl:output method="html" indent="no"/>
	<xsl:decimal-format NaN=""/>
	<xsl:param name="dvt_apos">&apos;</xsl:param>
	<xsl:variable name="dvt_1_automode">0</xsl:variable>
	
	<xsl:template match="/" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:SharePoint="Microsoft.SharePoint.WebControls">
	<script src="http://maps.google.com/maps?file=api&amp;v=1&amp;key=ABQIAAAAHsWKdQOVLvpaStdFijUyWxSsBYGvOGNk1qfvEBygY4vpZ0IJYBSiEaQiKN52hlj10hIOPS3yvIRIhA" type="text/javascript"></script> <div id="map" style="width: 1000px; height: 750px"></div> 

        <script language="javascript"  type="text/javascript">
        
        function createMarker(point, titlehtml, commenthtml, markerOptions) {
	     var marker = new GMarker(point, markerOptions);
	    GEvent.addListener(marker, &quot;click&quot;, function() { var myHtml = titlehtml + &quot;<br />&quot; + commenthtml;  marker.openInfoWindowHtml(myHtml); });
	    return marker;
 	}
                
    function renderMarker()
    {
     <xsl:call-template name="dvt_1" />
    }
                    
     var map;
     var toggleState = 1;
     var markerOptions;     
     var alertMarkerOptions;
     var addMarkerOptions;
     var off_markerOptions;


    
    function Rendermap()
    {
    	if (GBrowserIsCompatible()) {
			map = new GMap2(document.getElementById(&quot;map&quot;));
			//map.setCenter(new GLatLng(44.11,103.48), 5);
			map.setCenter(new GLatLng(33.2951,-111.052), 2);

			//the depth or level of the view
			map.addControl(new GLargeMapControl());
			map.addControl(new GMapTypeControl());
			map.setMapType(G_HYBRID_MAP);
			map.enableScrollWheelZoom();

			
			var offIcon = new GIcon(G_DEFAULT_ICON);
			offIcon.iconSize = new GSize(20, 20); 
			offIcon.image = &quot;http://maps.google.com/mapfiles/kml/pal3/icon21.png&quot;;
			// Set up our GMarkerOptions object
			off_markerOptions = { icon:offIcon };
			renderOffices();
			
			var blueIcon = new GIcon(G_DEFAULT_ICON);
			blueIcon.iconSize = new GSize(25, 25); 
			blueIcon.image = &quot;http://maps.google.com/mapfiles/kml/pal4/icon21.png&quot;;
					
			
			var alertIcon = new GIcon(G_DEFAULT_ICON);
			alertIcon.iconSize = new GSize(25, 25); 
			alertIcon.image = &quot;http://maps.google.com/mapfiles/kml/pal3/icon37.png&quot;;

            		var addIcon = new GIcon(G_DEFAULT_ICON);
			addIcon.iconSize = new GSize(25, 25); 
			addIcon.image = &quot;http://maps.google.com/mapfiles/kml/pal3/icon38.png&quot;;

			

			
			// Set up our GMarkerOptions object
			markerOptions = { icon:blueIcon };			
			// Set up our GMarkerOptions object
			alertMarkerOptions = { icon:alertIcon };
			// Set up our GMarkerOptions object
			addMarkerOptions = { icon:addIcon };		

			
			
			renderMarker();
			
		}
	}
                
	function GetMultiLine(sStr)
	{
		var s = sStr;
		s = s.replace(/function\(\){/, &apos;&apos;);
		s = s.replace(/\*\/}/, &apos;&apos;);
		s = s.replace(/\//, &apos;&apos;, -1);
		s = s.replace(/\*/, &apos;&apos;, -1);
		return s;
	}

        
        
        
        </script> </xsl:template>                
	<xsl:template name="dvt_1">
		<xsl:variable name="Rows" select="/dsQueryResponse/NewDataSet/Row"/>
		
		<xsl:call-template name="dvt_1.body">
		            <xsl:with-param name="Rows" select="$Rows"/>
		</xsl:call-template>
	</xsl:template>
	
	<xsl:template name="dvt_1.body">
		<xsl:param name="Rows"/>
		<xsl:for-each select="$Rows">	                
	                <xsl:if test="@active=1">	                
	                   <xsl:call-template name="dvt_1.rowview"/>
	                </xsl:if>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template name="dvt_1.rowview">
		var point = new GLatLng(<xsl:value-of select="@gps_lat"/>,<xsl:value-of select="@gps_long"/>);
   	
	    var f<xsl:value-of select="@id"/> = function(){/*Start Date/Time: <FONT COLOR="blue" size="2" face="arial"><xsl:value-of select="@time_start"/></FONT><br/>Detailed Summary: <a href='http://10.0.6.11/WebSetup1/Default.aspx?HOLEID={@hole_id}&amp;DATE={@time_start}' target="_blank"><FONT COLOR="blue" size="2" face="arial">Summary Report</FONT><br/></a><xsl:value-of select="@msg"/><br/><xsl:value-of select="@link"/><br/>*/};
        var htmlComment = GetMultiLine(new String(f<xsl:value-of select="@id"/>));
        var marker = createMarker(point,&quot;Hole: <xsl:value-of select="@hole_id"/>&quot;, htmlComment,<xsl:value-of select="@pin_type"/>);			
      	map.addOverlay(marker);
	</xsl:template>
</xsl:stylesheet>	</Xsl>
</WebPartPages:DataFormWebPart>

<WebPartPages:DataFormWebPart runat="server" SuppressWebPartChrome="False" Description="" PartImageSmall="" DataSourceID="" MissingAssembly="Cannot import this Web Part." ListName="{CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB}" FrameType="Default" ConnectionID="00000000-0000-0000-0000-000000000000" DetailLink="" ExportControlledProperties="True" IsVisible="True" AllowRemove="True" AllowEdit="True" ID="g_079bfc03_d0b9_4e0c_a279_3a2c4f62645a" Dir="Default" FrameState="Normal" DisplayName="offices" ViewContentTypeId="" AllowConnect="True" PageSize="-1" Default="FALSE" ZoneID="Left" AllowMinimize="True" IsIncludedFilter="" ShowWithSampleData="False" HelpMode="Modeless" ExportMode="All" ViewFlag="0" Title="offices" HelpLink="" AllowHide="True" AllowZoneChange="True" PartOrder="2" UseSQLDataSourcePaging="True" PartImageLarge="" IsIncluded="True" NoDefaultStyle="TRUE" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table TOPLEVEL border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
	&lt;tr&gt;
		&lt;td&gt;&lt;table border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
			&lt;tr class=&quot;ms-WPHeader&quot;&gt;
				&lt;td title=&quot;offices&quot; id=&quot;WebPartTitleWPQ2&quot; style=&quot;width:100%;&quot;&gt;&lt;div class=&quot;ms-WPTitle&quot;&gt;&lt;nobr&gt;&lt;span&gt;offices&lt;/span&gt;&lt;span id=&quot;WebPartCaptionWPQ2&quot;&gt;&lt;/span&gt;&lt;/nobr&gt;&lt;/div&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td class=&quot;&quot; valign=&quot;top&quot;&gt;&lt;div WebPartID=&quot;079bfc03-d0b9-4e0c-a279-3a2c4f62645a&quot; HasPers=&quot;false&quot; id=&quot;WebPartWPQ2&quot; width=&quot;100%&quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div id=&quot;WebPartContent&quot;&gt;
			&lt;table TOPLEVEL border=&quot;0&quot; cellpadding=&quot;0&quot; cellspacing=&quot;0&quot; width=&quot;100%&quot;&gt;
	&lt;tr&gt;
		&lt;td valign=&quot;top&quot;&gt;&lt;div WebPartID=&quot;079bfc03-d0b9-4e0c-a279-3a2c4f62645a&quot; HasPers=&quot;false&quot; id=&quot;WebPartWPQ2&quot; width=&quot;100%&quot; allowDelete=&quot;false&quot; style=&quot;&quot; &gt;&lt;div ID=&quot;WebPartContent&quot;&gt;The DataFormWebPart does not provide a design-time preview.&lt;/div&gt;&lt;/div&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;
		&lt;/div&gt;&lt;/div&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N='DisplayName' ID='1' T='offices' /&gt;&lt;P N='ViewFlag' T='0' /&gt;&lt;P N='Default' T='FALSE' /&gt;&lt;P N='ListName' T='{CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB}' /&gt;&lt;P N='DataSourcesString' T='&amp;lt;%@ Register TagPrefix=&quot;sharepoint&quot; Namespace=&quot;Microsoft.SharePoint.WebControls&quot; Assembly=&quot;Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&amp;gt;&amp;lt;%@ Register TagPrefix=&quot;webpartpages&quot; Namespace=&quot;Microsoft.SharePoint.WebPartPages&quot; Assembly=&quot;Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c&quot; %&amp;gt;&amp;lt;sharepoint:SPDataSource runat=&quot;server&quot; DataSourceMode=&quot;List&quot; SelectCommand=&quot;&amp;amp;lt;View&amp;amp;gt;&amp;amp;lt;/View&amp;amp;gt;&quot; UpdateCommand=&quot;&quot; InsertCommand=&quot;&quot; DeleteCommand=&quot;&quot; UseInternalName=&quot;True&quot; ID=&quot;offices1&quot;&amp;gt;&amp;lt;SelectParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;webpartpages:DataFormParameter ParameterKey=&quot;ListID&quot; PropertyName=&quot;ParameterValues&quot; DefaultValue=&quot;CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB&quot; Name=&quot;ListID&quot;&amp;gt;&amp;lt;/webpartpages:DataFormParameter&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/SelectParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;UpdateParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;webpartpages:DataFormParameter ParameterKey=&quot;ListID&quot; PropertyName=&quot;ParameterValues&quot; DefaultValue=&quot;CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB&quot; Name=&quot;ListID&quot;&amp;gt;&amp;lt;/webpartpages:DataFormParameter&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/UpdateParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;InsertParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;webpartpages:DataFormParameter ParameterKey=&quot;ListID&quot; PropertyName=&quot;ParameterValues&quot; DefaultValue=&quot;CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB&quot; Name=&quot;ListID&quot;&amp;gt;&amp;lt;/webpartpages:DataFormParameter&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/InsertParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;DeleteParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;webpartpages:DataFormParameter ParameterKey=&quot;ListID&quot; PropertyName=&quot;ParameterValues&quot; DefaultValue=&quot;CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB&quot; Name=&quot;ListID&quot;&amp;gt;&amp;lt;/webpartpages:DataFormParameter&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/DeleteParameters&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/sharepoint:SPDataSource&amp;gt;&amp;#xD;&amp;#xA;' /&gt;&lt;P N='Xsl' T='&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;&amp;lt;xsl:stylesheet xmlns:x=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:d=&quot;http://schemas.microsoft.com/sharepoint/dsp&quot; version=&quot;1.0&quot; exclude-result-prefixes=&quot;xsl msxsl ddwrt&quot; xmlns:ddwrt=&quot;http://schemas.microsoft.com/WebParts/v2/DataView/runtime&quot; xmlns:asp=&quot;http://schemas.microsoft.com/ASPNET/20&quot; xmlns:__designer=&quot;http://schemas.microsoft.com/WebParts/v2/DataView/designer&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot; xmlns:msxsl=&quot;urn:schemas-microsoft-com:xslt&quot; xmlns:SharePoint=&quot;Microsoft.SharePoint.WebControls&quot; xmlns:ddwrt2=&quot;urn:frontpage:internal&quot;&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:output method=&quot;html&quot; indent=&quot;no&quot;/&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:decimal-format NaN=&quot;&quot;/&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:param name=&quot;dvt_apos&quot;&amp;gt;&amp;apos;&amp;lt;/xsl:param&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:variable name=&quot;dvt_1_automode&quot;&amp;gt;0&amp;lt;/xsl:variable&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:template match=&quot;/&quot;&amp;gt;&amp;#xD;&amp;#xA;		&amp;#xD;&amp;#xA;	&amp;lt;script language=&quot;javascript&quot;  type=&quot;text/javascript&quot;&amp;gt;&amp;#xD;&amp;#xA;	     &amp;#xD;&amp;#xA;	     function renderOffices() {&amp;#xD;&amp;#xA;	        &amp;lt;xsl:call-template name=&quot;dvt_1&quot; /&amp;gt;&amp;#xD;&amp;#xA;	     }&amp;#xD;&amp;#xA;		&amp;lt;/script&amp;gt; &amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1&quot;&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:variable name=&quot;Rows&quot; select=&quot;/dsQueryResponse/Rows/Row&quot;/&amp;gt;&amp;#xD;&amp;#xA;			&amp;lt;xsl:call-template name=&quot;dvt_1.body&quot;&amp;gt;&amp;#xD;&amp;#xA;				&amp;lt;xsl:with-param name=&quot;Rows&quot; select=&quot;$Rows&quot;/&amp;gt;&amp;#xD;&amp;#xA;			&amp;lt;/xsl:call-template&amp;gt;&amp;#xD;&amp;#xA;		&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1.body&quot;&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:param name=&quot;Rows&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;xsl:for-each select=&quot;$Rows&quot;&amp;gt;&amp;#xD;&amp;#xA;			&amp;lt;xsl:call-template name=&quot;dvt_1.rowview&quot;/&amp;gt;&amp;#xD;&amp;#xA;		&amp;lt;/xsl:for-each&amp;gt;&amp;#xD;&amp;#xA;		&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;	&amp;#xD;&amp;#xA;	&amp;lt;xsl:template name=&quot;dvt_1.rowview&quot;&amp;gt;&amp;#xD;&amp;#xA;		var off_point = new GLatLng(&amp;lt;xsl:value-of select=&quot;@gps_lat&quot;/&amp;gt;,&amp;lt;xsl:value-of select=&quot;@gps_long&quot;/&amp;gt;);&amp;#xD;&amp;#xA;	    var off_f&amp;lt;xsl:value-of select=&quot;@ID&quot;/&amp;gt; = function(){/*&amp;lt;xsl:value-of select=&quot;@desc&quot;/&amp;gt;*/};&amp;#xD;&amp;#xA;        var off_htmlComment = GetMultiLine(new String(off_f&amp;lt;xsl:value-of select=&quot;@ID&quot;/&amp;gt;));&amp;#xD;&amp;#xA;        var off_marker = createMarker(off_point,&amp;amp;quot;&amp;lt;xsl:value-of select=&quot;@Title&quot;/&amp;gt;&amp;amp;quot;, off_htmlComment,off_markerOptions );			&amp;#xD;&amp;#xA;   		map.addOverlay(off_marker);&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;     		&amp;#xD;&amp;#xA;	&amp;lt;/xsl:template&amp;gt;&amp;#xD;&amp;#xA;&amp;lt;/xsl:stylesheet&amp;gt;	' /&gt;&lt;P N='DataFields' T='&amp;#xD;&amp;#xA;@Title,office;@location,location;@gps_lat,gps_lat;@gps_long,gps_long;@desc,desc;@ID,ID;@ContentType,Content Type;@Modified,Modified;@Created,Created;@Author,Created By;@Editor,Modified By;@_UIVersionString,Version;@Attachments,Attachments;@File_x0020_Type,File Type;@FileLeafRef,Name (for use in forms);@FileDirRef,Path;@FSObjType,Item Type;@_HasCopyDestinations,Has Copy Destinations;@_CopySource,Copy Source;@ContentTypeId,Content Type ID;@_ModerationStatus,Approval Status;@_UIVersion,UI Version;@Created_x0020_Date,Created;@FileRef,URL Path;' /&gt;&lt;P N='NoDefaultStyle' T='TRUE' /&gt;&lt;P N='ParameterBindings' T='&amp;#xD;&amp;#xA;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;ListID&quot; Location=&quot;None&quot; DefaultValue=&quot;CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB&quot;/&amp;gt;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;dvt_apos&quot; Location=&quot;Postback;Connection&quot;/&amp;gt;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;UserID&quot; Location=&quot;CAMLVariable&quot; DefaultValue=&quot;CurrentUserName&quot;/&amp;gt;&amp;#xD;&amp;#xA;				   &amp;lt;ParameterBinding Name=&quot;Today&quot; Location=&quot;CAMLVariable&quot; DefaultValue=&quot;CurrentDate&quot;/&amp;gt;&amp;#xD;&amp;#xA;			   ' /&gt;&lt;P N='ParameterValues' Serial='AAEAAAD/////AQAAAAAAAAAMAgAAAFhNaWNyb3NvZnQuU2hhcmVQb2ludCwgVmVyc2lvbj0xMi4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj03MWU5YmNlMTExZTk0MjljBQEAAAA9TWljcm9zb2Z0LlNoYXJlUG9pbnQuV2ViUGFydFBhZ2VzLlBhcmFtZXRlck5hbWVWYWx1ZUhhc2h0YWJsZQEAAAAFX2NvbGwDHFN5c3RlbS5Db2xsZWN0aW9ucy5IYXNodGFibGUCAAAACgs' /&gt;&lt;P N='FilterValues' Serial='AAEAAAD/////AQAAAAAAAAAMAgAAAFhNaWNyb3NvZnQuU2hhcmVQb2ludCwgVmVyc2lvbj0xMi4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj03MWU5YmNlMTExZTk0MjljBQEAAAA9TWljcm9zb2Z0LlNoYXJlUG9pbnQuV2ViUGFydFBhZ2VzLlBhcmFtZXRlck5hbWVWYWx1ZUhhc2h0YWJsZQEAAAAFX2NvbGwDHFN5c3RlbS5Db2xsZWN0aW9ucy5IYXNodGFibGUCAAAACgs' /&gt;&lt;P N='Title' R='1' /&gt;&lt;P N='ZoneID' T='Left' /&gt;&lt;P N='PartOrder' T='2' /&gt;&lt;P N='ID' T='g_079bfc03_d0b9_4e0c_a279_3a2c4f62645a' /&gt;&lt;P N='StorageKey' T='079bfc03-d0b9-4e0c-a279-3a2c4f62645a' /&gt;&lt;P N='UseDefaultStyles' T='False' /&gt;&lt;P N='Qualifier' T='WPQ2' /&gt;&lt;P N='ClientName' T='varPartWPQ2' /&gt;&lt;P N='Permissions' E='0' /&gt;&lt;P N='EffectiveTitle' R='1' /&gt;&lt;P N='EffectiveStorage' E='2' /&gt;&lt;P N='EffectiveFrameType' E='2' /&gt;&lt;P N='DisplayTitle' R='1' /&gt;&lt;P N='ExportMode' E='1' /&gt;&lt;P N='IsShared' T='True' /&gt;&lt;P N='IsStandalone' T='False' /&gt;&lt;P N='IsStatic' T='False' /&gt;&lt;P N='WebBrowsableObject' R='0' /&gt;&lt;P N='ZoneIndex' T='2' /&gt;&lt;P N='Font' ID='2' /&gt;&lt;P N='Page' ID='3' /&gt;&lt;P N='TemplateControl' R='3' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;" __MarkupType="vsattributemarkup" __WebPartId="{079BFC03-D0B9-4E0C-A279-3A2C4F62645A}" __AllowXSLTEditing="true" WebPart="true" Height="" Width=""><DataSources>
<SharePoint:SPDataSource runat="server" DataSourceMode="List" SelectCommand="&lt;View&gt;&lt;/View&gt;" UseInternalName="True" ID="offices1"><SelectParameters>
<WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB" Name="ListID"></WebPartPages:DataFormParameter>
</SelectParameters>
<UpdateParameters>
<WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB" Name="ListID"></WebPartPages:DataFormParameter>
</UpdateParameters>
<InsertParameters>
<WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB" Name="ListID"></WebPartPages:DataFormParameter>
</InsertParameters>
<DeleteParameters>
<WebPartPages:DataFormParameter ParameterKey="ListID" PropertyName="ParameterValues" DefaultValue="CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB" Name="ListID"></WebPartPages:DataFormParameter>
</DeleteParameters>
</SharePoint:SPDataSource>
</DataSources>
<ParameterBindings>


				   <ParameterBinding Name="ListID" Location="None" DefaultValue="CCCCCA7B-DA97-4FB5-8A38-733C984ED0DB"/>
				   <ParameterBinding Name="dvt_apos" Location="Postback;Connection"/>
				   <ParameterBinding Name="UserID" Location="CAMLVariable" DefaultValue="CurrentUserName"/>
				   <ParameterBinding Name="Today" Location="CAMLVariable" DefaultValue="CurrentDate"/>
			   </ParameterBindings>
<DataFields>

@Title,office;@location,location;@gps_lat,gps_lat;@gps_long,gps_long;@desc,desc;@ID,ID;@ContentType,Content Type;@Modified,Modified;@Created,Created;@Author,Created By;@Editor,Modified By;@_UIVersionString,Version;@Attachments,Attachments;@File_x0020_Type,File Type;@FileLeafRef,Name (for use in forms);@FileDirRef,Path;@FSObjType,Item Type;@_HasCopyDestinations,Has Copy Destinations;@_CopySource,Copy Source;@ContentTypeId,Content Type ID;@_ModerationStatus,Approval Status;@_UIVersion,UI Version;@Created_x0020_Date,Created;@FileRef,URL Path;</DataFields>
<Xsl>



<xsl:stylesheet xmlns:x="http://www.w3.org/2001/XMLSchema" xmlns:d="http://schemas.microsoft.com/sharepoint/dsp" version="1.0" exclude-result-prefixes="xsl msxsl ddwrt" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:SharePoint="Microsoft.SharePoint.WebControls" xmlns:ddwrt2="urn:frontpage:internal">
	<xsl:output method="html" indent="no"/>
	<xsl:decimal-format NaN=""/>
	<xsl:param name="dvt_apos">'</xsl:param>
	<xsl:variable name="dvt_1_automode">0</xsl:variable>
	<xsl:template match="/">
		
	<script language="javascript"  type="text/javascript">
	     
	     function renderOffices() {
	        <xsl:call-template name="dvt_1" />
	     }
		</script> </xsl:template>
	<xsl:template name="dvt_1">
		<xsl:variable name="Rows" select="/dsQueryResponse/Rows/Row"/>
			<xsl:call-template name="dvt_1.body">
				<xsl:with-param name="Rows" select="$Rows"/>
			</xsl:call-template>
		
	</xsl:template>
	<xsl:template name="dvt_1.body">
		<xsl:param name="Rows"/>
		<xsl:for-each select="$Rows">
			<xsl:call-template name="dvt_1.rowview"/>
		</xsl:for-each>
		
	</xsl:template>
	
	<xsl:template name="dvt_1.rowview">
		var off_point = new GLatLng(<xsl:value-of select="@gps_lat"/>,<xsl:value-of select="@gps_long"/>);
	    var off_f<xsl:value-of select="@ID"/> = function(){/*<xsl:value-of select="@desc"/>*/};
        var off_htmlComment = GetMultiLine(new String(off_f<xsl:value-of select="@ID"/>));
        var off_marker = createMarker(off_point,&quot;<xsl:value-of select="@Title"/>&quot;, off_htmlComment,off_markerOptions );			
   		map.addOverlay(off_marker);

     		
	</xsl:template>
</xsl:stylesheet>	</Xsl>
</WebPartPages:DataFormWebPart>

</ZoneTemplate></WebPartPages:WebPartZone>
			   &nbsp;
		   </td>
		   <td>&nbsp;</td>
		   <td valign="top" width="30%">
			   <WebPartPages:WebPartZone runat="server" FrameType="TitleBarOnly" ID="Right" Title="loc:Right" __designer:Preview="&lt;Regions&gt;&lt;Region Name=&quot;0&quot; Editable=&quot;True&quot; Content=&quot;&quot; NamingContainer=&quot;True&quot; /&gt;&lt;/Regions&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;0&quot; border=&quot;0&quot; id=&quot;Right&quot;&gt;
	&lt;tr&gt;
		&lt;td style=&quot;white-space:nowrap;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
			&lt;tr&gt;
				&lt;td style=&quot;white-space:nowrap;&quot;&gt;Right&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;&lt;tr&gt;
		&lt;td style=&quot;height:100%;&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;border-color:Gray;border-width:1px;border-style:Solid;width:100%;height:100%;&quot;&gt;
			&lt;tr valign=&quot;top&quot;&gt;
				&lt;td _designerRegion=&quot;0&quot;&gt;&lt;table cellspacing=&quot;0&quot; cellpadding=&quot;2&quot; border=&quot;0&quot; style=&quot;width:100%;&quot;&gt;
					&lt;tr&gt;
						&lt;td style=&quot;height:100%;&quot;&gt;&lt;/td&gt;
					&lt;/tr&gt;
				&lt;/table&gt;&lt;/td&gt;
			&lt;/tr&gt;
		&lt;/table&gt;&lt;/td&gt;
	&lt;/tr&gt;
&lt;/table&gt;" __designer:Values="&lt;P N='FrameType' E='2' /&gt;&lt;P N='Title' ID='1' T='Right' /&gt;&lt;P N='HeaderText' T='loc:Right' /&gt;&lt;P N='DisplayTitle' R='1' /&gt;&lt;P N='MenuPopupStyle'&gt;&lt;P N='CellPadding' T='1' /&gt;&lt;P N='CellSpacing' T='0' /&gt;&lt;/P&gt;&lt;P N='PartChromeType' E='3' /&gt;&lt;P N='ControlStyle'&gt;&lt;P N='BorderColor' T='Gray' /&gt;&lt;P N='BorderWidth' T='1px' /&gt;&lt;P N='BorderStyle' E='4' /&gt;&lt;P N='Font' ID='2' /&gt;&lt;/P&gt;&lt;P N='Font' R='2' /&gt;&lt;P N='ID' R='1' /&gt;&lt;P N='Page' ID='3' /&gt;&lt;P N='TemplateControl' R='3' /&gt;&lt;P N='AppRelativeTemplateSourceDirectory' T='~/' /&gt;" __designer:Templates="&lt;Group Name=&quot;ZoneTemplate&quot;&gt;&lt;Template Name=&quot;ZoneTemplate&quot; Content=&quot;&quot; /&gt;&lt;/Group&gt;"><ZoneTemplate></ZoneTemplate></WebPartPages:WebPartZone>
			   &nbsp;
		   	</td>
		   <td>&nbsp;</td>
		  </tr>
		 </table>
		</td>
	  </tr>
	</table>
</asp:Content>
<asp:Content id="Content1" runat="server" contentplaceholderid="PlaceHolderUtilityContent">
	<Script language="javascript" type="text/javascript">Rendermap();</Script> 
	</asp:Content>