using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using Tweetbook.Contracts.V1.Responses;
using Tweetbook.Domain;
using Tweetbook.Services;

namespace Tweetbook.Controllers.V1
{ 
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostsController : Controller
    {

        private readonly IPostService _postService;
        
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }




        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {

            var post = new Post
            {
                Id = postId,
                Iin = request.Iin,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate.ToString("yyyy-MM-dd")
            };

            var updated = await _postService.UpdatePostAsync(post);

            if (updated)
                return Ok(post);
            
            return NotFound();
        }




        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {

            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
                return NotFound();
            
            return Ok(post);
        }




        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {

           var deleted = await _postService.DeletePostAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();

        }



        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            
            var post = new Post 
            {
                Iin = postRequest.Iin,
                FirstName = postRequest.FirstName,
                LastName = postRequest.LastName,
                BirthDate = postRequest.BirthDate.ToString("yyyy-MM-dd")
            };

            await _postService.CreatePostAsync(post);

            
            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUri + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse {Id = post.Id };
            return Created(locationUri, postRequest);
        }












    }
}
