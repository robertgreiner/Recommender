using System;
using Recommender.Data;

namespace Recommender
{
    class SimilarityScoreRunner
    {
        static void Main(string[] args)
        {
            RunEuclideanDistanceWithLowScore();
            RunEuclideanDistanceWithHighScore();
            Console.ReadKey();
        }

        private static void RunEuclideanDistanceWithLowScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer1();
            var r2 = ReviewerBuilder.BuildReviewer2();
            var euclideanDistance = new EuclideanDistance(r1, r2);

            Console.WriteLine("The similarity score between {0} and {1} is: {2}", r1.Name, r2.Name, euclideanDistance.Score());
        }

        private static void RunEuclideanDistanceWithHighScore()
        {
            var r1 = ReviewerBuilder.BuildReviewer3();
            var r2 = ReviewerBuilder.BuildReviewer5();
            var euclideanDistance = new EuclideanDistance(r1, r2);

            Console.WriteLine("The similarity score between {0} and {1} is: {2}", r1.Name, r2.Name, euclideanDistance.Score());
        }
    }
}
