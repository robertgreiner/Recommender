using System;
using System.Collections.Generic;
using Recommender.Common;
using Recommender.Instructions;
using Recommender.Reviews;

namespace Recommender.SimilarityScore
{
    public class EuclideanDistance : SimilarityScore
    {
        private readonly Reviewer R1;
        private readonly Reviewer R2;
        private List<string> SimilarReviews;

        public EuclideanDistance(Reviewer r1, Reviewer r2)
        {
            R1 = r1;
            R2 = r2;
        }

        public double Score()
        {
            SimilarReviews = new FindSimilarReviews(R1.Reviews, R2.Reviews).Calculate();
            
            if (DoReviewersHaveSimilarReviews())
            {
                return 0.0;
            }

            var sumDifferenceSquares = new SumDifferenceSquares(SimilarReviews, R1.Reviews, R2.Reviews).Calculate();
            return NormalizeAnswer(sumDifferenceSquares);
        }

        private static double NormalizeAnswer(double sumDifferenceSquares)
        {
            return Math.Round(1 / (1 + sumDifferenceSquares), 3);
        }

        private bool DoReviewersHaveSimilarReviews()
        {
            return SimilarReviews.Count == 0;
        }

       
    }
}
