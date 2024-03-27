using BaseDomain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questor.Controllers;
using QuestorApi.Dto;
using QuestorApi.Services;
using System.Collections.Generic;

namespace QuestorApi.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly AuthenticationService _authenticationService;

        public AuthController(AuthenticationService authenticationService,
                              INotificador notificador) : base(notificador)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Email: teste@teste.com Senha: 123456
        /// </summary>
        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(AcessoDto usuarioLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!usuarioLogin.Email.ToUpper().Equals("TESTE@TESTE.COM") && !usuarioLogin.Password.ToUpper().Equals("123456"))
            {
                NotificarErro("Usuário ou Senha incorretos.");
                return CustomResponse();
            }
            else
            {
                return CustomResponse(await _authenticationService.GerarJwt(usuarioLogin.Email));
            }
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
            {
                NotificarErro("Refresh token inválido.");
                return CustomResponse();
            }

            var token = await _authenticationService.ObterRefreshToken(Guid.Parse(refreshToken));

            if (token == null)
            {
                NotificarErro("Refresh token expirado.");
                return CustomResponse();
            }

            return CustomResponse(await _authenticationService.GerarJwt(token.Username));
        }
    }
}
