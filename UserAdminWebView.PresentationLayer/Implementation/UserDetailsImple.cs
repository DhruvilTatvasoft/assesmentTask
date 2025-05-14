
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

    public ProfileDetails getUserDetails(string email)
    {
        ProfileDetails userDetails = _context.ProfileDetails.FirstOrDefault(user=>user.email == email);
        return userDetails;
    }
}