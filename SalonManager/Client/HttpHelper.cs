using Microsoft.AspNetCore.WebUtilities;

namespace SalonManager.Client
{
  
            public static class HttpHelper
    {
        public static string ParseQuery<TQuery>(string basePath, TQuery query)
        {
            var querParams = new Dictionary<string, string>();

            foreach (var prop in query.GetType().GetProperties())
            {
                object value = prop.GetValue(query);

                // Skip if reference type default value
                if (value is null)
                    continue;

                // Skip if value type default value
                object propDefaultValue = GetValueTypeDefaultValue(value);
                if (value.Equals(propDefaultValue))
                    continue;

                querParams.Add(prop.Name, value.ToString());
            }

            return QueryHelpers.AddQueryString(basePath, querParams);
        }

        private static object GetValueTypeDefaultValue(object value)
        {
            Type type = value.GetType();
            return Activator.CreateInstance(type);
        }
    }
    
}
