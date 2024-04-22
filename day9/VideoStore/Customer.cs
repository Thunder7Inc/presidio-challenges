namespace VideoStore;

public class Customer
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }

    public Customer(int customerID, string name, string contactInfo)
    {
        CustomerID = customerID;
        Name = name;
        ContactInfo = contactInfo;
    }
}
