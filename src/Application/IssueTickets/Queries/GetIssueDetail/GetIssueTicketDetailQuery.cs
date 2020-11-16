﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeClinic.Application.Common.Exceptions;
using CodeClinic.Application.Common.Interfaces;
using CodeClinic.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.IssueItems.Queries.GetIssueDetail
{
  public  class GetIssueTicketDetailQuery : IRequest<IssueTicketDetailVm>
    {
        public int Id { get; set; }

    }

    public class GetIssueDetailQueryHandler : IRequestHandler<GetIssueTicketDetailQuery, IssueTicketDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIssueDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IssueTicketDetailVm> Handle(GetIssueTicketDetailQuery request, CancellationToken cancellationToken)
        {
            var viewModel = await _context.IssueTickets
                .ProjectTo<IssueTicketDetailVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(i => i.IssueId == request.Id, cancellationToken);
                
            if(viewModel == null) throw new NotFoundException(nameof(IssueTicket), request.Id);

            return viewModel;
        }
    }
}
