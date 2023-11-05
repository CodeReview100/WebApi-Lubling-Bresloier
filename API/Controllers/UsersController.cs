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
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET api/<ValuesController>
        [HttpGet]
        // Consider using a meaningful variable name like userFound (Do you mean userExists? ) 
        //getUserByNameAndPassword- more meaningfull function name
        public async Task<ActionResult<User>> Get(
            [FromQuery] string userName="", [FromQuery] string password="")
        {
           User userAgsist = await _userService.getUser(userName, password);

            if(userAgsist ==null)
            {
                return  NotFound();
                //Use Unauthorized() , (or NoContent())
                //The 401 (Unauthorized) status code indicates that the request has not been applied because it lacks valid authentication credentials for the target resource.
                //404 is indicating that the requested address (URL) is not found or does not exist.
            }
            return  Ok(userAgsist);

        }
        //GetUserById??? add...

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            User newUser =await _userService.addUser(user);
            if (newUser == null)
            {
                return  NoContent();//BadRequest()
            }
            return  CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }
        //suggestion for shorter and nicer code- == null ? BadRequest("Password isn't strong") : CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);


        [HttpPost("check")]
       //meaningfull function name: CheckPasswordStrength
        public async Task<int> Check([FromBody] string password)
        {
            //Call to the adjusted function in service. Don't implement logical code in the controller. 
            if (password != "")
            {
                var result = Zxcvbn.Core.EvaluatePassword(password);
                return  result.Score;
            }
            return  -1;

        }



        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
           //User updatedUser (clean code) 
            User newUser = await _userService.editUser(userToUpdate);
            if (newUser != null)
            {
                return  Ok(newUser);
            }

            return  NoContent();//BadRequest()

        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
