using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recommender.Steps
{
    public class SumSquaresOfSimilarScores : SimilarityScoreCommand
    {
        private readonly List<string> SimilarReviews;
        private readonly Dictionary<string, double> UserReviews;

        public SumSquaresOfSimilarScores(List<string> similarReviews, Dictionary<string, double> userReviews)
        {
            SimilarReviews = similarReviews;
            UserReviews = userReviews;
        }

        public double Calculate()
        {
            return SimilarReviews.Sum(title => Math.Pow(UserReviews[title], 2));
        }
    }
}
