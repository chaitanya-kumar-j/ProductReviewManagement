using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // UC1 
            IList<ProductReview> productReviews = new List<ProductReview>() { };
            List<string> reviewList = new List<string>() { "Good", "Bad", "Ok" };
            Random random = new Random();
            for (int i = 1; i <= 25; i++)
            {
                ProductReview review = new ProductReview();
                review.ProductID = random.Next(1, 10);
                review.UserID = random.Next(1, 11);
                review.Rating = random.Next(1, 6);
                review.Review = reviewList[random.Next(reviewList.Count)];
                review.isLike = Convert.ToBoolean(random.Next(2));
                productReviews.Add(review);
            }
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (ProductReview review in productReviews)
            {
                
                Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
            }

            ReviewManagement reviewManagement = new ReviewManagement();

            // UC2
            reviewManagement.TopThreeHighestRatedReviews(productReviews);

            // UC3
            reviewManagement.RetrieveRequiredData(productReviews);

            // UC4
            reviewManagement.CountOfReviesGroupedByProductId(productReviews);

        }
    }
}
