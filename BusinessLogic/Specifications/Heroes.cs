using Ardalis.Specification;
using BusinessLogic.Entities;

namespace BusinessLogic.Specifications
{
    public static class Heroes
    {
        public class GetAll : Specification<Hero>
        {
            public GetAll()
            {
                Query
                    .Include(x => x.Card)
                    .Include(x => x.City)
                    .Include(x => x.Battalion);
            }
        }

        public class GetById : Specification<Hero>
        {
            public GetById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Card)
                    .Include(x => x.City)
                    .Include(x => x.Battalion);
            }
        }

        public class FilterByCity : Specification<Hero>
        {
            public FilterByCity(string city)
            {
                Query
                    .Include(x => x.City)
                    .Where(x => x.City.Name == city)
                    .Include(x => x.Card)
                    .Include(x => x.Battalion);
            }
        }

        public class FilterByBattalion : Specification<Hero>
        {
            public FilterByBattalion(string battalion)
            {
                Query
                    .Include(x => x.Battalion)
                    .Where(x => x.Battalion.Name == battalion)
                    .Include(x => x.Card)
                    .Include(x => x.City);
            }
        }

        public class FilterByName : Specification<Hero>
        {
            public FilterByName(string name)
            {
                Query
                    .Where(x => x.Name.Contains(name))
                    .Include(x => x.Card)
                    .Include(x => x.City)
                    .Include(x => x.Battalion);
            }
        }
    }
}
