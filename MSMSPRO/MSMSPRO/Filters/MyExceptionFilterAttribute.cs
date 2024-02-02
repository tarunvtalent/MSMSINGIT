using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;

namespace MSMSPRO.Filters
{
    public class MyExceptionFilterAttribute :ExceptionFilterAttribute
    {
        public static string Errorline, Errormsg, Extype, Errorlocation;

        public static void SendErrorToExt(Exception ex)
        {

            var line = Environment.NewLine + Environment.NewLine;

            Errorline = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            Extype = ex.GetType().ToString();
            Errorlocation = ex.Message.ToString();

            try
            {

                System.IO.Directory.GetCurrentDirectory();
                string filepath = Path.GetFullPath("ErrorLogFile/"); //Text file path 

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                filepath = filepath + "ErrorLog-" + DateTime.Today.ToString("dd-mm-yy") + ".txt";   //Text File Name 
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date : " + " " + DateTime.Now.ToString() + line + " Error line No : " + Errorline + " Error Message : " + Errormsg + " Error type : " + Extype + " Error Location : " + Errorlocation;

                    sw.WriteLine("---------------------Exception Details  on  " + " " + DateTime.Now.ToString() + "----------------------");
                    sw.WriteLine("------------------------------------------------------------------------------------------------------");
                    sw.Write(line);
                    sw.Write(error);
                    sw.Write("-------------------------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();


                }

            }
            catch (Exception e)
            {
                e.ToString();
            }

        }

        public override void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            //Logging Exception into aText File 
            SendErrorToExt(ex);

            context.Result = new ObjectResult(ex.Message)
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;


        }


    }
}
