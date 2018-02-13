using System.Collections.Generic;
using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
	[Route("[controller]")]
	public class AuthorsController : Controller
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorsController(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		[HttpGet]
		public IEnumerable<Author> Get()
		{
			return _authorRepository.All();
		}

		[HttpGet("{id}", Name = "GetAuthor")]
		public IActionResult Get(int id)
		{
			var author = _authorRepository.Find(id);
			if (author == null)
			{
				return NotFound();
			}

			return Ok(author);
		}

		[HttpPost]
		public IActionResult Post([FromBody] Author author)
		{
			_authorRepository.Create(author);
			return CreatedAtRoute("GetAuthor", new {id = author.Id}, author);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Author author)
		{
			_authorRepository.Update(id, author);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_authorRepository.Remove(id);
			return Ok();
		}
	}
}