using SimpleEshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Application.Services
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);

    }
}
