using DTTL.IL.HRT.Employees.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DTTL.IL.HRT.Employees.APIs.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public List<UserModel> users = new List<UserModel>
    {
        new UserModel("Cohen, Daniel",  "FullStack Engineer","daniel@deloitte.co.ill", "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Dahan, David" ,  "Spec Eng",          "david@deloitte.co.ill" ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Lorem, Yotam" , "Designer",           "yotam@deloitte.co.ill" ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Ipsum, Alex"  ,"QA Engineer",         "alex@deloitte.co.ill"  ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Maron, Yael"  ,"FullStack Engineer",  "yael@deloitte.co.ill"  ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Mikon, Shlomi"  ,"Low Code Implementor",  "shlomi@deloitte.co.ill"  ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Shitrit, Yarden"  ,"Low Code Implementor",  "yarden@deloitte.co.ill"  ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
        new UserModel("Noh, Moti"  ,"Low Code Implementor",  "moti@deloitte.co.ill"  ,  "https://www.pinclipart.com/picdir/middle/541-5416602_dummy-profile-image-url-clipart.png"),
    };

    [HttpGet]
    public List<UserModel> Get()
    {
        return users;
    }

    public class SearchRequest
    {
        public string Text { get; set; }
    }

    [HttpPost]
    public ActionResult<List<UserModel>> Post([FromBody] SearchRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Text))
            return BadRequest("Search text cannot be empty.");

        var filteredUsers = users
            .Where(u => u.FullName.Contains(request.Text, StringComparison.OrdinalIgnoreCase)
                     || u.WorkTitle.Contains(request.Text, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(filteredUsers);
    }


}

