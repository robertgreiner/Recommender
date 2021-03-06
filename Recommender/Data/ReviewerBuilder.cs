﻿using System.Collections.Generic;
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
            var reviewer = new Reviewer { Name = "Swish" };
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
            reviewer.AddReview("Code Complete", 1.0);
            reviewer.AddReview("C# in Depth", 1.0);
            reviewer.AddReview("Clean Code", 1.0);
            reviewer.AddReview("Unit Testing", 1.0);
            reviewer.AddReview("Joel on Software", 1.0);
            reviewer.AddReview("Refactoring", 1.0);
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
            reviewer.AddReview("C# in Depth", 1.0);
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
            reviewer.AddReview("Code Complete", 3.5);
            reviewer.AddReview("C# in Depth", 1.0);
            reviewer.AddReview("Clean Code", 4.0);
            reviewer.AddReview("Unit Testing", 1.5);
            reviewer.AddReview("Joel on Software", 2.5);
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
            reviewer.AddReview("Code Complete", 1.5);
            reviewer.AddReview("C# in Depth", 1.0);
            reviewer.AddReview("Unit Testing", 2.5);
            reviewer.AddReview("Refactoring", 5.0);
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

        public static Reviewer BuildReviewer6()
        {
            var reviewer = new Reviewer { Name = "Luke" };
            reviewer.AddReview("Code Complete", 2.5);
            reviewer.AddReview("C# in Depth", 3.5);
            reviewer.AddReview("Clean Code", 3.0);
            reviewer.AddReview("Unit Testing", 3.5);
            reviewer.AddReview("Joel on Software", 2.5);
            reviewer.AddReview("C# for Dummies", 3.0);
            return reviewer;
        }

        public static Reviewer BuildReviewer7()
        {
            var reviewer = new Reviewer { Name = "Paul" };
            reviewer.AddReview("Code Complete", 3.0);
            reviewer.AddReview("C# in Depth", 3.5);
            reviewer.AddReview("Clean Code", 1.5);
            reviewer.AddReview("Unit Testing", 5.0);
            reviewer.AddReview("Joel on Software", 3.5);
            reviewer.AddReview("C# for Dummies", 3.0);
            return reviewer;
        }

        public static Reviewer BuildReviewerWithNoReviews()
        {
            var reviewer = new Reviewer {Name = "Sam"};
            return reviewer;
        }

        public static Reviewer BuildMyReviews()
        {
            var reviewer = new Reviewer { Name = "Robert" };
            reviewer.AddReview("Code Complete", 4.5);
            reviewer.AddReview("C# in Depth", 5.0);
            reviewer.AddReview("Clean Code", 4.0);
            reviewer.AddReview("Unit Testing", 4.5);
            reviewer.AddReview("Joel on Software", 4.0);
            reviewer.AddReview("Refactoring", 5.0);
            return reviewer;
        }

        public static Reviewer BuildReviewerWithInvalidReviews()
        {
            var reviewer = new Reviewer { Name = "Invalid Reviews" };
            reviewer.AddReview("Code Complete", 0.0);
            reviewer.AddReview("C# in Depth", -2.0);
            return reviewer;
        }
        
        public static Reviewer BuildReviewerThatNeedsRecommendations()
        {
            var reviewer = new Reviewer { Name = "JoeProgrammer" };
            reviewer.AddReview("Code Complete", 3.0);
            reviewer.AddReview("C# in Depth", 4.5);
            return reviewer;
        }

        public static List<Reviewer> BuildReviewers()
        {
            return new List<Reviewer>
                        {
                            {BuildReviewer2()},
                            {BuildReviewer3()},
                            {BuildReviewer4()},
                            {BuildReviewer5()},
                        };
        }
    }
}
