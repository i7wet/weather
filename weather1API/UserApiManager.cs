using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace weather1API
{
    class UserApiManager
    {
        public static ObservableCollection<UserApi> userApiList = new ObservableCollection<UserApi>();

        public static void WriteUserApiToLocalStorage(string formalUserApi)
        {
            UserApi userApiProp = new UserApi
            {
                UserApiProperty = formalUserApi
            };

            userApiList.Add(userApiProp);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));
            using (StreamWriter sw = new StreamWriter("UserApi.xml"))
            {
                xmlSerializer.Serialize(sw, userApiList);
            }
        }
        public static void ReadUserApiToLocalStorage()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));
            try
            {
                using (StreamReader sr = new StreamReader("UserApi.xml"))
                {
                    userApiList = xmlSerializer.Deserialize(sr) as ObservableCollection<UserApi>; 
                }
            }
            catch (Exception ex)
            {
            }
        }
        
    }
}