using System;
using Recommender.Common;
using Recommender.Reviews;
using Recommender.Steps;

namespace Recommender
{
    public class EuclideanDistance : SimilarityScore
    {
        private readonly Reviewer R1;
        private readonly Reviewer R2;

        public EuclideanDistance(Reviewer r1, Reviewer r2)
        {
            R1 = r1;
            R2 = r2;
        }

        public double Score()
        {
            var similarReviews = new FindSimilarReviews(R1.Reviews, R2.Reviews).Calculate();
            
            if (similarReviews.Count == 0)
            {
                return 0.0;
            }

            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, R1.Reviews, R2.Reviews).Calculate();
            return Math.Round(1 / (1 + sumDifferenceSquares), 3);
        }
    }
}
