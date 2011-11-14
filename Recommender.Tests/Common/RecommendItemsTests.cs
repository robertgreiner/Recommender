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
        public void ShouldRecommendAnItem()
        {
            var r = new RecommendItems(currentUser, reviewers).Calculate();
            Assert.AreEqual(4, r.Count);
        }
    }
}
