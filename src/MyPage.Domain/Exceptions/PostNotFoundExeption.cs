using MyPage.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPage.Domain.Exceptions;

internal class PostNotFoundExeption : MyPageException {
    public PostNotFoundExeption(int postId) : base(message: $"Post with {postId} not found.") {

    }
}