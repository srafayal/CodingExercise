using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace CodingExercise.Others
{
    public class ApplicationSettings
    {

        public static int BoxCapacity;
     
        
        
        #region CTOR
        static ApplicationSettings()
        {
            BoxCapacity = int.Parse(ConfigurationManager.AppSettings["Box.Capacity"].ToString());

        }

        #endregion
        
    }
}