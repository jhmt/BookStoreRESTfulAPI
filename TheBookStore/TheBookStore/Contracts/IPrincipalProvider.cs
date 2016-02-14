using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookStore.Contracts
{
    public interface IPrincipalProvider
    {
        IPrincipal CreatePrincipal(string username, string password);
    }
}
