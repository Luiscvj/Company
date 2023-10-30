

namespace API.Helpers;

public class Autorization
{
    public enum Roles
    {
        Manager,
        Empleado
    }
    public const Roles rol_predeterminado = Roles.Empleado;
}