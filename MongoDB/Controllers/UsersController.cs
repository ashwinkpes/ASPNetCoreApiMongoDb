using Microsoft.AspNetCore.Mvc;

using MongoDB.Database.Models;
using MongoDB.Repository;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UsersController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _repository.Users.GetAllAsync();

            if (users is null || users.Count is 0)
                return NoContent();

            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            User user = await _repository.Users.FindAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        // GET: api/users/{id}/posts
        [HttpGet("{id}/posts")]
        public async Task<IActionResult> GetUserPostsAsync([FromRoute] Guid id)
        {
            User user = await _repository.Users.FindAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user.Posts);
        }

        [HttpPost("{id}/posts")]
        public async Task<IActionResult> PostPostAsync([FromRoute] Guid id, [FromBody] Post model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model");

            User user = await _repository.Users.FindAsync(id);

            if (user is null)
                return NotFound();

            await _repository.Users.AddPostAsync(id, model);
            return Ok();
        }

        // POST: api/users/signin
        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync([FromBody] User model)
        {
            Token token = await _repository.Users.SignInAsync(model);

            if (token is null)
                return Unauthorized();

            return Ok(token);
        }

        // POST: api/users/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] User model)
        {
            try
            {
                User user = new User(model.Name, model.Email, model.Password);
                Token token = await _repository.Users.SignUpAsync(user);

                if (token is null)
                    return BadRequest("Could not generate token");

                return Ok(token);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] User model)
        {
            await _repository.Users.UpdateAsync(id, model);
            return Ok();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _repository.Users.DeleteAsync(id);
            return Redirect("/");
        }
    }
}
