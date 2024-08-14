using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class ProjectController : Controller {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _dbContext;
    public ProjectController(
        UserManager<ApplicationUser> _userManager,
        RoleManager<ApplicationRole> _roleManager,
        ApplicationDbContext _dbContext){
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._dbContext = _dbContext;
        }
   
     
     [HttpGet]
     public async Task<IActionResult> ProjCreate(){

        return View();
     }
     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> ProjCreate(ProjectModel model){

        var curruser = await _userManager.GetUserAsync(User);
      
         if (ModelState.IsValid){
            Project project = new Project(){
                Title = model.Title,
                Description = model.Description,
                Created_At = DateTime.UtcNow,
                Start_Date = DateTime.Parse(model.Start_Date),
                End_Date = DateTime.Parse(model.End_Date),
                UserId = curruser?.Id
            };
            _dbContext.Project.Add(project);
            _dbContext.SaveChanges(); 
         }
         
        return View(model);
     }
     [HttpGet]
     public async Task<IActionResult> AllProjects(){
        return View();
     }  
        


}

