using System;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace GA.Core.Util 
{
    public static class IOCContainer
    {
        private static IUnityContainer _uc;

        private static void InitUC()
        {
            try
            {
                _uc = new UnityContainer().LoadConfiguration();
                
            }
            catch (Exception ex)
            {
                Debug.Fail("Failed to local Unity Container", ex.ToString());
            }
        }

        public static T Resolve<T>()
        {
            try
            {
                if (_uc == null) InitUC();
                var instance = _uc.Resolve<T>();
                return instance;
            }
            catch (Exception )
            {
                throw;
            }
        }

        public static T Resolve<T>(string name)
        {
            if (_uc == null) InitUC();
            var instance = _uc.Resolve<T>(name);
            return instance;
        }
    }
}
