using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recommender.Reviews;
using Recommender.SimilarityScore;

namespace Recommender.Common
{
    public class RecommendItems
    {
        private readonly Reviewer CurrentUser;
        private readonly List<Reviewer> Reviewers;


        public RecommendItems(Reviewer currentUser, List<Reviewer> reviewers)
        {
            CurrentUser = currentUser;
            Reviewers = reviewers;
        }

        public List<string> Calculate()
        {
            var scores = new Dictionary<string, double>();
            var count = new Dictionary<string, double>();

            foreach (var r in Reviewers)
            {

                var similarityScore = new EuclideanDistance(CurrentUser, r).Score();
                if (similarityScore <= 0)
                {
                    continue;
                }
                var oppositeItems = new FindOppositeReviews(CurrentUser.Reviews, r.Reviews).Calculate();

                foreach (var item in oppositeItems)
                {
                    var weightedScore = r.Reviews[item] * similarityScore;
                    if (scores.ContainsKey(item))
                    {
                        count[item]++;
                        scores[item] += weightedScore;
                    }
                    else
                    {
                        scores.Add(item, weightedScore);    
                        count.Add(item, 1);
                    }
                }
                
            }

            var sortedRecommendations = CalculateSortedRecommendations(scores, count);
            return sortedRecommendations.Keys.ToList();
        }

        private static Dictionary<string, double> CalculateSortedRecommendations(Dictionary<string, double> scores, Dictionary<string, double> count)
        {
            var recommendations = scores.Keys.ToDictionary(item => item, item => scores[item] / count[item]);
            var sortedRecommendations = recommendations.OrderByDescending(key => key.Value).ToDictionary(item => item.Key,
                                                                                                         item => item.Value);
            return sortedRecommendations;
        }
    }
}
