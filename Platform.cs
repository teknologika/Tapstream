using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TapstreamMetrics.Sdk
{
    public class Platform : IPlatform
    {

        public Platform()
        {
        }

        #region IPlatform implementation

        public string GetUuid()
        {
            return new MonoTouch.UIKit.UIDevice().IdentifierForVendor.ToString();
        }

        public HashSet<string> LoadFiredEvents()
        {
            string[] defaultsArray = NSUserDefaults.StandardUserDefaults.StringArrayForKey(@"kTSFiredEventsKey");
            if (defaultsArray == null)
            {
                return new HashSet<string>();
            }
            else
            {
                HashSet<string> firedEvents = new HashSet<string>(defaultsArray);
                return firedEvents;
            }
        }

        public void SaveFiredEvents(HashSet<string> firedEvents)
        {
            String[] defaultsArray = new String[firedEvents.Count];
            firedEvents.CopyTo(defaultsArray);
            NSUserDefaults.StandardUserDefaults["kTSFiredEventsKey"] = NSArray.FromObjects(defaultsArray);
          }

        public string GetResolution()
        {
            RectangleF frame = UIScreen.MainScreen.Bounds;
            float scale = UIScreen.MainScreen.Scale;
            return string.Format("{0}x{1}",(int)(frame.Width * scale),(int)(frame.Height * scale));
        }

        public string GetManufacturer()
        {
            return "Apple";
        }

        public string GetModel()
        {
            return  UIDevice.CurrentDevice.Model;
        }

        public string GetOs()
        {
            return string.Format("{0} {1}",UIDevice.CurrentDevice.SystemName,UIDevice.CurrentDevice.SystemVersion);
        }

        public string GetLocale()
        {
            return NSLocale.CurrentLocale.LocaleIdentifier; 
        }

        public string GetAppName()
        {
            return (NSString)NSBundle.MainBundle.InfoDictionary.ObjectForKey(new NSString("CFBundleName")).ToString();
        }

        public string GetPackageName()
        {
            return NSBundle.MainBundle.BundleIdentifier;
        }

        public TSResponse Request(string url, string data)
        {
            int status = -1;
            string message = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded")).Result;
                    status = (int)response.StatusCode;
                    if(!response.IsSuccessStatusCode)
                    {
                        message = response.ReasonPhrase;
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                message = ex.Message;
            }
            return new TSResponse(status, message);
        }

        #endregion
    }
}

