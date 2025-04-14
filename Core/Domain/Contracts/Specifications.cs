using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifications<T> where T : class
    {
        public Specifications(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>>? Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpression { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T , object>> OrderBy { get; private set; }
        public Expression<Func<T , object>> OrderByDesc { get; private set; }
        #region For Pagination
        public int Skip { get; set; }
        public int Take {  get; set; }
        public bool IsPagenated {  get; set; }
        #endregion
        protected void AddInclude(Expression<Func<T, object>> expression)
        => IncludeExpression.Add(expression); 
        protected void SetOrderBy(Expression<Func<T, object>> expression)
        => OrderBy = expression;
        protected void SetOrderByDesc(Expression<Func<T, object>> expression)
        => OrderByDesc = expression;
        protected void ApplyPagination(int pageIndex ,  int pageSize)
        {
            IsPagenated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
    }
}
