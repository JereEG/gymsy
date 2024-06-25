# Gymsy - Gestión de Gimnasios

Welcome to Gymsy, a university project focused on gym management using .NET Windows Forms.

## Descripción del Proyecto

Este proyecto se centra en el desarrollo de una aplicación de gestión de gimnasios utilizando .NET Windows Forms. Aquí, encontrarás información detallada sobre el mismo.

## Recursos Adicionales

- **Bases de Datos:**

1. Importar Base de Datos

  Utiliza SQL Server para importar el archivo .bacpac ubicado en la raíz del proyecto. Asegúrate de que el nombre de la base de datos sea "gymsy". ¡La precisión en el nombre   es crucial para el correcto funcionamiento!

2. Configurar String Connection

  En el directorio "Properties", encontrarás un archivo llamado "Resources.resx". En este archivo, busca la variable `connectionString`, que enlaza con la base de datos. Por   defecto, el servidor está configurado como "localhost". Si estás utilizando un servidor diferente, modifica solo la parte `server=<own-server>`.

3. Todo listo!
   
   Es hora de entrenar!!!
   
- **Informe de Requerimientos:** Accede al informe completo que detalla los requisitos del proyecto.

## Datos de Acceso

### Administrador

- **Usuario:** admin
- **Contraseña:** admin

### Recepcionista

- **Usuario:** res
- **Contraseña:** admin

### Instructor

- **Usuario:** instructor
- **Contraseña:** instructor

### Cliente

- **Usuario:** cliente
- **Contraseña:** cliente

¡Explora y disfruta de Gymsy! Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con nosotros.



Presentador payPresenter
-public static Pago BuscarPago(int pIdPaySelected)- 1 uso 

EditClientPresenter
-public static AlumnoSuscripcion AlumSubDelCliente()-
-public static AlumnoSuscripcion BuscarPlanUnCliente( int idClienteBuscado)
-public static Usuario BuscarInstrucorDePlan(int pIdPlan)
-public static List<PlanEntrenamiento> PlanesQueNoSonDelCliente()
-public static void ActualizarCliente(string pUsuario, string pNombre,     string pApellido, string pRutaImagen, string pContraseña,
            string pNumeroTelefono, string pGenero, DateTime pBirthDay, DateTime pLastExpiration, int pIdPlan)
- public static PlanEntrenamiento BuscarPlan(int pIdPlan)


DashboardInstructorPresenter
-public static List<PagoPorMes> ObtenerPagosAgrupadosPorMes()
-public static List<Usuario> BuscarClientesActivosDelInstructor(List<int> pIdsPlanesInstructor)
-public static int ContarExpiradosONoExp(bool Expirado)
-public static AlumnoSuscripcion getAlumnoSuscripcion(int idusuario)

ControlPagosAlumnoPresenter
- public static List<Pago> listarPagosRealizados(int pIdUsuario)
-public static List<Pago> listarPagosRecibidos(int pIdUsuario)
-public static List<Pago> listarTodasTransferencias(int pIdUsuario)


ControlAlumnosPresenter
-public static Usuario BuscarCliente(int pIdCliente)
-public static void EliminarOActivarCliente(int pIdPersona, bool pDeleteOrAcitive)
