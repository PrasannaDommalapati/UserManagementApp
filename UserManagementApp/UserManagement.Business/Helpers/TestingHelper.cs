using System;
using System.Linq;
using System.Reflection;
using UserManagement.Business.Extensions;

namespace UserManagement.Business.Helpers
{
    public static class TestingHelper
    {
        public static bool ConstructorThrowsException(this Type typeofClass, object[] constructorArgs)
        {
            Type[] constructorTypes = constructorArgs
                .Select(a => a.GetType())
                .ToArray();

            ConstructorInfo ctor = typeofClass.GetConstructor(constructorTypes);

            if (ctor == null)
                throw new UserManagementException("There is no Such constructor");

            try
            {
                _ = ctor.Invoke(constructorArgs);
            }
            catch (Exception ex)
            {
                throw new UserManagementException("Constructor invocation failed.", ex);
            }

            for (int i = 0; i < constructorArgs.Length; i++)
            {
                var nullArgs = new object[constructorArgs.Length];
                Array.Copy(constructorArgs, nullArgs, constructorArgs.Length);
                nullArgs[i] = null;

                var parameter = ctor.GetParameters()[i];
                bool nullArgThrown = false;

                try
                {
                    _ = ctor.Invoke(nullArgs);
                }
                catch(Exception ex)
                {
                    nullArgThrown = ex.Message.Contains(parameter.Name)
                        || ex.InnerException?.Message.Contains(parameter.Name) == true
                        || ex.Message.Contains(parameter.ParameterType.Name)
                        || ex.InnerException?.Message.Contains(parameter.ParameterType.Name) == true;
                }

                if (nullArgThrown)
                    continue;

                throw new UserManagementException(string.Format("ArgumentNullException not thrown for '{0}'", parameter.Name));
            }
            return true;
        }
    }
}
