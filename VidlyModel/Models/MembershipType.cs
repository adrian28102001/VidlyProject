namespace VidlyModel.Models;

public class MembershipType
{
    public byte Id { get; set; }
    public String Name { get; set; }
    public short SignUpFee { get; set; }
    public byte DurationInMonth { get; set; }
    public byte DiscountRate { get; set; }
    
    public virtual ICollection<Customer> Customers { get; set; }
}