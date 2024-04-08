﻿using Cookapp_API.Data;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccoountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.AccountDTO;
using Cookapp_API.DataAccess.DTO.AllInOneDTO.PostDTO;

namespace Cookapp_API.DataAccess.BLL
{
    public class AccountBLL
    {
        string _connetionString;
        int _timeout;
        ESqlProvider _sqlProvider;
        public AccountBLL(string connetionString, ESqlProvider sqlProvider, int timeout)
        {
            _connetionString = connetionString;
            _sqlProvider = sqlProvider;
            _timeout = timeout;
        }
        private DAL.AccountDAL GetDAL_MSSQLSERVER()
        {
            if (!string.IsNullOrEmpty(_connetionString))
            {
                return new DAL.AccountDAL(_connetionString
                    , _timeout);
            }
            else
            {
                throw new Exception("SqlConnectionString is Empty");
            }
        }
        public List<AccountDTO> GetAccounts()
        {
            try
            {
                if(_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AccountDAL dal = GetDAL_MSSQLSERVER();
                    return dal.GetAccounts();
                }
                else { throw new Exception("not support unknown sqlProvider"); }
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
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AccountDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateAccount(id, account);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
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
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AccountDAL dal = GetDAL_MSSQLSERVER();
                    return dal.CreateAccount(account);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public LoginResponse isAuthenticated (string username, string password)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AccountDAL dal = GetDAL_MSSQLSERVER();
                    return dal.isAuthenticated(username,password);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int changerole(changerole role, string id)
        {
            try
            {
                if (_sqlProvider == ESqlProvider.SQLSERVER)
                {
                    DAL.AccountDAL dal = GetDAL_MSSQLSERVER();
                    return dal.UpdateRole(role, id);
                }
                else { throw new Exception("not support unknown sqlProvider"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
