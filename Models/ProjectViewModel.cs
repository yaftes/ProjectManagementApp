using System.ComponentModel.DataAnnotations;
public class ProjectModel {
    [Required]   
    [StringLength(100)] 
    public string Title { get; set; } = "";
    [Required]
    public string Description { get; set; } = "";
    public string Start_Date {get; set;} = "";
    public string End_Date {get; set;} = "";

}

public class TaskModel {
    [Required]   
    [StringLength(100)] 
    public string Title { get; set; } = "";
    [Required]
    public string Description { get; set; } = "";
    public string Start_Date {get; set;} = "";
    public string End_Date {get; set;} = "";
    public string SelectedUserName {get;set;} ="";
    
    public List<ApplicationUser>? AvailableUsers {get;set;}

    
}
