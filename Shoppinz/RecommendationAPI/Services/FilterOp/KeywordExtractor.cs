using RecommendationAPI.Model.ModelInterfaces;

namespace RecommendationAPI.Services.FilterOp
{
    public class KeywordExtractor : iOperation<iPost>
    {
        public iPost Execute(iPost input)
        {
            return Extract(input);
        }

        private iPost Extract(iPost input)
        {
            input.isKeywordsExtracted = true;
            return input;
        }
    }
}
