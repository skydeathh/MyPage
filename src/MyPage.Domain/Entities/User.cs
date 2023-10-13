﻿using MyPage.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace MyPage.Domain.Entities;
public class User {
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }   
    public string Password { get; set; }

    public readonly List<Post> Posts = new();

    public void AddPost(Post post) {
        Posts.Add(post);
    }

    public void RemovePost(int id) {
        var post = GetItem(id);
        Posts.Remove(post);
    }

    private Post GetItem(int id) {
        var post = Posts.FirstOrDefault(p => p.Id == id);

        if (post is null) {
            throw new PostNotFoundExeption(id);
        }

        return post;
    }
}