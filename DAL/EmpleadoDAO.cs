using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DAL
{
    public class EmpleadoDAO
    {
        empleadosEntities context;

        public EmpleadoDAO()
        {
            context = new empleadosEntities();
        }

        public void InsertarEmpleado(EmpleadoDTO empleado)
        {
            var nuevoEmpleado = new Empleado()
            {
                nombre = empleado.nombre,
                apellido = empleado.apellido,
                sueldo = empleado.sueldo
            };
            context.Empleados.Add(nuevoEmpleado);
            context.SaveChanges();
        }

        //public Empleado CrearEmpleados(string nombre, string apellido, double sueldo)
        //{
        //    Empleado nuevoEmpleado = new Empleado();

        //    nuevoEmpleado.nombre = nombre;
        //    nuevoEmpleado.apellido = apellido;
        //    nuevoEmpleado.sueldo = sueldo;
        //    context.Empleados.Add(nuevoEmpleado);
        //    context.SaveChanges();


        //    return nuevoEmpleado;
        //}

        public void EliminarEmpleado(EmpleadoDTO empleadoDTO)
        {
            //Busco el id del empleado que voy a elminar 
            Empleado empleadoEliminado = context.Empleados.Where(x => x.Id_Empleado == empleadoDTO.Id_Empleado).FirstOrDefault();
        
            if (empleadoEliminado != null)
            {
                context.Empleados.Remove(empleadoEliminado);
                context.SaveChanges();
            }

        }

        //public List<Empleado> listadoDeEmpleados()
        //{
        //    List<Empleado> listadoDeEmpleados = context.Empleados.ToList();

        //    return listadoDeEmpleados;
        //}

        //public List<EmpleadoDTO> listadoDeEmpleados()
        //{
        //    List<Empleado> empleado = context.Empleados.ToList();
        //    List<EmpleadoDTO> listadoDeEmpleados = new List<EmpleadoDTO>();

        //    foreach (var item in empleado)
        //    {
        //        listadoDeEmpleados.Add(new EmpleadoDTO()
        //        {
        //            Id_Empleado = item.Id_Empleado,
        //            nombre = item.nombre,
        //            apellido = item.apellido,
        //            sueldo = (double)item.sueldo
        //        });
        //    }

        public IEnumerable<EmpleadoDTO> listadoDeEmpleados()
        {
            return context.Empleados.Select(item => new EmpleadoDTO
            {
                Id_Empleado = item.Id_Empleado,
                nombre = item.nombre,
                apellido = item.apellido,
                sueldo = (double)item.sueldo
            }).ToList();
        }

  


        public EmpleadoDTO consultaEmpleados(int id_empleado)
        {
          Empleado empleadoFiltrado = context.Empleados.Where(x => x.Id_Empleado == id_empleado).FirstOrDefault();

            var empleado = new EmpleadoDTO()
            {
                Id_Empleado = empleadoFiltrado.Id_Empleado,
                nombre = empleadoFiltrado.nombre,
                apellido = empleadoFiltrado.apellido,
                sueldo = (double)empleadoFiltrado.sueldo

            };
            return empleado;

        }


        public void ModificarEmpleado(EmpleadoDTO empleadoDTO)
        {

            Empleado empleadoEditado = context.Empleados.Where(x => x.Id_Empleado == empleadoDTO.Id_Empleado).FirstOrDefault();
            

            if (empleadoEditado != null)
            {
                empleadoEditado.nombre = empleadoDTO.nombre;
                empleadoEditado.apellido = empleadoDTO.apellido;
                empleadoEditado.sueldo = empleadoDTO.sueldo;
                context.SaveChanges();
            }
        }
        
    }
}
