using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using UserManagement.Business.Extensions;

namespace UserManagement.Business.Helpers
{
    public static class Utility
    {
        public static string Serialize<T>(T data) where T : class
        {
            data.ValidateNotNull();

            var contractResolver = new CamelCasePropertyNamesContractResolver();
            contractResolver.NamingStrategy.OverrideSpecifiedNames = false;

            return JsonConvert.SerializeObject(data,
                new JsonSerializerSettings
                {
                    ContractResolver = contractResolver
                });
        }

        public static T Deserialize<T>(string data)
        {
            data.ValidateNotEmpty();

            try
            {
                return JsonConvert.DeserializeObject<T>(data,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
            }catch(Exception ex)
            {
                throw new UserManagementException("Deserialisation error.", ex);
            }
        }
    }
}
