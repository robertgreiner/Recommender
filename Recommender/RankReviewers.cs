using System.Collections.Generic;
using System.Linq;
using Recommender.Reviews;
using Recommender.SimilarityScore;

namespace Recommender
{
    public class RankReviewers
    {
        private readonly Reviewer CurrentUser;
        private readonly List<Reviewer> Reviewers;

        public RankReviewers(Reviewer currentUser, List<Reviewer> reviewers)
        {
            CurrentUser = currentUser;
            Reviewers = reviewers;
        }

        public IOrderedEnumerable<KeyValuePair<Reviewer, double>> Rank()
        {
            var scores = Reviewers.ToDictionary(r => r, r => new PearsonCorrelation(CurrentUser, r).Score());

            return scores.OrderByDescending(key => key.Value);
        }
    }
}