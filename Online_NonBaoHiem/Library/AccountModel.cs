using Online_NonBaoHiem.Models;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Model
{
    public class AccountModel
    {
        private NonData context = null;
        public AccountModel()
        {
            context = new NonData();
        }
        public bool Login(string userName, string passWord)
        {
            object[] sqlPara = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Pass",passWord)

            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName,@Pass", sqlPara).SingleOrDefault();
            return res;
        }
    }
}
