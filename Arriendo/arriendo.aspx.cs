using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class arriendo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txt_Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Pelicula/nomina_Pelicula.aspx");
    }
}