using AutoMapper;
using HoltelListing.Data;
using HoltelListing.IRepository;
using HoltelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoltelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unifOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unifOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(results);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, $"Something went wrong {nameof(GetCountries)}");
                return StatusCode(500, "Internal Server Error, please try again later");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var results = _mapper.Map<CountryDTO>(country);
                return Ok(results);
            }
            catch (Exception Ex)
            {
                _logger.LogError(Ex, $"Something went wrong {nameof(GetCountry)}");
                return StatusCode(500, "Internal Server Error, please try again later");
            }
        }

    }
}
