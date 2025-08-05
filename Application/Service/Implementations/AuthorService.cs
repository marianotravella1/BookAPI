using Application.Models.Requests;
using Application.Service.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorDto>> GetAuthors()
        {

            var authors = await _authorRepository.GetAuthors();

            return authors
                .Select(author => new AuthorDto
                {
                    Id = author.Id,
                    Name = author.Name,
                })
                .ToList();
        }
    }
}
