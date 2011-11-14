using System;
using System.Collections.Generic;
using Recommender.Common;
using Recommender.Instructions;
using Recommender.Reviews;

namespace Recommender.SimilarityScore
{
    public class PearsonCorrelation : SimilarityScore
    {
        private readonly Reviewer R1;
        private readonly Reviewer R2;
        private List<string> SimilarReviews;

        public PearsonCorrelation(Reviewer r1, Reviewer r2)
        {
            R1 = r1;
            R2 = r2;
        }
        
        public double Score()
        {
            SimilarReviews = new FindSimilarReviews(R1.Reviews, R2.Reviews).Calculate();

            if (ReviewersHaveNoSimilarReviews())
            {
                return 0.0;
            }

            var n = SimilarReviews.Count;

            var sumR1 = new SumScores(SimilarReviews, R1.Reviews).Calculate();
            var sumR2 = new SumScores(SimilarReviews, R2.Reviews).Calculate();
            
            var sumR1Sq = new SumSquares(SimilarReviews, R1.Reviews).Calculate();
            var sumR2Sq = new SumSquares(SimilarReviews, R2.Reviews).Calculate();

            var pSum = new SumProducts(SimilarReviews, R1.Reviews, R2.Reviews).Calculate();

            var num = Covariance(sumR1, sumR2, pSum, n);
            var den = Math.Sqrt(StandardDeviation(sumR1, sumR1Sq, n) * StandardDeviation(sumR2, sumR2Sq, n));

            if (den == 0.0)
            {
                return 0.0;
            }

            var answer = num / den;
            return Math.Round(answer, 3);
        }

        private static double Covariance(double sumR1, double sumR2, double sumOfProducts, int n)
        {
            return sumOfProducts - (sumR1 * sumR2 / n);
        }

        private static double StandardDeviation(double sum, double sumOfSquares, int numberOfItems)
        {
            return (sumOfSquares - Math.Pow(sum, 2) / numberOfItems);
        }

        private bool ReviewersHaveNoSimilarReviews()
        {
            return SimilarReviews.Count == 0;
        }
    }
}
