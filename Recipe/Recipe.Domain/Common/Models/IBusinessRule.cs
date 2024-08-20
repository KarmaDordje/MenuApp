namespace Recipe.Domain.Common.Models
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}