﻿using Application.Issues.Commands.CreateIssue;
using FluentValidation;

namespace CodeClinic.Application.TodoItems.Commands.UpdateTodoItem
{
    public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            
            RuleFor(v => v.Title)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
