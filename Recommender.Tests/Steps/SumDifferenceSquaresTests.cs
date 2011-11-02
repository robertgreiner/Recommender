using System.Collections.Generic;
using NUnit.Framework;
using Recommender.Data;
using Recommender.Steps;

namespace Recommender.Tests.Steps
{
    [TestFixture]
    class SumDifferenceSquaresTests
    {
        [Test]
        public void ShouldReturnZeroOnEmpty()
        {
            var emptyReviewer = ReviewerBuilder.BuildReviewerWithNoReviews();
            var similarReviews = new List<string>();
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, emptyReviewer.Reviews, emptyReviewer.Reviews).Calculate();
            Assert.AreEqual(0.0, sumDifferenceSquares);
        }

        [Test]
        public void ShouldReturnZeroWithIdenticalReviews()
        {
            var highScoreReviewer = ReviewerBuilder.BuildOneReviewMax();
            var similarReviews = new List<string>();
            similarReviews.Add("C# in Depth");
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, highScoreReviewer.Reviews, highScoreReviewer.Reviews).Calculate();
            Assert.AreEqual(0.0, sumDifferenceSquares);
        }

        [Test]
        public void ShouldCalculateTheSumOfTheSquareOfTheDifferenceOfASingleSimilarReview()
        {
            var highScoreReviewer = ReviewerBuilder.BuildOneReviewMax();
            var lowScoreReviewer = ReviewerBuilder.BuildOneReviewMid();
            var similarReviews = new List<string>();
            similarReviews.Add("C# in Depth");
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, highScoreReviewer.Reviews, lowScoreReviewer.Reviews).Calculate();
            Assert.AreEqual(4.0, sumDifferenceSquares);
        }

    }
}
