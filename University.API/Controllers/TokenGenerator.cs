using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Security.Claims;

namespace University.API.Controllers
{
    // Define el espacio de nombres University.API.Controllers,
    // que organiza las clases relacionadas con los controladores de la API.
    internal static class TokenGenerator
    {
        // Declara una clase estática interna llamada TokenGenerator.
        // Esta clase se utiliza para generar tokens JWT para autenticación.

        public static string GenerateTokenJwt(string username)
        {
            // Declara un método estático público llamado GenerateTokenJwt que acepta un parámetro username de tipo string.
            // Este método genera un token JWT para el usuario proporcionado y devuelve el token como una cadena (string).

            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            // Obtiene la clave secreta para firmar el token desde el archivo de configuración (appsettings).

            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            // Obtiene el token de audiencia desde el archivo de configuración.

            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            // Obtiene el token del emisor desde el archivo de configuración.

            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];
            // Obtiene el tiempo de expiración del token (en minutos) desde el archivo de configuración.

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            // Crea una clave de seguridad simétrica utilizando la clave secreta obtenida anteriormente.
            // La clave se codifica en bytes.

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            // Crea las credenciales de firma utilizando la clave de seguridad y el algoritmo HMAC-SHA256.

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) });
            // Crea una identidad de reclamaciones (claimsIdentity) con una reclamación (claim) del tipo nombre (Name)
            // y el valor proporcionado en el parámetro username.

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            // Crea un manejador de tokens JWT (JwtSecurityTokenHandler).

            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);
            // Crea un token de seguridad JWT utilizando los valores obtenidos y configurados.
            // audience: el token de audiencia.
            // issuer: el token del emisor.
            // subject: la identidad de reclamaciones (claimsIdentity).
            // notBefore: fecha y hora antes de la cual el token no es válido.
            // expires: fecha y hora en la que el token expira.
            // signingCredentials: las credenciales de firma utilizadas para firmar el token.

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            // Escribe el token JWT en una cadena (string) utilizando el manejador de tokens.

            return jwtTokenString;
            // Devuelve el token JWT como una cadena.
        }
    }
}
