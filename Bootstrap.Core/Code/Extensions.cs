using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bootstrap.Core.Code
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory _myTaskFactory = new
            TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return AsyncHelper._myTaskFactory
                .StartNew<Task<TResult>>(func)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            AsyncHelper._myTaskFactory
                .StartNew<Task>(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }
    }
    public static class Extensions
    {
       

        public static string ToJson(this object objectToSave)
        {
            try
            {
                if (objectToSave == null) return null;
                var st = new JsonSerializerSettings();
                st.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
                return JsonConvert.SerializeObject(objectToSave, Formatting.None, st);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static TJson FromJson<TJson>(this string jsonString)
        {
            try
            {

                return JsonConvert.DeserializeObject<TJson>(jsonString, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
