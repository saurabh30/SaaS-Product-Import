using Saas_Product_Import.Common;
using Saas_Product_Import.Sources.Source;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saas_Product_Import.Sources
{
    public static class SourceFactory
    {
        public static IBaseSource GetSource(string sourceType)
        {
            switch (sourceType)
            {
                case Constants.Capterra:
                    return new Capterra();
                /*Other providers to be added here*/
                default:
                    throw new Exception("Undefined Source");
            }
        }
    }
}
