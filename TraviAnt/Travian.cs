using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TraviAnt
{
    public class Travian
    {
        string content;

        public Form1 mainForm;
        public HtmlCrawler htmlCrawler;
        public readonly Random rnd = new Random();
        private const int Min = 0; // Change this!....
        int max = 100; // Change this!....
        private string _user, _pass;
        string _server;
        private readonly int _trainTroopType;
        private readonly int _farmlistTroopType;
        CookieCollection cookies = null;
        public string Proxy = null;
        public bool BuyAnimalsState = false;
        public bool BuyResourcesState = false;
        public bool ExcludeLastList = false;
        public bool DoNpc = false;
        List<string> lidList;
        int raidTurn = 0;
        public CancellationTokenSource cts;

        const string MARKEDPLACE_ID = "17";
        const string WAREHOUSE_ID = "10";
        const string RALLYPOINT_ID = "16";
        const string MAINBUILDING_ID = "15";
        const string BARRACKS_ID = "19";
        const string GRANARY_ID = "11";

        public Travian(string user, string pass, string server, int trainTroopType, int farmlistTroopType)
        {
            _user = user;
            _pass = pass;
            _server = server;
            _trainTroopType = trainTroopType;
            _farmlistTroopType = farmlistTroopType;
        }

        Dictionary<string, string> _getParams = new Dictionary<string, string>();

        public bool Login(string _loginToken)
        {
            _getParams.Clear();
            var postParams = new Dictionary<string, string>
            {
                { "user", _user },
                { "pw", _pass },
                { "s1", "Login" },
                { "w", "1366:768" },
                { "login", _loginToken }
            };

            if (_server.Contains("travian.com.tr"))
            {
                postParams = new Dictionary<string, string>
                {
                    { "name", _user },
                    { "password", _pass },
                    { "s1", "Giriş" },
                    { "w", "1366:768" },
                    { "login", _loginToken }
                };
            }

            return HTTP.PostRequest("https://" + _server + "/index.php", null, _getParams, postParams, ref cookies);
        }



        public void GetToken()
        {
            _getParams.Clear();
            if (HTTP.GetRequest("http://" + _server + "/index.php", _getParams, _server, true))
            {
                htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            }
            htmlCrawler.SetLoginId();
        }

        public bool StartRaid()
        {
            _getParams = new Dictionary<string, string>
            {
                { "tt", "99" },
                { "id", "39" }
            };

            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            Bot.Log("Navigated to farmlist", Color.Black);
            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            var ajaxToken = htmlCrawler.GetAjaxToken();
            var aToken = htmlCrawler.GetValueA();
            lidList = htmlCrawler.GetLid();

            if (lidList.Count < 1)
                return false;

            if (ExcludeLastList)
            {
                if (raidTurn >= lidList.Count - 1)
                    raidTurn = 0;
            }
            else
            {
                if (raidTurn >= lidList.Count)
                    raidTurn = 0;
            }

            if (ExpandRaidList(ajaxToken, lidList[raidTurn]))
            {
                if (ClickRaid(aToken, lidList[raidTurn]))
                {
                    var randomDelay = rnd.Next(Math.Min(Min, max), Math.Max(Min, max) + 1);
                    //0s - 2min 30s = 150s
                    var delay = (75 * randomDelay) + 30000;
                    TimeSpan t = TimeSpan.FromMilliseconds(delay);
                    string delayTime = $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}";
                    Bot.Log("List: " + raidTurn + " - Raid sent! Waiting " + delayTime + " before next raid.", Color.Black);
                    raidTurn++;
                    Thread.Sleep(delay);
                    return true;
                }
                Bot.Log("Raid failed", Color.Black);
                return false;
            }
            else
            {
                Bot.Log("Error while expanding raidlist", Color.Black);
                return false;
            }
        }

        public bool AttackPlayer(string x, string y)
        {
            _getParams = new Dictionary<string, string>
            {
                { "id", "39" },
                { "tt", "2" },
            };

            string ajaxToken;

            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            var aToken = htmlCrawler.GetValueA();

            Dictionary<string, string> attackInfo = htmlCrawler.GetAttackInfo();

            _getParams.Clear();

            var list = Info.AttackUnits;

            var postParams = new Dictionary<string, string>
            {
                { "timestamp", attackInfo["timestamp"] },
                { "timestamp_checksum", attackInfo["timestamp_checksum"] },
                { "b", attackInfo["b"] },
                { "currentDid", attackInfo["currentDid"] },
                { "mpvt_token", attackInfo["mpvt_token"] },
                { "t1", list[0] },
                { "t4", list[3] },
                { "t7", list[6] },
                { "t9", "" },
                { "t2", list[1] },
                { "t5", list[4] },
                { "t8", list[7] },
                { "t10", "" },
                { "t3", list[2] },
                { "t6", list[5] },
                { "t11", "" },
                { "dname", "" },
                { "x", x },
                { "y", y },
                { "c", "3" },
                { "s1", "ok" }
            };

            if (HTTP.PostRequest("https://" + _server + "/build.php?id=39&tt=2", null, _getParams, postParams, ref cookies))
            {
                attackInfo = htmlCrawler.GetAttackInfo();

                postParams = new Dictionary<string, string>
                {
                    { "redeployHero", "" },
                    { "timestamp", attackInfo["timestamp"] },
                    { "timestamp_checksum", attackInfo["timestamp_checksum"] },
                    { "id", "39" },
                    { "a", aToken },
                    { "c", "3" },
                    { "kid", attackInfo["kid"] },
                    { "t1", attackInfo["t1"] },
                    { "t2", attackInfo["t2"] },
                    { "t3", attackInfo["t3"] },
                    { "t4", attackInfo["t4"] },
                    { "t5", attackInfo["t5"] },
                    { "t6", attackInfo["t6"] },
                    { "t7", attackInfo["t7"] },
                    { "t8", attackInfo["t8"] },
                    { "t9", attackInfo["t9"] },
                    { "t10", attackInfo["t10"] },
                    { "t11", attackInfo["t11"] },
                    { "sendReally", "1" },
                    { "troopsSent", "1" },
                    { "currentDid", attackInfo["currentDid"] },
                    { "b", attackInfo["b"] },
                    { "dname", "" },
                    { "x", x },
                    { "y", y },
                    { "s1", "ok" }
                };

                if (list[7] != string.Empty || list[7] != null)
                {
                    postParams.Add("ctar1", "99");
                    postParams.Add("ctar2", "99");
                }

                if (HTTP.PostRequest("https://" + _server + "/build.php?id=39&tt=2", null, _getParams, postParams, ref cookies))
                {
                    Bot.Log("Attacked!", Color.Black);
                }
                return false;
            }
            else
            {
                Bot.Log("Error while attacking", Color.Black);
                return false;
            }
        }

        public bool ClickRaid(string token, string lid)
        {

            _getParams.Clear();

            var postParams = new Dictionary<string, string>
            {
                { "action", "startRaid" },
                { "a", token },
                { "sort", "distance" },
                { "direction", "asc" },
                { "lid", lid }
            };

            var json = Info.ResponseBody;
            var jsonData = JsonParser.FromJson(json);

            if (jsonData.Response.Data.List.Slots == null)
                return false;

            foreach (var list in jsonData.Response.Data.List.Slots)
            {
                postParams.Add("slot[" + list.Key + "]", "on");
            }

            return HTTP.PostRequest("https://" + _server + "/build.php?gid=16&tt=99", null, _getParams, postParams, ref cookies);
        }

        public bool TrainTroops(string id)
        {
            _getParams = new Dictionary<string, string>
            {
                { "id", id },
                { "fastUP", "0" }
            };

            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);

            if (htmlCrawler.isSessionExpired(content))
                return false;

            if (htmlCrawler.isBuildingThere(content))
            {
                var zToken = htmlCrawler.GetValueZ();
                var ajaxToken = htmlCrawler.GetAjaxToken();
                var troopResourceParams = htmlCrawler.GetTroopResource(ajaxToken);
                if (DoNpc)
                {
                    if (Npc(troopResourceParams, ajaxToken))
                    {
                        Bot.Log("NPC done.", Color.Black);
                    }
                }
                htmlCrawler = new HtmlCrawler(Info.ResponseBody);
                var troopsForRes = htmlCrawler.TroopsForRes();
                string[] trainType = new string[4]
                {
                    "0", "0", "0", "0"
                };

                if (troopsForRes.Count > 0)
                {
                    trainType[_trainTroopType] = troopsForRes[_trainTroopType];
                }
                else
                {
                    return false;
                }

                var postParams = new Dictionary<string, string>
                {
                    { "id", id },
                    { "z", zToken },
                    { "a", "2" },
                    { "s", "1" },
                    { "t1", trainType[0] },
                    { "t2", trainType[1] },
                    { "t3", trainType[2] },
                    { "t4", trainType[3] },
                    { "s1", "ok" }
                };

                if (!HTTP.PostRequest("https://" + _server + "/build.php", null, _getParams, postParams, ref cookies))
                    return false;

                var randomDelay = rnd.Next(Math.Min(Min, max), Math.Max(Min, max) + 1);
                //0s - 2min 30s = 150s
                var delay = (75 * randomDelay) + 2000;
                TimeSpan t = TimeSpan.FromMilliseconds(delay);
                string delayTime = $"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}";
                Bot.Log("Troops trained: " + troopsForRes[_trainTroopType] + " Waiting " + delayTime + " before next raid.", Color.Black);
                Thread.Sleep(delay);
                return true;
            }

            Bot.Log("Barracks is destroyed. Trying to build it up.", Color.Black);
            return BuildBuildings() && TrainTroops(id);
        }

        public bool BuildBuildings()
        {
            Build(Info.Queue[0].Location.ToString(), "", Info.Queue[0].ToLevel);
            return true;
        }

        public void Build(string posId, string buildingId, int toLevel)
        {
            int level = 0;
            TimeSpan buildingTime = new TimeSpan(0, 0, 0);
            var getParams = new Dictionary<string, string>
            {
                { "id", posId },
                { "fastUP", "0" }
            };

            if (!HTTP.GetRequest("http://" + _server + "/build.php", getParams, _server, true))
                return;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            var c = htmlCrawler.GetValueC(buildingId);

            var reg = new Regex(@"Construct new building");
            var match = reg.Match(Info.ResponseBody);
            if (match.Success)
            {
                _getParams = new Dictionary<string, string>
                {
                    { "a", buildingId },
                    { "id", posId },
                    { "c", c }
                };
            }
            else
            {

                htmlCrawler = new HtmlCrawler(Info.ResponseBody);
                buildingTime = htmlCrawler.GetBuildingTime();

                getParams = new Dictionary<string, string>
                {
                    { "a", posId },
                    { "c", c }
                };
            }

            if (!HTTP.GetRequest("http://" + _server + "/dorf2.php", getParams, _server, true))
                return;
            Bot.Log("Waiting for: " + buildingTime, Color.Black);
        }

        public bool ExpandRaidList(string token, string lid)
        {
            _getParams.Clear();
            var postParams = new Dictionary<string, string>
            {
                { "cmd", "raidListSlots" },
                { "lid", lid },
                { "ajaxToken", token }
            };

            if (HTTP.PostRequest("https://" + _server + "/ajax.php?cmd=raidListSlots", null, _getParams, postParams, ref cookies))
            {
                return Bot.SaveData(Info.ResponseBody);
            }
            return false;
        }

        public bool Npc(Dictionary<string, string> resourceParams, string ajaxToken)
        {
            _getParams.Clear();
            var postParams = resourceParams;

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=exchangeResources", _server, cookies,
                _getParams, postParams, ref cookies)) return true;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            var did = htmlCrawler.GetDid();
            postParams = new Dictionary<string, string>
            {
                { "cmd", "exchangeResources" },
                { "did", did },
                { "desired[0]" , postParams["defaultValues[r1]"] },
                { "desired[1]" , postParams["defaultValues[r2]"] },
                { "desired[2]" , postParams["defaultValues[r3]"] },
                { "desired[3]" , postParams["defaultValues[r4]"] },
                { "ajaxToken", ajaxToken }
            };

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=exchangeResources", _server, cookies,
                _getParams, postParams, ref cookies)) return true;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            postParams = htmlCrawler.GetExchangeParams(did, ajaxToken);

            return HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=premiumFeature",
                _server,
                cookies,
                _getParams,
                postParams,
                ref cookies);
        }

        public void BuyGoodies()
        {
            if (BuyAnimalsState == true)
            {
                Bot.Log("Buying animals...", Color.Black);
                if (BuyAnimals())
                    Bot.Log("Animals purchased.", Color.ForestGreen);
                else
                    Bot.Log("Couldn't puchase animals", Color.Red);
            }
            if (BuyResourcesState == true)
            {
                Bot.Log("Buying resources...", Color.Black);
                if (BuyResources())
                    Bot.Log("Resources purchased.", Color.ForestGreen);
                else
                    Bot.Log("Couldn't puchase resources", Color.Red);
            }
        }

        public bool BuyResources()
        {
            _getParams.Clear();
            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            string token;
            token = htmlCrawler.GetAjaxToken();

            var postParams = new Dictionary<string, string>
            {
                { "", "" },
                { "cmd", "paymentWizard" },
                { "goldProductId", "" },
                { "goldProductLocation", "" },
                { "location", "" },
                { "activeTab", "buyGold" },
                { "ajaxToken", token }
            };

            CookieCollection t = new CookieCollection();

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=paymentWizard", _server, cookies,
                _getParams, postParams, ref t)) return false;
            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams["activeTab"] = "paymentFeatures";
            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=paymentWizard", _server, cookies,
                _getParams, postParams, ref t)) return false;
            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams = new Dictionary<string, string>
            {
                { "cmd", "premiumFeature" },
                { "featureKey", "buyResources6" },
                { "context", "paymentWizard" },
                { "activeTab", "buyGold" },
                { "ajaxToken", token }
            };
            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=premiumFeature", _server, cookies,
                _getParams, postParams, ref t)) return false;
            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams = new Dictionary<string, string>
            {
                { "cmd", "getGoldAmount" },
                { "ajaxToken", token }
            };
            return HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=getGoldAmount", _server, cookies, _getParams, postParams, ref t);
        }

        public bool BuyAnimals()
        {
            _getParams.Clear();

            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            string token;
            token = htmlCrawler.GetAjaxToken();

            var postParams = new Dictionary<string, string>
            {
                { "", "" },
                { "cmd", "paymentWizard" },
                { "goldProductId", "" },
                { "goldProductLocation", "" },
                { "location", "" },
                { "activeTab", "buyGold" },
                { "ajaxToken", token }
            };

            CookieCollection t = new CookieCollection();
            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=paymentWizard", _server, cookies,
                _getParams, postParams, ref t)) return false;

            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams["activeTab"] = "paymentFeatures";

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=paymentWizard", _server, cookies,
                _getParams, postParams, ref t)) return false;

            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams = new Dictionary<string, string>
            {
                { "cmd", "premiumFeature" },
                { "featureKey", "buyAnimal5" },
                { "context", "paymentWizard" },
                { "ajaxToken", token }
            };

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=premiumFeature", _server, cookies,
                _getParams, postParams, ref t)) return false;

            if (Bot.GetErrorMessage(Info.ResponseBody))
                return false;

            postParams = new Dictionary<string, string>
            {
                { "cmd", "getGoldAmount" },
                { "ajaxToken", token }
            };
            if (HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=getGoldAmount", _server, cookies, _getParams, postParams, ref t))
            {
                // Hata mesajı varsa false döndürür
                return !Bot.GetErrorMessage(Info.ResponseBody);
            }
            return false;
        }

        public bool CreateFarmlist()
        {
            _getParams.Clear();

            string ajaxToken, aToken;

            if (!HTTP.GetRequest("http://" + _server + "/spieler.php?uid=1", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            ajaxToken = htmlCrawler.GetAjaxToken();
            List<Coordinates> coordinates = htmlCrawler.GetCoordinates();

            _getParams = new Dictionary<string, string>
            {
                { "tt", "99" },
                { "id", "39" }
            };

            if (!HTTP.GetRequest("http://" + _server + "/build.php", _getParams, _server, true))
                return false;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            Bot.Log("Navigated to farmlist", Color.Black);
            lidList = htmlCrawler.GetLid();

            if (lidList.Count < 1)
            {
                Bot.Log("No farmlists detected!", Color.Red);
                return false;
            }

            int addToList;
            for (addToList = 0; addToList < lidList.Count; addToList++)
            {
                if (ExpandRaidList(ajaxToken, lidList[addToList]))
                {
                    var farmCoordinates = coordinates.GetRange((0 + (addToList*100)), 100);
                    foreach (Coordinates c in farmCoordinates)
                    {
                        if (ClickAdd(ajaxToken, lidList[addToList], c.X, c.Y))
                        {
                            Bot.Log("List: " + addToList + " - Farm added. X: " + c.X + " Y: " + c.Y + " %" + (farmCoordinates.IndexOf(c) + 1), Color.DarkGreen);
                        }
                        else
                        {
                            Bot.Log("Error while adding farm to farmlist.", Color.DarkRed);
                            return false;
                        }
                    }
                }
                else
                {
                    Bot.Log("Error while expanding raidlist", Color.DarkRed);
                    return false;
                }
            }
            return true;
        }

        public bool ClickAdd(string token, string lid, string x, string y)
        {
            _getParams.Clear();

            var postParams = new Dictionary<string, string>
            {
                { "cmd", "raidList" },
                { "action", "ActionAddSlotForm" },
                { "listId", lid },
                { "x", "" },
                { "y", "" },
                { "context", "rallyPoint" },
                { "ajaxToken", token }
            };

            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=raidList", _server, null, _getParams,
                postParams, ref cookies)) return false;

            string[] defaultType = new string[9]
            {
                "0", "0", "0", "0", "0", "0", "0", "0", "0"
            };

            defaultType[_farmlistTroopType] = TroopInfo.Amount;

            postParams = new Dictionary<string, string>
            {
                { "cmd", "raidList" },
                { "action", "ActionAddSlot" },
                { "listId", lid },
                { "x", x },
                { "y", y },
                { "t1",	defaultType[0] },
                { "t2", defaultType[1] },
                { "t3", defaultType[2] },
                { "t5", defaultType[3] },
                { "t6", defaultType[4] },
                { "t7", defaultType[5] },
                { "t8", defaultType[6] },
                { "t9", defaultType[7] },
                { "t10", defaultType[8] },
                { "ajaxToken", token }
            };
            if (!HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=raidList", _server, null, _getParams,
                postParams, ref cookies)) return false;
            postParams["action"] = "ActionAddSlot";
            return HTTP.PostAjaxRequest("https://" + _server + "/ajax.php?cmd=raidList", _server, null, _getParams, postParams, ref cookies);
        }

        public void CollectData(ref VillageInfo info)
        {
            var getParams = new Dictionary<string, string> { };

            if (!HTTP.GetRequest("http://" + _server + "/dorf2.php", getParams, _server, true))
                return;

            htmlCrawler = new HtmlCrawler(Info.ResponseBody);
            info = htmlCrawler.GetBuildingInfo();
        }
    }
}
