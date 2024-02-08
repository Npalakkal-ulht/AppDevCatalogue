<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AppDevCatalogue._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetApplications" UpdateMethod="UpdateApplication" OnUpdating="ObjectDataSource1_Updating" OnInserting="ObjectDataSource1_Inserting" TypeName="BLL.ApplicationBLL" DataObjectTypeName="BusinessObjects.ApplicationBO" InsertMethod="InsertApplication"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GetApplicationTypes" runat="server" SelectMethod="GetApplicationTypes" TypeName="BLL.ApplicationBLL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GetCriticalityTypes" runat="server" SelectMethod="GetCriticalityTypes" TypeName="BLL.ApplicationBLL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GetServers" runat="server" SelectMethod="GetServers" TypeName="BLL.ApplicationBLL"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GetApplicationsStatus" runat="server" SelectMethod="GetApplicationsStatus" TypeName="BLL.ApplicationBLL"></asp:ObjectDataSource>

    <div>
        <dx:ASPxGridView ID="AppDevCatalogueGridView" runat="server"
            ClientInstanceName="AppDevCatalogueGridView" KeyFieldName="ApplicationID" DataSourceID="ObjectDataSource1"
            OnCommandButtonInitialize="AppDevCatalogueGridView_CommandButtonInitialize"
            OnInit="AppDevCatalogueGridView_Init" AutoGenerateColumns="False">

            <SettingsAdaptivity AdaptivityMode="HideDataCellsWindowLimit" HideDataCellsAtWindowInnerWidth="780" AllowOnlyOneAdaptiveDetailExpanded="true" AdaptiveDetailColumnCount="2"></SettingsAdaptivity>

            <SettingsPopup>
                <FilterControl AutoUpdatePosition="False"></FilterControl>
            </SettingsPopup>

            <EditFormLayoutProperties>
                <Items>

                    <dx:GridViewColumnLayoutItem ColumnName="Application Name" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem Caption="Application Type" ColumnName="AppTypeID" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem Caption="Criticality" ColumnName="CriticalityID" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="ApplicationDescription" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem Caption="Application Server" ColumnName="AppServerID" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem Caption="Database Server" ColumnName="DBServerID" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <%-- <dx:GridViewColumnLayoutItem ColumnName="APPServerName" ColSpan="1"></dx:GridViewColumnLayoutItem>--%>
                    <%--<dx:GridViewColumnLayoutItem ColumnName="ServerID" ColSpan="1"></dx:GridViewColumnLayoutItem>--%>
                    <%-- <dx:GridViewColumnLayoutItem ColumnName="DBServerName" ColSpan="1"></dx:GridViewColumnLayoutItem>--%>
                    <dx:GridViewColumnLayoutItem Caption="Database Name" ColumnName="DBName" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="AppURL" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="ADLinked" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="NotesID" ClientVisible="false" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="ApplicationNotesText" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="AppStatusID" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <%--<dx:GridViewColumnLayoutItem ColumnName="StatusName" ColSpan="1"></dx:GridViewColumnLayoutItem>--%>
                    <dx:GridViewColumnLayoutItem ColumnName="DateCreated" ClientVisible="false" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="CreatedByUserID" ClientVisible="false" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="DateLastEdited" ClientVisible="false" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="EditedByUserID" ClientVisible="false" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:GridViewColumnLayoutItem ColumnName="IsActive" ColSpan="1"></dx:GridViewColumnLayoutItem>
                    <dx:EditModeCommandLayoutItem ColSpan="1"></dx:EditModeCommandLayoutItem>
                </Items>

            </EditFormLayoutProperties>

            <%--   <SettingsDataSecurity AllowInsert="false" />
        <EditFormLayoutProperties>
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
        </EditFormLayoutProperties>
        <SettingsPopup>
            <EditForm Width="600">
                <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" />
            </EditForm>
        </SettingsPopup>--%>
            <Columns>
                <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowEditButton="true"></dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="ApplicationName" VisibleIndex="2" Width="150px"></dx:GridViewDataTextColumn>
             <%--   <asp:RequiredFieldValidator
                    ControlToValidate="ApplicationName"
                    runat="server"
                    ErrorMessage="Please enter a Applicaiton Name"
                    Text="*" />--%>
                <dx:GridViewDataComboBoxColumn Caption="Application Type" FieldName="AppTypeID" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox DataSourceID="GetApplicationTypes" TextField="AppTypeName" ValueField="AppTypeID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <%--<asp:RequiredFieldValidator
                    ControlToValidate="AppTypeID"
                    runat="server"
                    ErrorMessage="Please enter a Application Type"
                    Text="*" />--%>
                <%--<dx:GridViewDataTextColumn FieldName="CriticalityID" VisibleIndex="5" Width="150px"></dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataComboBoxColumn Caption="Criticality" FieldName="CriticalityID" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox DataSourceID="GetCriticalityTypes" TextField="CriticalityName" ValueField="CriticalityID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <%--<asp:RequiredFieldValidator
                    ControlToValidate="CriticalityID"
                    runat="server"
                    ErrorMessage="Please enter a Criticality Name"
                    Text="*" />--%>
                <dx:GridViewDataTextColumn FieldName="ApplicationDescription" VisibleIndex="6" Width="150px"></dx:GridViewDataTextColumn>
                <%--<asp:RequiredFieldValidator
                    ControlToValidate="ApplicationDescription"
                    runat="server"
                    ErrorMessage="Please enter a Application Description"
                    Text="*" />--%>
                <dx:GridViewDataComboBoxColumn Caption="Application Server" FieldName="AppServerID" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox DataSourceID="GetServers" TextField="ServerName" ValueField="ServerID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Database Server" FieldName="DBServerID" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox DataSourceID="GetServers" TextField="ServerName" ValueField="ServerID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn Caption="Database Name" FieldName="DBName" VisibleIndex="11" Width="150px"></dx:GridViewDataTextColumn>

                <dx:GridViewDataHyperLinkColumn FieldName="AppURL" VisibleIndex="1">
                    <PropertiesHyperLinkEdit NavigateUrlFormatString="AppURL"
                        TextField="AppURL" />
                </dx:GridViewDataHyperLinkColumn>

                <%--<dx:GridViewDataTextColumn FieldName="AppURL" VisibleIndex="12" Width="150px"></dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataComboBoxColumn Caption="ADL inked" FieldName="ADLinked" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="True" Value="True" />
                            <dx:ListEditItem Text="False" Value="False" />
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>

                <%--<dx:GridViewDataTextColumn FieldName="ADLinked" VisibleIndex="13" Width="150px"></dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataTextColumn FieldName="NotesID" Visible="false" VisibleIndex="14" Width="150px"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="ApplicationNotesText" VisibleIndex="14" Width="150px"></dx:GridViewDataTextColumn>
                <%--<dx:GridViewDataTextColumn FieldName="AppStatusID"  VisibleIndex="15" Width="150px"></dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataComboBoxColumn FieldName="AppStatusID" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox DataSourceID="GetApplicationsStatus" TextField="StatusName" ValueField="StatusID"></PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <%--<dx:GridViewDataDateColumn FieldName="DateCreated" client VisibleIndex="16" Width="150px"></dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CreatedByUserID" VisibleIndex="17" Width="150px"></dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="DateLastEdited" VisibleIndex="18" Width="150px"></dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="EditedByUserID" VisibleIndex="19" Width="150px"></dx:GridViewDataTextColumn>--%>
                <%--<dx:GridViewDataTextColumn FieldName="IsActive" VisibleIndex="20" Width="150px"></dx:GridViewDataTextColumn>--%>
                <dx:GridViewDataComboBoxColumn Caption="Is Active" FieldName="IsActive" VisibleIndex="3" Width="150px">
                    <PropertiesComboBox>
                        <Items>
                            <dx:ListEditItem Text="True" Value="True" />
                            <dx:ListEditItem Text="False" Value="False" />
                        </Items>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
            </Columns>
        </dx:ASPxGridView>

    </div>


</asp:Content>
