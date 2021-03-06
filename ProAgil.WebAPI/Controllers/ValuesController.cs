﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProAgilContext _context;

        public ValuesController(ProAgilContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        // public ActionResult<IEnumerable<Evento>> Get()
        public async Task<IActionResult> Get()
        {
            // return new string[] { "value1", "value2","value3", "value4" };
            // return new Evento[] { 
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e .Net Core",
            //         Local = "Belo Horizonte",
            //         Lote = "1 Lote",
            //         QtdPe4ssoas = 25,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            //     },
            //     new Evento(){
            //         EventoId = 2,
            //         Tema = "Angular e Suas Novidades",
            //         Local = "Florianópolis",
            //         Lote = "2 Lote",
            //         QtdPe4ssoas = 253,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
            //     }
            // };
            // return _context.Eventos.ToList();
            try
            {
                var results =  await _context.Eventos.ToListAsync();

                return Ok(results);   
            }
            catch (System.Exception)
            {                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        // public ActionResult<Evento> Get(int id)
        public async Task<ActionResult> Get(int id)
        {
            // return new Evento[] { 
            //     new Evento() {
            //         EventoId = 1,
            //         Tema = "Angular e .Net Core",
            //         Local = "Belo Horizonte",
            //         Lote = "1 Lote",
            //         QtdPe4ssoas = 25,
            //         DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
            //     },
            //     new Evento(){
            //         EventoId = 2,
            //         Tema = "Angular e Suas Novidades",
            //         Local = "Florianópolis",
            //         Lote = "2 Lote",
            //         QtdPe4ssoas = 253,
            //         DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
            //     }
            // }.FirstOrDefault(x => x.EventoId == id);
            // return _context.Eventos.FirstOrDefault(x => x.EventoId == id);

            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);

                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
