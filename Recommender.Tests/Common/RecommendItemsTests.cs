using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;
using Recommender.Reviews;
using Recommender.SimilarityScore;

namespace Recommender.Tests.Common
{
    [TestFixture]
    class RecommendItemsTests
    {
        private List<Reviewer> reviewers;
        private Reviewer currentUser;
        IOrderedEnumerable<KeyValuePair<Reviewer, double>> sortedReviewers;

        [SetUp]
        public void SetUp()
        {
            currentUser = ReviewerBuilder.BuildReviewerThatNeedsRecommendations();
            reviewers = ReviewerBuilder.BuildReviewers();
        }

        [Test]
        public void ShouldRecommendSomeItems()
        {
            var r = new RecommendItems(currentUser, reviewers).Calculate();
            Assert.AreEqual(4, r.Count);
        }

        [Test]
        public void ShouldOrderRecommendationsBasedOnSimilarityScore()
        {
            currentUser = ReviewerBuilder.BuildReviewerThatNeedsRecommendations();
            reviewers = new List<Reviewer> {ReviewerBuilder.BuildMyReviews()};
            var r = new RecommendItems(currentUser, reviewers).Calculate();
            Assert.AreEqual("Refactoring", r.First());
        }

        [Test]
        public void ShouldNotMakeRecommendationsIfUsersHaveNoSimilarReviews()
        {
            currentUser = ReviewerBuilder.BuildAReviewerThatReviewedSomethingUnique();
            var r = new RecommendItems(currentUser, reviewers).Calculate();
            Assert.AreEqual(0, r.Count);
        }
    }
}
