using MyPage.Domain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyPage.Domain.Entities;
public class User {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }   
    public string Password { get; set; }

    public readonly List<Post> Posts = new();

    public User(string firstName, string lastName, string email, string password) {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

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