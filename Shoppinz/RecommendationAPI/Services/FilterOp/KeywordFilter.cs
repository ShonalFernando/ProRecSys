using RecommendationAPI.Model.ModelInterfaces;

namespace RecommendationAPI.Services.FilterOp
{
    public class KeywordFilter : iOperation<iPost>
    {
        public iPost Execute(iPost input)
        {
            input.isPostFiltered = true;
            return input;
        }
    }
}
