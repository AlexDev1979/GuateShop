using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuateShop.Share.Enums
{
    public enum UserType
    {
        [Description ("Administrador")]
        Admin = 1,
        [Description("Vendedor")]
        Seller = 2,
        [Description("Cliente")]
        Customer = 3,
        [Description("Invitado")]
        Guest = 4,
    }
}
