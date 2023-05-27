using ProjetoMVC2023.DAL;
using ProjetoMVC2023.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMVC2023.BLL
{
    class LoginBLL
    {
        //metodo de controle
        public bool GetLoginBLL(LoginDTO dadosLogin)
        {
            // validação
            if (dadosLogin.Email == "" || dadosLogin.Senha == "")
            {
                return false;
            }

            // criar um obj da DAL
            LoginDAL login = new LoginDAL();

            // chamar o logindall
            return login.GetLoginDAL(dadosLogin);
        }
    }
}
