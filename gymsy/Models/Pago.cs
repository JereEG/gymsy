using gymsy.App.Presenters;
using gymsy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace gymsy.Modelos;

public partial class Pago
{
    public int IdPago { get; set; }

    public int IdUsuario { get; set; }

    public int IdTipoPago { get; set; }

    public string CbuDestino { get; set; } = null!;

    public string CbuOrigen { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public decimal Monto { get; set; }

    public bool InactivoPago { get; set; }

    public virtual TipoDePago IdTipoPagoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public static Pago buscarPago(int idPago)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.Pagos
                                .Where(pay => pay.IdPago == idPago)
                                .First();

        }
    }

    public static List<Pago> listarPagosPorUsuario(int idUsuario)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            return gymsydb.Pagos
            .Where(p => p.IdUsuario == idUsuario)
            .Include(p => p.IdTipoPagoNavigation)
            .ToList();
        }

    }


    public static void guardarPago(int pIdCliente, decimal pMonto)
        {

            using (var gymsydb = new NuevoGymsyContext())
            {
                var admin = AddPayPresenter.TraerAdmin();
            
                //var resepcionist = this.dbContext.People.FirstOrDefault(person => person.Rol.IdRol == 4);//rol de secretaria
                var client = AddPayPresenter.BuscarCliente(pIdCliente);
                Usuario.buscarUsuario(pIdCliente,3);


                if (admin != null && client != null)
                {

                    var newPay = new Pago
                    {
                        FechaCreacion = DateTime.Now,
                        Monto = (decimal)pMonto,  // Aquí debes proporcionar el monto deseado
                        InactivoPago = false,
                        IdUsuario = client.IdUsuario,
                        IdTipoPago = 1,
                        CbuDestino = "admin",
                        CbuOrigen = "unCliente"
                    };
                    gymsydb.Pagos.Add(newPay);
                    gymsydb.SaveChanges();

                    //agregar alumno suscripcion completo
                    var suscripcion = gymsydb.AlumnoSuscripcions.Where(u => u.IdAlumno == client.IdUsuario);
                    foreach (AlumnoSuscripcion sus in suscripcion)
                    {
                        sus.FechaExpiracion = DateTime.Now.AddMonths(1);
                    }

                    gymsydb.SaveChanges();
                    client.UsuarioInactivo = false;
                    gymsydb.SaveChanges();
                }
            }
        }
}
