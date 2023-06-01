using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_Infracciones2
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaInfracciones sistema = new SistemaInfracciones();

            #region pantalla de inicio del sistema
            Console.Clear();
            Console.WriteLine(" Iniciando el sistema ");
            Console.WriteLine(" Ingrese base monetaria (litros/costo litro)");
            double baseMonetaria = Convert.ToDouble( Console.ReadLine() );
            sistema.IniciarSistemaInfracciones(baseMonetaria);
            #endregion

            ConsoleKeyInfo key;
            do
            {
                #region pantalla del menú
                Console.Clear();
                Console.WriteLine("1- Ingresar acta.");
                Console.WriteLine("2- Mostrar recaudación.");
                Console.WriteLine("Otros- Mostrar recaudación.");
                key = Console.ReadKey();
                #endregion

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            #region pantalla de ingreso de acta
                            Console.Clear();

                            Console.WriteLine("Ingreso del acta");
                            Console.WriteLine("Ingresar dni, nombre, tipo vehiculo (1,2,3) infractor");
                            int dni = Convert.ToInt32(Console.ReadLine());
                            string nombre = Console.ReadLine();
                            int tipoVehiculo = Convert.ToInt32(Console.ReadLine());
                            sistema.IniciarActa(dni, nombre, tipoVehiculo);

                            Console.WriteLine("{0,10}{1,30}", sistema.DniActa, sistema.NombreActa);
                            Console.WriteLine("----------------------------------------");

                            Console.WriteLine("Ingresar el tipo de infracción");
                            int codigo = Convert.ToInt32(Console.ReadLine());
                            while (codigo > 0)
                            {
                                sistema.AgregarInfraccion(codigo);
                                Console.WriteLine("{0,10}{1,40}({2,10}){3,10:f2}", 
                                                                                sistema.CodigoInfraccion, 
                                                                                sistema.DescripcionInfraccion, 
                                                                                sistema.UnidadesInfraccion,
                                                                                sistema.MontoInfraccion);

                                Console.WriteLine("Ingresar el tipo de infracción");
                                codigo = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Paga en el  luegar");
                            int tipoPago = Convert.ToInt32(Console.ReadLine());
                            sistema.FinalizarActa(tipoPago == 1);
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Subtotal: ${0,10:f2}", sistema.SubTotalActa);
                            Console.WriteLine("Ajuste tipo vehiculo:$-{0,10:f2}", sistema.AjusteTipoVehiculo);
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Total a pagar: ${0,10:f2}",sistema.SubTotalAjustadoActa);
                            Console.WriteLine("Descuento Pago en lugar:$ -{0,10:f2}", sistema.DescuentoPagoActa);
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Total:$ {0,10:f2}", sistema.TotalActaAPagar);
                            Console.WriteLine("----------------------------------------");

                            Console.WriteLine("Presione una tecla para volver al menú");
                            Console.ReadKey();
                            #endregion
                        }
                        break;                        
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            #region pantalla de ingreso de acta
                            Console.Clear();
                            
                            Console.WriteLine("Detalle del final del día");
                            Console.WriteLine("Recaudación: ${0,10:f2}",sistema.Recaudacion);

                            Console.WriteLine("Presione una tecla para volver al menú");
                            Console.ReadKey();
                            #endregion
                        }
                        break;
                }

            } while (key.Key != ConsoleKey.D0 && key.Key != ConsoleKey.NumPad0);
        }
    }
}
