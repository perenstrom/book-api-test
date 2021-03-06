﻿using System.Collections.Generic;
using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApi.Controllers
{
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.All();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult Get(int id)
        {
            var book = _bookRepository.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Book book)
        {
            _bookRepository.Create(book);
            return CreatedAtRoute("GetBook", new {id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book book)
        {
            _bookRepository.Update(id, book);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookRepository.Remove(id);
            return Ok();
        }
    }
}
