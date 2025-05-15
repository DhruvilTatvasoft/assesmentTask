using Microsoft.EntityFrameworkCore;

public class UserAdminWebViewContext : DbContext
{
    public UserAdminWebViewContext(DbContextOptions<UserAdminWebViewContext> options) : base(options)
        {

        }
    public DbSet<Roles> Roles{get;set;}
    public DbSet<ProfileDetails> ProfileDetails{get;set;}
    public DbSet<LoginDetails> LoginDetails{get;set;}
    public DbSet<UserDetails> UserDetails{get;set;}
    public DbSet<BookDetails> BookDetails{get;set;}
    public DbSet<UserBook> UserBooks{get;set;}
}