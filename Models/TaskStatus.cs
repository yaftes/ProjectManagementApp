
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskStatus {
    [Key]
    public int Id {get;set;}
    public string? Status {get;set;}
    // Navigation Properties
    public Task? Task {get;set;}
    // foreign Key
    [ForeignKey("Task")]
    public int TaskId {get;set;}
}