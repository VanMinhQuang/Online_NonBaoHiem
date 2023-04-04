using System;
using System.Data.SqlClient;
using Online_NonBaoHiem.Models;
namespace Model
{
    public class AccountModel
    {
        private NonDBO context = null;
        public AccountModel()
        {
            context = new NonDBO();
        }
        public bool Login(string userName,string passWord)
        {
            object[] sqlPara = new SqlParameter[]
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Pass",passWord)

            };
            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @UserName,@Pass", sqlPara).SingleOrDefaultAsync();
            return res;

        }
    }
}
