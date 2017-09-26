using Exam70_483.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam70_483.Services
{
    public class Reflections
    {
        public static void SetPropertiesOnObject(object obj, string byCos, string setCos)
        {
            Type typPrzekazany = obj.GetType();
            IEnumerable<PropertyInfo> props = obj.GetType().GetProperties()
                .Where(x => x.Name == byCos || x.Name == setCos);

            if (props?.Count() == 2 &&
                props.FirstOrDefault(x => x.Name == byCos).GetValue(obj) != null)
            {
                props.FirstOrDefault(x => x.Name == setCos).SetValue(obj, true);
            }
        }

        public List<Type> GetTypesFromCurrentDomain()
        {
            var x = GetType();
            List<Type> types = (AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass && t.Assembly == this.GetType().Assembly)).ToList<Type>();

            return types;
        }
    }
}
