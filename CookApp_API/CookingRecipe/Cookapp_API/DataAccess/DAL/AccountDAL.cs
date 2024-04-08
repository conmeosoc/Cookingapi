﻿using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccoountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccountDTO;
using Microsoft.Extensions.Hosting;
using System.Collections;

namespace Cookapp_API.DataAccess.DAL
{
    public class AccountDAL : MSSQLSERVERDataAccess
    {
        public const string _TABLE_NAME_ACCOUNT = "Accounts";
        public const string _TABLE_NAME_IMAGES = "images";
        public AccountDAL() : base() { }

        public AccountDAL(string connectionString) : base(connectionString) { }

        public AccountDAL(string connectionString, int timeout) : base(connectionString, timeout) { }

        public List<AccountDTO> GetAccounts()
        {
            try
            {
                string query = "select * from " + _TABLE_NAME_ACCOUNT;
                List<Hashtable> arrHsObj;
                arrHsObj = ExecuteArrayHastable(query);
                AccountDTO acc;
                if (arrHsObj != null && arrHsObj.Count > 0)
                {
                    List<AccountDTO> arrRes = new List<AccountDTO>(arrHsObj.Count);
                    for(int i = 0; i < arrHsObj.Count; i++)
                    {
                        acc = new AccountDTO(arrHsObj[i]);
                        arrRes.Add(acc);
                    }
                    return arrRes;
                }
                else
                    return new List<AccountDTO> { };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int UpdateAccount(string id, ProfileDTO account)
        {
            try
            {
                string query = "update " + _TABLE_NAME_ACCOUNT;
                string filed = " SET ";
                if(account != null)
                {
                    if(!string.IsNullOrEmpty(account.username))
                    {                        
                        filed += " username='" + account.username + "'";
                    }
                    if(!string.IsNullOrEmpty(account.Password))
                    {
                        filed += (filed != " SET " ? "," : "") + " password='" + account.Password + "'";
                    }
                    if(account.Dob != DateTime.MinValue) 
                    {
                        filed += (filed != " SET " ? "," : "") + " dob='" + account.Dob.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                    }
                    if(!string.IsNullOrEmpty(account.FullName)) 
                    {
                        filed += (filed != " SET " ? "," : "") + " fullname='" + account.FullName + "'";
                    }
                    if (account.avatar != null)
                    {
                        filed += (filed != " SET " ? "," : "") + "avatar = CONVERT(varbinary(max), '" + Convert.ToBase64String(account.avatar) + "')";
                    }
                    if (!string.IsNullOrEmpty(account.Bio))
                    {
                        filed += (filed != " SET " ? "," : "") + " Bio='" + account.Bio + "'";
                    }
                }
                if (filed != " SET ")
                {
                    query += filed + " where id='" + id + "'";
                    return ExecuteNonQuery(query);                    
                }
                else
                    return 0;
                                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int CreateAccount(RegisterDTO account)
        {
            try
            {
                string query = "insert into "+ _TABLE_NAME_ACCOUNT;
                string field =" values ";
                if (account != null)
                {
                    field += "('" + Guid.NewGuid().ToString() + "'";
                    
                    if (!string.IsNullOrEmpty(account.username))
                    {
                        field += (field != " values " ? "," : "")+ "'" +  account.username + "'";
                    }
                    if (!string.IsNullOrEmpty(account.Password))
                    {
                        field += (field != " values " ? "," : "") + "'" + account.Password + "'";
                    }
                    field += (field != " values " ? "," : "") + "'3'";
                    if (account.Dob != DateTime.MinValue)
                    {
                        field += (field != " values " ? "," : "") + "'" + account.Dob.ToString("yyyy/MM/dd HH:mm:ss") + "'";
                    }
                    field += (field != " values " ? "," : "") + "'True'";
                    if (!string.IsNullOrEmpty(account.FullName))
                    {
                        field += (field != " values " ? "," : "") + " '" + account.FullName + "'";
                    }
                    if (account.avatar != null)
                    {
                        field += (field != " values " ? "," : "") + "CONVERT(varbinary(max), '" + Convert.ToBase64String(account.avatar) + "')";
                    }
                    if (!string.IsNullOrEmpty(account.Bio))
                    {
                        field += (field != " values " ? "," : "") + " '" + account.Bio + "')";
                    }
                }
                if (field != " values ")
                {
                    query += field;
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public LoginResponse isAuthenticated(string username, string password)
        {
          try
            {
                //string query = "create Procedure Authorized_Account @username varchar(100), @pass varchar(100)\r\nas\r\nbegin\r\nDeclare @rowcount int;\r\nSelect @rowcount = COUNT(@username) from accounts\r\nwhere ((username LIKE @username) AND (password LIKE @pass))\r\nif  (@rowCount > 0) \r\nBEGIN SELECT * from\r\naccounts where username = @username END \r\nELSE \r\nSELECT 0\r\nend\r\ngo "

                //string query = "exec Authorized_Account " + "'" + username + "', '" + password + "'";
                string query = "select top 1 * from Accounts where username like '" + username + "' and password like '" + password + "'";
                Hashtable res = ExecuteHashtable(query);
                if (res != null)
                {
                    return new LoginResponse(res);
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            
        }
        public int UpdateRole(changerole account, string id)
        {
            try
            {
                string query = "update " + _TABLE_NAME_ACCOUNT;
                string filed = " SET ";

                if (account != null)
                {
                    filed += "roleid = '" + account.Roleid + "'";
                }
                if (filed != " SET ")
                {
                    query += filed + " where id='" + id + "'";
                    return ExecuteNonQuery(query);
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
