using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APPD_layout
{
    public class AccountContainer : GenericContainer<Account>
    {
        public void LoadAccounts(string filepath)
        {
            string accountsFile = System.IO.File.ReadAllText(filepath);
            string[] key = { "username", "password", "email" };

            Regex gameSeperator = new Regex(@"<account>(.*?)</account>", RegexOptions.Singleline);

            MatchCollection match = gameSeperator.Matches(accountsFile);

            foreach (Match m in match)
            {
                Account account;

                object[] info = new string[key.Length];
                Regex seperator;

                for (int i = 0; i < key.Length; i++)
                {
                    seperator = new Regex(@"<" + key[i] + @">(.*?)</" + key[i] + @">", RegexOptions.Singleline);

                    info[i] = Regex.Replace(seperator.Match(m.ToString()).ToString(), @"<" + key[i] + @">", "");
                    info[i] = Regex.Replace(info[i].ToString(), @"</" + key[i] + @">", "");
                }

                account = new Account(info[0].ToString(), info[1].ToString(), info[2].ToString());
                AddToContainer(account);
            }
        }
    }
}
