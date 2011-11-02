using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recommender.Steps
{
    public class SumDifferenceSquares : SimilarityScoreCommand
    {
        private readonly List<string> SimilarReviews;
        private readonly Dictionary<string, double> FirstUserReviews;
        private readonly Dictionary<string, double> SecondUserReviews;

        public SumDifferenceSquares(List<string> similarReviews, Dictionary<string, double> firstUserReviews, Dictionary<string, double> secondUserReviews)
        {
            SimilarReviews = similarReviews;
            FirstUserReviews = firstUserReviews;
            SecondUserReviews = secondUserReviews;
        }

        public double Calculate()
        {
            return SimilarReviews.Sum(title => Math.Pow(FirstUserReviews[title] - SecondUserReviews[title], 2));
        }
    }
}
