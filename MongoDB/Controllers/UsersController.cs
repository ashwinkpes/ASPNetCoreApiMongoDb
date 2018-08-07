using Microsoft.AspNetCore.Mvc;

using MongoDB.Database.Models;
using MongoDB.Manager;
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
        private readonly IAccountManager<User> _accountManager;
        private readonly IRepositoryWrapper _repository;

        public UsersController(IAccountManager<User> accountManager, IRepositoryWrapper repository)
        {
            _accountManager = accountManager;
            _repository = repository;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _repository.Users.GetAllAsync();

            if (users.Count is 0)
                return NoContent();

            return Ok(users);
        }

        // GET: api/users/{id}
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

        // POST: api/users/{id}/posts
        [HttpPost("{id}/posts")]
        public async Task<IActionResult> PostPostAsync([FromRoute] Guid id, [FromBody] Post model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Token token = await _accountManager.SignInAsync(model);

            if (token is null)
                return Unauthorized();

            return Ok(token);
        }

        // POST: api/users/signup
        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Token token = await _accountManager.SignUpAsync(model);

                if (token is null)
                    return BadRequest("Could not generate token");

                return Ok(token);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] User model)
        {
            await _repository.Users.UpdateAsync(id, model);
            return Ok();
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _repository.Users.DeleteAsync(id);
            return Redirect("/");
        }
    }
}
