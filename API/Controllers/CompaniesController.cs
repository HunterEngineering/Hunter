using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hunter.API.Data;
using AutoMapper;
using Hunter.API.DTOs;
using Hunter.API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Hunter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(HunterDbContext context, IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            this._companyRepository = companyRepository;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCompanyDto>>> GetCompanys()
        {
            var companies = await _companyRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCompanyDto>>(companies);
            return Ok(records);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company = await _companyRepository.GetAsync(id);
  ///////////          //var projects = await _
            //    .Include(p => p.Projects).FirstOrDefaultAsync(q => q.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            if (id != updateCompanyDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(company).State = EntityState.Modified;
            var company = await _companyRepository.GetAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCompanyDto, company);

            try
            {
                await _companyRepository.UpdateAsync(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await _companyRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CreateCompanyDto createCompanyDto)
        {
            var company = _mapper.Map<Company>(createCompanyDto);

            await _companyRepository.AddAsync(company);

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyRepository.GetAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CompanyExists(int id)
        {
            return await _companyRepository.Exists(id);
        }
    }
}
