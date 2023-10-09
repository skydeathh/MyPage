using MyPage.Domain.Consts.cs;
using MyPage.Domain.Exceptions;
using MyPage.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace MyPage.Domain.Entities;
public class User : IdentityUser<long> {

    private Name _name;
    private Surname _surname;
    private Role _role;

    private readonly List<Post> _posts = new();

    internal User(Id id, Name name, Surname surname, Role role) {
        _name = name;
        _surname = surname;
        _role = role;
    }

    public void AddPost(Post post) {
        _posts.Add(post);
//        AddEvent(new PackingItemAdded(this, item));
    }

    public void RemovePost(int id) {
        var post = GetItem(id);
        _posts.Remove(post);
//        AddEvent(new PackingItemRemoved(this, item));
    }

    private Post GetItem(int id) {
        var post = _posts.FirstOrDefault(p => p.Id == id);

        if (post is null) {
            throw new PostNotFoundExeption(id);
        }

        return post;
    }
}