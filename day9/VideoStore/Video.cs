namespace VideoStore;

public class Video
{
    public int VideoID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
    public double RentalPrice { get; set; }

    public Video(int videoID, string title, string genre, double rentalPrice)
    {
        VideoID = videoID;
        Title = title;
        Genre = genre;
        IsAvailable = true;
        RentalPrice = rentalPrice;
    }
    
}
