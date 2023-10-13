﻿namespace MyPage.Domain.Entities;

public class Post {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public User User { get; set; }
    public int UserId { get; set; }
}