using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreWebAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Persistence.Extensions
{
    public static class PersistenceExtension
    {
        public static void AddPersistence(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<BookStoreContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        }
    }
}
