namespace Recipe.Domain.RecipeAggregate.Entities
{
    using global:: Recipe.Domain.Common.Models;
    using global::Recipe.Domain.ValueObjects;
    public class RecipeStep : Entity<RecipeStepId>
    {
        public int Order { get; private set; }
        public string Name { get; private set; }
        public string ImgUrl { get; private set; }
        public string VideoUrl { get; private set; }
        private RecipeStep(int order, string name, string imgUrl, string videoUrl)
        : base(RecipeStepId.CreateUnique())
        {
            Name = name;
            Order = order;
            ImgUrl = imgUrl;
            VideoUrl = videoUrl;
        }

        public static RecipeStep Create(int order, string name, string imgUrl, string videoUrl)
        {
        // TODO: enforce invariants
            return new RecipeStep(order, name, imgUrl, videoUrl);
        }

#pragma warning disable CS8618
        private RecipeStep()
        {
        }
#pragma warning restore CS8618
    }
}