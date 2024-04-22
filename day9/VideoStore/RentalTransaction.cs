namespace VideoStore;

public class RentalTransaction
{
    public int TransactionID { get; set; }
    public int CustomerID { get; set; }
    public int VideoID { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime DueDate { get; set; }

    public RentalTransaction(int transactionID, int customerID, int videoID, DateTime rentalDate, int rentalDurationDays)
    {
        TransactionID = transactionID;
        CustomerID = customerID;
        VideoID = videoID;
        RentalDate = rentalDate;
        DueDate = rentalDate.AddDays(rentalDurationDays);
    }
}
