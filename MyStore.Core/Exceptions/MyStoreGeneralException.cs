using System;

namespace MyStore.Core.Exceptions
{
    public class MyStoreGeneralException : Exception
    {
        public MyStoreGeneralException(string message)
            : base(message)
        {
        }
        public MyStoreGeneralException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
