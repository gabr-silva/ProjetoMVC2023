using ProjetoMVC2023.DAL;
using ProjetoMVC2023.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoMVC2023.BLL
{
    class CadastrarBLL
    {
        public bool GetCadastrarBLL(CadastrarDTO dadosCadastrar)
        {
            // validação
            if ( VerificarNome(dadosCadastrar) && ValidarEmail(dadosCadastrar) && VerificarSenha(dadosCadastrar) && !(dadosCadastrar.Nivel == ""))
            {
                // criar um obj da DAL
                CadastrarDAL cadastrar = new CadastrarDAL();

                // chamar o logindall
                return cadastrar.Cadastrar_DAL(dadosCadastrar);
            }
            return false;
        }

        //metodo para verificar o campo nome
        public bool VerificarNome(CadastrarDTO dadosCadastrar)
        {
            string nome = dadosCadastrar.Nome.Trim();
            /*
                1° [A-Z][a-z] - Verifica o primeiro nome sendo que: a primeira letra tem que ser maiuscula, e a restante minuscula
                2° \s[A-Z][a-z] - verifica o sobrenome a expressão \s 
                    indica que o que as especificações colocadas serão feitas para uma outra palavra após ser aperto espaco
            */
            Regex rgxNome = new Regex(@"^[A-Z][a-z]+\s[A-Z][a-z]+$");
            if (rgxNome.Match(nome).Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Erro! O nome deve conter nome e sobrenome tendo a primeira letra maiuscula ");
                return false;
            };
        }

        public bool ValidarEmail(CadastrarDTO dadosCadastrar)
        {
            string email = dadosCadastrar.Email.Trim();

            /*
             * email exemplo: exemplo@gmail.com
             * 1° [a-zA-Z0-9_.+-] campo "exemplo" - aceita letras maiuscula, minuscula, numeros e caracteres expeciais antes do simbolo @
             * 2° +@ - verifica se no texto existe este caracter
             * 3° [a-z] campo "gmail" - somente aceita letras minusculas
             * 4° +\. - indica que precisa ter um ponto depois da 3° parte
             * 5° [a-z]{2,3} campo "com" - somente aceita letras minusculas e tem quer ter no minimo 2 letras e no maximo 3
             */
            Regex rgxEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-z]+\.[a-z]+${2,3}");
            if (rgxEmail.Match(email).Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show("E-mail digitado é invalido");
                return false;
            }
        }
        public bool VerificarSenha(CadastrarDTO dadosCadastrar)
        {
            string senha = dadosCadastrar.Senha.Trim();

            //{7,} - Indica que tem que ter no minimo 8 digitos e no maximo n
            Regex rgxSenha = new Regex(@"^[A-Za-z0-9_.+-].{7,}$");
            if (rgxSenha.Match(senha).Success)
            {
                //verifica a senha e a confirmação de senha
                if (senha == dadosCadastrar.ConfirSenha)
                {
                    return true;
                }
                MessageBox.Show("A senha e a confirmação não estão iguais");
                return false;
            }
            else
            {
                MessageBox.Show("Senha invalida! A senha deve conter no minino 8 caracteres");
                return false;
            }
        }
    }
}
