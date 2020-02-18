using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core3RestfulApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core3RestfulApi.Controllers
{
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
             _companyRepository= companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }
        /// <summary>
        /// 获取所有的数据集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompaniesAsync();
            return Ok(companies); //OK:成功会返回状态码200，以及返回的数据
        }
        /// <summary>
        /// 获取单一的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCompanie(Guid companyId)
        {
            var companies = await _companyRepository.GetCompanyAsync(companyId);
            return Ok(companies); //OK:成功会返回状态码200，以及返回的数据
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
