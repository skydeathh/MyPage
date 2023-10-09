namespace MyPage.Domain.ValueObjects;

public record Post {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public Post(int id, string title, string content, DateTime createdAt) {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt;
    }
}