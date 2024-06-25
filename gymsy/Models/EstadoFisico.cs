using gymsy.Context;
using gymsy.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace gymsy.Modelos;

public partial class EstadoFisico
{
    public int IdEstadoFisico { get; set; }

    public string Titulo { get; set; } = null!;

    public decimal Peso { get; set; }

    public decimal Altura { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string Notas { get; set; } = null!;

    public bool EstadoFisicoInactivo { get; set; }

    public int IdAlumnoSuscripcion { get; set; }

    public string ImagenUrl { get; set; } = null!;

    public virtual AlumnoSuscripcion IdAlumnoSuscripcionNavigation { get; set; } = null!;
    public static bool tituloUnico(string nuevoTitulo)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {
            // Consulta para encontrar registros con el mismo título
            var registrosConMismoTitulo = gymsydb.EstadoFisicos
            .Where(d => d.Titulo == nuevoTitulo);

            // Verificamos si se encontró algún registro con el mismo título
            bool tituloUnico = !registrosConMismoTitulo.Any();

            // Devolvemos el resultado
            return tituloUnico;
        }
    }
    public static bool guardarProgreso(string ptitle_dataFisic, string pnotes_dataFisic, float pweight_dataFisic, float pheight_dataFisic, string pruta_imagen)
    {
        using (var gymsydb = new NuevoGymsyContext())
        {

            EstadoFisico DataFisicModel = new EstadoFisico();
            DataFisicModel.FechaCreacion = DateTime.Now;

            if (AppState.ClientActive == null)
            {
                DataFisicModel.IdAlumnoSuscripcion = AlumnoSuscripcion.obtenerSuscripcionPorAlumno(AppState.auxIdClient).IdAlumnoSuscripcion;
            }
            else
            {
                DataFisicModel.IdAlumnoSuscripcion = AlumnoSuscripcion.obtenerSuscripcionPorAlumno(AppState.ClientActive.IdUsuario).IdAlumnoSuscripcion;
            }

            DataFisicModel.EstadoFisicoInactivo = false;
            DataFisicModel.Titulo = ptitle_dataFisic;
            DataFisicModel.Notas = pnotes_dataFisic;
            DataFisicModel.Peso = (decimal)pweight_dataFisic;
            DataFisicModel.Altura = (decimal)pheight_dataFisic;
            DataFisicModel.ImagenUrl = pruta_imagen;
            var DataFisicSave = gymsydb.Add(DataFisicModel);
            gymsydb.SaveChanges();

            if (DataFisicSave != null)
            {

                gymsydb.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }


    public static List<EstadoFisico> listarProgresosPorAlumnoSuscripcion(int idAlumnoSuscripcion)
        {
            using (var gymsydb=new NuevoGymsyContext())
            {
                return (List<EstadoFisico>)gymsydb.EstadoFisicos.Where(a => a.IdAlumnoSuscripcion==idAlumnoSuscripcion).ToList();
            }
        }

 }
