namespace Menu.Contracts.Menu;

    using global::Menu.Domain.Common.Shared;
    public class CreateMenuRequest
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public List<MealCategory> MealTypes { get; set; }
        public int Days { get; set; }
    }