using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorsController(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository ??
              throw new ArgumentNullException(nameof(AuthorRepository));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetAuthors")]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAllAuthors()
        {
            var authorsFromRepo = _authorRepository.GetAllAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpPut("{AuthorId}")]
        public IActionResult UpdateAuthor(int authorId, AuthorForUpdateDto author)
        {
            var authorEntity = _authorRepository.getAuthor(authorId);
            if (authorEntity == null)
                return NotFound();
            _mapper.Map(author, authorEntity);
            _authorRepository.UpdateAuthor();
            var authorDto = _mapper.Map<AuthorDto>(authorEntity);
            return NoContent();
        }
    }
}
