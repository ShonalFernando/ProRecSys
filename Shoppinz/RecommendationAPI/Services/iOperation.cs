namespace RecommendationAPI.Services
{
    public interface iOperation<T>
    {
        T Execute(T input);
    }
}
