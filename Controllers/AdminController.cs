// role of the admin is to add users and skill sets
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class AdminController : Controller {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly ApplicationDbContext _dbContext;

    private readonly SignInManager<ApplicationUser> _signInManager;
    public AdminController(
        UserManager<ApplicationUser> _userManager,
        RoleManager<ApplicationRole> _roleManager,
        SignInManager<ApplicationUser> _signInManager,
        ApplicationDbContext _dbContext){
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._dbContext = _dbContext;
            this._signInManager = _signInManager;
        }
    
            [HttpGet]
            public IActionResult Register()
            {
                var model = new RegisterViewModel(){
                    ListofSkill = _dbContext.Skill.ToList(),
                };
                
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model,string select)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        UserName = model.UserName,
                        Skills = _dbContext.Skill.ToList(),
                        
                    };
                    
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user,select);

                        return RedirectToAction("Login", "Login");

                    }
                    ModelState.AddModelError(string.Empty, "Failed to register user.");
                }
                return View(model);
            }

        public  IActionResult AddSkill(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(CreateSkill model){
            if (ModelState.IsValid){
                 bool check = _dbContext.Skill.Any(s => s.SkillName == model.skillName); 
                if(!check){
                    Skill skill = new Skill(){
                        SkillName = model.skillName,
                    };
                     _dbContext.Skill.Add(skill);
                    await _dbContext.SaveChangesAsync();
         
                    return View();
                }
                else {
                    ModelState.AddModelError(string.Empty,"Already Exists");
                    return View();
                }

            }
            return View();
        }
        
}
        

