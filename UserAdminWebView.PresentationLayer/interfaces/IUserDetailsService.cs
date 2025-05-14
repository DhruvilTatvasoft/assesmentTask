public interface IUserDetailsService{
    public ProfileDetails getUserDetails(string email);
    public List<ProfileDetails> getAllUserDetails();
}