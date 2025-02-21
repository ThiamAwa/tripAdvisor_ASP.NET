using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcExampleM1GlGroupe2.App_Start
{
    public class Helper
    {
    }
    public enum FlashLevel
    {
        Info = 0,
        Success = 1,
        Warning = 2,
        Danger = 3        
    }
    public static class FlashHelper
    {
        public static void Flash(this Controller controller, string message,FlashLevel level)
        {
            IList<string> messages = null;
            string key = string.Format("flash{-0}", level.ToString().ToLower());
        messages = (controller.TempData.ContainsKey(key))
                ? (IList<string>)controller.TempData[key]
                : new List<string>();
            messages.Add(message);

            controller.TempData[key] =messages;
        }
    }
}