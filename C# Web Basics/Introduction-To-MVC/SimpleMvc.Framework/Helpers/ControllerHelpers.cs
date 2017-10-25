﻿namespace SimpleMvc.Framework.Helpers
{
    public static class ControllerHelpers
    {
        public static string GetControllerName(object controller)
        {
            return controller.GetType().Name.Replace(MvcContext.Get.ControllersSuffix, string.Empty);
        }

        public static string GetFullQualifiedName(string controller, string action)
        {
            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.Viewsfolder,
                controller,
                action);

            return fullQualifiedName;
        }
    }
}
