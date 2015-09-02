using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LearningC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int number1 = int.Parse(TextBox1.Text.Trim());
            var number2 = int.Parse(TextBox2.Text.Trim());
            var result = number1 * number2;
            Label1.Text = result.ToString();
        }
    }
}