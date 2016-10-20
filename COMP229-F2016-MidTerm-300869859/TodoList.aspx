<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm_300869859.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <a href="TodoDetails.aspx" class="btn btn-success btn-sm">
                    <i class="fa fa-plus"></i> Add Todo
                </a>
  <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover" DataKeyNames="TodoID"
                    OnRowDeleting="GridView_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" />
                        <asp:BoundField DataField="TodoDescription" HeaderText="Todo Description" Visible="true" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Todo Notes" Visible="true" />
                        <asp:templatefield HeaderText="Completed">
                        <itemtemplate>
                        <asp:checkbox ID="CheckBox" 
                          runat="server"></asp:checkbox>
                        </itemtemplate>
                        </asp:templatefield>
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm"
                            runat="server" DataNavigateUrlFields="TodoID"
                            DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />

                             <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
</asp:Content>
