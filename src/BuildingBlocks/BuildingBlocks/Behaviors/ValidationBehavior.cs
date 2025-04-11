using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TRespone>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TRespone>
        where TRequest : ICommand<TRespone>
    {
        public async Task<TRespone> Handle(TRequest request, 
            RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = 
                await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failure = 
                validationResults
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .ToList();

            if(failure.Any())
            {
                throw new ValidationException(failure);
            }

            return await next();
        }
    }
}
