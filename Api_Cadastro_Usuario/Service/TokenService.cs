using Api_Cadastro_Usuario.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Api_Cadastro_Usuario.Service
{
    public class TokenService
    {
        public static string TokenGenerator(UsuarioModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string TokenGenerator(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static ClaimsPrincipal GetPrincipalFromExpiresToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurytiToken ||
                !jwtSecurytiToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }


        private static List<(string, string)> _refreshTokens = new();
        private static List<(string, string)> _normalToken = new();

        #region Normal tokens

        public static void SaveToken(string userEmail, string token)
        {
            _normalToken.Add(new(userEmail, token));
        }
        public static string GetToken(string userEmail)
        {
            return _normalToken.FirstOrDefault(x => x.Item1 == userEmail).Item2;
        }
        public static void DeletToken(string email, string token)
        {
            var item = _normalToken.FirstOrDefault(x => x.Item1 == email && x.Item2 == token);
            _normalToken.Remove(item);
        }
        #endregion

        #region refresh tokens

        public static void SaveRefreshToken(string userEmail, string refreshToken)
        {
            _refreshTokens.Add(new(userEmail, refreshToken));
        }

        public static string GetRefreshToken(string userEmail)
        {
            return _refreshTokens.FirstOrDefault(x => x.Item1 == userEmail).Item2;
        }
        public static void DeletRefreshToken(string userName, string refreshToken)
        {
            var item = _refreshTokens.FirstOrDefault(x => x.Item1 == userName && x.Item2 == refreshToken);
            _refreshTokens.Remove(item);
        }
        #endregion

        public static string GetAllTokensByEmail(string email)
        {
            var token1 = _normalToken.FirstOrDefault(x => x.Item1 == email).Item2;
            var token2 = _refreshTokens.FirstOrDefault(x => x.Item1 == email).Item2;

            if (token1 != null)
                return token1;

            if (token2 != null)
                return token2;

            return null;
        }
        public static string GetAllEmailsByTokens(string token)
        {
            var email1 = _normalToken.FirstOrDefault(x => x.Item2 == token).Item1;
            var email2 = _refreshTokens.FirstOrDefault(x => x.Item2 == token).Item1;

            if (email1 != null)
                return email1;

            if (email2 != null)
                return email2;

            return null;
        }

        public static string GetEmailByTokens(string token)
        {
            var email1 = _normalToken.FirstOrDefault(x => x.Item2 == token).Item1;
            var email2 = _refreshTokens.FirstOrDefault(x => x.Item2 == token).Item1;

            if (email1 != null)
                return email1;

            if (email2 != null)
                return email2;

            return null;
        }
        public static void DeletAllTokens(string email)
        {
            var token1 = _normalToken.FirstOrDefault(x => x.Item1 == email);
            var token2 = _refreshTokens.FirstOrDefault(x => x.Item1 == email);

            _normalToken.Remove(token1);
            _refreshTokens.Remove(token2);
        }

        public static TokensModel LoginSaveTokens(UsuarioModel user)
        {
            DeletAllTokens(user.Email);
            var token = TokenGenerator(user);
            var refreshToken = GenerateRefreshToken();

            SaveRefreshToken(user.Email, refreshToken);
            SaveToken(user.Email, token);

            TokensModel newTokens = new();
            newTokens.Token = token;
            newTokens.RefreshToken = refreshToken;

            return newTokens;

        }
        public static TokensModel RefreshGenerator(string token, string refreshToken, string email)
        {

            var principal = GetPrincipalFromExpiresToken(token);
            var saveRefreshToken = GetRefreshToken(email);

            if (saveRefreshToken == null || saveRefreshToken != refreshToken)
                return null;

            var newRefreshToken = GenerateRefreshToken();
            var newJwtToken = TokenGenerator(principal.Claims);
            DeletAllTokens(email);
            SaveToken(email, newJwtToken);
            SaveRefreshToken(email, newRefreshToken);

            TokensModel newTokens = new();
            newTokens.Token = newJwtToken;
            newTokens.RefreshToken = newRefreshToken;

            return newTokens;

        }
    }
}
