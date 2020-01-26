using System;
using System.Runtime.Serialization;

namespace UserManagement.Business.Extensions
{
    [Serializable]
    public class UserManagementException : Exception
    {
        public UserManagementException() 
        {
        }

        public UserManagementException(string message) : base(message)
        {
        }

        public UserManagementException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserManagementException(SerializationInfo info, in StreamingContext context) : base(info, context) { }
    }
}
