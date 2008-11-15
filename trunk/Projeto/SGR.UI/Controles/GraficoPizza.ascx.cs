using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using SGR.BP.Objeto.Home.Entidade;
using SGR.BP.Objeto.Home;

public partial class Controles_GraficoPizza : System.Web.UI.UserControl
{

    SolidBrush[] brushes = {   
        new SolidBrush(Color.DarkRed),
        new SolidBrush(Color.Red),
        new SolidBrush(Color.DarkOrange),
        new SolidBrush(Color.Orange),
        new SolidBrush(Color.Beige),
        new SolidBrush(Color.Yellow),
        new SolidBrush(Color.GreenYellow),
        new SolidBrush(Color.Green),
        new SolidBrush(Color.DarkGreen),
        new SolidBrush(Color.LightGreen),
        new SolidBrush(Color.Pink)};
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GerarGraficoPizza();
    }

    private void GerarGraficoPizza()
    {
        using (Bitmap imagemRetorno = new Bitmap(200, 400, PixelFormat.Format24bppRgb))
        {
            using (Graphics grafico = Graphics.FromImage(imagemRetorno))
            {
                grafico.Clear(Color.White);
                double anguloSomatorio = 0.0;
                double percentualAcumulado = 0.0;
                SolidBrush brush = null;
                float posicaoLegenda = 210.0F;
                double percentual = 0.0;
                int brushIndex = 0;
                List<ResiduoGrafico> residuos = Home.Residuos(Meses, Quantidade);
                foreach (ResiduoGrafico residuo in residuos)
                {

                    percentualAcumulado += residuo.Percentual;
                    percentual = residuo.Percentual * 360;
                  
                    brush = brushes[brushIndex];
                 
                    grafico.FillPie(brush, 0.0F, 0.0F, 180.0F, 180.0F, (float)(anguloSomatorio), (float)(percentual));

                    //legenda
                    grafico.FillRectangle(brush, 25, posicaoLegenda, 10, 10);
                    grafico.DrawString(residuo.Nome, new Font("Verdana", 7, FontStyle.Bold), Brushes.Black, 38, posicaoLegenda);

                    anguloSomatorio += percentual;
                    posicaoLegenda += 12;
                    brushIndex++;
                }
            }
            imagemRetorno.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
        }
        Response.ContentType = "image/gif";

    }
    
    public int Quantidade
    {
        get 
        { 
            return (int)ViewState["_Quantidade"]; 
        }
        set 
        { 
            ViewState["_Quantidade"] = value; 
        }
    }
	
    public int Meses
    {
        get 
        {
            return (int)ViewState["_Meses"]; 
        }
        set 
        {
            ViewState["_Meses"] = value; 
        }
    }

}


