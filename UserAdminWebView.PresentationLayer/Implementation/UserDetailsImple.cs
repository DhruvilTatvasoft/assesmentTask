
public class UserDetailsImple : IUserDetailsService
{
     private UserAdminWebViewContext _context;

    public UserDetailsImple(UserAdminWebViewContext context){
        _context = context;
    }
    public List<ProfileDetails> getAllUserDetails()
    {
        List<ProfileDetails> allUsers = _context.ProfileDetails.Where(user=>user.Roleid == 2).ToList();
        return allUsers;
    }

    public decimal getHighestSalary()
    {
       List<ProfileDetails> list = _context.ProfileDetails.ToList();
       decimal highestSalary = list.Max(p => p.currentSalary);
       return highestSalary;
    }

    public ProfileDetails getUserDetails(string email)
    {
        ProfileDetails userDetails = _context.ProfileDetails.FirstOrDefault(user=>user.email == email);
        return userDetails;
    }
}