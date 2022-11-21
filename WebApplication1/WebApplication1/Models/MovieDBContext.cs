using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class MovieDBContext:DbContext
    {
        public MovieDBContext():base("name = Movies")
        {

        }
        public DbSet<Movies> movies { get; set; }    
    }
}