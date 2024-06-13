using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;
using SacraLingua.Vocalbulary.WebAPI.Services;

namespace SacraLingua.Vocalbulary.WebAPI.Controllers
{
    [Authorize(Policy = "ReadScopePolicy")]
    [Route(Constants.HebrewWordsRoute)]
    [ApiVersion(Constants.ApiVersion)]
    [ApiController]
    public class HebrewWordsController : ControllerBase
    {
        private readonly IHebrewWordApiService _hebrewWordApiService;

        public HebrewWordsController(IHebrewWordApiService hebrewWordApiService)
        {
            _hebrewWordApiService = hebrewWordApiService;
        }

        /// <summary>
        /// Get List of Hebrew Words witch query criteria
        /// </summary>
        /// <param name="filterRequest">Query criteria</param>
        /// <returns>List of hebrew words</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponse<HebrewWordResponse>>> GetGreekWordsAsync([FromQuery] HebrewWordFilterRequest filterRequest)
            => await _hebrewWordApiService.GetHebrewWordAsync(filterRequest);
    }
}
