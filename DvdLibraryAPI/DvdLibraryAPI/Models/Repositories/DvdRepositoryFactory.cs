﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibraryAPI.Models.Repositories
{
    public static class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            switch(ConfigurationManager.AppSettings.Get("Mode"))
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                case "ADO":
                    return new DvdRepositoryADO(ConfigurationManager.ConnectionStrings["DvdLibraryADO"].ConnectionString);
                default:
                    throw new ConfigurationErrorsException("Invalid Application Mode");
            }
        }
    }
}