using System.ComponentModel.DataAnnotations;
public class ProjectModel {
    [Required]   
    [StringLength(100)] 
    public string Title { get; set; } = "";
    [Required]
    public string Description { get; set; } = ""; 

}
