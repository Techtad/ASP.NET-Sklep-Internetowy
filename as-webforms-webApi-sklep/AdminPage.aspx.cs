﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data;

namespace f3b_store
{
    public partial class AdminPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Tak tylko dla sprawdzenia czy działa
            if (!Page.IsPostBack)
            {
                if (Session["usertoken"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else if (AccountOperations.getAccessLevel(Session["usertoken"].ToString()) != AccessLevel.ADMIN && AccountOperations.getAccessLevel(Session["usertoken"].ToString()) != AccessLevel.ROOT)
                {
                    lTest.Text = "Nie jesteś adminem.";
                }
                else
                {
                    gvUsers.DataSource = DBOperations.selectTable("users");
                    gvUsers.DataBind();

                    gvProducts.DataSource = DBOperations.selectTable("product_info");
                    gvProducts.DataBind();

                    gvOrders.DataSource = DBOperations.selectTable("orders");
                    gvOrders.DataBind();


                    addCat.DataSource = DBOperations.selectTable("product_categories");
                    addCat.DataTextField = "name";
                    addCat.DataValueField = "id";
                    addCat.DataBind();

                }
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                Debug.WriteLine(e.CommandArgument.ToString());

                if (AccountOperations.deleteUser(e.CommandArgument.ToString()))
                    Debug.WriteLine("Deleted user with id: " + e.CommandArgument.ToString());
                else
                    Debug.WriteLine("Failed to delete user with id: " + e.CommandArgument.ToString());

                gvUsers.DataSource = DBOperations.selectTable("users");
                gvUsers.DataBind();
            }
            else if (e.CommandName == "UpdateUser")
            {
                Debug.WriteLine(e.CommandArgument.ToString());
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string id = commandArgs[0];
                string access = commandArgs[1];

                if(AccountOperations.updateAccess(id,access == "1" ? "0" : "1"))
                    Debug.WriteLine("Updated access for user with id: " + id + " to: " + access);
                else
                    Debug.WriteLine("Failed to update access for user with id: " + id + " to: " + access);

                gvUsers.DataSource = DBOperations.selectTable("users");
                gvUsers.DataBind();
            }
        }

        public static string ProcessAccessLevel(object myValue)
        {
            if (myValue == null)
            {
                return "error";
            }
            else
            {
                if (Convert.ToInt32(myValue) == 1)
                    return "Demote";
                else if (Convert.ToInt32(myValue) == 0)
                    return "Promote";
                else
                    return "";
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void updateOrderState(object sender, EventArgs e)
        {
            GridViewRow gvr = ((DropDownList)sender).NamingContainer as GridViewRow;
            var list = gvr.FindControl("orderStateList") as DropDownList;
            string val = list.SelectedValue;
            HiddenField hf1 = (HiddenField)gvr.FindControl("hiddenID");
            string id = hf1.Value;
            DBOperations.updateOrder(id,val);
            gvOrders.DataSource = DBOperations.selectTable("orders");
            gvOrders.DataBind();
        }

        protected void Orders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl = e.Row.FindControl("orderStateList") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = DBOperations.selectTable("order_states");
                    ddl.DataTextField = "name";
                    ddl.DataValueField = "id";
                    ddl.DataBind();
                    ddl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "state").ToString();
                }

                string userId = e.Row.Cells[1].Text;
                var usernameQuery = DBOperations.selectQuery("SELECT username FROM users WHERE id LIKE '" + userId + "'");
                if (usernameQuery.Rows.Count == 1)
                    e.Row.Cells[1].Text = usernameQuery.Rows[0]["username"].ToString();
            }
        }

        // products

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void updateProductCat(object sender, EventArgs e)
        {
            GridViewRow gvr = ((DropDownList)sender).NamingContainer as GridViewRow;
            var list = gvr.FindControl("productsCatList") as DropDownList;
            string val = list.SelectedValue;
            HiddenField hf1 = (HiddenField)gvr.FindControl("hiddenID");
            string id = hf1.Value;
            DBOperations.updateProductCategory(id, val);
            gvProducts.DataSource = DBOperations.selectTable("product_info");
            gvProducts.DataBind();
        }

        protected void Products_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl = e.Row.FindControl("productsCatList") as DropDownList;
                if (ddl != null)
                {
                    ddl.DataSource = DBOperations.selectTable("product_categories");
                    ddl.DataTextField = "name";
                    ddl.DataValueField = "id";
                    ddl.DataBind();
                    ddl.SelectedValue = DataBinder.Eval(e.Row.DataItem, "category").ToString();
                }
            }
        }

        protected void tbProduct_Update(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GridViewRow gvr = textBox.NamingContainer as GridViewRow;
            HiddenField hf1 = (HiddenField)gvr.FindControl("hiddenID");
            string id = hf1.Value;
            string val = textBox.Text;
            // remove 9 first chars from id to recognize column name
            string column = textBox.ID.Substring(9, textBox.ID.Length - 9).ToLower();
            DBOperations.updateProductCol(id, column, val);
        }

        protected void addBT_Click(object sender, EventArgs e)
        {
            if(addName.Text.Length > 0 && addImg.Text.Length > 0 && addDesc.Text.Length > 0 && addPrice.Text.Length > 0 && addSupp.Text.Length > 0)
            {
                DBOperations.addProduct(addCat.SelectedValue, addName.Text, addImg.Text, addDesc.Text, addPrice.Text, addSupp.Text);
                gvProducts.DataSource = DBOperations.selectTable("product_info");
                gvProducts.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Wszystkie pola muszą być wypełnione!')</script>");
            }
        }
    }
}