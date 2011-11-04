using System.Collections.Generic;
using System.Linq;

namespace Recommender.Common
{
    public class FindSimilarReviews
    {
        private readonly Dictionary<string, double> FirstUserReviews;
        private readonly Dictionary<string, double> SecondUserReviews;

        public FindSimilarReviews(Dictionary<string, double> firstUserReviews, Dictionary<string, double> secondUserReviews)
        {
            FirstUserReviews = firstUserReviews;
            SecondUserReviews = secondUserReviews;
        }

        public List<string> Calculate()
        {
            return (from r in FirstUserReviews where SecondUserReviews.ContainsKey(r.Key) select r.Key).ToList();
        }
    }
}