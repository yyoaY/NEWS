using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;

public partial class ValidCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (Bitmap image = new Bitmap(30, 20))
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.FillRectangle(Brushes.LightPink, 0, 0, 100, 50);
                g.DrawRectangle(Pens.LightYellow, 0, 0, 99, 49);
                Font f = new Font("Arial", 9, FontStyle.Italic);
                string code = Request.QueryString["code"];
                g.DrawString(code, f, Brushes.White, 0, 0);
                Response.ContentType = "image/Gif";
                image.Save(Response.OutputStream, ImageFormat.Gif);

                //Session保存验证码的值，传递给LoginPage.aspx.cs
                Session["Code"] = code.Trim();
            }
        }
    }

}