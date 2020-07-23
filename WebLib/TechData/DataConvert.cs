using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WebLib.TechData
{
    public static class DataConvert
    {
        public static List<T> T2TList<T>(this object arr)
        {
            var s1 = Newtonsoft.Json.JsonConvert.SerializeObject(arr);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(s1);
        }
        public static T T2T<T>(this object arr)
        {
            var s1 = Newtonsoft.Json.JsonConvert.SerializeObject(arr);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(s1);
        }
        public static void Update<T, T2>(T dest, T2 source)
        {
            var prop1 = dest.GetType().GetProperties();
            var prop2 = source.GetType().GetProperties();
            foreach (var p in prop2)
            {
                var value = p.GetValue(source);
                if (value != null)
                {
                    var field = prop1.Where(x => x.Name == p.Name).FirstOrDefault();
                    if (field == null) continue;
                    field.SetValue(dest, value);
                }
            }
        }
    }
}
