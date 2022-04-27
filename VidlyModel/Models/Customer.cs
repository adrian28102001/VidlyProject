namespace VidlyModel.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
    public DateTime? Birthdate { get; set; }
    public virtual MembershipType MembershipType { get; set; }
    public byte MembershipTypeId { get; set; }
    
}