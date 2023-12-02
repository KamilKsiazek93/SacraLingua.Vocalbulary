using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SacraLingua.Vocalbulary.WebAPI.Interfaces;
using SacraLingua.Vocalbulary.WebAPI.Models.Requests;
using SacraLingua.Vocalbulary.WebAPI.Models.Responses;

namespace SacraLingua.Vocalbulary.WebAPI.Controllers
{
    [Authorize(Policy = "ReadScopePolicy")]
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

        /// <summary>
        /// Get List of Greek Words witch query criteria
        /// </summary>
        /// <param name="filterRequest">Query criteria</param>
        /// <returns>List of greek words</returns>
        [HttpGet]
        public async Task<ActionResult<PagedResponse<GreekWordResponse>>> GetGreekWordsAsync([FromQuery] GreekWordFilterRequest filterRequest)
            => await _greekWordApiService.GetGreekWordAsync(filterRequest);

        /// <summary>
        /// Get Greek Word when thanks to ID
        /// </summary>
        /// <param name="greekWordId">Id of Greek Word</param>
        /// <returns>GreekWordResponse</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GreekWordResponse>> GetGreekWordByIdAsync([FromRoute] int id)
            => await _greekWordApiService.GetGreekWordByIdAsync(id);

        /// <summary>
        /// Add new greek Word
        /// </summary>
        /// <param name="greekWord">Greek Word object with all data filled</param>
        /// <returns>Created Greek Word</returns>
        [Authorize(Policy = "WriteScopePolicy")]
        [HttpPost]
        public async Task<ActionResult<GreekWordResponse>> AddGreekWordAsync([FromBody] GreekWordRequest greekWord)
            => await _greekWordApiService.AddGreekWordAsync(greekWord);
    }
}
