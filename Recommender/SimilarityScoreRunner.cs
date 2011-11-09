using System;
using System.Collections.Generic;
using Recommender.Data;
using Recommender.Reviews;
using Recommender.SimilarityScore;

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
            Console.WriteLine();
            ReviewersMostSimilarToMe();
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

        private static void ReviewersMostSimilarToMe()
        {
            Console.WriteLine("Ranked reviewers most similar to me.");
            var currentUser = ReviewerBuilder.BuildMyReviews();
            var reviewers = new List<Reviewer>
                        {
                            {ReviewerBuilder.BuildReviewer1()},
                            {ReviewerBuilder.BuildReviewer2()},
                            {ReviewerBuilder.BuildReviewer3()},
                            {ReviewerBuilder.BuildReviewer4()},
                            {ReviewerBuilder.BuildReviewer5()},
                            {ReviewerBuilder.BuildAllMaxScores()},
                            {ReviewerBuilder.BuildAllMidScores()},
                            {ReviewerBuilder.BuildAllMinScores()}
                        };
            var sortedReviewers = new RankReviewers(currentUser, reviewers).Rank();

            foreach (var r in sortedReviewers)
            {
                Console.WriteLine("{0}: {1}", r.Key.Name, r.Value);
            }
        }
    }
}
