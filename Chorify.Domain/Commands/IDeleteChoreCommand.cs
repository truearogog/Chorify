using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorify.Domain.Commands
{
    public interface IDeleteChoreCommand
    {
        Task Execute(Guid id);
    }
}
