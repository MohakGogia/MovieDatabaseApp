using Microsoft.AspNetCore.Mvc;
using Movie_Database_App.Models;
using Movie_Database_App.Repository;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IMongoRepository<Movie> _movieRepository;

    public ReviewsController(IMongoRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(string movieId, Review review)
    {
        var movie = await _movieRepository.Get(movieId);
        if (movie == null) return NotFound();

        movie.Reviews.Add(review);
        await _movieRepository.Update(movieId, movie);
        return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetReview(string movieId, string id)
    {
        var movie = await _movieRepository.Get(movieId);
        if (movie == null) return NotFound();

        var review = movie.Reviews.FirstOrDefault(r => r.Id == id);
        if (review == null) return NotFound();

        return Ok(review);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateReview(string movieId, string id, Review review)
    {
        var movie = await _movieRepository.Get(movieId);
        if (movie == null) return NotFound();

        var existingReview = movie.Reviews.FirstOrDefault(r => r.Id == id);
        if (existingReview == null) return NotFound();

        existingReview.ReviewerName = review.ReviewerName;
        existingReview.Comment = review.Comment;
        existingReview.Rating = review.Rating;

        await _movieRepository.Update(movieId, movie);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteReview(string movieId, string id)
    {
        var movie = await _movieRepository.Get(movieId);
        if (movie == null) return NotFound();

        var review = movie.Reviews.FirstOrDefault(r => r.Id == id);
        if (review == null) return NotFound();

        movie.Reviews.Remove(review);
        await _movieRepository.Update(movieId, movie);
        return NoContent();
    }
}
