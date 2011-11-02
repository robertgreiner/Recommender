using System.Collections.Generic;
using NUnit.Framework;
using Recommender.Steps;

namespace Recommender.Tests.Steps
{
    [TestFixture]
    class SumDifferenceSquaresTests
    {
        [Test]
        public void ShouldReturnZeroOnEmpty()
        {
            var emptyReviewer = new Dictionary<string, double>();
            var similarReviews = new List<string>();
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, emptyReviewer, emptyReviewer).Calculate();
            Assert.AreEqual(0.0, sumDifferenceSquares);
        }

        [Test]
        public void ShouldReturnZeroWithIdenticalReviews()
        {
            var highScoreReviewer = new Dictionary<string, double>();
            var similarReviews = new List<string>();
            highScoreReviewer.Add("C# in Depth", 5);
            similarReviews.Add("C# in Depth");
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, highScoreReviewer, highScoreReviewer).Calculate();
            Assert.AreEqual(0.0, sumDifferenceSquares);
        }

        [Test]
        public void ShouldCalculateTheSumOfTheSquareOfTheDifferenceOfASingleSimilarReview()
        {
            var highScoreReviewer = new Dictionary<string, double>();
            var lowScoreReviewer = new Dictionary<string, double>();
            var similarReviews = new List<string>();
            highScoreReviewer.Add("C# in Depth", 5);
            lowScoreReviewer.Add("C# in Depth", 3);
            similarReviews.Add("C# in Depth");
            var sumDifferenceSquares = new SumDifferenceSquares(similarReviews, highScoreReviewer, lowScoreReviewer).Calculate();
            Assert.AreEqual(4.0, sumDifferenceSquares);
        }

    }
}
