using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.Validators
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(expression: x => x.FirstName)
                .NotEmpty()
                .Matches(expression: "^[a-zA-Z]*$");

            RuleFor(expression: x => x.LastName)
            .NotEmpty()
            .Matches(expression: "^[a-zA-Z]*$");

            RuleFor(expression: x => x.Iin)
            .NotEmpty()
            .Matches(expression: "^[0-9]*$")
            .Length(12);

            RuleFor(expression: x => x.BirthDate)
            .NotEmpty();
            


        }

    }
}
