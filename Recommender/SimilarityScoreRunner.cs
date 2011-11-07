using System;
using Recommender.Data;

namespace Recommender
{
    class SimilarityScoreRunner
    {
        static void Main(string[] args)
        {
            RunEuclideanDistanceWithLowScore();
            RunPearsonCorrelationWithLowScore();
            Console.WriteLine();
            RunEuclideanDistanceWithHighScore();
            RunPearsonCorrelationWithHighScore();
            Console.ReadKey();
        }

        private static void RunEuclideanDistanceWithLowScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer2();
            var euclideanDistance = new EuclideanDistance(r1, r2);

            Console.WriteLine("The Euclidean Distance between {0} and {1} is: {2}", r1.Name, r2.Name, euclideanDistance.Score());
        }

        private static void RunEuclideanDistanceWithHighScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer4();
            var r2 = ReviewerBuilder.BuildReviewer1();
            var euclideanDistance = new EuclideanDistance(r1, r2);

            Console.WriteLine("The Euclidean Distance between {0} and {1} is: {2}", r1.Name, r2.Name, euclideanDistance.Score());
        }

        private static void RunPearsonCorrelationWithLowScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer2();
            var pearsonCorrelation = new PearsonCorrelation(r1, r2);

            Console.WriteLine("The Pearson Correlation between {0} and {1} is: {2}", r1.Name, r2.Name, pearsonCorrelation.Score());
        }

        private static void RunPearsonCorrelationWithHighScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer4();
            var r2 = ReviewerBuilder.BuildReviewer1();
            var pearsonCorrelation = new PearsonCorrelation(r1, r2);

            Console.WriteLine("The Pearson Correlation between {0} and {1} is: {2}", r1.Name, r2.Name, pearsonCorrelation.Score());
        }
    }
}
