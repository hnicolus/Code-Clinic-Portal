﻿using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using CodeClinic.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Issues.Commands.UpdateIssue
{
    public class UpdateIssueTicketCommand : IRequest
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public ProgressStatus Status { get; set; }
        public string  Body { get; set; }

        public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueTicketCommand>
        {
            private readonly IApplicationDbContext _ctx;

            public UpdateIssueCommandHandler(IApplicationDbContext ctx)
            {
                _ctx = ctx;
            }

            public async Task<Unit> Handle(UpdateIssueTicketCommand request, CancellationToken cancellationToken)
            {
                var entity = await _ctx.IssueTickets.FindAsync(request.Id);

                if (entity == null) throw new NotFoundException(nameof(IssueTicket), request.Id);

                entity.Title = request.Title;
                entity.Body = request.Body;
                entity.Status = request.Status;

                _ctx.IssueTickets.Update(entity);

                await _ctx.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }


    
}
