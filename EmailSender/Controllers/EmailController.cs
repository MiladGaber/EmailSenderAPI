using EmailSender.Core.Interfaces;
using EmailSender.Core.Models;
using EmailSender.Core.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailSender.API.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IUnitOfWork<Email> _email;

        public EmailController(IUnitOfWork<Email> email)
        {
            _email = email;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _email.Entity.GetAllAsync());
        }


        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _email.Entity.GetByIdAsync(id);
            if (result != null) return Ok(result);
            return BadRequest("Not Founded");
        }

        [HttpPost]
        [Route("addEmail")]
        public async Task<IActionResult> AddEmailData([FromBody] CreateEmailVM model)
        {
            if (ModelState.IsValid)
            {
                var email = new Email
                {
                    Subject = model.Subject,
                    Message = model.Message
                };

                var result = await _email.Entity.AddAsync(email);
                _email.Save();
                return result != null ? Ok(result) : BadRequest(result);
            }
            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        [HttpPut]
        [Route("editEmail")]
        public async Task<IActionResult> EditEmailData([FromBody] Email model)
        {

            if (ModelState.IsValid)
            {
                _email.Entity.Attach(model);
                _email.Save();
                return NoContent();
            }
            return BadRequest("Some properties are not valid"); // Status code: 400
        }

        [HttpDelete]
        [Route("deleteEmail")]
        public async Task<IActionResult> DeleteEmailData(int id)
        {
            if (await _email.Entity.GetByIdAsync(id) == null || id == null) return NotFound();

            _email.Entity.Delete(id);
            _email.Save();
            return NoContent();
        }



    }
}

