using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using HtmlAgilityPack;
using HtmlAgilityPack.Samples;



namespace OnePieceDiscoBot.Commands
{
    /*
    public abstract class Anime : ModuleBase
    {
        protected delegate Task<bool> hasInfo(String charSite, out String result);
        protected delegate Task<bool> hasItemLink(String itemName, out String result);
        

        protected HtmlWeb web;

        public static Dictionary<String, String> authorMap = new Dictionary<String, String>();

        public Anime()
        {
            web = new HtmlWeb();
        }

        protected abstract Task<bool> getCharacterLink(String itemName, out String result);
        protected abstract Task<bool> getPowerLink(String itemName, out String result);

        protected abstract Task<bool> getTrivia(String charSite, out String result);
        protected abstract Task<bool> getAttacks(String charSite, out String result);

        protected async Task<String> getItemLink(String itemName, hasItemLink del)
        {
            String link = "";
            await del(itemName, out link);

            return link;
        } 
        protected async Task<String> getItemInfo(String charSite, hasInfo del)
        {
            String info = "";
            await del(charSite, out info);

            return info;
        }



    }




    [Group("animinfo")]

    public class AnimeInfo : ModuleBase
    {


        [Group("op")]

        public class OnePiece : Anime
        {


            [Command("char"), Summary("searches up a One Piece character")]

          
            protected override async Task charInfo(string charName)
            {
                String res = await getCharacterLink("http://onepiece.wikia.com/wiki/List_of_Canon_Characters",
                    ".//*[@id='mw-content-text']/table[1]//tr/td[2]/a", charName);

                await ReplyAsync((res == String.Empty) ? "Unable to find One Piece character" : res);
            }

            [Command("df"), Summary("searches up a df")]

            protected async override Task powerInfo(string powerName)
            {
                String res = await getPowerLink("http://onepiece.wikia.com/wiki/Category:Devil_Fruits",
                     "html/body/div[2]/section/div[2]/article/div/div[1]/div[2]/table//tr/td/table//td/table//a", powerName);

                await ReplyAsync((res == String.Empty) ? "Unable to find devil fruit" : res);
            }

            public override async Task<String> getTriviaInfo(String charSite)
            {
                Console.WriteLine("get trivia entered");


                String res = String.Empty;

                if (charSite != default(String))
                {
                    res = await base.getTriviaInfo(charSite, "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2");
                    res = (res == String.Empty) ? await base.getTriviaInfo(charSite + "/Misc.", "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2") : res;
                }
                else res = String.Empty;

                return res;

            }

            public async override Task<String> getAttackInfo(String charSite)
            {
                String res = String.Empty;

                if (charSite != default(String))
                {
                    res = await base.getAttackInfo(charSite, "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2");
                }
                else res = String.Empty;

                return res;
            }
        }

        [Group("mha")]

        public class MyHero : Anime
        {

            [Command("char"), Summary("searches up a My Hero character")]

            protected override async Task charInfo(string charName)
            {
                String res = await getCharacterLink("http://bokunoheroacademia.wikia.com/wiki/List_of_Characters",
                    ".//*[@id='mw-content-text']/table//tr//th//div/table//tr[2]/td/center/big/a", charName);

                await ReplyAsync((res == String.Empty) ? "Unable to find My Hero character" : res);
            }

            [Command("quirk"), Summary("searches up a quirk")]

            protected async override Task powerInfo(string powerName)
            {
                String res = String.Empty;

                for (int i = 0; i < 10 && (res == String.Empty); i++)
                {
                    res = await getPowerLink("http://bokunoheroacademia.wikia.com/wiki/Category:Quirks?page=" + i.ToString(),
                    "html/body/div[2]/section/div[2]/article/div/div[1]/div[2]/div[2]/div[1]/div/div[1]/div//a", powerName);
                }

                await ReplyAsync((res == String.Empty) ? "Unable to find quirk" : res);
            }

            public async override Task<String> getAttackInfo(String charSite)
            {
                String res = String.Empty;

                if (charSite != default(String))
                {
                    res = await base.getAttackInfo(charSite, "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2");
                }
                else res = String.Empty;

                return res;
            }


            public override async Task<String> getTriviaInfo(String charSite)
            {

                String res = String.Empty;

                if (charSite != default(String))
                {
                    res = await base.getTriviaInfo(charSite, "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2");
                }
                else res = String.Empty;

                return res;
            }
        }

        [Group("HxH")]

        public class HunterHunter : Anime
        {
            [Command("char"), Summary("searches up a My Hero character")]

            protected override async Task charInfo(string charName)
            {
                String res = await getCharacterLink("http://hunterxhunter.wikia.com/wiki/List_of_Hunter_%C3%97_Hunter_Characters",
                    "html/body/div[2]/section/div[2]/article/div/div[1]/div[2]/table//tr//td//div/table//tr//td/center/big/a", charName);
                   //
                await ReplyAsync((res == String.Empty) ? "Unable to find HxH character" : res);

            }

            [Command("nen"), Summary("searches up a nen ability")]

            protected async override Task powerInfo(string powerName)
            {
                String res = String.Empty;

                for (int i = 0; i < 10 && (res == String.Empty); i++)
                {
                    res = await getPowerLink("http://hunterxhunter.wikia.com/wiki/Category:Nen_Abilities?page=" + i.ToString(),
                    "html/body/div[2]/section/div[2]/article/div/div[1]/div[2]/div[2]/div[1]/div/div[1]/div//a", powerName);
                    //html/body/div[2]/section/div[2]/article/div/div[1]/div[2]/div[2]/div[1]/div/div[1]/div//a
                }

                await ReplyAsync((res == String.Empty) ? "Unable to find nen ability" : res);
            }

            public async override Task<String> getAttackInfo(String charSite)
            {
                return "";
            }

            public override async Task<String> getTriviaInfo(String charSite)
            {
                String res = String.Empty;

                if (charSite != default(String))
                {
                    res = await base.getTriviaInfo(charSite, "html/body/div[2]/section/div[2]/article/div/div//div[2]/h2");
                }
                else res = String.Empty;

                return res;
            }
        }

    }



    public class Options : ModuleBase
    {
        public Options()
        {
            Console.WriteLine("entered");
            if (Anime.authorMap.Count > 20)
            {
                Anime.authorMap.Clear();
            }
        }

        [Command("Trivia")]

        public async Task Trivia()
        {
            var map = Anime.authorMap;

            String val = default(String);

            map.TryGetValue(Context.Message.Author.Username, out val);

            if (val != default(String))
            {
                Console.WriteLine(val);

                Anime anime = null;

                if (val.ToLower().Contains("onepiece"))
                    anime = new AnimeInfo.OnePiece();
                else if (val.ToLower().Contains("boku"))
                    anime = new AnimeInfo.MyHero();
                else if (val.ToLower().Contains("hunter"))
                    anime = new AnimeInfo.HunterHunter();

                String res = await anime.getTriviaInfo(val);
                res = (res != String.Empty) ? res : "could not find trivia info";

                var triviaEmbed = new EmbedBuilder();
                EmbedBuilderExtensions.WithColor(triviaEmbed.WithTitle("Trivia"), 0, 100, 100);
                triviaEmbed.WithDescription(res);

                await Context.Channel.SendMessageAsync("", false, triviaEmbed); 
                return;
            }
            else
            {
                Console.WriteLine("nonexistant");
                await ReplyAsync("Please request info on a character");
            }
        }

        [Command("attacks")]
        public async Task Attacks()
        {
            var map = Anime.authorMap;

            String val = default(String);

            map.TryGetValue(Context.Message.Author.Username, out val);

            if (val != default(String))
            {
                Console.WriteLine(val);

                Anime anime = null;

                if (val.ToLower().Contains("onepiece"))
                    anime = new AnimeInfo.OnePiece();
                else if (val.ToLower().Contains("boku"))
                    anime = new AnimeInfo.MyHero();
                else if (val.ToLower().Contains("hunter"))
                    anime = new AnimeInfo.HunterHunter();

                String res = await anime.getAttackInfo(val);
                res = (res != String.Empty) ? res : "could not find attack info";

                var triviaEmbed = new EmbedBuilder();
                EmbedBuilderExtensions.WithColor(triviaEmbed.WithTitle("Attacks"), 0, 100, 100);
                triviaEmbed.WithDescription(res);

                await Context.Channel.SendMessageAsync("", false, triviaEmbed);
                return;
            }
            else
            {
                Console.WriteLine("nonexistant");
                await ReplyAsync("Please request info on a character");
            }
        }
    }
}


/*
           String link = String.Empty;

           var doc = await Task.Factory.StartNew(() => web.Load(siteLink));

           HtmlNodeCollection characterNodes = doc.DocumentNode.SelectNodes(xpath);


           if (characterNodes == null) { Console.WriteLine("failed to find nodes, contact the Author of this bot immediately"); return String.Empty; }
           else
           {

               Parallel.ForEach(characterNodes, (node) =>
               {
                   if (node.InnerText.ToLower().Contains(charName.ToLower()))
                   {
                       String value = node.GetAttributeValue("href", "");

                       String[] res = siteLink.Split(new String[] { "com" }, 2, StringSplitOptions.None);
                       link = res[0] + "com" + value;

                       if (authorMap.Keys.Contains(Context.Message.Author.Username))
                       {
                           authorMap.Remove(Context.Message.Author.Username);
                           authorMap.Add(Context.Message.Author.Username, link);
                       }
                       else
                           authorMap.Add(Context.Message.Author.Username, link);
                       return;
                   }
               });
               return link;
           }
           */
    //-----------------------------------------------------------------------------

    /*
           String link = String.Empty;

           var doc = await Task.Factory.StartNew(() => web.Load(siteLink));

           HtmlNodeCollection dfNodes = doc.DocumentNode.SelectNodes(xpath);


           if (dfNodes == null) { Console.WriteLine("failed to find nodes, contact the Author of this bot immediately"); return String.Empty; }
           else
           {
               Parallel.ForEach(dfNodes, (node) =>
               {
                   if (node.InnerText.ToLower().Contains(dfName.ToLower()))
                   {

                       String value = node.GetAttributeValue("href", "");

                       if (!value.Contains("com"))
                       {
                           String[] res = siteLink.Split(new String[] { "com" }, 2, StringSplitOptions.None);
                           link = res[0] + "com" + value;
                       }
                       else
                       {
                           link = value;
                       }

                       if (authorMap.Keys.Contains(Context.Message.Author.Username))
                       {
                           authorMap.Remove(Context.Message.Author.Username);
                           authorMap.Add(Context.Message.Author.Username, link);
                       }
                       else
                           authorMap.Add(Context.Message.Author.Username, link);
                       return;
                   }
               });

               return  link;
           }
           */
    //-------------------------------------------------------------------------------------
    /*
               var doc = await Task.Factory.StartNew(() => web.Load(charSite));
               if (doc == null) { Console.WriteLine("doc failed to load"); return ""; }

               var headerNodes = doc.DocumentNode.SelectNodes(xpath);

               if (headerNodes == null) { Console.WriteLine("failed to find header nodes, contact Bot Author immediately"); return String.Empty; }


               String trivia = String.Empty;
               foreach (var header in headerNodes)
               {
                   if (header.InnerText.Contains("Trivia"))
                   {
                       HtmlNode triviaNode = header;

                       for (int i = 0; i < 5 && triviaNode.Element("li") == null; i++)
                       {
                           triviaNode = triviaNode.NextSibling;
                           Console.WriteLine("i is " + i);
                       }

                       if (triviaNode == header) { Console.WriteLine("empty");  return String.Empty; }; 
                       foreach (var node in triviaNode.ChildNodes)
                       {
                           trivia += node.InnerText + "\n";
                       }
                       break;
                   }
               }

               if (trivia.Length > 1995) trivia = trivia.Substring(0, 1995) + "...";


               Console.WriteLine(trivia);
               return trivia;
               */
    //-------------------------------------------------------------
    /*

               var doc = await Task.Factory.StartNew(() => web.Load(charSite));
               if (doc == null) { Console.WriteLine("doc failed to load"); return ""; }

               var headerNodes = doc.DocumentNode.SelectNodes(xpath);

               if (headerNodes == null) { Console.WriteLine("failed to find header nodes, contact Bot Author immediately"); return ""; }


               String attacks = "";

               foreach (var header in headerNodes)
               {
                   if (header.InnerText.Contains("Abilit"))
                   {
                       var abilityNode = header;

                       for (int i = 0; i < 50 && abilityNode.Element("li") == null; i++)
                       {
                           abilityNode = abilityNode.NextSibling;
                           Console.WriteLine("i is " + i);
                       }
                       if (abilityNode == header) { Console.WriteLine("empty"); return String.Empty; };

                       foreach (var node in abilityNode.ChildNodes)
                       {
                           attacks += node.InnerText + "\n";
                       }

                       break;
                   }

               }
               if (attacks.Length > 1995) attacks = attacks.Substring(0, 1995) + "...";


               Console.WriteLine(attacks);
               return attacks;

           }
           */
}