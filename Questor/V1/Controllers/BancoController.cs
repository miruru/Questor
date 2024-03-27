using BancoClass.Interfaces;
using BancoClass.Validators;
using BaseDomain.Notifications;
using BoletoClass.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questor.Controllers;
using Questor.Dto;

namespace Questor.V1.Controllers
{
    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/banco")]
    public class BancoController : MainController
    {
        private readonly IBancoService _bancoService;
        private readonly IBancoRepository _bancoRepository;

        public BancoController(IBancoService bancoService,
                                  IBancoRepository bancoRepository,
                                  INotificador notificador) : base(notificador)
        {
            _bancoService = bancoService;
            _bancoRepository = bancoRepository;
        }

        #region Get
        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(_bancoService.Get<GetBancoDto>());
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult> Obter(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(_bancoService.GetById<GetBancoDto>(id));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult> Inserir(CreateBancoDto banco)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(_bancoService.Add<CreateBancoDto, GetBancoDto, BancoValidator>(banco));
        }
        #endregion
    }
}
