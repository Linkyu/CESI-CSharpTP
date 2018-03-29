<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexPeople.aspx.cs" Inherits="PeopleByET.View.IndexPeople" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SHARPEOPLE</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="PeopleTable" runat="server" >
                <HeaderTemplate>
                    <table>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Height</th>
                        <th>Weight</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                <tr>
                    <td bgcolor="#CCFFCC">
                    <asp:Label runat="server" ID="Label1" 
                        text='<%# DataBinder.Eval(Container.DataItem,"Id") %>' />
                    </td>

                    <td bgcolor="#CCFFCC">
                        <asp:Label runat="server" ID="Label2" 
                            text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' />
                    </td>

                    <td bgcolor="#CCFFCC">
                        <asp:Label runat="server" ID="Label3" 
                            text='<%#  DataBinder.Eval(Container.DataItem,"Height") %>' />
                    </td>

                    <td bgcolor="#CCFFCC">
                        <asp:Label runat="server" ID="Label4" 
                            text='<%#  DataBinder.Eval(Container.DataItem,"Weight") %>' />
                    </td>
                    <td>
                     <asp:LinkButton ID="btnDelete" Runat="server" CommandName="delete" 
                       CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'>Delete</asp:LinkButton></td>
                    </td>

                    <td>
                     <asp:LinkButton ID="btnUpdate" Runat="server" CommandName="update" 
                       CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Id") %>'>Update</asp:LinkButton></td>
                    </td>


                </tr>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <p style="width: 125px">
            Name</p>
        <asp:TextBox ID="NameBox" runat="server" ></asp:TextBox>
        <br />
        <br />
        Height<p>
            <asp:TextBox ID="HeightBox" runat="server"></asp:TextBox>
        </p>
        <p>
            Weight</p>
        <p>
            <asp:TextBox ID="WeightBox" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="CreateUpdate" runat="server" OnClick="CreateOrUpdateMethod" Text="Create Or Update" Width="135px" />
        <asp:TextBox ID="IdBox" runat="server" Visible="False"></asp:TextBox>
    </form>
</body>
</html>





