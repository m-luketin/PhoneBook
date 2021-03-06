﻿using Microsoft.AspNetCore.Http;
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
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public ActionResult<List<Contact>> Get()
        {
            return Ok(_contactRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            return Ok(_contactRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult<Contact> Create(Contact contactToAdd)
        {
            var createdContact = _contactRepository.Create(contactToAdd);
            if (createdContact == null)
                return BadRequest();

            return Ok(createdContact);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var wasSuccessful = _contactRepository.DeleteById(id);
            if (wasSuccessful)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public ActionResult Update(Contact newContact)
        {
            var editedContact = _contactRepository.Edit(newContact);
            if (editedContact == null)
                return BadRequest();

            return Ok(editedContact);
        }
    }
}
