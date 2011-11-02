using Recommender.Reviews;

namespace Recommender.Data
{
    public class ReviewerBuilder
    {
        public static Reviewer BuildAllMaxScores()
        {
            var reviewer = new Reviewer {Name = "Maximillian"};
            reviewer.AddReview("Code Complete", 5.0);
            reviewer.AddReview("C# in Depth", 5.0);
            reviewer.AddReview("Clean Code", 5.0);
            reviewer.AddReview("Unit Testing", 5.0);
            reviewer.AddReview("Joel on Software", 5.0);
            reviewer.AddReview("Refactoring", 5.0);
            return reviewer;
        }

        public static Reviewer BuildAllMidScores()
        {
            var reviewer = new Reviewer { Name = "Mini" };
            reviewer.AddReview("Code Complete", 3.0);
            reviewer.AddReview("C# in Depth", 3.0);
            reviewer.AddReview("Clean Code", 3.0);
            reviewer.AddReview("Unit Testing", 3.0);
            reviewer.AddReview("Joel on Software", 3.0);
            reviewer.AddReview("Refactoring", 3.0);
            return reviewer;
        }

        public static Reviewer BuildAllMinScores()
        {
            var reviewer = new Reviewer {Name = "Mini"};
            reviewer.AddReview("Code Complete", 0.0);
            reviewer.AddReview("C# in Depth", 0.0);
            reviewer.AddReview("Clean Code", 0.0);
            reviewer.AddReview("Unit Testing", 0.0);
            reviewer.AddReview("Joel on Software", 0.0);
            reviewer.AddReview("Refactoring", 0.0);
            return reviewer;
        }

        public static Reviewer BuildOneReviewMax()
        {
            var reviewer = new Reviewer {Name = "Maximillian"};
            reviewer.AddReview("C# in Depth", 5.0);
            return reviewer;
        }

        public static Reviewer BuildOneReviewMid()
        {
            var reviewer = new Reviewer { Name = "Swhish" };
            reviewer.AddReview("C# in Depth", 3.0);
            return reviewer;
        }

        public static Reviewer BuildOneReviewMin()
        {
            var reviewer = new Reviewer {Name = "Mini"};
            reviewer.AddReview("C# in Depth", 0.0);
            return reviewer;
        }

        public static Reviewer BuildAReviewerThatReviewedSomethingUnique()
        {
            var reviewer = new Reviewer {Name = "Fisher"};
            reviewer.AddReview("Chess", 4.0);
            return reviewer;
        }

        public static Reviewer BuildReviewer1()
        {
            var reviewer = new Reviewer {Name = "Lisa"};
            reviewer.AddReview("Code Complete", 2.5);
            reviewer.AddReview("C# in Depth", 3.5);
            reviewer.AddReview("Clean Code", 3.0);
            reviewer.AddReview("Unit Testing", 3.5);
            reviewer.AddReview("Joel on Software", 3.0);
            reviewer.AddReview("Refactoring", 2.5);
            return reviewer;
        }

        public static Reviewer BuildReviewer2()
        {
            var reviewer = new Reviewer {Name = "Seymour"};
            reviewer.AddReview("Code Complete", 3.0);
            reviewer.AddReview("C# in Depth", 3.5);
            reviewer.AddReview("Clean Code", 1.5);
            reviewer.AddReview("Unit Testing", 5.0);
            reviewer.AddReview("Joel on Software", 3.0);
            reviewer.AddReview("Refactoring", 3.5);
            return reviewer;
        }

        public static Reviewer BuildReviewer3()
        {
            var reviewer = new Reviewer {Name = "Michael"};
            reviewer.AddReview("Code Complete", 2.5);
            reviewer.AddReview("C# in Depth", 3.0);
            reviewer.AddReview("Unit Testing", 3.5);
            reviewer.AddReview("Refactoring", 4.0);
            return reviewer;
        }

        public static Reviewer BuildReviewer4()
        {
            var reviewer = new Reviewer {Name = "Carol"};
            reviewer.AddReview("C# in Depth", 3.5);
            reviewer.AddReview("Clean Code", 3.0);
            reviewer.AddReview("Joel on Software", 4.5);
            reviewer.AddReview("Unit Testing", 4.0);
            reviewer.AddReview("Refactoring", 2.5);
            return reviewer;
        }

        public static Reviewer BuildReviewer5()
        {
            var reviewer = new Reviewer {Name = "Shelby"};
            reviewer.AddReview("Code Complete", 3.0);
            reviewer.AddReview("C# in Depth", 4.0);
            reviewer.AddReview("Clean Code", 2.0);
            reviewer.AddReview("Unit Testing", 3.0);
            reviewer.AddReview("Joel on Software", 3.0);
            return reviewer;
        }

        public static Reviewer BuildReviewerWithNoReviews()
        {
            var reviewer = new Reviewer {Name = "Robert"};
            return reviewer;
        }
    }
}
