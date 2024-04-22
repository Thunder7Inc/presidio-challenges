
using VideoStore;

class Program
{
    static List<Video> videos = new List<Video>();
    static List<Customer> customers = new List<Customer>();
    static List<RentalTransaction> transactions = new List<RentalTransaction>();

    static void Main(string[] args)
    {
        InitializeSystem();
        Console.WriteLine("Welcome to the Video Store Management System!");

        string userOption;
        do
        {
            ShowMainMenu();
            userOption = Console.ReadLine();
            switch(userOption)
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

    static void InitializeSystem()
    {
        videos.Add(new Video(1, "Ben 10", "Sci-Fi", 10));
        videos.Add(new Video(2, "Heidi", "Drama", 2.99));
        customers.Add(new Customer(1, "Harsha", "1234567890"));
    }

    static void RegisterNewCustomer()
    {
        Console.WriteLine("Enter Customer ID:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Customer Name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Contact Info:");
        string contact = Console.ReadLine();

        var newCustomer = new Customer(id, name, contact);
        // List<Customer>
        // 
        customers.Add(newCustomer);
        Console.WriteLine("New customer registered successfully!");
    }

    static void ListAvailableVideos()
    {
        var availableVideos = videos.Where(v => v.IsAvailable).ToList();
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

    static void RentVideo()
    {
        ListAvailableVideos();
        Console.WriteLine("Enter Video ID to rent:");
        int videoID = int.Parse(Console.ReadLine());
        Video video = videos.FirstOrDefault(v => v.VideoID == videoID && v.IsAvailable);
        if (video != null)
        {
            
            Console.WriteLine("Enter Customer ID:");
            int customerID = int.Parse(Console.ReadLine());
            
            if (customers.Any(c => c.CustomerID == customerID))
            {
                var transaction = new RentalTransaction(transactions.Count + 1, customerID, videoID, DateTime.Now, 7); // Assume 7 days rental
                transactions.Add(transaction);
                video.IsAvailable = false; // Update video availability status
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

    static void ReturnVideo()
    {
        Console.WriteLine("Enter Video ID to return:");
        int videoID = int.Parse(Console.ReadLine());
        Video video = videos.FirstOrDefault(v => v.VideoID == videoID && !v.IsAvailable);
        
        if (video != null)
        {
            
            Console.WriteLine("Enter Customer ID:");
            video.IsAvailable = true;
            var transaction = transactions.FirstOrDefault(t => t.VideoID == videoID && t.CustomerID == int.Parse(Console.ReadLine()));
            
            if (transaction != null)
            {
                double daysLate = (DateTime.Now - transaction.DueDate).TotalDays;
                if (daysLate > 0)
                {
                    Console.WriteLine($"Video is late by {Math.Ceiling(daysLate)} days. Late fee is: ${Math.Ceiling(daysLate) * 1.50}");
                }
                else
                {
                    Console.WriteLine("Video returned on time. No late fee.");
                }
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

