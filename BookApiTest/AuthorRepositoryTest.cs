using BookApi.Models;
using BookApi.Repository;
using NUnit.Framework;

namespace BookApiTest
{
    [TestFixture]
    public class AuthorRepositoryTest
    {
        private AuthorRepository _authorRepository;

        [SetUp]
        public void SetUp()
        {
            _authorRepository = new AuthorRepository();
        }

        [Test]
        public void Should_return_null_if_author_doesnt_exist()
        {
            var author = _authorRepository.Find(10);

            Assert.That(author, Is.Null);
        }

        [Test]
        public void Should_add_new_author()
        {
            var newAuthor = new Author
            {
                Id = 2,
                Name = "Jens Lapidus"
            };

            _authorRepository.Create(newAuthor);
            var author = _authorRepository.Find(newAuthor.Id);

            Assert.That(author, Is.EqualTo(author));
        }

        [Test]
        public void Should_update_author()
        {
            var newAuthor = new Author
            {
                Id = 2,
                Name = "Jens Lapidus"
            };
            var updateAuthor = new Author
            {
                Id = 2,
                Name = "Hulk Hogan"
            };

            _authorRepository.Create(newAuthor);
            _authorRepository.Update(newAuthor.Id, updateAuthor);

            var author = _authorRepository.Find(newAuthor.Id);

            Assert.That(author, Is.EqualTo(updateAuthor));
        }

        [Test]
        public void Should_remove_author()
        {
            var newAuthor = new Author
            {
                Id = 2,
                Name = "Jens Lapidus"
            };

            _authorRepository.Create(newAuthor);
            _authorRepository.Remove(newAuthor.Id);

            var author = _authorRepository.Find(newAuthor.Id);

            Assert.That(author, Is.Null);
        }
    }
}
