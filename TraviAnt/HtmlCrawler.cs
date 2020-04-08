using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TraviAnt
{
    public class HtmlCrawler
    {
        HtmlDocument doc;

        private string content;
        VillageInfo villageInfo;

        public HtmlCrawler(string content)
        {
            this.content = content;
            doc = new HtmlDocument();
            doc.LoadHtml(content);
        }


        public void SetLoginId()
        {
            var loginFormId = doc.DocumentNode.SelectSingleNode("//input[@name='login']");
            var id = loginFormId?.GetAttributeValue("value", "");
            Info.LoginId = id ?? "";
        }

        public List<Coordinates> GetCoordinates()
        {
            string pattern = @"(‭(-?[1-9][0-9]{0,2})‬‬<\/span><span class=""coordinatePipe"">\|<\/span><span class=""coordinateY"">‭(-?[1-9][0-9]{0,2})‬‬)";
            string input = content;
            RegexOptions options = RegexOptions.Multiline;
            var list = new List<Coordinates>();
            foreach (Match match in Regex.Matches(input, pattern, options))
            {
                list.Add(new Coordinates() { X = match.Groups[2].Value, Y = match.Groups[3].Value });
            }
            return list;
        }

        public string GetAjaxToken()
        {
            var regex = new Regex(@"ajaxToken = '(.*)'");
            return regex.Match(content).Groups[1].Value;
        }

        public List<string> TroopsForRes()
        {
            List<string> list = new List<string>();
            var postParams = new Dictionary<string, string>();
            string pattern = @"getElement\('input'\)\.value=([0-9\(\)]+)";
            RegexOptions options = RegexOptions.Multiline;
            foreach (Match m in Regex.Matches(content, pattern, options))
            {
                list.Add(m.Groups[1].Value);
            }
            return list;
        }

        public string GetValueA()
        {
            return doc.DocumentNode.SelectSingleNode("//input[@name='a']")?.GetAttributeValue("value", "");
        }

        public string GetValueZ()
        {
            return doc.DocumentNode.SelectSingleNode("//input[@name='z']")?.GetAttributeValue("value", "");
        }

        public List<string> GetLid()
        {
            string id = "";
            List<string> list = new List<string>();
            var lidId = doc.DocumentNode.SelectNodes("//input[@name='lid']");
            if (lidId != null)
            {
                foreach (var lid in lidId)
                {
                    if (lid != null)
                    {
                        id = lid.GetAttributeValue("value", "");
                        list.Add(id);
                    }
                }
            }

            return list;
        }

        public int GetBuildingLevel()
        {
            var regexA = new Regex(@"class=""level"">level ([0-9]{1,2})");
            var match = regexA.Match(content).Groups[1].Value;
            int.TryParse(match, out int level);
            return level;
        }

        public TimeSpan GetBuildingTime()
        {
            var time = new Regex(@"(?:[01]\d|[0123]):(?:[012345]\d):(?:[012345]\d)");
            var match = time.Matches(content)[8].Value;
            TimeSpan.TryParse(match.Trim(), out TimeSpan result);
            return result;
        }

        public Dictionary<string, string> GetTroopResource(string ajaxToken)
        {
            List<string> list = new List<string>();
            var postParams = new Dictionary<string, string>();
            string pattern = @"""data"":{""cmd"":""exchangeResources"",""defaultValues"":{""tid"":""(.)"",""nr"":(.),""btyp"":(.),""r1"":([0-9\(\)]+),""r2"":([0-9\(\)]+),""r3"":([0-9\(\)]+),""r4"":([0-9\(\)]+),""supply"":(.),""pzeit"":(.),""max1"":([0-9\(\)]+),""max2"":([0-9\(\)]+),""max3"":([0-9\(\)]+),""max4"":([0-9\(\)]+),""max"":([0-9\(\)]+)}}";
            RegexOptions options = RegexOptions.Multiline;
            foreach (Match m in Regex.Matches(content, pattern, options))
            {
                GroupCollection groups = m.Groups;
                foreach (var g in groups)
                {
                    list.Add(g.ToString());
                }
            }

            try
            {
                postParams = new Dictionary<string, string>
                {
                    { "cmd", "exchangeResources" },
                    { "defaultValues[tid]", list[1] },
                    { "defaultValues[nr]", list[2] },
                    { "defaultValues[btyp]", list[3] },
                    { "defaultValues[r1]", list[4] },
                    { "defaultValues[r2]", list[5] },
                    { "defaultValues[r3]", list[6] },
                    { "defaultValues[r4]", list[7] },
                    { "defaultValues[pzeit]", list[9] },
                    { "defaultValues[max1]", list[10] },
                    { "defaultValues[max2]", list[11] },
                    { "defaultValues[max3]", list[12] },
                    { "defaultValues[max4]", list[13] },
                    { "defaultValues[max]", list[14] },
                    { "ajaxToken", ajaxToken }
                };
            }
            catch (Exception e)
            {
                Bot.Log(e.Message, Color.Black);
                return postParams;
            }

            Bot.Log("Data collected.", Color.Black);
            return postParams;
        }

        public VillageInfo GetBuildingInfo()
        {
            villageInfo = new VillageInfo();
            var reg = new Regex(@"buildingSlot a([0-9]{1,2}) g19");
            var match = reg.Match(content);
            if (match.Success)
            {
                villageInfo.Buildings.Barracks.Id = match.Groups[1].Value;
            }
            return villageInfo;
        }

        public string GetDid()
        {
            string did = "";
            string pattern = @"id=\\""d\\"" value=\\""([0-9\(\)]+)\\""";
            RegexOptions options = RegexOptions.Multiline;
            foreach (Match m in Regex.Matches(content, pattern, options))
            {
                did = m.Groups[1].Value;
            }
            return did;
        }

        public Dictionary<string, string> GetExchangeParams(string did, string ajaxToken)
        {
            var data = JsonParser.FromJson(content);

            var exchangeParams = new Dictionary<string, string>
            {
                { "null", "0" },
                { "t", "3" },
                { "a", "6" },
                { "c", "0" },
                { "d", did },
                { "m2[0]", data.Response.Data.Distributed[0].ToString() },
                { "m1[0]", data.Response.Data.Resources[0].ToString() },
                { "m2[1]", data.Response.Data.Distributed[1].ToString() },
                { "m1[1]", data.Response.Data.Resources[1].ToString() },
                { "m2[2]", data.Response.Data.Distributed[2].ToString() },
                { "m1[2]", data.Response.Data.Resources[2].ToString() },
                { "m2[3]", data.Response.Data.Distributed[3].ToString() },
                { "m1[3]", data.Response.Data.Resources[3].ToString() },
                { "cmd", "premiumFeature" },
                { "featureKey", "marketplace" },
                { "context", "" },
                { "ajaxToken", ajaxToken }
            };

            return exchangeParams;
        }

        public Dictionary<string, string> GetAttackInfo()
        {
            HtmlNode timestamp = doc.DocumentNode.SelectSingleNode("//input[@name='timestamp']");
            var timestampVal = timestamp.GetAttributeValue("value", "");
            HtmlNode checksum = doc.DocumentNode.SelectSingleNode("//input[@name='timestamp_checksum']");
            var checksumVal = checksum.GetAttributeValue("value", "");
            HtmlNode b = doc.DocumentNode.SelectSingleNode("//input[@name='b']");
            string bVal = b.GetAttributeValue("value", "");
            HtmlNode currentId = doc.DocumentNode.SelectSingleNode("//input[@name='currentDid']");
            string currentIdVal = currentId.GetAttributeValue("value", "");
            HtmlNode mpvt = doc.DocumentNode.SelectSingleNode("//input[@name='mpvt_token']");
            string mpvtVal = mpvt.GetAttributeValue("value", "");
            HtmlNode kid = doc.DocumentNode?.SelectSingleNode("//input[@name='kid']");
            string kidVal = kid?.GetAttributeValue("value", "");
            HtmlNode t1 = doc.DocumentNode.SelectSingleNode("//input[@name='t1']");
            string t1Val = t1.GetAttributeValue("value", "");
            HtmlNode t2 = doc.DocumentNode.SelectSingleNode("//input[@name='t2']");
            string t2Val = t2.GetAttributeValue("value", "");
            HtmlNode t3 = doc.DocumentNode.SelectSingleNode("//input[@name='t3']");
            string t3Val = t3.GetAttributeValue("value", "");
            HtmlNode t4 = doc.DocumentNode.SelectSingleNode("//input[@name='t4']");
            string t4Val = t4.GetAttributeValue("value", "");
            HtmlNode t5 = doc.DocumentNode.SelectSingleNode("//input[@name='t5']");
            string t5Val = t5.GetAttributeValue("value", "");
            HtmlNode t6 = doc.DocumentNode.SelectSingleNode("//input[@name='t6']");
            string t6Val = t6.GetAttributeValue("value", "");
            HtmlNode t7 = doc.DocumentNode.SelectSingleNode("//input[@name='t7']");
            string t7Val = t7.GetAttributeValue("value", "");
            HtmlNode t8 = doc.DocumentNode.SelectSingleNode("//input[@name='t8']");
            string t8Val = t8.GetAttributeValue("value", "");
            HtmlNode t9 = doc.DocumentNode.SelectSingleNode("//input[@name='t9']");
            string t9Val = t9.GetAttributeValue("value", "");
            HtmlNode t10 = doc.DocumentNode.SelectSingleNode("//input[@name='t10']");
            string t10Val = t10.GetAttributeValue("value", "");
            HtmlNode t11 = doc.DocumentNode.SelectSingleNode("//input[@name='t11']");
            string t11Val = t11?.GetAttributeValue("value", "");

            string pattern = @"document\.snd\.t([0-9(\)]+)\.value=([0-9\(\)]+)";

            List<string> list = new List<string>();
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(content, pattern, options))
            {
                GroupCollection groups = m.Groups;
                foreach (var g in groups)
                {
                    list.Add(g.ToString());
                }
            }

            var crawlParams = new Dictionary<string, string>
            {
                { "timestamp", timestampVal ?? ""},
                { "timestamp_checksum", checksumVal ?? ""},
                { "b", bVal ?? ""},
                { "currentDid", currentIdVal ?? ""},
                { "mpvt_token", mpvtVal ?? ""},
                { "kid", kidVal ?? "" },
                { "t1", t1Val },
                { "t2", t2Val },
                { "t3", t3Val },
                { "t4", t4Val },
                { "t5", t5Val },
                { "t6", t6Val },
                { "t7", t7Val },
                { "t8", t8Val },
                { "t9", t9Val },
                { "t10", t10Val },
                { "t11", t11Val }
            };

            return crawlParams; 
        }

        public bool isSessionExpired(string content)
        {
            var reg = new Regex("webkit chrome login");
            var match = reg.Match(content);
            if (match.Success)
            {
                return true;
            }
            else
                return false;
        }

        public string GetValueC(string id)
        {
            var reg = new Regex(@"c=([a-zA-Z0-9]{6,9})");
            var match = reg.Match(content);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
                return string.Empty;
        }

        public bool isBuildingThere(string content)
        {
            var reg = new Regex("Construct new building");
            var match = reg.Match(content);
            if (match.Success)
            {
                return false;
            }
            else
                return true;
        }
    }
}
