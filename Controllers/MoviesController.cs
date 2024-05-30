using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Movie_Database_App.Models;
using Movie_Database_App.Repository;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMongoRepository<Movie> _repository;

    public MoviesController(IMongoRepository<Movie> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAll());

    [HttpGet("GetMovie")]
    public async Task<IActionResult> Get(string id)
    {
        var movie = await _repository.Get(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Movie movie)
    {
        await _repository.Create(movie);
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Update(string id, Movie movie)
    {
        var existingMovie = await _repository.Get(id);
        if (existingMovie == null) return NotFound();

        movie.Id = existingMovie.Id;
        await _repository.Update(id, movie);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var movie = await _repository.Get(id);
        if (movie == null) return NotFound();

        await _repository.Delete(id);
        return NoContent();
    }
}
