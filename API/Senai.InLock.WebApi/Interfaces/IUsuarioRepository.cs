using Domains;

using Senai.InLock.WebApi.ViewModel;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuariosDomain> Listar();

        UsuariosDomain BuscarPorEmailSenha(LoginViewModel login);


        void Cadastrar(UsuariosDomain novoUsuario);

    }
}
