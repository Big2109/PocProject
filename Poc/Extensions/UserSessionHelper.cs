public static class UserSessionHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    public static bool IsLogged =>
        _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public static string UserName =>
        _httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? string.Empty;
    public static string Nome => GetClaim("Nome");
    public static string GetClaim(string claimType) =>
        _httpContextAccessor?.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == claimType)?.Value ?? string.Empty;
}
