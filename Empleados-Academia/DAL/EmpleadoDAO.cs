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

        public void EliminarEmpleado(int Id_Empleado)
        {
            //Busco el id del empleado que voy a elminar 
            Empleado empleadoEliminado = context.Empleados.Where(X => X.Id_Empleado == Id_Empleado).FirstOrDefault();

            if (empleadoEliminado != null)
            {
                context.Empleados.Remove(empleadoEliminado);
                context.SaveChanges();
            }

        }

        public List<Empleado> listadoDeEmpleados()
        {
            List<Empleado> listadoDeEmpleados = context.Empleados.ToList();

            return listadoDeEmpleados;
        }



        public Empleado consultaEmpleados(int id_empleado)
        {
            Empleado empleadoFiltrado = context.Empleados.Where(x => x.Id_Empleado == id_empleado).FirstOrDefault();

            return empleadoFiltrado;

        }


        public void ModificarEmpleado(int id_Empleado, string nombre, string apellido, double sueldo)
        {

            Empleado empleadoEditado = context.Empleados.Where(x => x.Id_Empleado == id_Empleado).FirstOrDefault();

            if (empleadoEditado != null)
            {
                empleadoEditado.nombre = nombre;
                empleadoEditado.apellido = apellido;
                empleadoEditado.sueldo = sueldo;
                context.SaveChanges();
            }
        }
        
    }
}
