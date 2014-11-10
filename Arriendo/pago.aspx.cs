using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Arriendo_pago : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id_cliente = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_cliente"]);
        int id_staff = Convert.ToInt32(Request.Form["ctl00$ContentPlaceHolder1$ddl_staff"]);
        var fecha = (Request.Form["ctl00$ContentPlaceHolder1$cdl_devolucion"]);

        SqlConnection recuperar_datos = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand inserta_datos = new SqlCommand("insert into dbo.rental(customer_id,staff_id,return_date) values(@v_cliente,@v_staff,@v_fecha);", recuperar_datos);
        SqlCommand consulta_datos = new SqlCommand("SELECT a.rental_id, a.staff_id, a.customer_id, b.name, c.name FROM dbo.rental as a, customer_list as b,staff_list as c where a.customer_id=b.ID and a.staff_id=c.ID ORDER BY rental_id DESC;", recuperar_datos);
        inserta_datos.Parameters.AddWithValue("@v_cliente", id_cliente);
        inserta_datos.Parameters.AddWithValue("@v_staff", id_staff);
        inserta_datos.Parameters.AddWithValue("@v_fecha", fecha);
        
        try
        {
            recuperar_datos.Open();
            SqlDataReader obtiene_datos = consulta_datos.ExecuteReader();
            obtiene_datos.Read();
            var id_renta = obtiene_datos["rental_id"].ToString();
            hdn_renta.Value = id_renta;
            var cliente = obtiene_datos["customer_id"].ToString();
            hdn_cliente.Value = cliente;
            var staff = obtiene_datos["staff_id"].ToString();
            hdn_staff.Value = staff;
            lbl_nombre.Text = obtiene_datos.GetString(3).ToString();
            lbl_staff.Text = obtiene_datos.GetString(4).ToString();
        }
        catch (Exception ex)
        {
            lbl_estado.Text = "Se ha producido un problema al obtener los datos. " + ex.Message;

        }
        recuperar_datos.Close();
    }
    protected void cmd_arrendar_Click(object sender, EventArgs e)
    {
        SqlConnection conexionSakila = new SqlConnection(ConfigurationManager.ConnectionStrings["sakilaConnectionString"].ToString());
        SqlCommand inserta_cliente = new SqlCommand("insert into dbo.payment(customer_id,staff_id,rental_id,amount,payment_date) values(@v_cliente,@v_staff,@v_renta,@v_costo,@v_fecha)", conexionSakila);
        inserta_cliente.Parameters.AddWithValue("@v_cliente", hdn_cliente.Value);
        inserta_cliente.Parameters.AddWithValue("@v_staff", hdn_staff.Value);
        inserta_cliente.Parameters.AddWithValue("@v_renta", hdn_renta.Value);
        inserta_cliente.Parameters.AddWithValue("@v_costo", txt_precio.Text);
        inserta_cliente.Parameters.AddWithValue("@v_fecha", cld_fechaPago.SelectedDate);

        try
        {
            conexionSakila.Open();
            inserta_cliente.ExecuteNonQuery();
            Response.Redirect("/Pelicula/nomina_Pelicula.aspx");
        }
        catch (Exception ex)
        {

            lbl_estado.Text = "Error al arrendar " + ex.Message;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Pelicula/nomina_Pelicula.aspx");
    }
}