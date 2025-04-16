using System.ComponentModel;

namespace GuateShop.Shared.Emun
{
    public enum UserType
    {
        [Description("Administrador")]
        Admin = 1,

        [Description("Cliente")]
        Customer = 2,

        [Description("Vendedor")]
        Seller = 3,

        [Description("Servicio al cliente")]
        CustomerService = 4,
    }
}