using RanchTracker.DAL.App_Classes;
using RanchTracker.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RanchTracker.BLL
{
    public class LoginController
    {
        TokenDAL tokenDAL;
        RanchDAL rancheDAL;
        public LoginController()
        {
            rancheDAL = new RanchDAL();
            tokenDAL = new TokenDAL();
        }

        public Ranch Login(string username, string password)
        {
            List<Ranch> ranches = rancheDAL.GetAll();
            Ranch ranch = ranches.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
            return ranch;
        }

        public int RegisterToken(string Token,int ID)
        {
            if(tokenDAL.GetAll().Where(x => x.DeviceToken == Token).Count() == 0)
            {
                Token token = new Token();
                token.DeviceToken = Token;
                token.RanchID = ID;
                tokenDAL.Add(token);
                return token.ID;
            }
            else
            {
                return 0;
            }

            
        }
    }
}
