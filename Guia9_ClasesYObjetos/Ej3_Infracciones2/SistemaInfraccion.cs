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
    class SistemaInfraccion
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
        double baseMonetaria;
        public double recaudacion;
        #endregion

        #region por acta
        public int dniActa;
        public string nombreActa;
        int tipoVehiculo;
        public double subTotalActa;
        public double ajusteTipoVehiculo;
        public double subTotalAjustadoActa;
        public double descuentoPagoActa;
        public double totalActaAPagar;
        #endregion

        #region por infraccion
        public int codigoInfraccion;
        public string descripcionInfraccion;
        public int unidadesInfraccion;
        public double montoInfraccion;
        #endregion

        public void IniciarSistemaInfracciones(double baseMonetaria)
        {
            this.baseMonetaria=baseMonetaria;
        }

        public void IniciarActa(int dni, string nombre, int tipoVehiculo)
        {
            this.dniActa = dni;
            this.nombreActa = nombre;
            this.tipoVehiculo = tipoVehiculo;
            subTotalActa = 0;
        }

        public void AgregarInfraccion(int tipoInfraccion)
        {
            codigoInfraccion = tipoInfraccion;
            montoInfraccion = 0;
            switch (tipoInfraccion)
            {
                case 1:
                    {                        
                        descripcionInfraccion = TIPO_1_DESCRP;
                        unidadesInfraccion = TIPO_1_MONTO;                        
                    }
                    break;
                case 2:
                    {
                        descripcionInfraccion = TIPO_2_DESCRP;
                        unidadesInfraccion = TIPO_2_MONTO;
                    }
                    break;
                case 3:
                    {
                        descripcionInfraccion = TIPO_3_DESCRP;
                        unidadesInfraccion = TIPO_3_MONTO;
                    }
                    break;
                case 4:
                    {
                        descripcionInfraccion = TIPO_4_DESCRP;
                        unidadesInfraccion = TIPO_4_MONTO;
                    }
                    break;
                case 5:
                    {
                        descripcionInfraccion = TIPO_5_DESCRP;
                        unidadesInfraccion = TIPO_5_MONTO;
                    }
                    break;
            }

            montoInfraccion = unidadesInfraccion *baseMonetaria;
            subTotalActa += montoInfraccion;
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
            ajusteTipoVehiculo= subTotalActa * rec / 100;
            subTotalAjustadoActa = subTotalActa + ajusteTipoVehiculo;

            double desc = 0;
            if (pagaEnElLugar)
                desc = 50;
            descuentoPagoActa = subTotalAjustadoActa *  desc/100;

            totalActaAPagar = subTotalAjustadoActa -descuentoPagoActa;

            if (pagaEnElLugar)
            {
                recaudacion += totalActaAPagar;
            }
        }
    }
}
