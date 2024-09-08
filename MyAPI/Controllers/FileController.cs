using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class FileController : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var filePath = Path.Combine("Uploads", file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { FilePath = filePath });
    }

    [HttpGet("{id}")]
    public IActionResult GetFile(int id)
    {
        // Fetch file info from database
        // Example response
        return Ok(new { FileUrl = "http://example.com/file" });
    }

    [HttpGet("search")]
    public IActionResult SearchFiles(string query)
    {
        // Implement search logic here
        return Ok(new { Files = new string[] { "file1", "file2" } });
    }
}
