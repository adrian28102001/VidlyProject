using VidlyModel.Models;

namespace VidlyModel.Pages;

public class CustomerFromViewModel
{
    public IEnumerable<MembershipType> MembershipTypes { get; set; }
    public Customer Customer { get; set; }
}