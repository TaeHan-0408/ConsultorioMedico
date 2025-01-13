using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        protected void AddOrderBy(Expression<Func<T, Object>> orderByExpression)
        {
            OrderBy = orderByExpression;

        }
        protected void AddOrderByDescending(Expression<Func<T, Object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;

        }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool paginaHabilitada { get; private set; }
        protected void AplicarPaginado(int take, int skip)
        {
            Skip = skip;
            Take = take;
            paginaHabilitada = true;
        }
    }
}
