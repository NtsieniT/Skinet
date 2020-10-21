using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        // This method takes includes statement and aggregates them and pass 
        // them in the query and return the results
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification)
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria); // eg: p => p.ProductTypeId == id
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy); // for ordering
            }

            if (specification.OrderByDecending != null)
            {
                query = query.OrderByDescending(specification.OrderByDecending); // for ordering descending
            }


            if (specification.isPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }


            query = specification.Includes.Aggregate(query, (current, include) =>
            current.Include(include));

            return query;
        }
    }
}
