using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PhoneBookApi.Data.Entities.Models;
using PhoneBookApi.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        public PhoneNumberController(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        [HttpGet]
        public ActionResult<List<PhoneNumber>> Get()
        {
            return Ok(_phoneNumberRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<PhoneNumber> Get(int id)
        {
            return Ok(_phoneNumberRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult<PhoneNumber> Create([FromBody] JObject data)
        {
            var value = data["value"].ToString();
            var createdPhoneNumber = _phoneNumberRepository.Create(new PhoneNumber(value));
            if (createdPhoneNumber == null)
                return BadRequest();

            return Ok(createdPhoneNumber);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var wasSuccessful = _phoneNumberRepository.DeleteById(id);
            if (wasSuccessful)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(PhoneNumber newPhoneNumber)
        {
            var editedPhoneNumber = _phoneNumberRepository.Edit(newPhoneNumber);
            if (editedPhoneNumber == null)
                return BadRequest();

            return Ok(editedPhoneNumber);
        }
    }
}
