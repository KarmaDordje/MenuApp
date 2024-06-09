namespace Recipe.API.Common.Errors
{
    using FluentResults;


    public record struct DuplicateIngredientError : IError
    {

        public List<IError> Reasons => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}