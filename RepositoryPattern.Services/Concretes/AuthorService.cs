using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstracts;
using RepositoryPattern.Services.DTOs;

namespace RepositoryPattern.Services.Concretes
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public AuthorDTO? Get(int id)
        {
            return _repository.Get().Where(c=>c.Id==id)
                .Select(c=>new AuthorDTO
            {
                Bio = c.Bio,
                BirthDate = c.BirthDate,
                Name = c.Name,
                Surname = c.Surname
            }).FirstOrDefault();
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            return _repository.Get().Select(c => new AuthorDTO
            {
                Bio = c.Bio,
                BirthDate = c.BirthDate,
                Name = c.Name,
                Surname = c.Surname
            }).ToList();
        }

        public void Add(AuthorDTO dto)
        {
            _repository.Add(new Author
            {
                IsDeleted = false,
                Bio = dto.Bio,
                BirthDate = dto.BirthDate,
                Name = dto.Name,
                Surname = dto.Surname,
                CreateDate = DateTime.Now,
                LastUpdateDate = null
            });
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public void Update(int id, AuthorDTO dto)
        {
            _repository.Update(new Author
            {
                Id = id,
                Bio = dto.Bio,
                BirthDate = dto.BirthDate,
                Name = dto.Name,
                Surname = dto.Surname,
                LastUpdateDate = DateTime.Now
            });
        }
    }
}
