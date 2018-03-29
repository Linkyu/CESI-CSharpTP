using System;
using System.Collections.Generic;
using System.Linq;
using SHARPEOPLE_LIB;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHARPEOPLE_HOST
{
    public partial class IndexPeople : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            base.OnInit(e);
            PeopleTable.ItemCommand += new RepeaterCommandEventHandler(PeopleTable_ItemCommand);
        }

        private void PeopleTable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
	        
	        var serv = new PeopleService();
            switch (e.CommandName)
            {
                case "update":
	                var updatedPeople = serv.GetPeople(Convert.ToInt32(e.CommandArgument));
                    NameBox.Text = Convert.ToString(updatedPeople.Name);
                    HeightBox.Text = Convert.ToString(updatedPeople.Height);
                    WeightBox.Text = Convert.ToString(updatedPeople.Weight);
                    IdBox.Text = Convert.ToString(updatedPeople.Id);
                    break;
                case "delete":
                    serv.DelPeople(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
            
            //Refresh data
	        PeopleTable.DataSource = serv.GetPeoples();
            PeopleTable.DataBind();
           
        }

        protected void PageLoad(object sender, EventArgs e)
        {
            var serv = new PeopleService();
	        var people = serv.GetPeoples();
            PeopleTable.DataSource = people;
            PeopleTable.DataBind();
        }


        protected void CreateOrUpdateMethod(object sender, EventArgs e)
        {
            var serv = new PeopleService();

            if (string.IsNullOrEmpty(IdBox.Text))
            {
                serv.AddPeople(NameBox.Text, Convert.ToInt32(WeightBox.Text), Convert.ToInt32(HeightBox.Text));
            }
            else
            {
                serv.SetPeople(Convert.ToInt32(IdBox.Text), NameBox.Text, Convert.ToInt32(WeightBox.Text), Convert.ToInt32(HeightBox.Text));
            }

            NameBox.Text = string.Empty;
            WeightBox.Text = string.Empty;
            HeightBox.Text = string.Empty;
            IdBox.Text = string.Empty;

            //Refresh data
            PeopleTable.DataSource = serv.GetPeoples();
            PeopleTable.DataBind();
        }
    }
}