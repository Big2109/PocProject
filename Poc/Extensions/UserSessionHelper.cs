namespace Poc.Extensions;

public static class UserSessionHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    public static bool IsLogged
    {
        get
        {
            var user = _httpContextAccessor?
                .HttpContext?
                .Session?
                .GetString("UsuarioNome");

            return !string.IsNullOrEmpty(user);
        }
    }

    public static string UserName =>
        _httpContextAccessor.HttpContext.Session.GetString("UsuarioNome");
}
