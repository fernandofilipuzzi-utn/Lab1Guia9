using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_Infracciones2
{
    /// <summary>
    /// un acta tiene muchas multas
    /// </summary>
    class SistemaInfracciones
    {
        #region tabla multas
        int TIPO_1_MONTO = 25;
        string TIPO_1_DESCRP = "Sin luces bajas, ley 25….";
        int TIPO_2_MONTO = 30;
        string TIPO_2_DESCRP = "Falta de Matafuego, ley 2…";
        int TIPO_3_MONTO = 100;
        string TIPO_3_DESCRP = "Sobrevelocidad";
        int TIPO_4_MONTO = 85;
        string TIPO_4_DESCRP = "Falta de cinturón de seguridad (>2 ejes) o falta de casco (1 eje)";
        int TIPO_5_MONTO = 1500;
        string TIPO_5_DESCRP = "Falta de respeto A la autoridad";
        #endregion

        #region del sistema de infracciones
        public double BaseMonetaria { get; private set; }
        public double Recaudacion { get; private set; }
        #endregion

        #region por acta
        public int DniActa { get; private set; }
        public string NombreActa { get; private set; }
        int tipoVehiculo;
        public double SubTotalActa { get; private set; }
        public double AjusteTipoVehiculo { get; private set; }
        public double SubTotalAjustadoActa { get; private set; }
        public double DescuentoPagoActa { get; private set; }
        public double TotalActaAPagar { get; private set; }
        #endregion

        #region por infracción
        public int CodigoInfraccion { get;  private set; }
        public string DescripcionInfraccion { get; private set; }
        public int UnidadesInfraccion { get; private set; }
        public double MontoInfraccion { get; private set; }
        #endregion

        public void IniciarSistemaInfracciones(double baseMonetaria)
        {
            this.BaseMonetaria=baseMonetaria;
        }

        public void IniciarActa(int dni, string nombre, int tipoVehiculo)
        {
            this.DniActa = dni;
            this.NombreActa = nombre;
            this.tipoVehiculo = tipoVehiculo;
            SubTotalActa = 0;
        }

        public void AgregarInfraccion(int tipoInfraccion)
        {
            CodigoInfraccion = tipoInfraccion;
            MontoInfraccion = 0;
            switch (tipoInfraccion)
            {
                case 1:
                    {                        
                        DescripcionInfraccion = TIPO_1_DESCRP;
                        UnidadesInfraccion = TIPO_1_MONTO;                        
                    }
                    break;
                case 2:
                    {
                        DescripcionInfraccion = TIPO_2_DESCRP;
                        UnidadesInfraccion = TIPO_2_MONTO;
                    }
                    break;
                case 3:
                    {
                        DescripcionInfraccion = TIPO_3_DESCRP;
                        UnidadesInfraccion = TIPO_3_MONTO;
                    }
                    break;
                case 4:
                    {
                        DescripcionInfraccion = TIPO_4_DESCRP;
                        UnidadesInfraccion = TIPO_4_MONTO;
                    }
                    break;
                case 5:
                    {
                        DescripcionInfraccion = TIPO_5_DESCRP;
                        UnidadesInfraccion = TIPO_5_MONTO;
                    }
                    break;
            }

            MontoInfraccion = UnidadesInfraccion *BaseMonetaria;
            SubTotalActa += MontoInfraccion;
        }

        public void FinalizarActa(bool pagaEnElLugar)
        {
            double rec = 0;
            switch (tipoVehiculo)
            {
                case 1:
                    {
                        rec = 1;
                    } 
                    break;
                case 2:
                    {
                        rec = 50;
                    }
                    break;
                case 3:
                    {
                        rec = 200;
                    }
                    break;
            }
            AjusteTipoVehiculo= SubTotalActa * rec / 100;
            SubTotalAjustadoActa = SubTotalActa + AjusteTipoVehiculo;

            double desc = 0;
            if (pagaEnElLugar)
                desc = 50;
            DescuentoPagoActa = SubTotalAjustadoActa *  desc/100;

            TotalActaAPagar = SubTotalAjustadoActa -DescuentoPagoActa;

            if (pagaEnElLugar)
            {
                Recaudacion += TotalActaAPagar;
            }
        }
    }
}
