using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}