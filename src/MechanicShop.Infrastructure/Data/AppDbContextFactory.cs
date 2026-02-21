using MechanicShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MechanicShop.Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        
   
        optionsBuilder.UseSqlServer("Server = . ; Database = MechanicShopDb ; Trusted_Connection=True; MultipleActiveResultSets = true ; TrustServerCertificate = True;");


        return new AppDbContext(optionsBuilder.Options, mediator: null!); 
  
    }
}