using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeter;
using Microsoft.Extensions.Logging;
using PostComment;

namespace GrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<BoolReply> AddComment(CommentRequest commentRequest, ServerCallContext context)
        {
            return Task.FromResult(new BoolReply
            {
                Message = commentRequest.Message
            });
        }

        public override Task<BoolReply> AddPost(PostRequest postRequest, ServerCallContext context)
        {
            return Task.FromResult(new BoolReply
            {
                Message = postRequest.Message.AddPost()
            });
        }

        public override Task<IntReply> DeletePost(IntRequest id, ServerCallContext context)
        {
            Post post = new Post();
            return Task.FromResult(new IntReply
            {
                Message = post.DeletePost(id.value)
            });
        }

        public override Task<CommentReply> GetCommentById(IntRequest id, ServerCallContext context)
        {
            Comment comment = new Comment();
            return Task.FromResult(new CommentReply
            {
                Message = comment.GetCommentById(id.value)
            });
        }

        public override Task<PostReply> GetPostById(IntRequest id, ServerCallContext context)
        {
            // E nevoie de ac instanta. Metodele din API sunt metode ale instantei.
            Post post = new Post();
            // Mesaj ce apare in server CUI. Nu e necesar.
            Console.WriteLine("GetPostById. Id = {0}", id);
            post = post.GetPostById(id.value); // Neclar acest cod.
            Console.WriteLine("Post returnat. Id = {0} , Description = {1}",
           post.PostId, post.Description);
            return Task.FromResult(new PostReply
            {
                Message = post
            });
        }

        public override Task<PostListReply> GetPosts(ServerCallContext context)
        {
            Post post = new Post();
            return Task.FromResult(new PostListReply
            {
                Message = post.GetAllPosts()
            });
        }

        public override Task<CommentReply> UpdateComment(CommentRequest newComment, ServerCallContext context)
        {
            return Task.FromResult(new CommentReply
            {
                Message = newComment.comment.UpdateComment(newComment.comment)
            });
        }

        public override Task<PostReply> UpdatePost(PostRequest postRequest)
        {
            return Task.FromResult(new PostReply
            {
                Message = postRequest.post.UpdatePost(postRequest.post)
            });
        }
    }
}
