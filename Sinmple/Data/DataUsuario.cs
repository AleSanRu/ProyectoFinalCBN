using Sinmple.Models;

namespace Sinmple.Data
{
    public class DataUsuario
    {
        public List<Usuarios> ListaUsuarios()
        {
            return new List<Usuarios>()
            { new Usuarios(){ Nombre="Alejandro",Correo="Ale@gmail.com",Clave="123",Roles=new string[]{"Administrador"} },
            new Usuarios(){ Nombre="Nelly",Correo="Nelly@gmail.com",Clave="123",Roles=new string[]{ "Supervisor" } },
            new Usuarios(){ Nombre="Carlos",Correo="Carlos@gmail.com",Clave="123",Roles=new string[]{ "Empleado" } }
            };
        }
        public Usuarios ValidaUsuario(string correo, string clave)
        {
            return ListaUsuarios().Where(item => item.Correo == correo && item.Clave == clave).FirstOrDefault();
        }
    }
}
