using System;
using System.Collections.Generic;
using System.Text;
using BookApi.Models;
using BookApi.Repository;
using NUnit.Framework;

namespace BookApiTest
{
    [TestFixture]
    public class BookRepositoryTest
    {
        private BookRepository _bookRepository;

        [SetUp]
        public void SetUp()
        {
            _bookRepository = new BookRepository();
        }

        [Test]
        public void Should_return_null_if_book_doesnt_exist()
        {
            var book = _bookRepository.Find(10);

            Assert.That(book, Is.Null);
        }

        [Test]
        public void Should_add_new_book()
        {
            var newBook = new Book
            {
                Id = 2,
                Title = "Aldrig fucka upp",
                Intro = "Uppföljaren till succén...",
                Author = 1
            };

            _bookRepository.Create(newBook);
            var book = _bookRepository.Find(newBook.Id);

            Assert.That(book, Is.EqualTo(book));
        }

        [Test]
        public void Should_update_book()
        {
            var newBook = new Book
            {
                Id = 2,
                Title = "Aldrig fucka upp",
                Intro = "Uppföljaren till succén...",
                Author = 1
            };
            var updateBook = new Book
            {
                Id = 2,
                Title = "Sthlm Delete",
                Intro = "Lapidus nya serie...",
                Author = 1
            };

            _bookRepository.Create(newBook);
            _bookRepository.Update(newBook.Id, updateBook);

            var book = _bookRepository.Find(newBook.Id);

            Assert.That(book, Is.EqualTo(updateBook));
        }

        [Test]
        public void Should_remove_book()
        {
            var newBook = new Book
            {
                Id = 2,
                Title = "Aldrig fucka upp",
                Intro = "Uppföljaren till succén...",
                Author = 1
            };

            _bookRepository.Create(newBook);
            _bookRepository.Remove(newBook.Id);

            var book = _bookRepository.Find(newBook.Id);

            Assert.That(book, Is.Null);
        }
    }
}
