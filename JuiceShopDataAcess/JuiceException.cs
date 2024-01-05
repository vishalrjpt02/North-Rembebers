/*************************************************************************************************
 * @author  : Vishal kumar
 * @file    : JuiceDatamanager
 * @purpose : to add and retrive data from database i.e: ado.net and stored procedure will be used
 * **********************************************************************************************/

using System;
using System.Runtime.Serialization;

namespace JuiceShopDataAcess
{
    [Serializable]
    internal class JuiceException : Exception
    {
        public JuiceException()
        {
        }

        public JuiceException(string message) : base(message)
        {
        }

        public JuiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JuiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}