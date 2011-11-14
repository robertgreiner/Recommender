using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Recommender.Common;
using Recommender.Data;
using Recommender.Reviews;

namespace Recommender.Tests.Common
{
    [TestFixture]
    class RankReviewersTests
    {
        private List<Reviewer> reviewers;
        IOrderedEnumerable<KeyValuePair<Reviewer, double>> sortedReviewers;
        private RankReviewers rankReviewers;

        [SetUp]
        public void SetUp()
        {
            var currentUser = BuildCurrentUser();
            reviewers = ReviewerBuilder.BuildReviewers();
            sortedReviewers = new RankReviewers(currentUser, reviewers).Rank();
        }

        private static Reviewer BuildCurrentUser()
        {
            return ReviewerBuilder.BuildReviewer1();
        }

        [Test]
        public void OrderingOfSortedReviewersShouldBeDifferentThanInitialListOfReviewers()
        {
            Assert.AreNotEqual(reviewers.First(), sortedReviewers.First().Key);
        }

        [Test]
        public void TheMostSimilarReviewerShouldBeCarol()
        {
            Assert.AreEqual(reviewers.ElementAt(2).Name, "Carol");
        }

        [Test]
        public void TheSecondRankedReviewerShouldBeShelby()
        {
            Assert.AreEqual(reviewers.ElementAt(3).Name, "Shelby");
        }

        [Test]
        public void TheThirdRankedReviewerShouldBeSeymour()
        {
            Assert.AreEqual(reviewers.ElementAt(0).Name, "Seymour");
        }

        [Test]
        public void TheLeastSimilarReviewerShouldBeMichael()
        {
            Assert.AreEqual(reviewers.ElementAt(1).Name, "Michael");
        }
    }
}
