using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAPIDemo.Entities;
using CoreAPIDemo.Repository.Contract;
using Microsoft.AspNetCore.Authorization;

namespace CoreAPIDemo.Controllers
{
    [Route("api/Libraries")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository<Author> _libraryRepository;

       

        public LibrariesController(ILibraryRepository<Author> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        // GET: api/Libraries/GetAllAuthor
     [Authorize]
        [HttpGet]
        [Route("GetAllAuthor")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Author> authors = null;  
            var currentUser = HttpContext.User;
          

            if (currentUser.HasClaim(c => c.Type == "DateOfJoing"))
            {
                 authors = _libraryRepository.GetAllAuthor();
                
            }
            return Ok(authors);
        }
        [HttpGet]
        [Route("GetAuthor")]

        public IActionResult GetAuthor(Guid authorId)
        {
            try
            {
                Author author = _libraryRepository.GetAuthor(authorId);
                return Ok(author);
            }
            catch(Exception ex)
            {
                //log exception 
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteAuthor")]
        public IActionResult DeleteAuthor(Guid authorId)
        {
            try
            {
                int result = _libraryRepository.DeleteAuthor(authorId);
               
                return Ok(result);
            }
            catch (Exception ex)
            {
                //log Exception
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddAuthor")]
        public IActionResult AddAuthor([FromBody]Author authorparam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _libraryRepository.PostAuthor(authorparam);
                    return Ok(author);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                //log Exception
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("UpdateAuthor")]
        public IActionResult UpdateAuthor([FromBody]Author authorparam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author author = _libraryRepository.UpdateAuthor(authorparam);
                    return Ok(author);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                //log Exception
                return BadRequest();
            }
        }
        



    }

   


}