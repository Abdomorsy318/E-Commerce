using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Reposatories
{
    public class SpecificationEvaluator
    {
        public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specifications<T> specifications) where T : class
        {
            //Step 01:
            var query = inputQuery.AsQueryable();
            //Step 02: 
            if (specifications.Criteria != null)
                query = query.Where(specifications.Criteria);
            //Step 03: Aggregate Expressions
            //foreach(var item in  specifications.IncludeExpression)
            //{
            //    query = query.Include(item);
            //}
            query = specifications.IncludeExpression.Aggregate(query,
                (currentquery, includeexpression) => currentquery.Include(includeexpression));
            if (specifications.OrderBy != null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDesc != null)
            {
                query = query.OrderByDescending(specifications.OrderByDesc);
            }
            if(specifications.IsPagenated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }
            return query;
        }
    }
}
