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
                    .Include(x => x.Card);
            }
        }

        public class GetById : Specification<Hero>
        {
            public GetById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Card);
            }
        }

        public class FilterByCity : Specification<Hero>
        {
            public FilterByCity(string city)
            {
                Query
                    .Include(x => x.Card)
                    .Where(x => x.City.Name == city);
            }
        }

        public class FilterByBattalion : Specification<Hero>
        {
            public FilterByBattalion(string battalion)
            {
                Query
                    .Include(x => x.Card)
                    .Where(x => x.Battalion.Name == battalion);
            }
        }

        public class FilterByName : Specification<Hero>
        {
            public FilterByName(string name)
            {
                Query
                    .Include(x => x.Card)
                    .Where(x => x.Name.Contains(name));
            }
        }
    }
}
