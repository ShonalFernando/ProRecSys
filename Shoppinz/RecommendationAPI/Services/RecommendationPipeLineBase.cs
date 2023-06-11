using System.Collections.Generic;
using System.Linq;

namespace RecommendationAPI.Services
{
    public abstract class RecommendationPipeLineBase<T>
    {
        private readonly List<iOperation<T>> operations = new List<iOperation<T>>();

        public RecommendationPipeLineBase<T> Register(iOperation<T> operation)
        {
            this.operations.Add(operation);
            return this;
        }

        public T PerformOperation(T input)
        {
            return this.operations.Aggregate(input, (current, operation) => operation.Execute(current));
        }
    }
}
