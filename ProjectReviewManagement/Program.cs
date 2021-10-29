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
            List<string> reviewList = new List<string>() { "Good", "Bad", "Nice" };
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
            ReviewManagement reviewManagement = new ReviewManagement();
            List<int> listOfOptions = new List<int>(); 
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("Select UC number:\n1. Add reviews to list, 2. TopThreeHighestRatedReviews\n" +
                    "3. RetrieveRequiredData, 4. CountOfReviesGroupedByProductId\n" +
                    "5. GetRequiredFields, 6. SkipTopFiveReviews, 7. GetRequiredFields,\n" +
                    "8. AddDataToTable, 9. GetReviewsWithIsLikeAsTrue, 10. GetAverageRatingOfEachProductId, 11. GetReviewsWithReviewAsNice\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine($"\nProductID\tUserID\tRating\tReview\tisLike");
                        foreach (ProductReview review in productReviews)
                        {

                            Console.WriteLine($"{review.ProductID}\t\t{review.UserID}\t{review.Rating}\t{review.Review}\t{review.isLike}");
                        }
                        break;
                    case 2:
                        // UC2
                        reviewManagement.TopThreeHighestRatedReviews(productReviews);
                        break;
                    case 3:
                        // UC3
                        reviewManagement.RetrieveRequiredData(productReviews);
                        break;
                    case 4:
                        // UC4
                        reviewManagement.CountOfReviesGroupedByProductId(productReviews);
                        break;
                    case 5:
                        // UC5
                        reviewManagement.GetRequiredFields(productReviews);
                        break;
                    case 6:
                        // UC6
                        reviewManagement.SkipTopFiveReviews(productReviews);
                        break;
                    case 7:
                        // UC7
                        reviewManagement.GetRequiredFields(productReviews);
                        break;
                    case 8:
                        // UC8 
                        if (!listOfOptions.Contains(8) && !listOfOptions.Contains(9) && !listOfOptions.Contains(10) && !listOfOptions.Contains(11))
                        {
                            reviewManagement.AddDataToTable(productReviews);
                        }
                        break;
                    case 9:
                        // UC8 
                        if (!listOfOptions.Contains(8) && !listOfOptions.Contains(9) && !listOfOptions.Contains(10) && !listOfOptions.Contains(11))
                        {
                            reviewManagement.AddDataToTable(productReviews);
                        }
                        reviewManagement.GetReviewsWithIsLikeAsTrue();
                        break;
                    case 10:
                        if (!listOfOptions.Contains(8) && !listOfOptions.Contains(9) && !listOfOptions.Contains(10) && !listOfOptions.Contains(11))
                        {
                            reviewManagement.AddDataToTable(productReviews);
                        }
                        reviewManagement.GetAverageRatingOfEachProductId();
                        break;
                    case 11:
                        if (!listOfOptions.Contains(8) && !listOfOptions.Contains(9) && !listOfOptions.Contains(10) && !listOfOptions.Contains(11))
                        {
                            reviewManagement.AddDataToTable(productReviews);
                        }
                        reviewManagement.GetReviewsWithReviewAsNice();
                        break;
                    default:
                        isRun = !isRun;
                        break;
                }
                listOfOptions.Add(option);
            }
        }
    }
}
