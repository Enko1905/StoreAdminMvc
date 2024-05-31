using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace StoreAdmin.Extensions
{
    public static class TempDataExtension
    {
        public static void Put(this ITempDataDictionary tempData, string key, string message, string messageType)
        {
            tempData[key] = new ToastMessage { Message = message, MessageType = messageType };
        }

        public static ToastMessage GetToastMessage(this ITempDataDictionary tempData, string key)
        {
            tempData.TryGetValue(key, out var o);
            tempData.Remove(key); // Mesajı okuduktan sonra kaldır.
            return o as ToastMessage;
        }
    }

    public class ToastMessage
    {
        public string Message { get; set; }
        public string MessageType { get; set; } // success, info, warning, error
    }
}
