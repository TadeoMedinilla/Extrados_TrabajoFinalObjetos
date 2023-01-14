using Hotel.DTOs;
using Hotel.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Servicios.CRUDs
{
    internal class UsuarioCRUD : SQL_Methods<Usuario>, IGenericCRUD<Usuario>
    {
        private Usuario user { get; set; }
        private Empleado Empleado { get; set; }

        //Querys

        private string InsertQuery = "INSERT INTO Hotel.dbo.Usuarios \r\n\t\t\t( Usuario_ID, Usuario_Mail, Usuario_Password) \r\nVALUES ( @User_ID, @User_Mail, @User_Password)";
        
        private string ChangePassword = "UPDATE Hotel.dbo.Usuarios SET Usuario_Password = @User_Password WHERE Usuario_ID = @User_ID;";

        private string SelectFirstOrDefault = "";

        private string LogInSelect = "";

        public async Task Insertar(Usuario aInsertar)
        {
            string sentencia = InsertQuery;

            await SQL_Executable(sentencia, aInsertar);
        }
        
        public async Task Update(Usuario aModificar)
            //Modifica la contraseña. 
        {
            await SQL_Executable(ChangePassword, aModificar);
        }

        public Usuario BuscarPorID(int ID)
        {
            Usuario aux_user = new Usuario();
            aux_user.User_ID = ID;

            string sentencia = SelectFirstOrDefault;

            user = SQL_QueryFirstOrDefault(sentencia, aux_user);

            return user;
        }


        public Task<List<Usuario>> Select()
        {
            throw new NotImplementedException();
        }

        public Usuario SelectUsuario(Usuario Personal)
        {
            string sentencia = LogInSelect;

            user = SQL_Select(sentencia, Personal);

            return user;
        }

    }
}
