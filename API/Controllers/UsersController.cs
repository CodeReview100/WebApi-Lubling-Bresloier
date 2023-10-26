using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

   
    public class UsersController : ControllerBase
    {
      
        // GET api/<ValuesController>
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string userName="", [FromQuery] string password="")
        {
           User userAgsist = userService.getUser(userName, password);
            if(userAgsist ==null)
            {
                return NoContent();
            }
            return Ok(userAgsist);

        }


        UserService userService = new UserService();

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {

            User newUser = userService.addUser(user);
            if (newUser == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }




        [HttpPost("check")]
        public int Check([FromBody] string password)
        {
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return result.Score;
            }
            return -1;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            User newUser = userService.editUser(userToUpdate);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
