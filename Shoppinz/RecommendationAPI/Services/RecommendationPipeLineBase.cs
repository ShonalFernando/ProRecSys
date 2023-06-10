using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace RecommendationAPI.Services
{
    public abstract class RecommendationPipeLineBase<T>
    {
        private readonly List<IOperation<T>> operations = new List<IOperation<T>>();
    }
}
