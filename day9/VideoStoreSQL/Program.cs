using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VideoStoreSql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VideoStoreContext())
            {
                context.Database.EnsureCreated();
                InitializeSystem(context);
            }
            Console.WriteLine("Welcome to the Video Store Management System!");
            string userOption;
            do
            {
                ShowMainMenu();
                userOption = Console.ReadLine();
                switch (userOption)
                {
                    case "1":
                        RegisterNewCustomer();
                        break;
                    case "2":
                        ListAvailableVideos();
                        break;
                    case "3":
                        RentVideo();
                        break;
                    case "4":
                        ReturnVideo();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the system.");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            } while (userOption != "5");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Register New Customer");
            Console.WriteLine("2. Show Available Videos");
            Console.WriteLine("3. Rent a Video");
            Console.WriteLine("4. Return a Video");
            Console.WriteLine("5. Exit");
        }

        static void InitializeSystem(VideoStoreContext context)
        {
            if (!context.Videos.Any())
            {
                context.Videos.AddRange(
                    new Video { VideoID = 1, Title = "Ben 10", Genre = "Sci-Fi", RentalPrice = 10 },
                    new Video { VideoID = 2, Title = "Heidi", Genre = "Drama", RentalPrice = 2.99 }
                );
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer { CustomerID = 1, Name = "Thunder", ContactInfo = "12345678" },
                    new Customer { CustomerID = 2, Name = "Harsha", ContactInfo = "00000000" }
                );
                context.SaveChanges();
            }
        }

        static void RegisterNewCustomer()
        {
            using (var context = new VideoStoreContext())
            {
                Console.WriteLine("Enter Customer ID:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Customer Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Contact Info:");
                string contact = Console.ReadLine();

                var newCustomer = new Customer { CustomerID = id, Name = name, ContactInfo = contact };
                context.Customers.Add(newCustomer);
                context.SaveChanges();
                Console.WriteLine("New customer registered successfully!");
            }
        }

        static void ListAvailableVideos()
        {
            using (var context = new VideoStoreContext())
            {
                var availableVideos = context.Videos.Where(v => v.IsAvailable).ToList();
                if (availableVideos.Any())
                {
                    Console.WriteLine("Available Videos:");
                    foreach (var video in availableVideos)
                    {
                        Console.WriteLine($"ID: {video.VideoID}, Title: {video.Title}, Genre: {video.Genre}, Price: ${video.RentalPrice}");
                    }
                }
                else
                {
                    Console.WriteLine("No available videos at the moment.");
                }
            }
        }

        static void RentVideo()
        {
            using (var context = new VideoStoreContext())
            {
                ListAvailableVideos();
                Console.WriteLine("Enter Video ID to rent:");
                int videoID = int.Parse(Console.ReadLine());
                var video = context.Videos.FirstOrDefault(v => v.VideoID == videoID && v.IsAvailable);
                Console.WriteLine(video);
                if (video != null)
                {
                    Console.WriteLine("Enter Customer ID:");
                    int customerID = int.Parse(Console.ReadLine());
                    if (context.Customers.Any(c => c.CustomerID == customerID))
                    {
                        var transaction = new RentalTransaction
                        {
                            CustomerID = customerID,
                            VideoID = videoID,
                            RentalDate = DateTime.Now,
                            DueDate = DateTime.Now.AddDays(7) // 7 days rental
                        };
                        context.RentalTransactions.Add(transaction);
                        video.IsAvailable = false;
                        context.SaveChanges();
                        Console.WriteLine($"Video rented successfully! Due back on {transaction.DueDate.ToShortDateString()}");
                    }
                    else
                    {
                        Console.WriteLine("Customer ID not found. Please register the customer first.");
                    }
                }
                else
                {
                    Console.WriteLine("Video not available or not found.");
                }
            }
        }

        static void ReturnVideo()
        {
            using (var context = new VideoStoreContext())
            {
                Console.WriteLine("Enter Video ID to return :");
                int videoID = int.Parse(Console.ReadLine());
                Console.WriteLine("Video return method", videoID);
                Console.WriteLine(context.Videos.ToString());
                var video = context.Videos.FirstOrDefault(v => v.VideoID == videoID && !v.IsAvailable);
                Console.WriteLine(video.ToString(),"return video");
                if (video != null)
                {
                    Console.WriteLine("Enter Customer ID:");
                    int customerID = int.Parse(Console.ReadLine());
                    var transaction = context.RentalTransactions.FirstOrDefault(t => t.VideoID == videoID && t.CustomerID == customerID);
                    Console.WriteLine(transaction.ToString());
                    if (transaction != null)
                    {
                        video.IsAvailable = true;
                        double daysLate = (DateTime.Now - transaction.DueDate).TotalDays;
                        if (daysLate > 0)
                        {
                            Console.WriteLine($"Video is late by {Math.Ceiling(daysLate)} days. Late fee is: ${Math.Ceiling(daysLate) * 1.50}");
                        }
                        else
                        {
                            Console.WriteLine("Video returned on time. No late fee.");
                        }
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("No rental record found for this video and customer.");
                    }
                }
                else
                {
                    Console.WriteLine("This video was not rented or not found.");
                }
            }
        }

    }
}
