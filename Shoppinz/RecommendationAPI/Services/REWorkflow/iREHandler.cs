using RecommendationAPI.Model;
using System.Reflection.Metadata;

namespace RecommendationAPI.Services.REWorkflow
{
    public interface iREHandler
    {
        void SetNext(iREHandler handler);
        TweetPost HandleRequest(RERequest request,TweetPost tpost);
    }
}
