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
            reviewers = BuildReviewers();

            sortedReviewers = new RankReviewers(BuildCurrentUser(), BuildReviewers()).Rank();
        }

        private List<Reviewer> BuildReviewers()
        {
            return new List<Reviewer>
                        {
                            {ReviewerBuilder.BuildReviewer2()},
                            {ReviewerBuilder.BuildReviewer3()},
                            {ReviewerBuilder.BuildReviewer4()},
                            {ReviewerBuilder.BuildReviewer5()},
                        };
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
        public void TheMostSimilarReviewerShouldBeR4()
        {
            Assert.AreEqual(reviewers.ElementAt(2).Name, sortedReviewers.ElementAt(0).Key.Name);
        }

        [Test]
        public void TheSecondRankedReviewerShouldBeR5()
        {
            Assert.AreEqual(reviewers.ElementAt(3).Name, sortedReviewers.ElementAt(1).Key.Name);
        }

        [Test]
        public void TheThirdRankedReviewerShouldBeR2()
        {
            Assert.AreEqual(reviewers.ElementAt(0).Name, sortedReviewers.ElementAt(2).Key.Name);
        }

        [Test]
        public void TheLeastSimilarReviewerShouldBeR3()
        {
            Assert.AreEqual(reviewers.ElementAt(1).Name, sortedReviewers.ElementAt(3).Key.Name);
        }
    }
}
