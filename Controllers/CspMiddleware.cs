using System.Security.Cryptography;

public class CspMiddleware
{
    private readonly RequestDelegate _next;

    public CspMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        byte[] nonceBytes = new byte[32]; // 32 bytes for a 256-bit nonce, you can adjust the size as needed
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(nonceBytes);
        }

        string nonceValue = Convert.ToBase64String(nonceBytes);
        context.Items["NonceValue"] = nonceValue; // Store nonceValue in HttpContext.Items
        context.Response.Headers.Add("Content-Security-Policy", $"default-src 'self' 'unsafe-inline'; script-src 'unsafe-inline'  https://cdn.jsdelivr.net 'self' 'nonce-{nonceValue}' ; style-src  'self' 'unsafe-inline'; font-src 'self'; img-src 'self'; frame-src 'self'");
        await _next(context);
    }
}
