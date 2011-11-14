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
            var recommendations = new HashSet<string>();
            foreach (var r in Reviewers)
            {

                var score = new EuclideanDistance(CurrentUser, r).Score();
                if (score <= 0)
                {
                    continue;
                }
                var oppositeItems = new FindOppositeReviews(CurrentUser.Reviews, r.Reviews).Calculate();

                //TODO: Right now, this method recommends all items not reviewed by the current user.
                //Next, I will calculate a weighted average for each item and order the recommended items accordingly.
                //Calculated weighted score => r.Reviews[item] * score
                foreach (var item in oppositeItems)
                {
                    recommendations.Add(item);
                }
            }

            return recommendations.ToList();
        } 
    }
}
