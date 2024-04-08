﻿using System.Collections;
using System.Globalization;
using System.Reflection;

namespace Cookapp_API.DataAccess.DTO.AllInOneDTO.CategoryDTO
{
    public class CategoryDTO
    {
        public string Id { get; set; } = null!;

        public string catetitle { get; set; } = null!;

        public CategoryDTO() { }
        public void InitEmptyValue() { }
        public CategoryDTO(Hashtable hsObj)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            //<==========
            InitEmptyValue();

            if (hsObj == null)
                return;

            try
            {
                PropertyInfo[] arrProInfo = this.GetType().GetProperties();
                PropertyInfo proInfo;
                object objValue;
                string sValue;
                string proName;
                for (int i = 0; i < arrProInfo.Length; i++)
                {
                    proInfo = arrProInfo[i];
                    proName = proInfo.Name.ToLower();
                    if (hsObj.ContainsKey(proName))
                    {
                        objValue = hsObj[proName];

                        sValue = Convert.ToString(objValue);
                        if (string.IsNullOrEmpty(sValue))
                            continue;
                        switch (proInfo.PropertyType.Name.ToLower())
                        {
                            case "byte":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToByte(sValue), null);
                                break;
                            case "int64":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToInt64(sValue), null);
                                break;
                            case "int32":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToInt32(sValue), null);
                                break;
                            case "datetime":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToDateTime(sValue), null);
                                break;
                            case "string":
                                proInfo.SetValue(this, sValue, null);
                                break;
                            case "double":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToDouble(sValue), null);
                                break;
                            case "float":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToDouble(sValue), null);
                                break;
                            case "byte[]":
                                proInfo.SetValue(this, (byte[])objValue, null);
                                break;
                            case "boolean":
                                proInfo.SetValue(this, GlobalFuncs.ConvertStringToBoolean(sValue), null);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
