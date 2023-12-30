using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Domain.DAL;
using Domain.BLL;
using Domain.DTO;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;


namespace UserApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly ModelsConverter _converters;

        public UsersController(UserContext context, ModelsConverter converters)
        {
            _context = context;
            _converters = converters;
        }

        // GET: api/UserModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserItems()
        {
        
            return await _context.UserItems.Select(x=> _converters.ConvertToDTO(x)).ToListAsync();
        }

        // GET: api/UserModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserModel(long id)
        {
            var signUpModel = await _context.UserItems.FindAsync(id);

            if (signUpModel == null)
            {
                return NotFound();
            }
         return _converters.ConvertToDTO(signUpModel);
        }

        // PUT: api/UserModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(long id, UserDTO model)
        {   var signUpModel = _converters.ConvertToModel(model);
            if (id != signUpModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(signUpModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/UserModels
        [HttpPost]

        public async Task<ActionResult<UserDTO>> PostUserModel(UserDTO signUpModel)
        {
           _context.Add(_converters.ConvertToModel(signUpModel));
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserModelExists(signUpModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserModel", new { id = signUpModel.Id }, signUpModel);
        }

        // DELETE: api/UserModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel(long id)
        {
            var signUpModel = await _context.UserItems.FindAsync(id);
            if (signUpModel == null)
            {
                return NotFound();
            }

            _context.UserItems.Remove(signUpModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserModelExists(long id)
        {
            return _context.UserItems.Any(e => e.Id == id);
        }
    }
}
