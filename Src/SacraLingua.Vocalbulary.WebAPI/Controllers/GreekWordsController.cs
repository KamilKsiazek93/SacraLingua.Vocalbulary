using Microsoft.AspNetCore.Mvc;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Controllers
{
    [Route(Constants.GreekWordsRoute)]
    [ApiVersion(Constants.ApiVersion)]
    [ApiController]
    public class GreekWordsController : ControllerBase
    {
        private readonly IGreekWordApiService _greekWordApiService;

        public GreekWordsController(IGreekWordApiService greekWordApiService)
        {
            _greekWordApiService = greekWordApiService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GreekWordResponse>> GetGreekWordByIdAsync([FromRoute] int id)
            => await _greekWordApiService.GetGreekWordByIdAsync(id);
    }
}
