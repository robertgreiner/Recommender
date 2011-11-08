using System.Collections.Generic;
using System.Linq;

namespace Recommender.Instructions
{
    public class SumScores : SimilarityScoreCommand
    {
        private readonly List<string> SimilarReviews;
        private readonly Dictionary<string, double> UserReviews;

        public SumScores(List<string> similarReviews, Dictionary<string, double> userReviews)
        {
            SimilarReviews = similarReviews;
            UserReviews = userReviews;
        }

        public double Calculate()
        {
            return SimilarReviews.Sum(title => UserReviews[title]);
        }
    }
}
