/* Contrôleur reprennant les méthodes d'accès aux données des docteurs */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Logotech.API.Data;
using Logotech.API.Dtos;
using Logotech.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logotech.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocteursController : ControllerBase
    {
        private readonly ILogotechRepository _repo;
        private readonly IMapper _mapper;
        public DocteursController(ILogotechRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocteurs()
        {
            var docteurs = await _repo.GetDocteurs();

            var docteursToReturn = _mapper.Map<IEnumerable<DocteurForListDto>>(docteurs);

            return Ok(docteursToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocteur(int id)
        {
            var docteur = await _repo.GetDocteur(id);

            var docteurToReturn = _mapper.Map<DocteurForDetailDto>(docteur);

            return Ok(docteurToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> AddDocteur(DocteurToAddDto docteurToAddDto)
        {
            var docteurToCreate = _mapper.Map<Docteur>(docteurToAddDto);

            if(docteurToCreate != null)
            {
                _repo.add(docteurToCreate);
            }
                
            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Ajout du docteur impossible");         
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateDocteur(int id, DocteurForUpdateDto docteurForUpdateDto)
        {
            var DocteurFromRepo = await _repo.GetDocteur(id);

            _mapper.Map(docteurForUpdateDto, DocteurFromRepo);
            
            if (await _repo.SaveAll())
             return NoContent();

            throw new Exception($"Les modifications pour le docteur {id} n'ont pas pu être sauvegardées");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocteur(int id)
        {
            var docteur = await _repo.GetDocteur(id);


            if (docteur != null)
            {
                _repo.Delete(docteur);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Suppression du docteur impossible");
        }
    }
}