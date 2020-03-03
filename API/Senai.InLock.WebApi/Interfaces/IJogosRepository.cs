
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IJogosRepository
    {
        List<JogosDomain> Listar();

        void Cadastrar(JogosDomain novoJogo);
    }
}
