using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TraviAnt;

namespace TraviAnt
{
    public static class Bot
    {
        public static void Log(string message, Color color)
        {
            try
            {
                Form1.form1.Invoke(Form1.form1.writer, new object[]
                {
                    message, color
                });
            }
            catch (Exception)
            {
            }
        }

        public static bool SaveData(string json)
        {
            JsonParser data = JsonParser.FromJson(json);
            try
            {
                if (data.Response.Error == true)
                {
                    Bot.Log("ERROR: " + data.Response.ErrorMsg.ToString(), Color.Red);
                    Info.ErrorMessage = data.Response.ErrorMsg.ToString();
                }
                string savejson = JsonConvert.SerializeObject(data);
                Info.ResponseBody = savejson;
                return true;
            }
            catch (Exception e)
            {
                Bot.Log(e.Message, Color.Black);
                return false;
            }
        }

        public static bool GetErrorMessage(string json)
        {
            JsonParser data;
            try
            {
                data = JsonParser.FromJson(json);
                if (data.Response.Error.Equals(true))
                {
                    Info.ErrorMessage = data.Response.ErrorMsg.ToString();
                    return true;
                }
                else if (data.Response.Data.Options.DialogOptions != null)
                {
                    Bot.Log("Not enough gold!", Color.DarkGoldenrod);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Bot.Log(e.Message, Color.Black);
                return true;
            }
        }
    }
}
