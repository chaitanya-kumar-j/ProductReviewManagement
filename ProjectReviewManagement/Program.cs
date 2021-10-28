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
                review.ProductID = i;
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

            // UC2
            var resultList = (from review in productReviews
                               orderby review.Rating descending
                               select review).Take(3);
            Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
            foreach (ProductReview review in resultList)
            {
                Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
            }

            // UC3
        }
    }
}
