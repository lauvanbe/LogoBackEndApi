/* Contrôleur reprennant les méthodes d'accès aux données des patients */

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
    public class PatientsController : ControllerBase
    {
        private readonly ILogotechRepository _repo;
        private readonly IMapper _mapper;
        public PatientsController(ILogotechRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _repo.GetPatients();

            var patientsToReturn = _mapper.Map<IEnumerable<PatientForListDto>>(patients);

            return Ok(patientsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _repo.GetPatient(id);

            var patientToReturn = _mapper.Map<PatientForDetailDto>(patient);

            return Ok(patientToReturn);
        } 


        [HttpPost()]
        public async Task<IActionResult> AddPatient(PatientToAddDto patientToAddDto)
        {
            var patientToCreate = _mapper.Map<Patient>(patientToAddDto);

            if(patientToCreate != null)
            {
                _repo.add(patientToCreate);
            }
                
            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Ajout du patient impossible");         
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientForUpdateDto patientForUpdateDto)
        {
             var patientFromRepo = await _repo.GetPatient(id); 

            //  _mapper.Map(patientForUpdateDto, patientFromRepo);

            patientFromRepo.Nom = patientForUpdateDto.Nom;
            patientFromRepo.Prenom = patientForUpdateDto.Prenom;
            patientFromRepo.DateNaissance = patientForUpdateDto.DateNaissance;
            patientFromRepo.Email = patientForUpdateDto.Email;
            patientFromRepo.TelFixe = patientForUpdateDto.TelFixe;
            patientFromRepo.Gsm = patientForUpdateDto.Gsm;
            patientFromRepo.PersonneContact = patientForUpdateDto.PersonneContact;
            patientFromRepo.TelContact = patientForUpdateDto.TelContact;
            patientFromRepo.Lateralite = patientForUpdateDto.Lateralite;
            patientFromRepo.Anamnese = patientForUpdateDto.Anamnese;
            patientFromRepo.Commentaire = patientForUpdateDto.Commentaire;
            patientFromRepo.Adresse.Rue = patientForUpdateDto.Adresse.Rue;
            patientFromRepo.Adresse.NumeroRue = patientForUpdateDto.Adresse.NumeroRue;
            patientFromRepo.Adresse.BoitePostal = patientForUpdateDto.Adresse.BoitePostal;
            patientFromRepo.Adresse.CodePostal = patientForUpdateDto.Adresse.CodePostal;
            patientFromRepo.Adresse.Ville = patientForUpdateDto.Adresse.Ville;
            patientFromRepo.Adresse.Pays = patientForUpdateDto.Adresse.Pays;
            
            if (await _repo.SaveAll())
             return NoContent();

            throw new Exception($"Les modifications pour le patient {id} n'ont pas pu être sauvegardées");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _repo.GetPatient(id);


            if (patient != null)
            {
                _repo.Delete(patient);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Suppression du patient impossible");
        }

    }
}