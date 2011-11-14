using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recommender.Common
{
    public class FindOppositeReviews
    {
        private readonly Dictionary<string, double> FirstUserReviews;
        private readonly Dictionary<string, double> SecondUserReviews;

        public FindOppositeReviews(Dictionary<string, double> firstUserReviews, Dictionary<string, double> secondUserReviews)
        {
            FirstUserReviews = firstUserReviews;
            SecondUserReviews = secondUserReviews;
        }

        public List<string> Calculate()
        {
            return (from r in SecondUserReviews where ShouldCountReviewAsOpposite(r) select r.Key).ToList();
        }

        private bool ShouldCountReviewAsOpposite(KeyValuePair<string, double> r)
        {
            return IsReviewUnique(r) && IsReviewValid(SecondUserReviews[r.Key]);
        }

        private static bool IsReviewValid(double value)
        {
            return value > 0.0;
        }

        private bool IsReviewUnique(KeyValuePair<string, double> r)
        {
            return !FirstUserReviews.ContainsKey(r.Key);
        }
    }
}
