

using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IEstudiosRepository
    {

        List<EstudiosDomain> Listar();

        void Cadastrar(EstudiosDomain novoEstudio);
    }
}
