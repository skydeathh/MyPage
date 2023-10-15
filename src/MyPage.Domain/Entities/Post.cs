using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyPage.Domain.Entities;

public class Post {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public Post(string title, string content, DateTime createdDate, DateTime updatedDate, int userId) {
        Title = title;
        Content = content;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        UserId = userId;
    }
}