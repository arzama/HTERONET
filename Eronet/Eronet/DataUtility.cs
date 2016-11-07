using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
//--------------------------------------------------------//
using System.Net.Http;
using Windows.UI.Popups;
using System.Xml.Serialization;
using Windows.UI.Xaml;
using System.IO;
//--------------------------------------------------------//

namespace Eronet
{
    class DataUtility
    {
        private static mobAppModel allApps { get; set; }

        // Constructor
        public DataUtility() { }

        // Helper methods
        //---------------------------------------------------------//
        //---               DOWNLOAD DATA FROM XML              ---//
        //---------------------------------------------------------//
        public async Task GetData()
        {
            // Get xml data from URL
            HttpClient hc = new HttpClient();
            HttpResponseMessage response = await hc.GetAsync("https://dl.dropboxusercontent.com/s/y2e6s4v2f67zfq1/xmlData.xml");

            

            // Check if the data is downloaded successfully
            if (response.IsSuccessStatusCode)
            {
                // Put the xml data into string
                string s = await response.Content.ReadAsStringAsync();

                // Check if the data is transfered to string
                if (response.Content.ReadAsStringAsync().IsCompleted)
                {
                    // Parse xml data
                    allApps = ParseXmlData(s);
                }
            }
            else                    // If any error occurs while downloading data
                throw new Exception("Unable to communicate with server...");
            // Message to display to the user
        }
        //---------------------------------------------------------//

        //---------------------------------------------------------//
        //---       PARSING XML STRING TO CLASS OBJECT          ---//
        //---------------------------------------------------------//
        private mobAppModel ParseXmlData(string s)
        {
            XmlSerializer xs = new XmlSerializer(typeof(mobAppModel));
            mobAppModel ai = (mobAppModel)xs.Deserialize(new StringReader(s));

            return ai;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public List<mobAppModelAppInfo> GetAllApps()
        {
            List<mobAppModelAppInfo> ai = new List<mobAppModelAppInfo>();

            for (int i = 0; i < allApps.appInfo.Length; i++)
            {
                ai.Add(allApps.appInfo[i]);
            }
            return ai;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public List<mobAppModelAppInfo> GetPreporuceneApps()
        {
            List<mobAppModelAppInfo> ai = new List<mobAppModelAppInfo>();

            for (int i = 0; i < allApps.appInfo.Length; i++)
            {
                //Add extension to screenshots
                for (int j = 0; j < 2; j++)
                {
                    allApps.appInfo[i].screenshots[j] += "?imageType=ws_icon_small";
                }

                //Add extension to icon
                allApps.appInfo[i].iconUrl += "?imageType=ws_icon_tiny";

                if(allApps.appInfo[i].preporuceno == true)
                    ai.Add(allApps.appInfo[i]);
            }
            ai.Reverse();
            return ai;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public mobAppModelAppInfo[] GetNajgledanije()
        {
            List<mobAppModelAppInfo> m = new List<mobAppModelAppInfo>();
            for (int f = 0; f < allApps.appInfo.Length; f++)
            {
                m.Add(allApps.appInfo[f]);
            }

            int naj = 2;
            //if (allApps.appInfo.Length < naj)
                naj = allApps.appInfo.Length;

            mobAppModelAppInfo[] ai = new mobAppModelAppInfo[naj];

            mobAppModelAppInfo[] mm = m.ToArray();
            Array.Sort(mm, delegate(mobAppModelAppInfo a, mobAppModelAppInfo b)
            {
                return b.ratingPoints.CompareTo(a.ratingPoints);
            });

            for (int i = 0; i < naj; i++)
            {
                ai[i] = mm[i];
            }
            return ai;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public List<string> GetKategorije()
        {
            List<string> kategorije = new List<string>();

            for (int i = 0; i < allApps.appInfo.Length; i++)
            {
                kategorije.Add(allApps.appInfo[i].category);
            }

            List<string> distinctKategorije = kategorije.Distinct().ToList();

            return distinctKategorije;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING APPS PO KATEGORIJI         ---//
        //---------------------------------------------------------//
        public List<mobAppModelAppInfo> GetAppsPoKategoriji(string kategorija)
        {
            List<mobAppModelAppInfo> l = new List<mobAppModelAppInfo>();

            for (int i = 0; i < allApps.appInfo.Length; i++)
            {
                if (allApps.appInfo[i].category == kategorija)
                    l.Add(allApps.appInfo[i]);
            }

            return l;
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public mobAppModelAppInfo GetApp(int id)
        {
            return allApps.appInfo.FirstOrDefault(x => x.id == id);
        }
        //--------------------------------------------------------//

        //---------------------------------------------------------//
        //---       METHOD RETURNING PREPORUCENE APPS           ---//
        //---------------------------------------------------------//
        public List<string> GetScreenShots(int id)
        {
            List<string> s = new List<string>();
            for (int i = 0; i < 2; i++)
			{
                s.Add(allApps.appInfo.FirstOrDefault(x => x.id == id).screenshots[i]);
			}
            return s;
        }
        //--------------------------------------------------------//
    }
}
