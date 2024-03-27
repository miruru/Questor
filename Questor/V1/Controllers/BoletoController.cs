using BancoClass.Interfaces;
using BaseDomain.Notifications;
using BoletoClass.Entities;
using BoletoClass.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questor.Controllers;
using Questor.Dto;

namespace Questor.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/boleto")]
    public class BoletoController : MainController
    {
        private readonly IBoletoService _boletoService;
        private readonly IBoletoRepository _boletoRepository;
        private readonly IBancoRepository _bancoRepository;

        public BoletoController(IBoletoService boletoService,
                                  IBoletoRepository boletoRepository,
                                  IBancoRepository bancoRepository,
                                  INotificador notificador) : base(notificador)
        {
            _boletoService = boletoService;
            _boletoRepository = boletoRepository;
            _bancoRepository = bancoRepository;
        }

        #region Get

        [HttpGet("listar")]
        public async Task<ActionResult> Listar()
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(_boletoService.Get<GetBoletoDto>());
        }

        [HttpGet("obter/{id:guid}")]
        public async Task<ActionResult> Obter(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            return CustomResponse(_boletoService.GetById<GetBoletoDto>(id));
        }
        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult> Inserir(CreateBoletoDto agenciaBancaria)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (_bancoRepository.Select(agenciaBancaria.IdBanco) == null)
            {
                NotificarErro("Banco inexistente.");
                return CustomResponse();
            }
            return CustomResponse(_boletoService.Add<CreateBoletoDto, GetBoletoDto, BoletoValidator>(agenciaBancaria));
        }
        #endregion
    }
}
