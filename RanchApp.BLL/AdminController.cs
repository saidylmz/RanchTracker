using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RanchTracker.BLL
{
    public class AdminController
    {
        CategoryDAL categoryDAL;
        RanchDAL ranchDAL;
        public AdminController()
        {
            categoryDAL = new CategoryDAL();
            ranchDAL = new RanchDAL();
        }


        public bool AddCategory(Category category,byte[] image)
        {
            category.Image = image;
            return categoryDAL.Add(category) > 0;
        }

        public bool AddRanch(Ranch ranch, byte[] image)
        {
            ranch.Logo = image;
            ranch.Role = false;
            return ranchDAL.Add(ranch) > 0;
        }

    }
}
