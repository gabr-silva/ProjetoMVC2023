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
            if (dadosLogin.Nome == "")
            {
                return false;
            }

            LoginDAL login = new LoginDAL();

            return login.GetLoginDAL(dadosLogin);
        }
    }
}
