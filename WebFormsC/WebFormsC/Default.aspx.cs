using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameCheckBox.Text.Trim();
            string result = "Hello, " + firstName + " " + lastName +"!";
            resultLabel.Text = result;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string age = TextBox1.Text.Trim();
            string wealth = TextBox2.Text;
            int num = Convert.ToInt32(TextBox2.Text);
            Label1.Text = age;
            Label2.Text = wealth;
            if (num < 33)
            {
                Label3.Text = "You Suck";
            }
            else
            {
                Label3.Text = "";
            }
        }
    }
}