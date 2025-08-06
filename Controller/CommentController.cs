
using ASP.Net.Dto.Comment;
using ASP.Net.Interface;
using ASP.Net.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controller
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            var comment = await _commentRepo.GetAllAsync();
            var commentDTO = comment.Select(s => s.ToCommentDTO());
            return Ok(commentDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
           
            var Comment = await _commentRepo.GetByIdAsync(id);
            if (Comment == null)
            {
                return NotFound();
            }
            return Ok(Comment.ToCommentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComment createComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var commentModel = createComment.ToCommentEntity();
            var commentCreated = await _commentRepo.CreateCommentAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentCreated.Id }, commentCreated.ToCommentDTO());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateComment updateComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var comment = await _commentRepo.UpdateCommentAsync(id, updateComment);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDTO());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            
            var CommentDelete = await _commentRepo.DeleteCommentAsync(id);
            if (CommentDelete == null)
            {
                return NotFound();
            }
            return Ok(new { message = "Delete successful" });
        }
    }
}