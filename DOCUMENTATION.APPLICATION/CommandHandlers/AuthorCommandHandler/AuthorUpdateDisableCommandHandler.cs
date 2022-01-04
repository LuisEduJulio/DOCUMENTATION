﻿using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorUpdateDisableCommandHandler : IRequestHandler<AuthorUpdateDisableCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorUpdateDisableCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(AuthorUpdateDisableCommand request, CancellationToken cancellationToken)
        {
            var validation = await new AuthorUpdateDisableCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.Id);

            if (author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            author.Admin = false;
            author.DateUpdated = DateTime.Now;
            author.DateDeleted = DateTime.Now;

            await _authorRepository.UpdateAsync(author);

            return Unit.Value;
        }
    }
}