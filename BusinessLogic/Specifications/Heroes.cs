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
    }
}
